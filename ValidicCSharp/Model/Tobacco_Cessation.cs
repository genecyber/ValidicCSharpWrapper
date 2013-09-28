using System;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Tobacco_Cessation : IValidic
    {
        public string _id { get; set; }
        public DateTime timestamp { get; set; }
        public string utc_offset { get; set; }
        public int cigarettes_allowed { get; set; }
        public int cigarettes_smoked { get; set; }
        public int cravings { get; set; }
        public string last_smoked { get; set; }
        public string source { get; set; }
    }
}
