using System;

namespace ValidicCSharp.Interfaces
{
    public interface ICommandFilter
    {
        String ToString();
        FilterType Type { get; set; }
    }

    public enum FilterType
    {
        Source = 0,
        FromDate,
        ToDate
    }
}