using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class UserId:EntityId<UserId>,IEntityId {
        //public static UserId Empty => new(Guid.Empty);
        //public static UserId New => new(Guid.NewGuid());
        //public Guid Value { get; }

        public UserId(Guid value) : base(value)
        {
            
        }
        public UserId():base(Guid.Empty)
        {
            
        }

        //public static implicit operator Guid(EntityId<TEntityId> id) => id.Value;

        //public static implicit operator EntityId<TEntityId>(Guid value) => new EntityId<TEntityId>(value);

        //public override string ToString() => Value.ToString();
    }
}
