using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Nutrition : Measurement
    {
        public double calories { get; set; }
        public double? carbohydrates { get; set; }
        public double? fat { get; set; }
        public double? fiber { get; set; }
        public double? protein { get; set; }
        public double? sodium { get; set; }
        public object water { get; set; }
        public string meal { get; set; }
    }
}