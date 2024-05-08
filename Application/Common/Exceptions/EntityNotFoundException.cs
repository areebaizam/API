using Domain.Primitives;

namespace Application.Common.Exceptions
{
    public sealed class EntityNotFoundException<TIdType> : Exception
    {
        public EntityNotFoundException(string entityName, TIdType value) : base($"The {entityName} with the ID = {value} was not found")
        {

        }
    }
}
