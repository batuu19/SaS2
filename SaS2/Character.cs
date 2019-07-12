using SaS2.Fighting;
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

        //public Character Test(string initString)
        //{
        //    //_root.game.champion.charDNA = 
        //    //"John the Butcher,
        //    //1,13,1,40,3,1,1,1,102,2,4,1,24,0,0,6,3,1,3,3,2,5,1,5,0,125,1,0,2500,1,0,1,4,6,1,0,0,0,0,1,0,1,0,0,0,0,0,5,1";
        //    //1,13,1,40,3,1,1,1,102,2,4,1,24,0,0,DNA             LEVEL,5,0,125,1,0,2500,1,0,1,4,6,1,0,0,0,0,1,0,1,0,0,0,0,0,5,1";
        //    //       hair,facehair?
        //    //102 - helmet
        //    //24-weapon


        //}

        public static Warrior CopyToWarrior(Character c)
        {
            Warrior warrior = new Warrior()
            {
                Name = c.Name,
                DNA = c.DNA,
                Equipment = c.Equipment,
                Level = c.Level,
            };
            if (c is Hero) warrior.IsPlayer = true;
            warrior.Init();
            return warrior;
        }
    }
}
