using System;
using Newtonsoft.Json;

namespace ImgwApi
{
    /// <summary>
    /// Data for a single station returned from the API.
    /// </summary>
    public class SynopData
    {
        /// <summary>
        /// Constructor using wile deserializing API response.
        /// </summary>
        [JsonConstructor]
        public SynopData(int stationId, string stationName, DateTime dateOfMeasurement, int hourOfMeasurement,
            decimal temperatureC, decimal windSpeed, decimal windDirection, decimal relativeHumidity, decimal rainfall,
            decimal? pressure)
        {
            StationId = stationId;
            StationName = stationName;
            DateOfMeasurement = dateOfMeasurement;
            HourOfMeasurement = hourOfMeasurement;
            TemperatureC = temperatureC;
            WindSpeed = windSpeed;
            WindDirection = windDirection;
            RelativeHumidity = relativeHumidity;
            Rainfall = rainfall;
            Pressure = pressure;
            DateTimeOfMeasurement = dateOfMeasurement.AddHours(hourOfMeasurement);
        }

        /// <summary>
        /// Numerical station id. should match one from <see cref="SynopStations"/>
        /// </summary>
        [JsonProperty("id_stacji")]
        public int StationId { get; }

        /// <summary>
        /// Human readable station name
        /// </summary>
        [JsonProperty("stacja")]
        public string StationName { get; }

        /// <summary>
        /// Date only of the measurement
        /// </summary>
        [JsonProperty("data_pomiaru")]
        public DateTime DateOfMeasurement { get; }

        /// <summary>
        /// Full hour of measurement
        /// </summary>
        [JsonProperty("godzina_pomiaru")]
        public int HourOfMeasurement { get; }

        /// <summary>
        /// DAte and Time of measurement as calculated by the library, for raw data see <see cref="DateOfMeasurement"/> and <see cref="HourOfMeasurement"/>
        /// </summary>
        [JsonIgnore]
        public DateTime DateTimeOfMeasurement { get; }

        /// <summary>
        /// Temperature in Celsius
        /// </summary>
        [JsonProperty("temperatura")]
        public decimal TemperatureC { get; }

        /// <summary>
        /// Wind speed
        /// </summary>
        [JsonProperty("predkosc_wiatru")]
        public decimal WindSpeed { get; }

        /// <summary>
        /// Wind direction in degrees
        /// </summary>
        [JsonProperty("kierunek_wiatru")]
        public decimal WindDirection { get; }

        /// <summary>
        /// Relative humidity
        /// </summary>
        [JsonProperty("wilgotnosc_wzgledna")]
        public decimal RelativeHumidity { get; }

        /// <summary>
        /// Sum of rainfall
        /// </summary>
        [JsonProperty("suma_opadu")]
        public decimal Rainfall { get; }

        /// <summary>
        /// Pressure in hPa. Not available for every station.
        /// </summary>
        [JsonProperty("cisnienie")]
        public decimal? Pressure { get; }
    }
}