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
    }
}