using Saul.Test.Services.WebAPI.Modules.GlobalException;

namespace Saul.Test.Services.WebAPI.Modules.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
