using SaS2.Gear.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Structure
{
    public interface IWeaponItem : IItem
    {
        WeaponType Type { get; set; }
        int MinDamage { get; set; }
        int MaxDamage { get; set; }
        int Range { get; set; }
    }
}
