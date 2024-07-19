using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace Saul.Test.Services.WebAPI.Modules.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Version = description.ApiVersion.ToString(),
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
            };
            return info;
        }
    }
}
