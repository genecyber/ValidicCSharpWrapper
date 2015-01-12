using System.Collections.Generic;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Activity : Measurement
    {
        public string type { get; set; }
        public string intensity { get; set; }
        public string start_time { get; set; }
        public double? distance { get; set; }
        public double? duration { get; set; }
        public double? calories { get; set; }
    }

    public class Activities
    {
        public List<Activity> Activity { get; set; }
    }
}