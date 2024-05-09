using Application.Abstractions.Data;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public abstract class Repository<TEntity, TId, TIdType> : IRepository<TEntity, TId, TIdType>
         where TEntity : Entity<TId>
         where TId : IEntityId<TIdType>
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
        {
            return await DbSet.ToListAsync(cancellationToken);
        }

        //Get by ID
        public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken)
        {
            return await DbSet.SingleOrDefaultAsync((e => e.Id.Equals(id)), cancellationToken);
        }

        public async Task AddAsync(TEntity T)
        {
            await DbSet.AddAsync(T);
        }

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
