using System.Text;
using System.Text.Json;
using Logdash.Logger.Internal;

namespace Logdash
{
    public class HttpLogSync : ILogSync
    {
        private readonly string _apiKey;
        private readonly string _host;
        private readonly bool _verbose;
        private int _sequenceNumber = 0;

        private static readonly HttpClient _httpClient = new();

        public HttpLogSync(string apiKey, string host, bool verbose = false)
        {
            _apiKey = apiKey;
            _host = host;
            _verbose = verbose;
        }

        public async Task SendAsync(string message, LogLevel level, string timestamp)
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                if (_verbose)
                    Console.WriteLine("[Logdash][DEBUG] API key is missing, log not sent.");
                return;
            }

            var payload = new
            {
                message = message,
                level = level.ToString().ToLower(),
                createdAt = timestamp,
                sequenceNumber = _sequenceNumber
            };

            string payloadJson = JsonSerializer.Serialize(payload);

            if (_verbose)
                Console.WriteLine($"[Logdash][DEBUG] Start request for: {message}");
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_host}/logs")
            {
                Content = new StringContent(payloadJson, Encoding.UTF8, "application/json")
            };
            request.Headers.Add("project-api-key", _apiKey);

            try
            {
                var response = await _httpClient.SendAsync(
                    request,
                    HttpCompletionOption.ResponseHeadersRead
                );

                if (response.IsSuccessStatusCode)
                {
                    if (_verbose)
                    {
                        Console.WriteLine($"[Logdash][DEBUG] Log sent successfully: {message}");
                    }
                    _sequenceNumber++;
                }
                else
                {
                    Console.WriteLine(
                        "[Logdash][DEBUG] Failed to send log: "
                            + message
                            + " HTTP status: "
                            + (int)response.StatusCode
                            + " "
                            + response.ReasonPhrase
                            + ")"
                    );
                }
            }
            catch (Exception ex)
            {
                if (_verbose)
                    Console.WriteLine($"[Logdash][EXCEPTION] Error sending log: {ex.Message}");
            }
        }
    }
}
