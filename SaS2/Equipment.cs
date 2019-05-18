using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaS2.Gear.Armour;
using SaS2.Gear.Weapons;
using SaS2.Structure;

namespace SaS2
{
    public class Equipment
    {
        public Shoulderguard Shoulderguard { get; set; }
        public Gauntlet Gauntlet { get; set; }
        public Breastplate Breastplate { get; set; }
        public Helmet Helmet { get; set; }
        public Greaves Greaves { get; set; }
        public Shinguard Shinguard { get; set; }
        public Boot Boot { get; set; }
        public Weapon Weapon { get; set; }
        public SecondaryWeapon SecondaryWeapon { get; set; }
        public Shield Shield { get; set; }

        public List<IArmourItem> ArmourItems => new List<IArmourItem> { Shoulderguard, Gauntlet, Breastplate, Helmet, Greaves, Shinguard, Boot, Shield };

        public void Add(IArmourItem armourItem)
        {
            if (armourItem is Shoulderguard) Shoulderguard = (Shoulderguard)armourItem;
            if (armourItem is Gauntlet) Gauntlet = (Gauntlet)armourItem;
            if (armourItem is Breastplate) Breastplate = (Breastplate)armourItem;
            if (armourItem is Helmet) Helmet = (Helmet)armourItem;
            if (armourItem is Greaves) Greaves = (Greaves)armourItem;
            if (armourItem is Shinguard) Shinguard = (Shinguard)armourItem;
            if (armourItem is Boot) Boot = (Boot)armourItem;
            if (armourItem is Shield) Shield = (Shield)armourItem;
        }
    }
}
