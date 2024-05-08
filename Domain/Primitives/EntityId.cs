using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public class EntityId<TEntityId> : IEntityId
    {
        public Guid Value { get; init; }

        public EntityId(Guid value)
        {
            Value = value;
        }


        public static implicit operator Guid(EntityId<TEntityId> id) => id.Value;

        public static implicit operator EntityId<TEntityId>(Guid value) => new EntityId<TEntityId>(value);

        public override string ToString() => Value.ToString();
    }
}
