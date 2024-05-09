using MediatR;

namespace Application.Features.UserFeatures
{
    public sealed record AddUserCommand(AddUserRequest user) : IRequest<AddUserResponse>;
}
