using System;
using Microsoft.IdentityModel.Tokens;

namespace MicroServices.Identity.Authentication.Authentication
{
   public class TokenProviderOptions
    {
        public string SecretKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }
        
        public int? Expiration { get; set; }
    }
}