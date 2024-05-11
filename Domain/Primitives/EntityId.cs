
namespace Domain.Primitives
{
    public abstract class EntityId<TIdType> : IEntityId<TIdType>
    {
        public TIdType Value { get; }
  
        protected EntityId(TIdType value)
        {
            Value = value;
        }
    }
}
