using System;
using System.Globalization;

namespace ValidicCSharp.Utility
{
    public static class Utilities
    {
        public static int GenerateRandom()
        {
            var rndNum =
                new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8),
                    NumberStyles.HexNumber));
            int rnd = rndNum.Next(300, 3000);
            return rnd;
        }
        public static bool TryToConvertToDataTimeOffset(string sTimeStamp, string utcOffset, out DateTimeOffset newTimeStamp)
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
        public static bool TryToConvertToDataTimeOffset(DateTimeOffset timeStamp, string utcOffset, out DateTimeOffset newTimeStamp)
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
    }
}