using Application.Abstractions.Dispatcher;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures
{
    public record UpdateUserCommand(UserId Id, UpdateUserRequest User) : ICommand<Unit>;
}
