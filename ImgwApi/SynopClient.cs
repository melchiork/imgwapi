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

        public async Task<IReadOnlyCollection<SynopData>> GetAllAsync()
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync(ApiAddress);
            }
            catch (Exception ex)
            {
                throw new ApiClientException("Unable to get API response.", ex);
            }

            var text = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<SynopData>>(text);

            return result;
        }

        public async Task<SynopData> GetAsync(SynopStations station)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync($"{ApiAddress}id/{(int)station}");
            }
            catch (Exception ex)
            {
                throw new ApiClientException("Unable to get API response.", ex);
            }

            var text = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<SynopData>(text);

            return result;
        }
    }
}
