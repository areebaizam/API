using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Login
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TokenResponse"/> class.
    /// </summary>
    /// <param name="token">The token value.</param>
    public sealed class TokenResponse(string token)
    {

        /// <summary>
        /// Gets the token.
        /// </summary>
        public string Token { get; } = token;
    }
}
