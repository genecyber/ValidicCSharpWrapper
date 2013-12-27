using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Application
    {
        public string name { get; set; }
    }

    public class Profile
    {
        [JsonProperty("uid")]
        public string uid { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

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
