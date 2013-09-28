using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
