
namespace Domain.Primitives
{
    public abstract class EntityId<TIdType>(TIdType value) : IEntityId<TIdType>
    {
        public TIdType Value { get;} = value;
    }
}
