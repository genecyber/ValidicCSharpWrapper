using System;
using System.Collections.Generic;
using System.Linq;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Command
{
    public class SourceFilter : ICommandFilter
    {
        public SourceFilter()
        {
            Type = FilterType.Source;
            Sources = new List<string>(); 
        }

        public FilterType Type { get; set; }
        public List<string> Sources { get; set; }

        string ICommandFilter.ToString()
        {
            return Sources.Aggregate("&source=", (current, source) => current + (source + " ")).Trim();
        }

        public SourceFilter AddSource(String source)
        {
            Sources.Add(source);
            return this;
        }
    }
}