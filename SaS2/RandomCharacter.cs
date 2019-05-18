using SaS2.Gear.Armour;
using SaS2.Gear.Weapons;
using SaS2.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2
{
    public class RandomCharacter
    {
        public Character RandomiseGladiator(Random rnd,int level)
        {
            Character character = new Character();
            character.Level = level;


            throw new NotImplementedException();
        }

        public DNA GetRandomDNA(Random rnd,int statPoints)
        {
            DNA dna = new DNA(1);

            return dna;
        }
        public int GetRandomLevel(Random rnd,int heroLevel)
        {
            var randomchance = rnd.Next(1, 99);
            if (randomchance < 86)
            {
                return heroLevel;
            }
            if (randomchance >= 86 && randomchance < 92)
            {
                return heroLevel - 1;
            }
            if (randomchance >= 92 && randomchance < 96)
            {
                return heroLevel + 1;
            }
            if (randomchance == 96)
            {
                return heroLevel - 2;
            }
            if (randomchance == 97)
            {
                return heroLevel + 2;
            }
            if (randomchance == 98)
            {
                return heroLevel - 3;
            }
            if (randomchance == 99)
            {
                return heroLevel + 3;
            }
            else return heroLevel;

            //????
            //if (whichcharacter.heroLevel < 1)
            //{
            //    whichcharacter.heroLevel = 1;
            //}
            
        }

        public Equipment GetRandomEquipment(Random rnd,int heroLevel,List<IArmourItem> armours,List<IWeaponItem> weapons)
        {
            Equipment equipment = new Equipment();
            int minLevel = heroLevel - 14;
            int maxLevel = heroLevel + 4;
            var types = Enum.GetValues(typeof(ArmourType));
            //random armours
            var armourChooseFrom = armours.Where(x => x.RequiredLevel >= minLevel && x.RequiredLevel <= maxLevel).ToList();
            foreach (var type in types)
            {   if ((ArmourType)type != ArmourType.UNDEFINED)
                {
                    var armour = StaticHelper.GetArmour((ArmourType)type);
                    var choosenByType = armourChooseFrom.Where(x => x.GetType() == armour.GetType()).ToList();
                    equipment.Add(RandomHelper.GetRandomItem(rnd,choosenByType));
                }
            }
            //random weapon
            equipment.Weapon = (Weapon)weapons[0];
            var weaponChoice = (WeaponType)rnd.Next(1, 3);
            //TODO
            //var randomRanged = rnd.Next(1, 80);
            List<IWeaponItem> weaponChooseFrom = weapons.Where(x => x.Type == weaponChoice).ToList();
            equipment.Weapon = (Weapon)RandomHelper.GetRandomItem(rnd, weaponChooseFrom);
            

            return equipment;
        }
    }
}
