using MediatR;
using Microsoft.Extensions.Logging;

namespace BakePopup.Application.Behaviors
{
    public class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<UnitOfWorkBehavior<TRequest, TResponse>> _logger;

        public UnitOfWorkBehavior(ILogger<UnitOfWorkBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling {RequestName} started.", typeof(TRequest).Name);

            var response = await next();

            _logger.LogInformation("Handling {RequestName} finished.", typeof(TRequest).Name);

            return response;
        }
    }
}