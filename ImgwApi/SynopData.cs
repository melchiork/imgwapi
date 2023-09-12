using System;
using Newtonsoft.Json;

namespace ImgwApi
{
    public class SynopData
    {
        [JsonConstructor]
        public SynopData(int stationId, string stationName, DateTime dateOfMeasurement, int hourOfMeasurement, decimal temparatureC, decimal windSpeed, decimal windDirection, decimal relativeHumidity, decimal rainfall, decimal? pressure)
        {
            StationId = stationId;
            StationName = stationName;
            DateOfMeasurement = dateOfMeasurement;
            HourOfMeasurement = hourOfMeasurement;
            TemparatureC = temparatureC;
            WindSpeed = windSpeed;
            WindDirection = windDirection;
            RelativeHumidity = relativeHumidity;
            Rainfall = rainfall;
            Pressure = pressure;
            DateTimeOfMeasurement = dateOfMeasurement.AddHours(hourOfMeasurement);
        }

        [JsonProperty("id_stacji")]
        public int StationId { get; }

        [JsonProperty("stacja")]
        public string StationName { get; }

        [JsonProperty("data_pomiaru")]
        public DateTime DateOfMeasurement { get; }

        [JsonProperty("godzina_pomiaru")]
        public int HourOfMeasurement { get; }

        public DateTime DateTimeOfMeasurement { get; }

        [JsonProperty("temperatura")]
        public decimal TemparatureC { get; }

        [JsonProperty("predkosc_wiatru")]
        public decimal WindSpeed { get; }

        [JsonProperty("kierunek_wiatru")]
        public decimal WindDirection { get; }

        [JsonProperty("wilgotnosc_wzgledna")]
        public decimal RelativeHumidity { get; }

        [JsonProperty("suma_opadu")]
        public decimal Rainfall { get; }

        [JsonProperty("cisnienie")]
        public decimal? Pressure { get; }
    }
}