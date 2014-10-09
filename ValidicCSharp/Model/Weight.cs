using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Weight : IValidic
    {
        public string _id { get; set; }
        public string timestamp { get; set; }
        public string utc_offset { get; set; }
        public double weight { get; set; }
        public double? height { get; set; }
        public double? free_mass { get; set; }
        public double? fat_percent { get; set; }
        public double? mass_weight { get; set; }
        public double? bmi { get; set; }
        public string source { get; set; }
        public string source_name { get; set; }
        public string last_updated { get; set; }
    }
}