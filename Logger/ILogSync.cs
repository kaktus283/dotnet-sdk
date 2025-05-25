namespace Logdash.Logger
{
    public interface ILogSync
    {
        Task SendAsync(string message, LogLevel level, string timestamp);
    }
}
