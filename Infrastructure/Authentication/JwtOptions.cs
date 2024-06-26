﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication
{
    public class JwtOptions
    {
        public JwtOptions()
        {
            Issuer = string.Empty;
            Audience = string.Empty;
            SecurityKey = string.Empty;
        }

        public string Issuer { get; set; }

        /// <summary>
        /// Gets or sets the audience.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Gets or sets the security key.
        /// </summary>
        public string SecurityKey { get; set; }

        /// <summary>
        /// Gets or sets the token expiration time in minutes.
        /// </summary>
        public int TokenExpirationInMinutes { get; set; }
    }
}
