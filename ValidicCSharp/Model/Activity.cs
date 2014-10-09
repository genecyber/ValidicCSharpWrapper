using System.Collections.Generic;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Activity : IValidic
    {
        public string _id { get; set; }
        public string timestamp { get; set; }
        public string utc_offset { get; set; }
        public string type { get; set; }
        public string intensity { get; set; }
        public string start_time { get; set; }
        public double? distance { get; set; }
        public double? duration { get; set; }
        public double? calories { get; set; }
        public string source { get; set; }
        public string source_name { get; set; }
        public string last_updated { get; set; }
    }

    public class Activities
    {
        public List<Activity> Activity { get; set; }
    }
}