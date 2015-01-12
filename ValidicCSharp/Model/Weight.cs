using System.Xml.Serialization;
using Newtonsoft.Json;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Weight : Measurement
    {
        [JsonProperty("weight")]
        public double? Value { get; set; }
        [JsonProperty("height")]
        public double? Height { get; set; }
        [JsonProperty("free_mass")]
        public double? FreeMass { get; set; }
        [JsonProperty("fat_percent")]
        public double? FatPercent { get; set; }
        [JsonProperty("mass_weight")]
        public double? MassWeight { get; set; }
        [JsonProperty("bmi")]
        public double? Bmi { get; set; }
    }
}