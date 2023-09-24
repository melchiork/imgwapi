using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ImgwApi
{
    /// <summary>
    /// Client for hydro data from IMGW.
    /// </summary>
    public class HydroClient
    {
        private readonly HttpClient _httpClient;

        private HydroClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Creates new instance of <see cref="HydroClient"/> using new instance of <see cref="HttpClient"/>
        /// </summary>
        public static HydroClient Create() => new HydroClient(new HttpClient());

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<HydroData>> GetAll()
        {
            var result = await _httpClient.GetAsync("https://danepubliczne.imgw.pl/api/data/hydro/");

            var data = await result.Content.ReadAsStringAsync();

            var deserialized = JsonConvert.DeserializeObject<List<HydroData>>(data);

            return deserialized;
        }

    }
}