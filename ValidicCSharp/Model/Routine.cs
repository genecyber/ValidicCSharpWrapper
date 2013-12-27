using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Routine : IValidic
    {
        public string _id { get; set; }
        public string timestamp { get; set; }
        public string utc_offset { get; set; }
        public double? steps { get; set; }
        public double? calories_burned { get; set; }
        public double? distance { get; set; }
        public object floors { get; set; }
        public object elevation { get; set; }
        public string source { get; set; }
        public string source_name { get; set; }
        public string last_updated { get; set; }
    }
}
