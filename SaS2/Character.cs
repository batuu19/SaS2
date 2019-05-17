using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2
{
    public class Character
    {
        public DNA DNA { get; set; }
        public Equipment Equipment { get; set; }
        public int Level { get; set; }

        protected int breastplate_dval = 16;
        protected int helmet_dval = 10;
        protected int shinguard_dval = 6;
        protected int greaves_dval = 3;
        protected int shoulderguard_dval = 8;
        protected int gauntlet_dval = 5;
        protected int boot_dval = 2;
        protected int shield_dval = 12;

        public int PhysicalSize => 80 + (int)Math.Round(DNA.Strength / 1.5);
        public int Hitpoints => Level * 10 + DNA.Vitality * 20;
    }
}
