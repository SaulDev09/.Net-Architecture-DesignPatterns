using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

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

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter JWT Bearer token ** Only **",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, new List<string>() { } }
                });
            });
            return services;
        }

    }
}
