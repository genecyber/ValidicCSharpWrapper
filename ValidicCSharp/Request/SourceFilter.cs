using System.Collections.Generic;
using System.Linq;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Request
{
    public class SourceFilter : ICommandFilter
    {
        public SourceFilter()
        {
            Type = FilterType.Source;
            Sources = new List<string>();
        }

        public List<string> Sources { get; set; }
        public FilterType Type { get; set; }

        string ICommandFilter.ToString()
        {
            return Sources.Aggregate("&source=", (current, source) => current + (source + " ")).Trim();
        }

        public SourceFilter AddSource(string source)
        {
            Sources.Add(source);
            return this;
        }
    }
}