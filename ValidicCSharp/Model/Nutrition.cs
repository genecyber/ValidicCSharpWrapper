using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Nutrition : IValidic
    {
        public string _id { get; set; }
        public string timestamp { get; set; }
        public string utc_offset { get; set; }
        public double calories { get; set; }
        public double? carbohydrates { get; set; }
        public double? fat { get; set; }
        public double? fiber { get; set; }
        public double? protein { get; set; }
        public double? sodium { get; set; }
        public object water { get; set; }
        public string meal { get; set; }
        public string source { get; set; }
        public string source_name { get; set; }
        public string last_updated { get; set; }
    }
}
