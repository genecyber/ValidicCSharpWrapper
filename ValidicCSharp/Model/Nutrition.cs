using Newtonsoft.Json;

namespace ValidicCSharp.Model
{
    public class Nutrition : Measurement
    {
        [JsonProperty("calories")]
        public double Calories { get; set; }

        [JsonProperty("carbohydrates")]
        public double? Carbohydrates { get; set; }

        [JsonProperty("fat")]
        public double? Fat { get; set; }

        [JsonProperty("fiber")]
        public double? Fiber { get; set; }

        [JsonProperty("protein")]
        public double? Protein { get; set; }

        [JsonProperty("sodium")]
        public double? Sodium { get; set; }

        [JsonProperty("water")]
        public object Water { get; set; }

        [JsonProperty("meal")]
        public string Meal { get; set; }
    }
}