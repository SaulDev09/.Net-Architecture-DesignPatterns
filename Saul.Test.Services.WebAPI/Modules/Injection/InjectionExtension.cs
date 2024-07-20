using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saul.Test.Application.Interface;
using Saul.Test.Application.Main;
using Saul.Test.Domain.Core;
using Saul.Test.Domain.Interface;
using Saul.Test.Infrastructure.Data;
using Saul.Test.Infrastructure.Interface;
using Saul.Test.Infrastructure.Repository;
using Saul.Test.Transversal.Common;
using Saul.Test.Transversal.Log4net;

namespace Saul.Test.Services.WebAPI.Modules.Injection
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<DapperContext>();
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();

            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            return services;
        }
    }
}
