namespace Logdash.Logger
{
    public interface ILogger
    {
        void Log(LogLevel level, string message);

        /// <summary>
        /// Logs a message as an error (ERROR) to the console and sends it to the logging system.
        /// </summary>
        /// <param name="message">The message content to be logged.</param>
        void Error(string message);

        /// <summary>
        /// Logs a message as an warning (WARNING) to the console and sends it to the logging system.
        /// </summary>
        /// <param name="message">The message content to be logged.</param>
        void Warn(string message);

        /// <summary>
        /// Logs a message as an information (INFORMATION) to the console and sends it to the logging system.
        /// </summary>
        /// <param name="message">The message content to be logged.</param>
        void Info(string message);
        void Http(string message);
        void Verbose(string message);
        void Debug(string message);
        void Silly(string message);
    }
}
