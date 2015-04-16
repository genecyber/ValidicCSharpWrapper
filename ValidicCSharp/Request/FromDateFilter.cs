using ValidicCSharp.Interfaces;

namespace ValidicCSharp.Request
{
    public class FromDateFilter : ValueFilter
    {
        public FromDateFilter()
        {
            Type = FilterType.FromDate;
            Label = "start_date";
        }
    }
}