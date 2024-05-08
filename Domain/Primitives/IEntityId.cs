namespace Domain.Primitives
{
    public interface IEntityId<TIdType>
    {
        TIdType Value { get;}
        string ToString();
    }
}
