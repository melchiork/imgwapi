using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        /// <exception cref="ApiClientException"></exception>
        /// <exception cref="JsonException"></exception>
        Task<IReadOnlyCollection<SynopData>> GetAllAsync();

        /// <summary>
        /// Returns data for one station.
        /// </summary>
        /// <exception cref="ApiClientException"></exception>
        /// <exception cref="JsonException"></exception>
        Task<SynopData> GetAsync(SynopStation station);
    }
}