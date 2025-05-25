namespace Logdash;

public static class LogdashFactory
{
    public static LogdashClient CreateLogdash(Dictionary<string, object>? parameters = null)
    {
        string? apiKey = "";
        string host = "https://api.logdash.io";
        bool verbose = false;

        if (parameters != null)
        {
            if (parameters.ContainsKey("api_key"))
                apiKey = parameters["api_key"] as string ?? apiKey;
            if (parameters.ContainsKey("host"))
                host = parameters["host"] as string ?? host;
            if (parameters.ContainsKey("verbose"))
                verbose = parameters["verbose"] is bool b && b;
        }

        return new LogdashClient(apiKey, host, verbose);
    }
}
