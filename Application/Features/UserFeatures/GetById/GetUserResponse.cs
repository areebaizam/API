namespace Application.Features.UserFeatures
{
    public sealed record GetUserResponse
    {
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Guid UserId { get; init; }
    }
}
