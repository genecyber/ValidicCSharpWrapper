using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Request
{
    public class FromDateFilter : ICommandFilter
    {
        public FromDateFilter()
        {
            Type = FilterType.FromDate;
        }

        public string Date { get; set; }
        public FilterType Type { get; set; }

        string ICommandFilter.ToString()
        {
            return "&start_date=" + Date;
        }

        public FromDateFilter AddDate(string date)
        {
            Date = date;
            return this;
        }
    }
}