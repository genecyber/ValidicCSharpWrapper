using Newtonsoft.Json;

namespace ValidicCSharp.Model
{
    public class UserRequest
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }
        [JsonProperty("profile")]
        public Profile Profile { get; set; }
    }
}