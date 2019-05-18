using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Gear.Weapons
{
    public class SecondaryWeapon : AbstractWeaponItem
    {
        public SecondaryWeapon(WeaponType type, string name, int weight, int minDmg, int maxDmg, int range)
            : base(type, name, weight, minDmg, maxDmg, range)
        { }
        public SecondaryWeapon(int type, string name, int weight, int minDmg, int maxDmg, int range)
        : base((WeaponType)type, name, weight, minDmg, maxDmg, range)
        { }
    }
}
