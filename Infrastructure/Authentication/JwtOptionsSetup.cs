using Domain.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Authentication
{
    internal class JwtOptionsSetup(IConfiguration configuration) : IConfigureOptions<JwtOptions>
    {
        private readonly IConfiguration _configuration = configuration;

        public void Configure(JwtOptions options)
        {
            _configuration.GetSection(Constants.ConfigurationSection.Jwt).Bind(options);
        }
    }
}
