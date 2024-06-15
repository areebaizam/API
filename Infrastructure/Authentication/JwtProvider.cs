using Application.Abstractions.Authentication;
using Domain.Shared;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentication
{
    public sealed class JwtProvider(IOptions<JwtOptions> jwtOptions) : IJwtProvider
    {
        private readonly JwtOptions _jwtSettings = jwtOptions.Value;
        private SymmetricSecurityKey SymmetricSecurityKey => new(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey));
        private SigningCredentials SigningCredentials => new(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        private static List<Claim> MakeClaims(JwtClaim claim)
        {
            List<Claim> claims = [];
            //Subject (id/username) Verified at Provider level
            claims.Add(new Claim(Constants.ClaimTypes.NameIdentifier, claim.NameIdentifier));
            if (!string.IsNullOrEmpty(claim.Name)) claims.Add(new Claim(Constants.ClaimTypes.Name, claim.Name));
            return claims;
        }

        public string WriteToken(JwtClaim claim)
        {
            List<Claim> claims = MakeClaims(claim);

            JwtSecurityToken tokenOptions = new(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                signingCredentials: SigningCredentials,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationInMinutes),
                notBefore: DateTime.UtcNow
            );           

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenValue;
        }
    }
}
