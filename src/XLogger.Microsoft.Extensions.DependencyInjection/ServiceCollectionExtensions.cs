using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace XLogger
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddXLogger(this IServiceCollection services, Action<ILoggerHub> loggerHubOptions) =>
            services.AddLogging(config => config.RegisterLoggerHub(loggerHubOptions));

        public static void RegisterLoggerHub(this ILoggingBuilder logging, Action<ILoggerHub> loggerHubOptions)
        {
            logging.ClearProviders();
            new LoggerHub(logging.Services, loggerHubOptions);
        }
    }
}