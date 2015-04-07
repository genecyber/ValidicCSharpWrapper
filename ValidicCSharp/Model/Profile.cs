using System.Collections.Generic;
using Newtonsoft.Json;

namespace ValidicCSharp.Model
{
    public class Profile : Me
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("gender")]
        public GenderType Gender { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("birth_year")]
        public object BirthYear { get; set; }

        [JsonProperty("height")]
        public double? Height { get; set; }

        [JsonProperty("weight")]
        public double? Weight { get; set; }

        [JsonProperty("applications")]
        public List<Application> Applications { get; set; }
    }
}