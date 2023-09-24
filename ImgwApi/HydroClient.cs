using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ImgwApi
{
    /// <summary>
    /// <inheritdoc cref="IHydroClient"/>
    /// </summary>
    public class HydroClient : BaseImgwApiClient, IHydroClient
    {
        private const string ApiAddress = "https://danepubliczne.imgw.pl/api/data/hydro/";
        
        private HydroClient(HttpClient httpClient) : base(httpClient)
        {
        }

        /// <summary>
        /// Creates new instance of <see cref="HydroClient"/> using new instance of <see cref="HttpClient"/>
        /// </summary>
        public static HydroClient Create() => new HydroClient(new HttpClient());

        /// <summary>
        /// Creates new instance of <see cref="HydroClient"/> using provided instance of <see cref="HttpClient"/>
        /// </summary>
        public static HydroClient Create(HttpClient httpClient) => new HydroClient(httpClient);

        /// <summary>
        /// <inheritdoc cref="IHydroClient.GetAllAsync"/>
        /// </summary>
        public async Task<IReadOnlyCollection<HydroData>> GetAllAsync()
        {
            var text = await Get(ApiAddress);

            var deserialized = JsonConvert.DeserializeObject<List<HydroData>>(text);

            return deserialized;
        }
    }
}