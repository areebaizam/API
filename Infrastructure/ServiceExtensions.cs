using Application.Abstractions.Authentication;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services) {
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            services.AddAuthorization();
            services.AddHttpContextAccessor();
            services.AddScoped<IClaimsPrincipalProvider, ClaimsPrincipalProvider>();
            services.AddScoped<IJwtProvider, JwtProvider>();            
        }
    }
}
