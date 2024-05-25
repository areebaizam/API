using Application.Abstractions.Dispatcher;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures
{
    public record DeleteUserCommand(UserId userId) : ICommand<Unit>;
}
