using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ImgwApi
{
    public class SynopClient
    {
        private readonly HttpClient _client;
        
        private SynopClient()
        {
            _client = new HttpClient();
        }

        public static SynopClient Create() => new SynopClient();

        public async Task<IReadOnlyCollection<SynopData>> GetAll()
        {
            var response = await _client.GetAsync("https://danepubliczne.imgw.pl/api/data/synop/");

            var text = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<SynopData>>(text);

            return result;
        }
    }
}
