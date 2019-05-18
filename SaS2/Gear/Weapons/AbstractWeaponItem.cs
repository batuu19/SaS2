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
        public string Name { get; set; }//1
        public int RequiredLevel { get; set; }
        public int Price => (int)Math.Round((int)Type * 2 + MinDamage * 9 + MaxDamage * 45 * 3.1) / (Type == WeaponType.RANGED?2:1);//divide by 2 if ranged



        //itemcost = Math.round(_root["weapon" + itemnumber][0] * 2 + _root["weapon" + itemnumber][3] * 9 + _root["weapon" + itemnumber][4] * 45 * 3.1);

        public WeaponType Type { get; set; }//0
        public int MinDamage { get; set; }//3
        public int MaxDamage { get; set; }//4
        public int Range { get; set; }//5
        //weight 2

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
