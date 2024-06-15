using Domain.Shared;

namespace Application.Abstractions.Authentication
{
    public interface IJwtProvider
    {
        string WriteToken(JwtClaim claim);
    }
}
