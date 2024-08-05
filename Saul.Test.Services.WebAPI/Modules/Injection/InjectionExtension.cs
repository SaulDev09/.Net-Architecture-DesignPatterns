using Saul.Test.Services.WebAPI.Modules.GlobalException;

namespace Saul.Test.Services.WebAPI.Modules.Injection
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddTransient<GlobalExceptionHandler>();

            return services;
        }
    }
}
