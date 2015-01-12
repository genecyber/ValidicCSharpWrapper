using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Sleep : Measurement
    {
        public double? awake { get; set; }
        public double? deep { get; set; }
        public double? light { get; set; }
        public object rem { get; set; }
        public double? times_woken { get; set; }
        public double? total_sleep { get; set; }
    }
}