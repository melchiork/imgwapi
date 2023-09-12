using System;
using Newtonsoft.Json;

namespace ImgwApi
{
    public class SynopData
    {
        [JsonProperty("id_stacji")]
        public int StationId { get; set; }

        [JsonProperty("stacja")]
        public string StationName { get; set; }

        [JsonProperty("data_pomiaru")]
        public DateTime DateOfMeasurement { get; set; }

        [JsonProperty("godzina_pomiaru")]
        public int HourOfMeasurement { get; set; }

        [JsonProperty("temperatura")]
        public decimal TemparatureC { get; set; }

        [JsonProperty("predkosc_wiatru")]
        public decimal WindSpeed { get; set; }

        [JsonProperty("kierunek_wiatru")]
        public decimal WindDirection { get; set; }

        [JsonProperty("wilgotnosc_wzgledna")]
        public decimal RelativeHumidity { get; set; }

        [JsonProperty("suma_opadu")]
        public decimal Rainfall { get; set; }

        [JsonProperty("cisnienie")]
        public decimal? Pressure { get; set; }
    }
}