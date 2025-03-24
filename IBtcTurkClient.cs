using System.Net.Http;
using System.Threading.Tasks;
using BtcTurk.Client.Models.Authentication;
using BtcTurk.Client.Services.Public;
using BtcTurk.Client.Services.Private;

namespace BtcTurk.Client
{
    /// <summary>
    /// Main client interface for interacting with BtcTurk API
    /// </summary>
    public interface IBtcTurkClient
    {
        /// <summary>
        /// The underlying HttpClient used for API requests
        /// </summary>
        HttpClient HttpClient { get; }

        /// <summary>
        /// API credentials for authenticated endpoints
        /// </summary>
        ApiCredentials? Credentials { get; }

        /// <summary>
        /// Base URL of the BtcTurk API
        /// </summary>
        string BaseUrl { get; }
        
        /// <summary>
        /// Access to public API endpoints that don't require authentication
        /// </summary>
        IBtcTurkPublicService PublicService { get; }

        /// <summary>
        /// Access to private API endpoints that require authentication
        /// </summary>
        IBtcTurkPrivateService PrivateService { get; }

        /// <summary>
        /// Send a request to the BtcTurk API
        /// </summary>
        /// <typeparam name="T">The expected response type</typeparam>
        /// <param name="method">HTTP method to use</param>
        /// <param name="endpoint">API endpoint to call</param>
        /// <param name="requestBody">Optional request body for POST requests</param>
        /// <returns>The deserialized response</returns>
        Task<T?> SendRequestAsync<T>(HttpMethod method, string endpoint, object? requestBody = null) where T : class;
    }
}
