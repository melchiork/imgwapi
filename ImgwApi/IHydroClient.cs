using System.Collections.Generic;
using System.Threading.Tasks;

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
        Task<IReadOnlyCollection<HydroData>> GetAllAsync();
    }
}