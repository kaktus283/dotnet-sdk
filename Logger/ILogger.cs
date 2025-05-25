namespace Logdash.Logger
{
    public interface ILogger
    {
        void Log(LogLevel level, string message);

        /// <summary>
        /// Log an error message.
        /// </summary>
        void Error(string message);

        /// <summary>
        /// Log a warning message.
        /// </summary>
        void Warn(string message);

        /// <summary>
        /// Log an info message.
        /// </summary>
        void Info(string message);

        /// <summary>
        /// Log an HTTP-related message.
        /// </summary>
        void Http(string message);

        /// <summary>
        /// Log a verbose message.
        /// </summary>
        void Verbose(string message);

        /// <summary>
        /// Log a debug message.
        /// </summary>
        void Debug(string message);

        /// <summary>
        /// Log a silly message (lowest priority).
        /// </summary>
        void Silly(string message);
    }
}
