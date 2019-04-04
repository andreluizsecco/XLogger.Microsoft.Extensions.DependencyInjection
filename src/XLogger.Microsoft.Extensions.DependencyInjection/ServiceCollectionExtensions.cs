using System;
using Microsoft.Extensions.Logging;
using XLogger;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddXLogger(this IServiceCollection services, Action<ILoggerHub> loggers)
        {
            return services.AddLogging(config =>
            {
                config.ClearProviders();
                var hub = new LoggerHub(config.Services);
                loggers.Invoke(hub);
            });
        }
    }
}