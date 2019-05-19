using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2
{
    public static class MathHelper
    {
        public static int ClampPercentage(int p) => Clamp(p, 1, 99);
        public static T Clamp<T>(T value,T min, T max) where T:IComparable<T>
        {
            //v1<v2 => -1 v1==v2 => 0 v1>v2 => 1
            if(value.CompareTo(min)<0)value = min;
            if(value.CompareTo(max)>0)value = max;
            return value;
        }
        public static double GetPercentage(int a, int b) => (double)a / b * 100.0;
        public static double AddPercentage(int a, int b) => Math.Ceiling(a * (b / 100.0));
    }
}
