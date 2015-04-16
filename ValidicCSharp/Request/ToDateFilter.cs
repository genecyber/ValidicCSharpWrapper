using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Request
{
    public class ToDateFilter : ValueFilter
    {
        public ToDateFilter()
        {
            Type = FilterType.ToDate;
            Label = "end_date";
        }
    }
}