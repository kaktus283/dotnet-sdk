namespace Logdash.Logger.Internal
{
    public interface ILogSync
    {
        Task SendAsync(string message, LogLevel level, string timestamp);
    }
}
