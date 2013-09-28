using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidicCSharp.Utility
{
    public static class Utilities
    {
        public static int GenerateRandom()
        {
            Random rndNum =
                new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8),
                                     System.Globalization.NumberStyles.HexNumber));
            int rnd = rndNum.Next(300, 3000);
            return rnd;
        }
    }
}
