using System.Collections.Generic;
using Newtonsoft.Json;

namespace ValidicCSharp.Model
{
    public class App
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }
    }

    public class Apps
    {
        [JsonProperty("apps")]
        public List<App> AppCollection { get; set; }
    }
}