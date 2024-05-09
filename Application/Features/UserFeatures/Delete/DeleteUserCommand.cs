using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures
{
    public record DeleteUserCommand(UserId userId) : IRequest<Unit>;
}
