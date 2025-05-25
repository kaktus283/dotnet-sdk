namespace Logdash.Core
{
    public static class CreateLogdash
    {
        /// <summary>
        /// Create a new logdash instance with logger and metrics.
        /// <para>
        /// Args:
        ///   params: Optional dictionary with configuration parameters:
        ///     - api_key: Your logdash API key
        ///     - host: logdash API host (defaults to https://api.logdash.io)
        ///     - verbose: Enable verbose mode
        /// </para>
        /// <para>
        /// Returns:
        ///   A logdash instance with logger and metrics properties.
        /// </para>
        /// </summary>
        public static LogdashClient Create(Dictionary<string, object>? parameters = null)
        {
            return LogdashFactory.CreateLogdash(parameters);
        }
    }
}
