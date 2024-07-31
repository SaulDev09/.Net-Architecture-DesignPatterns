using Microsoft.Extensions.DependencyInjection;
using Saul.Test.Application.Interface.Persistence;
using Saul.Test.Persistence.Contexts;
using Saul.Test.Persistence.Repositories;

namespace Saul.Test.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
