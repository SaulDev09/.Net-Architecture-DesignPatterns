using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saul.Test.Application.Interface;
using Saul.Test.Application.Main;
using Saul.Test.Domain.Core;
using Saul.Test.Domain.Interface;
using Saul.Test.Infrastructure.Data;
using Saul.Test.Infrastructure.Interface;
using Saul.Test.Infrastructure.Repository;
using Saul.Test.Services.WebAPI.Helpers;
using Saul.Test.Transversal.Common;
using Saul.Test.Transversal.Mapper;

namespace Saul.Test.Services.WebAPI
{
    public class Startup
    {
        readonly string myPolicy = "SaulTest";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));

            services.AddCors(x => x.AddPolicy(myPolicy, builder => builder.WithOrigins(Configuration["Config:OriginCors"])
            .AllowAnyHeader()
            .AllowAnyMethod()));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).
                AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                });

            var appSettingsSection = Configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(myPolicy);

            app.UseMvc();
        }
    }
}
