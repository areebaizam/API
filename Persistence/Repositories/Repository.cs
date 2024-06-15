using Microsoft.EntityFrameworkCore;
using Application.Abstractions.Data;
using Domain.Primitives;

namespace Persistence.Repositories
{
    public abstract class Repository<TEntity, TId>(DataContext dbContext) : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : notnull
    {
        public readonly DataContext DbContext = dbContext;
        protected readonly DbSet<TEntity> DbSet = dbContext.Set<TEntity>();

        //Get All
        public async Task<List<TEntity>?> GetAsync(CancellationToken cancellationToken) 
            => await DbSet.ToListAsync(cancellationToken);

        //Get by ID
        public virtual async Task<Maybe<TEntity>> GetByIdAsync(TId id, CancellationToken cancellationToken)
        {
            return await DbSet.SingleOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);
        }
        
        //Add Entity
        public async Task AddAsync(TEntity T, CancellationToken cancellationToken) 
            => await DbSet.AddAsync(T, cancellationToken);

        public void Update(TEntity T)
        {
            DbSet.Update(T);
        }
        
        public void Delete(TEntity T)
        {
            DbSet.Remove(T);
        }
    }
}
