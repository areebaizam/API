using Application.Features.UserFeatures;

namespace Application.Features.UserFeatures
{
    public sealed record GetUsersResponse() : GetUserResponse
    {
        public Guid UserId { get; set; } = Guid.Empty;
    }
}
