using Microsoft.Extensions.DependencyInjection;
using Saul.Test.Application.Interface.UseCases;
using Saul.Test.Application.UseCases.Categories;
using Saul.Test.Application.UseCases.Customers;
using Saul.Test.Application.UseCases.Users;

namespace Saul.Test.Application.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<ICategoriesApplication, CategoriesApplication>();
            return services;
        }

    }
}
