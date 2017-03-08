using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace ValidicCSharp.Utility
{
    public static class Utilities
    {
        public static int GenerateRandom()
        {
            var rndNum =
                new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8),
                    NumberStyles.HexNumber));
            var rnd = rndNum.Next(300, 3000);
            return rnd;
        }

        public static bool TryToConvertToDataTimeOffset(string sTimeStamp, string utcOffset,
            out DateTimeOffset newTimeStamp)
        {
            newTimeStamp = DateTimeOffset.MinValue;
            DateTimeOffset timeStamp;
            if (!DateTimeOffset.TryParse(sTimeStamp, out timeStamp))
                return false;

            var s = timeStamp.DateTime + utcOffset;
            DateTimeOffset utc;
            if (!DateTimeOffset.TryParse(s, out utc))
                return false;

            var t1 = timeStamp.Subtract(timeStamp.Offset);
            var t2 = new DateTimeOffset(t1.DateTime, utc.Offset);
            newTimeStamp = t2;
            return true;
        }

        public static bool TryToConvertToDataTimeOffset(DateTimeOffset timeStamp, string utcOffset,
            out DateTimeOffset newTimeStamp)
        {
            newTimeStamp = DateTimeOffset.MinValue;
            var s = timeStamp.DateTime + utcOffset;
            DateTimeOffset utc;
            if (!DateTimeOffset.TryParse(s, out utc))
                return false;

            var t1 = timeStamp.Subtract(timeStamp.Offset);
            var t2 = new DateTimeOffset(t1.DateTime, utc.Offset);
            newTimeStamp = t2;
            return true;
        }

        public static string ToString(object o, string delimeter = ", ", bool ignoreNull = true)
        {
            var myType = o.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            var sb = new StringBuilder();
            foreach (var prop in props)
            {
                var propValue = prop.GetValue(o, null);
                if (ignoreNull && propValue == null)
                    continue;


                sb.Append(prop.Name);
                sb.Append("=");
                sb.Append(propValue);
                sb.Append(delimeter);
            }
            return sb.ToString();
        }
    }
}