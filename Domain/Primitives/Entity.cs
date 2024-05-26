namespace Domain.Primitives
{
    public abstract class Entity<TId>(TId id) : IEntity
    {
        public TId Id { get; set; } = id;
    }
}
