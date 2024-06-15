using Domain.Primitives;

namespace Application.Abstractions.Data
{
    public interface IRepository<TEntity, TId> where TEntity : IEntity<TId> where TId : notnull
    {
        Task<List<TEntity>?> GetAsync(CancellationToken cancellationToken);
        Task<Maybe<TEntity>> GetByIdAsync(TId id, CancellationToken cancellationToken);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
