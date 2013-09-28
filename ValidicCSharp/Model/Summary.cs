using System;
using System.Runtime.Serialization;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Summary : IValidic
    {
        [DataMember(Name = "status")]
        public StatusCode Status { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "results")]
        public int Results { get; set; }

        [DataMember(Name = "start_date")]
        public DateTime? StartDate { get; set; }

        [DataMember(Name = "end_date")]
        public DateTime? EndDate { get; set; }

        [DataMember(Name = "offset")]
        public int Offset { get; set; }

        [DataMember(Name = "limit")]
        public int? Limit { get; set; }

        [DataMember(Name = "previous")]
        public string Previous { get; set; }

        [DataMember(Name = "next")]
        public string Next { get; set; }

        [DataMember(Name = "@params")]
        public Parameters Parameters { get; set; }
    }
}
