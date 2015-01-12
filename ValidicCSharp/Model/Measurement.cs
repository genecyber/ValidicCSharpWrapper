using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Model
{
    public class Measurement : IValidic
    {
        public string _id { get; set; }
        public string timestamp { get; set; }
        public string utc_offset { get; set; }
        public string last_updated { get; set; }
        [DefaultValue("")]
        public string source { get; set; }

        [DefaultValue("")]
        public string source_name { get; set; }

        [DefaultValue("")]
        public object extras { get; set; }
        public string user_id { get; set; }

    }
}
