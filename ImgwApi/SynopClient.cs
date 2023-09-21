using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ImgwApi
{
    /// <summary>
    /// <inheritdoc cref="ISynopClient"/>
    /// </summary>
    public class SynopClient : ISynopClient
    {
        private const string ApiAddress = "https://danepubliczne.imgw.pl/api/data/synop/";

        private readonly HttpClient _client;

        private SynopClient(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        private SynopClient() : this(new HttpClient())
        {
        }

        /// <summary>
        /// Creates instance with new <see cref="HttpClient"/>
        /// </summary>
        public static SynopClient Create() => new SynopClient();

        /// <summary>
        /// Creates instance with provided <see cref="HttpClient"/>
        /// </summary>
        public static SynopClient Create(HttpClient client) => new SynopClient(client);

        /// <summary>
        /// <inheritdoc cref="ISynopClient.GetAllAsync"/>
        /// </summary>
        /// <exception cref="ApiClientException"></exception>
        /// <exception cref="JsonSerializationException"></exception>
        public async Task<IReadOnlyCollection<SynopData>> GetAllAsync()
        {
            var text = await CallApi(ApiAddress);

            var result = JsonConvert.DeserializeObject<List<SynopData>>(text);

            return result;
        }
        
        /// <summary>
        /// <inheritdoc cref="ISynopClient.GetAsync"/>
        /// </summary>
        /// <exception cref="ApiClientException"></exception>
        /// <exception cref="JsonSerializationException"></exception>
        public async Task<SynopData> GetAsync(SynopStations station)
        {
            var text = await CallApi($"{ApiAddress}id/{(int)station}");
           
            var result = JsonConvert.DeserializeObject<SynopData>(text);

            return result;
        }

        private async Task<string> CallApi(string address)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync(address);
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