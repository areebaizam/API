using Domain.Primitives;
namespace Application.Abstractions.Data
{
    public interface IRepository<TEntity, TId, TIdType>
        where TEntity : Entity<TId>
        where TId : IEntityId<TIdType>
    {
        Task<List<TEntity>> GetAsync(CancellationToken cancellationToken);
        Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
