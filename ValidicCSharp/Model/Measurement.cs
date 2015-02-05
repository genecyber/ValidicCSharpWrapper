using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Measurement : Me
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonProperty("utc_offset")]
        public string UtcOffset { get; set; }
        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
        [JsonProperty("source"), DefaultValue("")] 
        public string Source { get; set; }

        [JsonProperty("source_name"), DefaultValue("")]
        public string SourceName { get; set; }

        [JsonProperty("extras"), DefaultValue("")]
        public object Extras { get; set; }
        [JsonProperty("user_id"), DefaultValue("")]
        public string UserId { get; set; }
    }
}
