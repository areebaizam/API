using Application.Abstractions.Data;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
    {
        public readonly DataContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DataContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        //Get All
        public async Task<List<TEntity>> GetAsync(CancellationToken cancellationToken) 
            => await DbSet.ToListAsync(cancellationToken);

        //Get by ID
        public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken) 
            => await DbSet.SingleOrDefaultAsync(e=> e.Id.Equals(id), cancellationToken);
        
        //Add Entity
        public async Task AddAsync(TEntity T, CancellationToken cancellationToken) 
            => await DbSet.AddAsync(T, cancellationToken);

        public void UpdateAsync(TEntity T)
        {
            DbSet.Update(T);
        }
        
        public void DeleteAsync(TEntity T)
        {
            DbSet.Remove(T);
        }
    }
}
