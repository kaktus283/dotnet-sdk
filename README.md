# logdash - Dotnet SDK

Logdash is a zero-config observability platform. This package serves as a C# interface to use it.

## Pre-requisites

Setup your free project in less than 2 minutes at [logdash.io](https://logdash.io/)

## Installation

```bash
~~dotnet add package logdash~~
```

## Logging

```C#
using static Logdash.Core.CreateLogdash;

// Initialize with your API key
var logdash = Create(
    new()
    {
        // optional, but recommended to see your logs in the dashboard
        ["api_key"] = "<your-api-key>"
    }
);

// Access the logger
var logger = logdash.Logger;

logger.Info("Application started successfully");
logger.Error("An unexpected error occurred");
logger.Warn("Low disk space warning");
```

## Metrics

```C#
using static Logdash.Core.CreateLogdash;

// Initialize with your API key
var logdash = Create(
    new()
    {
        // optional, but recommended to see your logs in the dashboard
        ["api_key"] = "<your-api-key>"
    }
);

// Access metrics
var metrics = logdash.Metrics

// to set absolute value
metrics.Set("users", 0)

// to modify existing metric
metrics.Mutate("users", 1)
```

## View

To see the logs or metrics, go to your project dashboard

![logs](https://raw.githubusercontent.com/logdash-io/python-sdk/main/docs/logs.png)
![delta](https://raw.githubusercontent.com/logdash-io/python-sdk/main/docs/delta.png)

## License

This project is licensed under the MIT License.

## Contributing

Contributions are welcome! Feel free to open issues or submit pull requests.

## Support

If you encounter any issues, please open an issue on GitHub or let us know at [contact@logdash.io](mailto:contact@logdash.io).