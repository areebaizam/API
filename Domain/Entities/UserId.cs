using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserId : EntityId<Guid>
    {
        public UserId(Guid value):base(value)
        {
        }
    }
}
