using System.Text;
using System.Text.Json;
using Logdash.Logger;

namespace Logdash
{
    public class HttpLogSync : ILogSync
    {
        private readonly string _apiKey;
        private readonly string _host;
        private readonly bool _verbose;
        private int _sequenceNumber = 0;

        private static readonly HttpClient _httpClient = new();

        // private static readonly HttpClient _httpClient = new HttpClient
        // {
        //     Timeout = TimeSpan.FromSeconds(5)
        // };

        public HttpLogSync(string apiKey, string host, bool verbose = false)
        {
            _apiKey = apiKey;
            _host = host;
            _verbose = verbose;
        }

        public async Task SendAsync(string message, LogLevel level, string timestamp)
        {
            // System.Console.WriteLine(
            //     $"[Logdash][DEBUG] HttpClient Timeout: {_httpClient.Timeout.TotalSeconds} seconds"
            // );
            if (string.IsNullOrEmpty(_apiKey))
            {
                if (_verbose)
                {
                    Console.WriteLine("[Logdash] API key is missing, log not sent.");
                }
                return;
            }

            var payload = new
            {
                message = message,
                level = level.ToString().ToLower(),
                /*level = level.ToString().ToLower() == "warn"
                    ? "warning"
                    : level.ToString().ToLower(),*/
                createdAt = timestamp,
                sequenceNumber = _sequenceNumber
            };

            string payloadJson = JsonSerializer.Serialize(payload);
            //System.Console.WriteLine($"[Logdash][DEBUG] Payload JSON: {payloadJson}");
            //System.Console.WriteLine("Start request");
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_host}/logs")
            {
                Content = new StringContent(payloadJson, Encoding.UTF8, "application/json")
            };
            request.Headers.Add("project-api-key", _apiKey);
            //System.Console.WriteLine($"[Logdash][DEBUG] Request URI: {request.RequestUri}");
            //System.Console.WriteLine($"[Logdash][DEBUG] Request Headers:");
            // foreach (var h in request.Headers)
            // {
            //     System.Console.WriteLine($"  {h.Key}: {string.Join(", ", h.Value)}");
            // }
            // System.Console.WriteLine($"[Logdash][DEBUG] Content Headers:");
            // foreach (var h in request.Content.Headers)
            // {
            //     System.Console.WriteLine($"  {h.Key}: {string.Join(", ", h.Value)}");
            // }

            try
            {
                //Console.WriteLine($"[Logdash] Sending log to: {request.RequestUri}");
                var response = await _httpClient.SendAsync(
                    request,
                    HttpCompletionOption.ResponseHeadersRead
                );
                // Console.WriteLine(
                //     $"[Logdash] HTTP status: {(int)response.StatusCode} {response.StatusCode}"
                // );
                // string responseContent = await response.Content.ReadAsStringAsync();
                //Console.WriteLine($"[Logdash][DEBUG] Server response body: {responseContent}");
                if (response.IsSuccessStatusCode)
                {
                    if (_verbose)
                    {
                        Console.WriteLine($"[Logdash] Log sent successfully: {message}");
                    }
                    _sequenceNumber++;
                }
                else
                {
                    Console.WriteLine(
                        "[Logdash] Failed to send log: "
                            + message
                            + " (HTTP "
                            + (int)response.StatusCode
                            + " "
                            + response.ReasonPhrase
                            + ")"
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Logdash][EXCEPTION] Error sending log: {ex.Message}");
                Console.WriteLine($"[Logdash][EXCEPTION] StackTrace: {ex.StackTrace}");
            }
        }
    }
}
