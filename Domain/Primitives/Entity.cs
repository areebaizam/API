using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public abstract class Entity<TEntityId> : IEntity where TEntityId : class
    {
        public TEntityId Id { get; init; }
        //protected Entity() { }
        protected Entity(TEntityId id)
        {
            Id = id;
        }
    }
}
