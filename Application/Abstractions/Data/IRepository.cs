namespace Application.Abstractions.Data
{
    public interface IRepository<TEntity, TId>
    {
        Task<List<TEntity>> GetAsync(CancellationToken cancellationToken);
        Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        void UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
    }
}
