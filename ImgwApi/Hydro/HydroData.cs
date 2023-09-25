using System;
using Newtonsoft.Json;

namespace ImgwApi
{
    /// <summary>
    /// Details of hydro measurement
    /// </summary>
    public class HydroData
    {
        /// <summary>
        /// Constructs new instance of <see cref="HydroData"/>. Used for deserialization.
        /// </summary>
        [JsonConstructor]
        public HydroData(int stationId, string stationName, string riverName, string voivodeship, int? waterLevel,
            DateTime? waterLevelMeasurementDate, decimal? waterTemperatureC, DateTime? waterTemperatureMeasurementDate,
            int? icePhenomenon, DateTime? icePhenomenonMeasurementDate,
            int? overgrowthPhenomenon,
            DateTime? overgrowthPhenomenonMeasurementDate)
        {
            StationId = stationId;
            StationName = stationName;
            RiverName = riverName;
            Voivodeship = voivodeship;
            WaterLevel = waterLevel;
            WaterLevelMeasurementDate = waterLevelMeasurementDate;
            WaterTemperatureC = waterTemperatureC;
            WaterTemperatureMeasurementDate = waterTemperatureMeasurementDate;
            IcePhenomenon = icePhenomenon;
            IcePhenomenonMeasurementDate = icePhenomenonMeasurementDate;
            OvergrowthPhenomenon = overgrowthPhenomenon;
            OvergrowthPhenomenonMeasurementDate = overgrowthPhenomenonMeasurementDate;
        }

        /// <summary>
        /// Numerical id of a measurement station.
        /// </summary>
        [JsonProperty("id_stacji")]
        public int StationId { get; }

        /// <summary>
        /// Name of a station, does not have to match a city/village name.
        /// </summary>
        [JsonProperty("stacja")]
        public string StationName { get; }

        /// <summary>
        /// Name of the river.
        /// </summary>
        [JsonProperty("rzeka")]
        public string RiverName { get; }

        /// <summary>
        /// Name of Voivodeship in which the station is located.
        /// </summary>
        [JsonProperty("województwo")]
        public string Voivodeship { get; }

        /// <summary>
        /// Water level in centimeters.
        /// </summary>
        [JsonProperty("stan_wody")]
        public int? WaterLevel { get; }

        /// <summary>
        /// Date and time of <see cref="WaterLevel"/> measurement.
        /// </summary>
        [JsonProperty("stan_wody_data_pomiaru")]
        public DateTime? WaterLevelMeasurementDate { get; }

        /// <summary>
        /// Water temperature in Celsius.
        /// </summary>
        [JsonProperty("temperatura_wody")]
        public decimal? WaterTemperatureC { get; }

        /// <summary>
        /// Date and time of <see cref="WaterTemperatureC"/> measurement.
        /// </summary>
        [JsonProperty("temperatura_wody_data_pomiaru")]
        public DateTime? WaterTemperatureMeasurementDate { get; }

        /// <summary>
        /// TODO ?
        /// </summary>
        [JsonProperty("zjawisko_lodowe")]
        public int? IcePhenomenon { get; }

        /// <summary>
        /// Date and time of <see cref="IcePhenomenon"/> measurement.
        /// </summary>
        [JsonProperty("zjawisko_lodowe_data_pomiaru")]
        public DateTime? IcePhenomenonMeasurementDate { get; }

        /// <summary>
        /// TODO ?
        /// </summary>
        [JsonProperty("zjawisko_zarastania")]
        public int?OvergrowthPhenomenon { get; }

        /// <summary>
        /// Date and time of <see cref="OvergrowthPhenomenon"/> measurement.
        /// </summary>
        [JsonProperty("zjawisko_zarastania_data_pomiaru")]
        public DateTime? OvergrowthPhenomenonMeasurementDate { get; }
    }
}