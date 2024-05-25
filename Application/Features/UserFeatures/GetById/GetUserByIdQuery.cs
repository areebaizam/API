using Application.Abstractions.Dispatcher;

namespace Application.Features.UserFeatures
{
    public sealed record GetUserByIdQuery(GetUserRequest Id) : IQuery<GetUserResponse>;
}