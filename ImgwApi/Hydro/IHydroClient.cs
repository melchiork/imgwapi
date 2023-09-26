using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ImgwApi
{
    /// <summary>
    /// Client for hydro data from IMGW.
    /// </summary>
    public interface IHydroClient
    {
        /// <summary>
        /// Gets all hydro stations measurements.
        /// </summary>
        /// <exception cref="ApiClientException"></exception>
        /// <exception cref="JsonException"></exception>
        Task<IReadOnlyCollection<HydroData>> GetAllAsync();
    }
}