using System;
using System.ComponentModel;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Tobacco_Cessation : IValidic
    {
        public string _id { get; set; }
        public DateTime timestamp { get; set; }
        public string utc_offset { get; set; }
        public double? cigarettes_allowed { get; set; }
        public double? cigarettes_smoked { get; set; }
        public double? cravings { get; set; }
        public string last_smoked { get; set; }
        [DefaultValue("")]
        public string source { get; set; }
        [DefaultValue("")]
        public string source_name { get; set; }
        public string last_updated { get; set; }
        [DefaultValue("")]
        public object extras { get; set; }
        public string user_id { get; set; }
    }
}
