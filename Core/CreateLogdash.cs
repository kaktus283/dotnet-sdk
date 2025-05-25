namespace Logdash.Core
{
    public static class CreateLogdash
    {
        public static LogdashClient Create(Dictionary<string, object>? parameters = null)
        {
            return LogdashFactory.CreateLogdash(parameters);
        }
    }
}
