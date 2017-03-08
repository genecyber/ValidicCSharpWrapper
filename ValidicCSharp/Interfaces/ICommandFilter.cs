namespace ValidicCSharp.Interfaces
{
    public interface ICommandFilter
    {
        FilterType Type { get; set; }
        void Add(string value);
        string ToString();
    }

    public enum FilterType
    {
        Source = 0,
        FromDate,
        ToDate,
        AuthenticationToken,
        AccessToken
    }
}