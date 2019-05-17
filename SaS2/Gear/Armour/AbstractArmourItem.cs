using SaS2.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Gear.Armour
{
    public abstract class AbstractArmourItem : IArmourItem
    {
        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public int Price { get; set; }

        public int SpecialChance { get; set; }
        public int ArmourValue { get; set; }
    }
}
