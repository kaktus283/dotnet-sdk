namespace Logdash.Logger.Internal
{
    /// <summary>
    /// Internal logger for SDK debug messages. Only prints to console, never sends logs via HTTP.
    /// </summary>
    internal static class InternalLogger
    {
        public static void Debug(string message)
        {
            Logger.PrintColored(LogLevel.DEBUG, message);
        }

        public static void Error(string message)
        {
            Logger.PrintColored(LogLevel.ERROR, message);
        }

        public static void Warning(string message)
        {
            Logger.PrintColored(LogLevel.WARNING, message);
        }

        public static void Info(string message)
        {
            Logger.PrintColored(LogLevel.INFO, message);
        }

        public static void Http(string message)
        {
            Logger.PrintColored(LogLevel.HTTP, message);
        }

        public static void Verbose(string message)
        {
            Logger.PrintColored(LogLevel.VERBOSE, message);
        }

        public static void Silly(string message)
        {
            Logger.PrintColored(LogLevel.SILLY, message);
        }
    }
}
