using Logdash.Core;
using Logdash.Logger;
using Logdash.Metrics;

namespace Logdash
{
    public static class MetricsFactory
    {
        public static IMetrics CreateMetrics(string? apiKey, string host, bool verbose)
        {
            return new StubMetrics();
        }
    }

    public class LogdashClient
    {
        private readonly string _apiKey;
        private readonly string _host;
        private readonly bool _verbose;
        private readonly ILogSync _logSync;
        private readonly IMetrics _metricsInstance;
        private readonly ILogger _loggerInstance;

        public LogdashClient(
            string? apiKey = "",
            string host = "https://api.logdash.io/",
            bool verbose = false
        )
        {
            _apiKey = apiKey ?? string.Empty;
            _host = host;
            _verbose = verbose;

            _logSync = LogSyncFactory.CreateLogSync(_apiKey, _host, _verbose);
            _metricsInstance = MetricsFactory.CreateMetrics(_apiKey, _host, _verbose);

            _loggerInstance = new Logger.Logger(
                (level, message) =>
                {
                    // fire-and-forget async
                    _ = _logSync?.SendAsync(message, level, DateTime.Now.ToString("o"));
                }
            );
        }

        public ILogger Logger => _loggerInstance;
        public IMetrics Metrics => _metricsInstance;
    }
}
