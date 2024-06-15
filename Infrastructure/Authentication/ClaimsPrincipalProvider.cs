using Application.Abstractions.Authentication;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Web;
using System.Security.Claims;
namespace Infrastructure.Authentication
{
    internal sealed class ClaimsPrincipalProvider : IClaimsPrincipalProvider
    {
        private readonly ClaimsPrincipal _claimsPrincipal;
        public ClaimsPrincipalProvider(IHttpContextAccessor httpContextAccessor)
        {
            _claimsPrincipal = httpContextAccessor.HttpContext?.User ?? throw new ArgumentException("The Claim Principal is missing.", nameof(httpContextAccessor));
            
            string userIdClaim = ClaimsPrincipalExtensions.GetNameIdentifierId(_claimsPrincipal) ?? throw new ArgumentException("The user identifier claim is required.", nameof(httpContextAccessor));   
            UserId = new UserId(new Guid(userIdClaim));
            UserName = ClaimsPrincipalExtensions.GetDisplayName(_claimsPrincipal) ?? string.Empty;
        }

        /// <inheritdoc />
        public UserId UserId { get; }
        public string UserName { get; }
    }
}
