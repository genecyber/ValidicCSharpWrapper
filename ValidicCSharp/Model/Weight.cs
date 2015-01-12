using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Weight : Measurement
    {
        public double? weight { get; set; }
        public double? height { get; set; }
        public double? free_mass { get; set; }
        public double? fat_percent { get; set; }
        public double? mass_weight { get; set; }
        public double? bmi { get; set; }
    }
}