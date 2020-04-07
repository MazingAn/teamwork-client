using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkClient.helper
{
    class SafeColors
    {
        private static string[] safeWebColors = {
            "#339933",
            "#339966",
            "#3399cc",
            "#33cc99",
            "#CC6633",
            "#CC6666",
            "#CC6699",
            "#CC66CC"
        };

        public static string GenSafeColorCode()
        {
            Random random = new Random();
            int idx = random.Next(0, safeWebColors.Length);
            return safeWebColors[idx];
        }

    }
}
