using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ValidicCSharp.Interfaces;
using ValidicCSharp.Utility;

namespace ValidicCSharp.Model
{
    public class Biometrics : Measurement
    {
        [JsonProperty("blood_calcium")]
        public object BloodCalcium { get; set; }

        [JsonProperty("blood_chromium")]
        public object BloodChromium { get; set; }

        [JsonProperty("blood_folic_acid")]
        public object BloodFolicAcid { get; set; }

        [JsonProperty("blood_magnesium")]
        public object BloodMagnesium { get; set; }

        [JsonProperty("blood_potassium")]
        public object BloodPotassium { get; set; }

        [JsonProperty("blood_sodium")]
        public object BloodSodium { get; set; }

        [JsonProperty("blood_vitamin_b12")]
        public object BloodVitaminB12 { get; set; }

        [JsonProperty("blood_zinc")]
        public object BloodZinc { get; set; }

        [JsonProperty("creatine_kinase")]
        public object CreatineKinase { get; set; }

        [JsonProperty("crp")]
        public object Crp { get; set; }

        [JsonProperty("diastolic")]
        public double? Diastolic { get; set; }

        [JsonProperty("ferritin")]
        public object Ferritin { get; set; }

        [JsonProperty("hdl")]
        public object Hdl { get; set; }

        [JsonProperty("hscrp")]
        public object Hscrp { get; set; }

        [JsonProperty("il6")]
        public object Il6 { get; set; }

        [JsonProperty("ldl")]
        public object Ldl { get; set; }

        [JsonProperty("resting_heartrate")]
        public double? RestingHeartrate { get; set; }

        [JsonProperty("systolic")]
        public double? Systolic { get; set; }

        [JsonProperty("testosterone")]
        public object Testosterone { get; set; }

        [JsonProperty("total_cholesterol")]
        public object TotalCholesterol { get; set; }

        [JsonProperty("tsh")]
        public object Tsh { get; set; }

        [JsonProperty("uric_acid")]
        public object UricAcid { get; set; }

        [JsonProperty("vitamin_d")]
        public object VitaminD { get; set; }

        [JsonProperty("white_cell_count")]
        public object WhiteCellCount { get; set; }
    }
}




