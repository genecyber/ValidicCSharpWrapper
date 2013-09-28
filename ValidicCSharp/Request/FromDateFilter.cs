using System;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Request
{
    public class FromDateFilter : ICommandFilter
    {
        public FromDateFilter()
        {
            Type = FilterType.FromDate;
        }
        public FilterType Type { get; set; }
        public string Date { get; set; }

        string ICommandFilter.ToString()
        {
            return Date = "&start_date=" + Date;
        }

        public FromDateFilter AddDate(String date)
        {
            Date = date;
            return this;
        }
    }
}
