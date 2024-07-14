using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Saul.Test.Services.WebAPI.Modules.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Saul Test",
                    Description = "Studying Architecture",
                    TermsOfService = new Uri("https://CPS.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "Saul Chipana",
                        Email = "Saul.Dev09@gmail.com",
                        Url = new Uri("https://CPS.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use to Study",
                        Url = new Uri("https://CPS.com")
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Authorization by API key.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            return services;
        }

    }
}
