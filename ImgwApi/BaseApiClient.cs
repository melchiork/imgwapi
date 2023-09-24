using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ImgwApi
{
    /// <summary>
    /// Base class fro calling IMGW APIs.
    /// </summary>
    public abstract class BaseImgwApiClient
    {
        /// <summary>
        /// Http client.
        /// </summary>
        protected readonly HttpClient HttpClient;
        
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        protected BaseImgwApiClient(HttpClient httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Calls provided API using HTTP GET and reads strings response.
        /// </summary>
        /// <exception cref="ApiClientException"></exception>
        protected async Task<string> Get(string address)
        {
            HttpResponseMessage response;
            try
            {
                response = await HttpClient.GetAsync(address);
            }
            catch (Exception ex)
            {
                throw new ApiClientException("Unable to get API response.", ex);
            }

            if (response.IsSuccessStatusCode == false)
            {
                throw new ApiClientException($"Api returned error code {response.StatusCode}");
            }

            var text = await response.Content.ReadAsStringAsync();
            return text;
        }
    }
}
