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

        public string Date { get; set; }
        public FilterType Type { get; set; }

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