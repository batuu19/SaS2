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

        public int PhysicalSize => 80 + (int)Math.Round(DNA.Strength / 1.5);
        public int Hitpoints => Level * 10 + DNA.Vitality * 20;
    }
}
