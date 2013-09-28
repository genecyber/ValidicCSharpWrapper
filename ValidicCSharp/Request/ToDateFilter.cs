using System;
using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Request
{
    public class ToDateFilter : ICommandFilter
    {
        public ToDateFilter()
        {
            Type = FilterType.ToDate;
        }
        public FilterType Type { get; set; }
        public string Date { get; set; }

        string ICommandFilter.ToString()
        {
            return Date = "&end_date=" + Date;
        }

        public ToDateFilter AddDate(String date)
        {
            Date = date;
            return this;
        }
    }
}
