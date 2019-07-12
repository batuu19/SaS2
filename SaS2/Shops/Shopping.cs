using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Shops
{
    public abstract class Shopping : IContinuable
    {
        public abstract void Begin();
        public abstract void Finish();
        public abstract bool NextMove();
    }
}
