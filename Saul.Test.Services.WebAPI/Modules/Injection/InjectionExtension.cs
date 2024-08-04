using Saul.Test.Services.WebAPI.Modules.GlobalException;
using Saul.Test.Transversal.Common;
using Saul.Test.Transversal.Log4net;

namespace Saul.Test.Services.WebAPI.Modules.Injection
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddTransient<GlobalExceptionHandler>();

            return services;
        }
    }
}
