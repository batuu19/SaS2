using SaS2.Fighting;
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
    public class Game
    {
        //    List<string> armourweights = new List<string> { "", "Light", "Medium", "Heavy" };
        //    List<string> armourconditions = new List<string> { "", "Broken", "Badly Damaged", "Damaged", "Slightly Damaged ", "Perfect" };
        //    List<string> armourtypes = new List<string> { "", "boot", "shinguard", "greaves", "breastplate", "gauntlet", "shoulderguard", "helmet", "shield" };
        //    List<string> armoursets = new List<string> { "None", "None", "Peasant", "Cutpurse", "Brigand", "Militia", "Veteran", "Hoplite", "Swashbuckler", "Retarius", "Myrmidon", "Legion", "Warlord", "Centurion", "Knight", "Paladin", "Templar", "Cavalier", "Crusader", "Avenger", "Infernal", "Samurai", "Demon-plate", "Conquerer", "Automaton", "Champions", "Emperors" };
        //    List<int> armoursetweights = new List<int> { 1, 1, 1, 2, 3, 1, 2, 2, 3, 1, 1, 2, 2, 3, 1, 2, 3, 2, 3, 1, 3, 2, 2, 3, 1, 2, 3 };
        List<IWeaponItem> weaponsTable = new List<IWeaponItem>
        {
            //type,name,weight,mindmg,maxdmg,range
            new Weapon(2,"Rusty knife", 5, 1, 3, 1),
            new Weapon(1,"Dagger",5,3,9,1),
            new Weapon(1,"Shortsword",5,4,16,1),
            new Weapon(1,"Dirk",5,5,25,1),
            new Weapon(1,"Gladius",4,6,36,1),
            new Weapon(1,"Broadsword",3,7,49,2),
            new Weapon(1,"Claymore",3,8,64,2),
            new Weapon(1,"Bastard Sword",3,9,81,2),
            new Weapon(1,"Longsword",3,10,100,2),
            new Weapon(1,"Knight Sword",3,12,144,2),
            new Weapon(1,"Silver Longsword",3,14,196,2),
            new Weapon(1,"Heartblade",3,16,256,2),
            new Weapon(1,"Crystal Sword",3,18,324,2),
            new Weapon(1,"Rapier",4,19,361,2),
            new Weapon(1,"Cutlas",4,20,400,2),
            new Weapon(1,"Scimitar",1,21,441,2),
            new Weapon(1,"Raj Scimitar",1,22,484,2),
            new Weapon(1,"Katana",3,23,529,3),
            new Weapon(1,"Ancestor Katana",2,24,576,3),
            new Weapon(1,"Kensai Spirit",2,25,625,3),
            new Weapon(1,"Daikatana",1,26,676,3),
            new Weapon(3,"Cleaver",5,4,16,1),
            new Weapon(3,"Hand axe",4,5,20,1),
            new Weapon(3,"Bronze axe",4,6,24,1),
            new Weapon(3,"Hatchet",4,8,32,1),
            new Weapon(3,"Warrior axe",3,10,40,1),
            new Weapon(3,"Berserker axe",3,15,60,1),
            new Weapon(3,"Greensteel axe",3,18,72,2),
            new Weapon(3,"Madman\'s cleaver",1,20,80,2),
            new Weapon(3,"Greataxe",3,25,100,2),
            new Weapon(3,"Iron greataxe",2,30,120,2),
            new Weapon(3,"Steel battleaxe",3,35,140,2),
            new Weapon(3,"Blacksteel battleaxe",3,40,160,2),
            new Weapon(3,"Ogre battleaxe",3,45,180,2),
            new Weapon(3,"Hunter spear",3,50,200,3),
            new Weapon(3,"Ramhead sickle",1,60,240,3),
            new Weapon(3,"Halberd",2,70,280,3),
            new Weapon(3,"Awl Pike",2,80,320,3),
            new Weapon(3,"Poleaxe",2,90,360,3),
            new Weapon(3,"Pilum",1,100,400,3),
            new Weapon(3,"Reaper scythe",1,110,440,3),
            new Weapon(2,"Blackjack",4,4,12,1),
            new Weapon(2,"Hammer",4,5,15,1),
            new Weapon(2,"Knuckle Duster",5,8,24,1),
            new Weapon(2,"Wooden club",3,10,30,1),
            new Weapon(2,"Iron Mace",3,15,45,1),
            new Weapon(2,"Steel Mace",3,20,60,2),
            new Weapon(2,"Spiked Mace",2,25,75,2),
            new Weapon(2,"Warhammer",3,30,90,2),
            new Weapon(2,"Morning Star",3,35,105,2),
            new Weapon(2,"Studded Mace",3,40,120,2),
            new Weapon(2,"Maul",2,45,135,2),
            new Weapon(2,"Spiked Maul",2,50,150,2),
            new Weapon(2,"Sledgehammer",1,60,180,2),
            new Weapon(2,"Claw Hammer",3,70,210,2),
            new Weapon(2,"Heavy Mallet",1,80,250,2),
            new Weapon(2,"Imperial Warhammer",2,90,270,3),
            new Weapon(2,"Bonecrusher Cudgel",2,100,30,3),
            new Weapon(2,"Quake Staff",4,120,360,3),
            new Weapon(2,"Skull staff",3,140,420,3),
            new Weapon(2,"Dual Maul",1,160,480,3),
            new Weapon(4,"Children\'s Slingshot",5,4,16,100),
            new Weapon(4,"Iron Slingshot",5,5,25,100),
            new Weapon(4,"Oak Slingshot",5,6,36,100),
            new Weapon(4,"Shuriken",4,7,49,100),
            new Weapon(4,"Yew Bow",3,8,64,4),
            new Weapon(4,"Hunter\'s Bow",3,9,81,100),
            new Weapon(4,"Tracker\'s Bow",3,10,100,100),
            new Weapon(4,"Oak Longbow",3,11,121,100),
            new Weapon(4,"Steel Longbow",3,12,144,100),
            new Weapon(4,"Reinforced Longbow",3,13,169,100),
            new Weapon(4,"Crabclaw Bow",3,14,196,100),
            new Weapon(4,"Batwing Bow",3,15,225,100),
            new Weapon(4,"Kraken Bow",4,16,256,100),
            new Weapon(4,"Wyvern Bow",4,17,289,100),
            new Weapon(4,"Seer\'s Bow",1,18,324,4),
            new Weapon(4,"Ironforge Warbow",1,19,361,100),
            new Weapon(4,"Titanium Warbow",3,20,400,100),
            new Weapon(4,"Knight Crossbow",2,21,441,100),
            new Weapon(4,"Falcon Crossbow",2,22,484,100),
            new Weapon(4,"Doombolt Crossbow",1,23,529,100),
            new Weapon(1,"Shamrock",4,5,19,2),
            new Weapon(1,"The Scurvy Blade",3,10,30,2),
            new Weapon(2,"Axe of Persuasion",4,20,80,2),
            new Weapon(3,"Pillar of Spheracles",3,25,100,2),
            new Weapon(3,"Hammer of Ownage",3,25,100,3),
            new Weapon(1,"Contemplation",3,30,110,3),
            new Weapon(1,"The Crystal Falchion",3,40,150,3),
            new Weapon(1,"Wicks Staff",3,30,300,3),
            new Weapon(1,"Blade of the Empire",3,200,800,4),
        };
        List<IArmourItem> armoursTable = new List<IArmourItem>();
        Random rnd = new Random();
        RandomCharacter randomCharacter = new RandomCharacter();

        Hero hero;
        public void Init()
        {
            var setsNames = Enum.GetNames(typeof(ArmourSet));
            var typesNames = Enum.GetNames(typeof(ArmourType));
            var sets = Enum.GetValues(typeof(ArmourSet));
            var types = Enum.GetValues(typeof(ArmourType));

            int i = 0;
            foreach (var setName in setsNames)
            {
                foreach (var type in types)
                {
                    if ((ArmourType)type != ArmourType.UNDEFINED)
                    {
                        var armour = StaticHelper.GetArmour((ArmourType)type);

                        armour.Name = string.Format("{0} {1}", setName, Enum.GetName(typeof(ArmourType), type).ToLower());
                        //TODO: fix autogenerate armour levels
                        armour.RequiredLevel = i / 3 == 0 ? 1 : i / 3 * 6;//1,1,1,6,6,6,12,12,12...
                        armour.ArmourValue = StaticHelper.GetArmourValue((ArmourType)type) * (i + 2);
                        armoursTable.Add(armour);
                    }
                }
                i++;
            }

            hero = new Hero()
            {
                Name = "Hero",
                Cash = 999999,
                Equipment = randomCharacter.GetRandomEquipment(rnd, 40, armoursTable, weaponsTable),
                DNA = new DNA(20),
                Level = 40,
            };
            hero.Equipment.Weapon = (Weapon)weaponsTable[weaponsTable.Count - 1];
        }

        public void Test()
        {
            var other = randomCharacter.RandomiseGladiator(rnd, 40, armoursTable, weaponsTable);
            //other.Equipment.Weapon = (Weapon)weaponsTable[0];
            var villain = Character.CopyToWarrior(other);
            Arena arena = new Arena(this.hero, villain,FightMode.CHAMPIONSHIP, rnd);
            arena.Begin();
            while (arena.NextMove()) ;
            arena.Finish();
            Console.ReadLine();
        }
    }
}
