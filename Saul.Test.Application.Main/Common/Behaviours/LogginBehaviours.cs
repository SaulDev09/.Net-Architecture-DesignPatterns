using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Saul.Test.Application.UseCases.Common.Behaviours
{
    public class LogginBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LogginBehaviours<TRequest, TResponse>> _logger;

        public LogginBehaviours(ILogger<LogginBehaviours<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CleanArchitecture Request Handling: {name} {@request}", typeof(TRequest).Name, JsonSerializer.Serialize(request));
            var response = await next();
            _logger.LogInformation("CleanArchitecture Response Handling: {name} {@response}", typeof(TRequest).Name, JsonSerializer.Serialize(response));
            return response;
        }
    }
}
