using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace XLogger
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add XLogger to the logging pipeline.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add logging provider to.</param>
        /// <param name="loggerHubOptions">The logger hub options and preferences.</param>
        /// <returns>The collection services</returns>
        public static IServiceCollection AddXLogger(this IServiceCollection services, Action<ILoggerHub> loggerHubOptions) =>
            services.AddLogging(config => config.RegisterLoggerHub(loggerHubOptions));

        /// <summary>
        /// Clear logging providers and add XLogger to the logging pipeline.
        /// </summary>
        /// <param name="logging">The <see cref="ILoggingBuilder" /> to add logging provider to.</param>
        /// <param name="loggerHubOptions">The logger hub options and preferences.</param>
        public static void RegisterLoggerHub(this ILoggingBuilder logging, Action<ILoggerHub> loggerHubOptions)
        {
            logging.ClearProviders();
            new LoggerHub(logging.Services, loggerHubOptions);
        }
    }
}