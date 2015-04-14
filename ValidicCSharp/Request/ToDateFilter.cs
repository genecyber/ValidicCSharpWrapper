using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Request
{
    public class ToDateFilter : ICommandFilter
    {
        public ToDateFilter()
        {
            Type = FilterType.ToDate;
        }

        public string Date { get; set; }
        public FilterType Type { get; set; }

        string ICommandFilter.ToString()
        {
            return "&end_date=" + Date;
        }

        public ToDateFilter AddDate(string date)
        {
            Date = date;
            return this;
        }
    }
}