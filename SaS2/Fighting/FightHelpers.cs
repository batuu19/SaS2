using SaS2.Gear.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Fighting
{
    public static class FightHelpers
    {
        public static List<AttackType> GetAvailableAttacks(bool ranged,bool close,bool weapon)
        {
            List<AttackType> attackTypes = new List<AttackType>();
            if (weapon)
            {
                if(ranged && close)
                {
                    attackTypes.Add(AttackType.BASH);
                }
                if(ranged && !close)
                {
                    attackTypes.Add(AttackType.QUICK);
                    attackTypes.Add(AttackType.BOMBARD);
                }
                if(!ranged && close)
                {
                    attackTypes.Add(AttackType.QUICK);
                    attackTypes.Add(AttackType.NORMAL);
                    attackTypes.Add(AttackType.POWER);
                }
                if(!ranged && !close)
                {
                    attackTypes.Add(AttackType.CHARGE);
                }
            }
            else
            {
                attackTypes.Add(AttackType.TAUNT);
                attackTypes.Add(AttackType.MAGICKA);
            }
            return attackTypes;
        }
    }
}
