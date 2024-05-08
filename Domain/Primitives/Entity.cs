using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public abstract class Entity<TEntityId> : IEntity where TEntityId : struct
    {
        public TEntityId Id { get; set; }
        //public string EntityName { get; private set; }

        //protected Entity() { }

        public Entity(TEntityId id)
        {
            Id = id;
        }
        
        //private void SetEntityName(TEntityId id)
        //{
            
        //    var idProp = this.GetType().GetProperty(Id);
        //    if (idProp != null)
        //    {
        //        idProp.SetValue(this, id);
        //    }
        //}
        //public static string GetIdPropertyName<TEntity>() where TEntity : new()
        //{
        //    var entity = new TEntity();
        //    var idProperty = entity.GetType().GetProperties().FirstOrDefault(prop => prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(BaseEntity<>));

        //    if (idProperty != null)
        //    {
        //        return idProperty.Name;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
