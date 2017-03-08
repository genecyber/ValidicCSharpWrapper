using Newtonsoft.Json;

namespace ValidicCSharp.Model
{
    public class Diabetes : Measurement
    {
        [JsonProperty("c_peptide")]
        public object CPeptide { get; set; }

        [JsonProperty("fasting_plasma_glucose_test")]
        public object FastingPlasmaGlucoseTest { get; set; }

        [JsonProperty("hba1c")]
        public double? Hba1C { get; set; }

        [JsonProperty("insulin")]
        public double? Insulin { get; set; }

        [JsonProperty("oral_glucose_tolerance_test")]
        public object OralGlucoseToleranceTest { get; set; }

        [JsonProperty("random_plasma_glucose_test")]
        public object RandomPlasmaGlucoseTest { get; set; }

        [JsonProperty("triglyceride")]
        public object Triglyceride { get; set; }

        [JsonProperty("blood_glucose")]
        public object BloodGlucose { get; set; }
    }
}