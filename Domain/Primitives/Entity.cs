using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public abstract class Entity<TId> : IEntity
    {
        public TId Id { get; set; }
        public Entity(TId id)
        {
            Id = id;
        }        
    }
}
