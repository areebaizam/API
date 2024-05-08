using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public sealed class NoContentException : Exception
    {
        public NoContentException(string entityName) : base($"No { entityName } data found")
        {
            
        }
    }
}
