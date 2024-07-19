using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Saul.Test.Services.WebAPI.Modules.Authentication;
using Saul.Test.Services.WebAPI.Modules.Feature;
using Saul.Test.Services.WebAPI.Modules.HealthCheck;
using Saul.Test.Services.WebAPI.Modules.Injection;
using Saul.Test.Services.WebAPI.Modules.Mapper;
using Saul.Test.Services.WebAPI.Modules.Swagger;
using Saul.Test.Services.WebAPI.Modules.Validator;
using Saul.Test.Services.WebAPI.Modules.Versioning;
//using SwaggerExtension;

namespace Saul.Test.Services.WebAPI
{
    public class Startup
    {
        readonly string myPolicy = "policySaulTest";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMapper();
            services.AddFeature(this.Configuration, myPolicy);
            services.AddInjection(this.Configuration);
            services.AddAuthentication(this.Configuration);
            services.AddVersioning();
            services.AddSwagger();
            services.AddValidator();
            services.AddHealthCheck(this.Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }

            });
            app.UseCors(myPolicy);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecksUI();
                endpoints.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });
        }
    }
}
