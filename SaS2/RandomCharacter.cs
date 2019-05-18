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
        public Character RandomiseGladiator(Random rnd,int heroLevel, List<IArmourItem> armours, List<IWeaponItem> weapons)
        {
            return new Character()
            {
                Name = GetRandomName(rnd),
                Level = GetRandomLevel(rnd, heroLevel),
                DNA = GetRandomDNA(rnd, heroLevel * 3 + 6),//hero level or character level?
                Equipment = GetRandomEquipment(rnd, heroLevel, armours, weapons),
            };
        }

        public DNA GetRandomDNA(Random rnd,int statPoints)
        {
            DNA dna = new DNA(1);
            //distribute stat points
            while(statPoints > 0)
            {
                var addToStat = rnd.Next(8);
                var pointsToTake = 1 + rnd.Next((int)Math.Round(statPoints / 3.0));

                dna[addToStat] += pointsToTake;
                statPoints -= pointsToTake;
            }


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
                    //make it not always wear all armour
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
        public string GetRandomName(Random rnd)
        {
            return "TestName";
        }
    }
}
