using System;

namespace ValidicCSharp.Interfaces
{
    public interface ICommandFilter
    {
        FilterType Type { get; set; }
        String ToString();
    }

    public enum FilterType
    {
        Source = 0,
        FromDate,
        ToDate
    }
}