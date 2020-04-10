using System;
using Microsoft.IdentityModel.Tokens;

namespace MicroServices.Identity.Authentication.Authentication
{
    public class TokenProviderOptions
    {
        public SymmetricSecurityKey SecurityKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public SigningCredentials SigningCredentials { get; set; }

        public TimeSpan Expiration { get; set; }
    }
}