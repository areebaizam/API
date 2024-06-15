using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Login
{
    public sealed record LoginRequest()
    {
        public required string Email { get; set; }
        public required  string Code { get; set; }
    }
}
