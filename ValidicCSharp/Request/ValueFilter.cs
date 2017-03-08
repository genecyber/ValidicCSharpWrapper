using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Request
{
    public class ValueFilter : BaseFilter, ICommandFilter
    {
        public string Value { get; set; }
        public string Label { get; set; }


        string ICommandFilter.ToString()
        {
            return "&" + Label + "=" + Value;
        }

        public void Add(string value)
        {
            Value = value;
        }
    }
}
