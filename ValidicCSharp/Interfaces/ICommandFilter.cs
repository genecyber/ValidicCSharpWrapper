namespace ValidicCSharp.Interfaces
{
    public interface ICommandFilter
    {
        FilterType Type { get; set; }
        string ToString();
    }

    public enum FilterType
    {
        Source = 0,
        FromDate,
        ToDate
    }
}