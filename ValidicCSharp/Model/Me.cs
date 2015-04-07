using Newtonsoft.Json;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Me : IValidic
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
    }
}