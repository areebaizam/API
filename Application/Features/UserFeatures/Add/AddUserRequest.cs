namespace Application.Features.UserFeatures
{
    public sealed record AddUserRequest()
    {
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
