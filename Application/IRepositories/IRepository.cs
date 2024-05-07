using Domain.Primitives;
namespace Application.IRepositories
{
    public interface IRepository<TEntity, TEntityId> 
        where TEntity : Entity<TEntityId> 
        where TEntityId : class
    {
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<TEntity?> GetAsync(TEntityId id, CancellationToken cancellationToken);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
