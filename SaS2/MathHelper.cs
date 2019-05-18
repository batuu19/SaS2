using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2
{
    public static class MathHelper
    {
        public static int ClampPercentage(int p)
        {
            if (p < 1) p = 1;
            if (p > 99) p = 99;
            return p;
        }
    }
}
