using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace iCloudBypass_SDK
{
    /// <summary>
    /// Main entry class for interacting with iCloud bypass services.
    /// </summary>
    public class iCloudBypassClient
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public iCloudBypassClient(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://gsmadjaa.com")
            };
        }

        /// <summary>
        /// Authenticates the SDK with the given API key.
        /// </summary>
        /// <returns>True if authentication is successful; otherwise, false.</returns>
        public async Task<bool> AuthenticateAsync()
        {
            var response = await _httpClient.PostAsync("/authenticate", new StringContent($"{{ \"apiKey\": \"{_apiKey}\" }}"));
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Bypasses iCloud for the specified device.
        /// </summary>
        /// <param name="deviceId">The unique device identifier (UDID) of the device.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the bypass status.</returns>
        public async Task<bool> BypassAsync(string deviceId)
        {
            var response = await _httpClient.PostAsync("/bypass", new StringContent($"{{ \"deviceId\": \"{deviceId}\" }}"));
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Checks the bypass status for the specified device.
        /// </summary>
        /// <param name="deviceId">The unique device identifier (UDID) of the device.</param>
        /// <returns>Returns true if the device is bypassed; otherwise, false.</returns>
        public async Task<bool> CheckBypassStatusAsync(string deviceId)
        {
            var response = await _httpClient.GetAsync($"/checkstatus?deviceId={deviceId}");
            return response.IsSuccessStatusCode;
        }
    }
}
