namespace Domain.Primitives
{
    public abstract class Entity<TId>(TId id) : IEntity<TId>
        where TId : notnull
    {
        public TId Id { get; } = id;
    }
}
