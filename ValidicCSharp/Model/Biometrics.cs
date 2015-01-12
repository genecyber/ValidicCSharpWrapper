using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Biometrics : Measurement
    {
        public object blood_calcium { get; set; }
        public object blood_chromium { get; set; }
        public object blood_folic_acid { get; set; }
        public object blood_magnesium { get; set; }
        public object blood_potassium { get; set; }
        public object blood_sodium { get; set; }
        public object blood_vitamin_b12 { get; set; }
        public object blood_zinc { get; set; }
        public object creatine_kinase { get; set; }
        public object crp { get; set; }
        public double? diastolic { get; set; }
        public object ferritin { get; set; }
        public object hdl { get; set; }
        public object hscrp { get; set; }
        public object il6 { get; set; }
        public object ldl { get; set; }
        public double? resting_heartrate { get; set; }
        public double? systolic { get; set; }
        public object testosterone { get; set; }
        public object total_cholesterol { get; set; }
        public object tsh { get; set; }
        public object uric_acid { get; set; }
        public object vitamin_d { get; set; }
        public object white_cell_count { get; set; }
    }
}