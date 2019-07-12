using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2
{
    public interface IContinuable
    {
        void Begin();
        bool NextMove();
        void Finish();
    }
}
