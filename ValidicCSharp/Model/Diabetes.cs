using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Diabetes : Measurement
    {
        public object c_peptide { get; set; }
        public object fasting_plasma_glucose_test { get; set; }
        public double? hba1c { get; set; }
        public double? insulin { get; set; }
        public object oral_glucose_tolerance_test { get; set; }
        public object random_plasma_glucose_test { get; set; }
        public object triglyceride { get; set; }
        public object blood_glucose { get; set; }
    }
}