using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Routine : Measurement
    {
        public double? steps { get; set; }
        public double? calories_burned { get; set; }
        public double? distance { get; set; }
        public object floors { get; set; }
        public object elevation { get; set; }
    }
}