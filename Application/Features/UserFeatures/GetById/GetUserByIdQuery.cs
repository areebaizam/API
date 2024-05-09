using MediatR;

namespace Application.Features.UserFeatures
{
    public sealed record GetUserByIdQuery(GetUserRequest id) : IRequest<GetUserResponse>;
}