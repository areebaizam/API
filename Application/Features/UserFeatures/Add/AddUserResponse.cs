namespace Application.Features.UserFeatures
{
    public sealed record AddUserResponse() {
        public Guid UserId { get; set; } = Guid.Empty;
    }
}
