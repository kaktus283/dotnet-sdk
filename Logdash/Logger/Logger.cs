using Logdash.Logger.Internal;
using static Logdash.Logger.Internal.LogColors;

namespace Logdash.Logger
{
    public class Logger(Action<LogLevel, string> onLog) : ILogger
    {
        private readonly Action<LogLevel, string> _onLog = onLog;
        private static readonly object _consoleLock = new();

        public void Log(LogLevel level, string message)
        {
            PrintColored(level, message);
            _onLog(level, message);
        }

        internal static void PrintColored(LogLevel level, string message)
        {
            var rgb = LOG_LEVEL_COLORS[level];
            var ansiColorCode = RgbToAnsi(rgb);
            var levelLabel = level.ToString().ToUpper();
            var timestamp = $"[{DateTime.Now:yyyy-MM-ddTHH:mm:ss.ffffff}] ";
            var reset = "\u001b[0m";
            lock (_consoleLock)
            {
                Console.WriteLine($"{timestamp}{ansiColorCode}{levelLabel} {reset}{message}");
            }
        }

        public void Error(string message)
        {
            Log(LogLevel.ERROR, message);
        }

        public void Warn(string message)
        {
            Log(LogLevel.WARNING, message);
        }

        public void Info(string message)
        {
            Log(LogLevel.INFO, message);
        }

        public void Http(string message)
        {
            Log(LogLevel.HTTP, message);
        }

        public void Verbose(string message)
        {
            Log(LogLevel.VERBOSE, message);
        }

        public void Debug(string message)
        {
            Log(LogLevel.DEBUG, message);
        }

        public void Silly(string message)
        {
            Log(LogLevel.SILLY, message);
        }
    }
}
