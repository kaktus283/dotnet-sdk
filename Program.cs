using static Logdash.Core.CreateLogdash;

public class Program
{
    public static async Task Main(string[] args)
    {
        //Initialize logdash
        //For testing without an API key, logs will only be printed locally
        var logdash = Create(
            new()
            {
                //Your API key of project - (optional)
                ["api_key"] = "mU4qpiWaI5gUn1yt95Cknczhx09kr0Em",
                //Your own Logdash host address - (optional)
                ["host"] = "https://api.logdash.io",
                //Enable (true) or disable (false) debug information - (optional)
                ["verbose"] = true
            }
        );

        //Get the logger instance
        var logger = logdash.Logger;

        //Get the metrics instance
        var metrics = logdash.Metrics;

        //Log messages at different levels
        logger.Error("C# ERROR");
        logger.Warn("C# WARNING");
        logger.Info("C# INFO");
        logger.Http("C# HTTP");
        logger.Verbose("C# VERBOSE");
        logger.Debug("C# DEBUG");

        for (int i = 0; i < 5; i++)
        {
            // Set absolute values
            metrics.Set("active_users", 100 + i * 10);

            // Mutate values (increment/decrement)
            metrics.Mutate("requests_count", 1);

            logger.Info($"Iteration {i + 1}/5 completed");
            Thread.Sleep(1000);
        }

        logger.Info("Example completed");

        //Workaround for application without endless-loop.
        //Without that, application just show logs in console, but not wait for response of HTTP.
        //Hard to say it's a bug or feature, as application which require logs rather wait in loop.
        //In case of exception or app closing, this should work.
        await Task.Delay(TimeSpan.FromSeconds(1));
    }
}

/*

    //to niby da global
    Logdash.LogdashGlobal.Client = logdash;
    Logdash.LogdashGlobal.Logger = logger;
    //

*/
