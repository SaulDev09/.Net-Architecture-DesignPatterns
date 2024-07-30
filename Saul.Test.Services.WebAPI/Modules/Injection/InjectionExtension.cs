using Saul.Test.Application.Interface.Persistence;
using Saul.Test.Application.Interface.UseCases;
using Saul.Test.Application.UseCases;
//using Saul.Test.Domain.Core;
//using Saul.Test.Domain.Interface;
using Saul.Test.Persistence.Data;
//using Saul.Test.Infrastructure.Interface;
using Saul.Test.Persistence.Repository;
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
            //services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();

            services.AddScoped<IUsersApplication, UsersApplication>();
            //services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoriesApplication, CategoriesApplication>();
            //services.AddScoped<ICategoriesDomain, CategoriesDomain>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();

            return services;
        }
    }
}
