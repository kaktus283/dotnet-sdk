using static Logdash.Logger.LogColors;

namespace Logdash.Logger
{
    public class Logger(Action<LogLevel, string> onLog) : ILogger
    {
        private readonly Action<LogLevel, string> _onLog = onLog;

        public void Log(LogLevel level, string message)
        {
            _onLog(level, message);
        }

        private static void PrintColored(LogLevel level, string message)
        {
            var rgb = LOG_LEVEL_COLORS[level];
            var ansiColorCode = RgbToAnsi(rgb);
            var levelLabel = level.ToString().ToUpper();

            Console.Write($"[{DateTime.Now:yyyy-MM-ddTHH:mm:ss.ffffff}] ");
            Console.Write(ansiColorCode);
            Console.Write($"{levelLabel} ");
            Console.Write("\u001b[0m");
            Console.Write(message);
            Console.WriteLine();
        }

        public void Error(string message)
        {
            PrintColored(LogLevel.ERROR, message);
            Log(LogLevel.ERROR, message);
        }

        public void Warn(string message)
        {
            PrintColored(LogLevel.WARNING, message);
            Log(LogLevel.WARNING, message);
        }

        public void Info(string message)
        {
            PrintColored(LogLevel.INFO, message);
            Log(LogLevel.INFO, message);
        }

        public void Http(string message)
        {
            PrintColored(LogLevel.HTTP, message);
            Log(LogLevel.HTTP, message);
        }

        public void Verbose(string message)
        {
            PrintColored(LogLevel.VERBOSE, message);
            Log(LogLevel.VERBOSE, message);
        }

        public void Debug(string message)
        {
            PrintColored(LogLevel.DEBUG, message);
            Log(LogLevel.DEBUG, message);
        }

        public void Silly(string message)
        {
            PrintColored(LogLevel.SILLY, message);
            Log(LogLevel.SILLY, message);
        }
    }
}
