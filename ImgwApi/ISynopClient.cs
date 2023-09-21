using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ImgwApi
{
    /// <summary>
    /// Client for weather data from IMGW.
    /// </summary>
    public interface ISynopClient
    {
        /// <summary>
        /// Returns data for all stations.
        /// </summary>
        Task<IReadOnlyCollection<SynopData>> GetAllAsync();

        /// <summary>
        /// Returns data for one station.
        /// </summary>
        Task<SynopData> GetAsync(SynopStations station);
    }
}