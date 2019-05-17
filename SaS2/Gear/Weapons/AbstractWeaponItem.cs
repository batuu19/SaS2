using SaS2.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Gear.Weapons
{
    public class AbstractWeaponItem : IWeaponItem
    {
        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public int Price { get; set; }

        public WeaponType Type { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public int Range { get; set; }

        public AbstractWeaponItem(WeaponType type,string name,int weight,int minDmg,int maxDmg,int range)
        {
            Type = type;
            Name = name;
            //Weight
            MinDamage = minDmg;
            MaxDamage = maxDmg;
            Range = range; 
        }
    }
}
