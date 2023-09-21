using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ImgwApi
{
    public class SynopClient
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

        public static SynopClient Create() => new SynopClient();

        public static SynopClient Create(HttpClient client) => new SynopClient(client);

        /// <summary>
        /// Returns data for all stations.
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
        /// Returns data for one station.
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
