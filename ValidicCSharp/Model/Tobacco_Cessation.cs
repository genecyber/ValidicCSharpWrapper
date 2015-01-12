using System;
using System.ComponentModel;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Tobacco_Cessation : Measurement
    {
        public double? cigarettes_allowed { get; set; }
        public double? cigarettes_smoked { get; set; }
        public double? cravings { get; set; }
        public string last_smoked { get; set; }
    }
}