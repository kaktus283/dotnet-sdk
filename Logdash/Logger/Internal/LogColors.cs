namespace Logdash.Logger.Internal
{
    public static class LogColors
    {
        public static readonly Dictionary<LogLevel, (int R, int G, int B)> LOG_LEVEL_COLORS =
            new()
            {
                { LogLevel.ERROR, (231, 0, 11) }, // Red
                { LogLevel.WARNING, (254, 154, 0) }, // Orange
                { LogLevel.INFO, (21, 93, 252) }, // Blue
                { LogLevel.HTTP, (0, 166, 166) }, // Teal
                { LogLevel.VERBOSE, (0, 166, 0) }, // Green
                { LogLevel.DEBUG, (0, 166, 62) }, // Light Green
                { LogLevel.SILLY, (80, 80, 80) } // Gray
            };

        public static string RgbToAnsi((int R, int G, int B) rgb) =>
            $"\u001b[38;2;{rgb.R};{rgb.G};{rgb.B}m";
    }
}
