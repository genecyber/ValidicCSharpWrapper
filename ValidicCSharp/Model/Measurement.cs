using System;
using System.ComponentModel;
using Newtonsoft.Json;
using ValidicCSharp.Utility;

namespace ValidicCSharp.Model
{
    public class Measurement : Me
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

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

        public DateTime Time
        {
            get
            {
                DateTimeOffset newTimeStamp;
                if (!Utilities.TryToConvertToDataTimeOffset(Timestamp, UtcOffset, out newTimeStamp))
                    return DateTimeOffset.MinValue.Date;

                return newTimeStamp.DateTime;
            }
        }
    }
}