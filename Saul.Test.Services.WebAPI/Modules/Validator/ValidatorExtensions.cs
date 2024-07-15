using Microsoft.Extensions.DependencyInjection;
using Saul.Test.Application.Validator;

namespace Saul.Test.Services.WebAPI.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<UsersDtoValidator>();
            return services;
        }

    }
}
