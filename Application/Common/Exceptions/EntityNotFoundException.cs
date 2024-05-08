using Domain.Primitives;

namespace Application.Common.Exceptions
{
    public sealed class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityName, IEntityId id) : base($"The {entityName} with the ID = {id.Value} was not found")
        {

        }
    }
}
