using Saul.Test.Application.Interface.Presentation;
using Saul.Test.Services.WebAPI.Modules.GlobalException;
using Saul.Test.Services.WebAPI.Services;

namespace Saul.Test.Services.WebAPI.Modules.Injection
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddTransient<GlobalExceptionHandler>();
            services.AddScoped<ICurrentUser, CurrentUser>();

            return services;
        }
    }
}
