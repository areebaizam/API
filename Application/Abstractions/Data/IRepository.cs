using Domain.Primitives;
namespace Application.Abstractions.Data
{
    public interface IRepository<TEntity, TEntityId>
        where TEntity : Entity<TEntityId>
        where TEntityId : IEntityId
    {
        Task<List<TEntity>> GetAsync(CancellationToken cancellationToken);
        Task<TEntity?> GetByIdAsync(TEntityId id, CancellationToken cancellationToken);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
