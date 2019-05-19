using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Fighting
{
    public abstract class AbstractPlayer
    {
        public abstract FightAction GetFightAction(Warrior enemy);
    }
}
