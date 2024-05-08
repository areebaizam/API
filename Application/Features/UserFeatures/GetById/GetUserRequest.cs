using MediatR;

namespace Application.Features.UserFeatures
{
    public sealed record GetUserRequest(Guid UserId) : IRequest<GetUserResponse>;

}
