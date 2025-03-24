using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BtcTurk.Client.Authentication;
using BtcTurk.Client.Models.Authentication;
using BtcTurk.Client.Serialization;
using BtcTurk.Client.Services.Public;
using BtcTurk.Client.Services.Private;


namespace BtcTurk.Client
{
    public class BtcTurkClient : IBtcTurkClient
    {
        private const string ApiBaseUrl = "https://api.btcturk.com/api/v1";
        private readonly AuthenticationHandler? _authHandler;
        private readonly Lazy<IBtcTurkPublicService> _publicService;
        private readonly Lazy<IBtcTurkPrivateService> _privateService;

        public HttpClient HttpClient { get; }
        public ApiCredentials? Credentials { get; }
        public string BaseUrl => ApiBaseUrl;

        public IBtcTurkPublicService PublicService => _publicService.Value;
        public IBtcTurkPrivateService PrivateService => _privateService.Value;

        public BtcTurkClient(HttpClient httpClient, ApiCredentials? credentials = null)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            Credentials = credentials;

            if (credentials != null)
            {
                _authHandler = new AuthenticationHandler(credentials);
            }

            _publicService = new Lazy<IBtcTurkPublicService>(() => new BtcTurkPublicService(this));
            _privateService = new Lazy<IBtcTurkPrivateService>(() => new BtcTurkPrivateService(this));

            ConfigureHttpClient();
        }

        private void ConfigureHttpClient()
        {
            HttpClient.BaseAddress = new Uri(ApiBaseUrl);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T?> SendRequestAsync<T>(HttpMethod method, string endpoint, object? requestBody = null) where T : class
        {
            using var request = new HttpRequestMessage(method, endpoint);
            string? jsonBody = null;

            if (requestBody != null)
            {
                jsonBody = JsonSerializer.Serialize(requestBody, JsonConfig.DefaultOptions);
                request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            }

            if (_authHandler != null)
            {
                var (signature, nonce) = _authHandler.CreateAuthenticationSignature(method.ToString(), endpoint, jsonBody);
                request.Headers.Add("X-PCK", Credentials!.ApiKey);
                request.Headers.Add("X-Signature", signature);
                request.Headers.Add("X-Stamp", nonce);
            }

            using var response = await HttpClient.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"API request failed with status code {response.StatusCode}: {content}");
            }

            if (typeof(T) == typeof(string))
            {
                return (T)(object)content;
            }

            return JsonSerializer.Deserialize<T>(content, JsonConfig.DefaultOptions);
        }

        protected Task<T?> GetAsync<T>(string endpoint) where T : class
            => SendRequestAsync<T>(HttpMethod.Get, endpoint);

        protected Task<T?> PostAsync<T>(string endpoint, object requestBody) where T : class
            => SendRequestAsync<T>(HttpMethod.Post, endpoint, requestBody);

        protected Task<T?> DeleteAsync<T>(string endpoint) where T : class
            => SendRequestAsync<T>(HttpMethod.Delete, endpoint);
    }
}
