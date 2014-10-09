using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Sleep : IValidic
    {
        public string _id { get; set; }
        public string timestamp { get; set; }
        public string utc_offset { get; set; }
        public double? awake { get; set; }
        public double? deep { get; set; }
        public double? light { get; set; }
        public object rem { get; set; }
        public double? times_woken { get; set; }
        public double? total_sleep { get; set; }
        public string source { get; set; }
        public string source_name { get; set; }
        public string last_updated { get; set; }
    }
}