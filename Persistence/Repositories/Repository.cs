﻿using Application.IRepositories;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public abstract class Repository<TEntity, TEntityId> : IRepository<TEntity, TEntityId>
         where TEntity : Entity<TEntityId>
         where TEntityId : class
    {
        protected readonly DataContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DataContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        //Get All
        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }

        //Get by ID
        public virtual async Task<TEntity?> GetAsync(TEntityId id, CancellationToken cancellationToken)
        {
            return await DbSet.SingleOrDefaultAsync((e => e.Id == id), cancellationToken);
        }

        public async Task AddAsync(TEntity T)
        {
            await DbSet.AddAsync(T);
        }

        public Task UpdateAsync(TEntity T)
        {
            throw new NotImplementedException();
        }
        
        public Task DeleteAsync(TEntity T)
        {
            throw new NotImplementedException();
        }
    }
}
