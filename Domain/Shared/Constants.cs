using System.IdentityModel.Tokens.Jwt;

namespace Domain.Shared
{
    public static class Constants
    {
        
        public struct ConfigurationSection
        {
            public const string Jwt = "Jwt";
        }
        public struct ClaimTypes
        {
            public const string NameIdentifier = "sub";
            public const string Name = "name";       
            public const string UserName = "preferred_username";       
        }
    }
}
