using Microsoft.Extensions.DependencyInjection;
using Saul.Test.Application.Interface.UseCases;
using Saul.Test.Application.UseCases.Categories;
using Saul.Test.Application.UseCases.Customers;
using Saul.Test.Application.UseCases.Discounts;
using Saul.Test.Application.UseCases.Users;
using Saul.Test.Application.Validator;
using System.Reflection;

namespace Saul.Test.Application.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<ICategoriesApplication, CategoriesApplication>();
            services.AddScoped<IDiscountsApplication, DiscountsApplication>();

            services.AddTransient<UsersDtoValidator>();
            services.AddTransient<DiscountDtoValidator>();
            return services;
        }

    }
}
