using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2
{
    public static class RandomHelper
    {
        public static T GetRandomItem<T>(Random rnd,IEnumerable<T> container)
        {
            return container.ElementAt(rnd.Next(container.Count()));
        }
    }
}
