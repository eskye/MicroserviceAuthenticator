using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MicroServices.Identity.Authentication
{
    public static class MicroServiceAuthenticator
    {

        public static IServiceCollection AddMicroServiceAuthenticator(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                sharedOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
                 {
                     cfg.RequireHttpsMetadata = false;

                     cfg.SaveToken = true;

                     cfg.TokenValidationParameters = new TokenValidationParameters
                     { 
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,
                         ValidIssuer = configuration["TokenAuthentication:Issuer"],
                         ValidAudience = configuration["TokenAuthentication:Audience"],
                         IssuerSigningKey =
                                    new SymmetricSecurityKey(
                                        Encoding.ASCII.GetBytes(configuration["TokenAuthentication:SecretKey"]))
                     };

                     cfg.Events = new JwtBearerEvents
                     {
                         OnAuthenticationFailed = context =>
                         {
                             Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                             return Task.CompletedTask;
                         },
                         OnTokenValidated = context =>
                         {
                             Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                             return Task.CompletedTask;
                         }
                     };
                 });

            return services;
        }

    }
}
