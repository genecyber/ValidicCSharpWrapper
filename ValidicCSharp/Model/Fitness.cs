using System;
using Newtonsoft.Json;

namespace ValidicCSharp.Model
{
    public class Fitness : Measurement
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("intensity")]
        public string Intensity { get; set; }

        [JsonProperty("start_time")]
        public DateTime? StartTime { get; set; }

        [JsonProperty("distance")]
        public double? Distance { get; set; }

        [JsonProperty("duration")]
        public double? Duration { get; set; }

        [JsonProperty("calories")]
        public double? Calories { get; set; }
    }
}