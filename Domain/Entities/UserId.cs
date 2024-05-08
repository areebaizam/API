using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public readonly record struct UserId(Guid Value) { 
    public static UserId Empty => new(Guid.Empty);
    public static UserId New => new(Guid.NewGuid());
    }
}
