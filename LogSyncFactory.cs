using Logdash.Logger.Internal;

namespace Logdash
{
    public static class LogSyncFactory
    {
        public static ILogSync CreateLogSync(string? apiKey, string host, bool verbose)
        {
            return new HttpLogSync(apiKey ?? string.Empty, host, verbose);
        }
    }
}
