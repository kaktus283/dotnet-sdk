using System;

namespace Logdash.Logger
{
    public class Logger : ILogger
    {
        private readonly Action<LogLevel, string> _onLog;

        public Logger(Action<LogLevel, string> onLog)
        {
            _onLog = onLog;
        }

        public void Log(LogLevel level, string message)
        {
            _onLog(level, message);
        }

        public void Error(string message)
        {
            Console.Write($"[{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.ffffff")}] ");
            Console.Write("\u001b[38;2;231;0;11m");
            Console.Write("ERROR ");
            Console.Write("\u001b[0m");
            Console.Write(message);

            Console.WriteLine();

            Log(LogLevel.ERROR, message);
        }

        public void Warn(string message)
        {
            Console.Write($"[{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.ffffff")}] ");
            Console.Write("\u001b[38;2;254;154;0m");
            Console.Write("WARN ");
            Console.Write("\u001b[0m");
            Console.Write(message);

            Console.WriteLine();

            Log(LogLevel.WARNING, message);
        }

        public void Info(string message)
        {
            Console.Write($"[{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.ffffff")}] ");
            Console.Write("\u001b[38;2;21;93;252m");
            Console.Write("INFO ");
            Console.Write("\u001b[0m");
            Console.Write(message);

            Console.WriteLine();

            Log(LogLevel.INFO, message);
        }

        public void Http(string message)
        {
            Console.Write($"[{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.ffffff")}] ");
            Console.Write("\u001b[38;2;0;166;166m");
            Console.Write("HTTP ");
            Console.Write("\u001b[0m");
            Console.Write(message);

            Console.WriteLine();

            Log(LogLevel.HTTP, message);
        }

        public void Verbose(string message)
        {
            Console.Write($"[{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.ffffff")}] ");
            Console.Write("\u001b[38;2;0;166;0m");
            Console.Write("VERBOSE ");
            Console.Write("\u001b[0m");
            Console.Write(message);

            Console.WriteLine();

            Log(LogLevel.VERBOSE, message);
        }

        public void Debug(string message)
        {
            Console.Write($"[{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.ffffff")}] ");
            Console.Write("\u001b[38;2;0;166;62m");
            Console.Write("DEBUG ");
            Console.Write("\u001b[0m");
            Console.Write(message);

            Console.WriteLine();

            Log(LogLevel.DEBUG, message);
        }

        public void Silly(string message)
        {
            Console.Write($"[{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.ffffff")}] ");
            Console.Write("\u001b[38;2;80;80;80m");
            Console.Write("SILLY ");
            Console.Write("\u001b[0m");
            Console.Write(message);

            Console.WriteLine();

            Log(LogLevel.SILLY, message);
        }
    }
}
