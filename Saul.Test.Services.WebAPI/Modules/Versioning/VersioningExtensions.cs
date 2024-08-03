using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace Saul.Test.Services.WebAPI.Modules.Versioning
{
    public static class VersioningExtensions
    {
        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ReportApiVersions = true;
                //o.ApiVersionReader = new QueryStringApiVersionReader("api-version");
                //o.ApiVersionReader = new HeaderApiVersionReader("api-version");
                o.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });
            return services;
        }
    }
}
