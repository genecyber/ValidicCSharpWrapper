using System.Collections.Generic;
using System.Linq;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Request
{
    public class SourceFilter : BaseFilter, ICommandFilter
    {
        public SourceFilter()
        {
            Type = FilterType.Source;
            Sources = new List<string>();
        }

        public List<string> Sources { get; set; }

        string ICommandFilter.ToString()
        {
            return Sources.Aggregate("&source=", (current, source) => current + (source + " ")).Trim();
        }

        public void Add(string source)
        {
            Sources.Add(source);
        }
    }
}