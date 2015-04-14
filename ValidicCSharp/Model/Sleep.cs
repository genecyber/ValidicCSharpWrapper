using Newtonsoft.Json;

namespace ValidicCSharp.Model
{
    public class Sleep : Measurement
    {
        [JsonProperty("awake")]
        public double? Awake { get; set; }

        [JsonProperty("deep")]
        public double? Deep { get; set; }

        [JsonProperty("light")]
        public double? Light { get; set; }

        [JsonProperty("rem")]
        public object Rem { get; set; }

        [JsonProperty("times_woken")]
        public double? TimesWoken { get; set; }

        [JsonProperty("total_sleep")]
        public double? TotalSleep { get; set; }
    }
}