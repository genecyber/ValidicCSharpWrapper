using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Parameters : IValidic
    {
        [DataMember(Name = "start_date")]
        public DateTime StartDate { get; set; }

        [DataMember(Name = "end_date")]
        [DefaultValue("")]
        public DateTime EndDate { get; set; }

        [DataMember(Name = "offset")]
        public int? Offset { get; set; }

        [DataMember(Name = "limit")]
        public int? Limit { get; set; }

        [DataMember(Name = "source")]
        public object Source { get; set; }
    }
}