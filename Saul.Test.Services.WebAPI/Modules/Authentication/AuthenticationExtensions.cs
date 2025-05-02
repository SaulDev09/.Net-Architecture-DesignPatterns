using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Saul.Test.Services.WebAPI.Helpers;
using System.Text;

namespace Saul.Test.Services.WebAPI.Modules.Authentication
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var Issuer = appSettings.Issuer;
            var Audience = appSettings.Audience;

            services.AddHttpContextAccessor();

            // Validate and Verify JWTBearer token
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).
            AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    // For example purposes: how to get values from token, userId
                    OnTokenValidated = context =>
                    {
                        var userId = int.Parse(context.Principal.Identity.Name);
                        return Task.CompletedTask;
                    },

                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Append("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = Issuer,
                    ValidateAudience = true,
                    ValidAudience = Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            return services;
        }
    }
}
