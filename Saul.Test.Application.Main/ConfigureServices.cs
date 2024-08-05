using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Saul.Test.Application.Interface.UseCases;
using Saul.Test.Application.UseCases.Categories;
using Saul.Test.Application.UseCases.Common.Behaviours;
using Saul.Test.Application.UseCases.Customers;
using Saul.Test.Application.UseCases.Discounts;
using Saul.Test.Application.UseCases.Users;
using System.Reflection;

namespace Saul.Test.Application.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LogginBehaviours<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<ICategoriesApplication, CategoriesApplication>();
            services.AddScoped<IDiscountsApplication, DiscountsApplication>();

            return services;
        }

    }
}
