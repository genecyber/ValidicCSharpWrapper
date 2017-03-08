using Newtonsoft.Json;

namespace ValidicCSharp.Model
{
    public class Routine : Measurement
    {
        [JsonProperty("steps")]
        public double? Steps { get; set; }

        [JsonProperty("calories_burned")]
        public double? CaloriesBurned { get; set; }

        [JsonProperty("distance")]
        public double? Distance { get; set; }

        [JsonProperty("floors")]
        public object Floors { get; set; }

        [JsonProperty("elevation")]
        public object Elevation { get; set; }
    }
}