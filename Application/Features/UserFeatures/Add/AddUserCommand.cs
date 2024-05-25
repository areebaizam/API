using Application.Abstractions.Dispatcher;

namespace Application.Features.UserFeatures
{
    public sealed record AddUserCommand(AddUserRequest User) : ICommand<AddUserResponse>;
}
