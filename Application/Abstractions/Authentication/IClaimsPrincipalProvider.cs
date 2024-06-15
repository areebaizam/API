using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Authentication
{
    public interface IClaimsPrincipalProvider
    {
        UserId UserId { get; }
        string UserName { get; }
    }
}
