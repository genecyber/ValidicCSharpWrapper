using Newtonsoft.Json;

namespace ValidicCSharp.Model
{
    public enum GenderType
    {
        [JsonProperty("M")] M = 0,

        [JsonProperty("F")] F
    }
}