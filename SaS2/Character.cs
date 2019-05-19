using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2
{
    public class Character
    {
        public string Name { get; set; }
        public DNA DNA { get; set; }
        public Equipment Equipment { get; set; }
        public int Level { get; set; }

        public int PhysicalSize => 80 + (int)Math.Round(DNA.Strength / 1.5);
        public int HitpointsMax => Level * 10 + DNA.Vitality * 20;
        public int StaminaMax => 100 + DNA.Stamina * 10;
        public int ArmourMax => Equipment.ArmourItems.Sum(x => x.ArmourValue);
        public int MinDamage => Equipment.Weapon.MinDamage;
        public int MaxDamage => Equipment.Weapon.MaxDamage;
    }
}
