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
            var dna = GetRandomDNA(rnd, heroLevel * 3 + 6);
            var name = GetRandomName(rnd, dna);
            var level = GetRandomLevel(rnd, heroLevel);
            var eq = GetRandomEquipment(rnd, heroLevel, armours, weapons);
            return new Character()
            {
                Name = name,
                DNA = dna,
                Level = level,
                Equipment = eq
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
        public string GetRandomName(Random rnd,DNA dna)
        {
            var randomprefix = 1 + rnd.Next(500);
            var randomnumber1 = 1 + rnd.Next(490);
            var randomnumber2 = 1 + rnd.Next(500);
            var randomprefix1 = "";
            var randomname1 = "";
            var randomname2 = "";
            if (randomprefix == 20)
            {
                randomprefix1 = "Senator ";
            }
            if (randomprefix == 21)
            {
                randomprefix1 = "Baron ";
            }
            if (randomprefix == 22)
            {
                randomprefix1 = "Earl ";
            }
            if (randomprefix == 23)
            {
                randomprefix1 = "Duke ";
            }
            if (randomprefix == 24)
            {
                randomprefix1 = "Prince ";
            }
            if (randomprefix == 25)
            {
                randomprefix1 = "Count ";
            }
            if (randomprefix == 26)
            {
                randomprefix1 = "Chief ";
            }
            if (randomprefix == 27)
            {
                randomprefix1 = "Sultan ";
            }
            if (randomprefix == 28)
            {
                randomprefix1 = "Lord ";
            }
            if (randomprefix == 29)
            {
                randomprefix1 = "Father ";
            }
            if (randomprefix == 30)
            {
                randomprefix1 = "Bishop ";
            }
            if (randomprefix == 31)
            {
                randomprefix1 = "Squire ";
            }
            if (randomprefix == 32)
            {
                randomprefix1 = "Good Sir ";
            }
            if (randomprefix == 33)
            {
                randomprefix1 = "Noble Sir ";
            }
            if (randomprefix == 34)
            {
                randomprefix1 = "Sir ";
            }
            if (randomprefix == 35)
            {
                randomprefix1 = "Pirate ";
            }
            if (randomprefix == 36)
            {
                randomprefix1 = "Knight ";
            }
            if (randomprefix == 37)
            {
                randomprefix1 = "Grim ";
            }
            if (randomprefix == 38)
            {
                randomprefix1 = "Young ";
            }
            if (randomprefix == 39)
            {
                randomprefix1 = "Old ";
            }
            if (randomprefix == 40)
            {
                randomprefix1 = "Captain ";
            }
            if (randomprefix == 41)
            {
                randomprefix1 = "Mc";
            }
            if (randomprefix == 42)
            {
                randomprefix1 = "Mac";
            }
            if (randomprefix == 43)
            {
                randomprefix1 = "O\'";
            }
            if (randomprefix == 44)
            {
                randomprefix1 = "Archbishop ";
            }
            if (randomprefix == 45)
            {
                randomprefix1 = "Von";
            }
            if (randomprefix == 46)
            {
                randomprefix1 = "Admiral ";
            }
            if (randomprefix == 48)
            {
                randomprefix1 = "Friar ";
            }
            if (randomprefix == 49)
            {
                randomprefix1 = "Sargeant ";
            }
            if (randomprefix == 50)
            {
                randomprefix1 = "Shaman ";
            }
            if (randomprefix == 51)
            {
                randomprefix1 = "Half-Arsed ";
            }
            if (randomprefix == 52)
            {
                randomprefix1 = "No-Good ";
            }
            if (randomprefix == 53)
            {
                randomprefix1 = "Scheming ";
            }
            if (randomprefix == 54)
            {
                randomprefix1 = "Fearsome ";
            }
            if (randomprefix == 55)
            {
                randomprefix1 = "Lazy ";
            }
            if (randomprefix == 56)
            {
                randomprefix1 = "Angry ";
            }
            if (randomprefix == 57)
            {
                randomprefix1 = "Gentle ";
            }
            if (randomprefix == 58)
            {
                randomprefix1 = "Devious ";
            }
            if (randomprefix == 59)
            {
                randomprefix1 = "Sinister ";
            }
            if (randomprefix == 60)
            {
                randomprefix1 = "Lord ";
            }
            if (randomprefix == 61)
            {
                randomprefix1 = "Warmaster ";
            }
            if (randomprefix == 62)
            {
                randomprefix1 = "Knight-Marshall ";
            }
            if (randomprefix == 63)
            {
                randomprefix1 = "Grand Duke ";
            }
            if (randomprefix == 64)
            {
                randomprefix1 = "Imperator ";
            }
            if (randomprefix == 65)
            {
                randomprefix1 = "Centurion ";
            }
            if (randomprefix == 66)
            {
                randomprefix1 = "Decturion ";
            }
            if (randomprefix == 67)
            {
                randomprefix1 = "Viscount ";
            }
            if (randomprefix == 68)
            {
                randomprefix1 = "Commodore ";
            }
            if (randomprefix == 69)
            {
                randomprefix1 = "Yeoman ";
            }
            if (randomprefix == 70)
            {
                randomprefix1 = "Swordmaster ";
            }
            if (randomprefix == 71)
            {
                randomprefix1 = "Man-At-Arms ";
            }
            if (randomprefix == 72)
            {
                randomprefix1 = "Battlemaster ";
            }
            if (randomprefix == 73)
            {
                randomprefix1 = "First Mate ";
            }
            if (randomprefix == 74)
            {
                randomprefix1 = "Deckhand ";
            }
            if (randomprefix == 75)
            {
                randomprefix1 = "Master ";
            }
            if (randomnumber1 == 1)
            {
                randomname1 = "Asgard";
            }
            if (randomnumber1 == 2)
            {
                randomname1 = "Argyle";
            }
            if (randomnumber1 == 3)
            {
                randomname1 = "Aldrix";
            }
            if (randomnumber1 == 4)
            {
                randomname1 = "Abacus";
            }
            if (randomnumber1 == 5)
            {
                randomname1 = "Agravain";
            }
            if (randomnumber1 == 6)
            {
                randomname1 = "Ajax";
            }
            if (randomnumber1 == 7)
            {
                randomname1 = "Agglax";
            }
            if (randomnumber1 == 8)
            {
                randomname1 = "Amon Ra";
            }
            if (randomnumber1 == 9)
            {
                randomname1 = "Achilles";
            }
            if (randomnumber1 == 10)
            {
                randomname1 = "Acondrius";
            }
            if (randomnumber1 == 11)
            {
                randomname1 = "Aromat";
            }
            if (randomnumber1 == 12)
            {
                randomname1 = "Actaeon";
            }
            if (randomnumber1 == 13)
            {
                randomname1 = "Alberich";
            }
            if (randomnumber1 == 14)
            {
                randomname1 = "Alemanus";
            }
            if (randomnumber1 == 15)
            {
                randomname1 = "Amphion";
            }
            if (randomnumber1 == 16)
            {
                randomname1 = "Antilloch";
            }
            if (randomnumber1 == 17)
            {
                randomname1 = "Apollo";
            }
            if (randomnumber1 == 18)
            {
                randomname1 = "Artax";
            }
            if (randomnumber1 == 19)
            {
                randomname1 = "Arion";
            }
            if (randomnumber1 == 20)
            {
                randomname1 = "Atlas";
            }
            if (randomnumber1 == 21)
            {
                randomname1 = "Augustus";
            }
            if (randomnumber1 == 22)
            {
                randomname1 = "Angus";
            }
            if (randomnumber1 == 23)
            {
                randomname1 = "Baal";
            }
            if (randomnumber1 == 24)
            {
                randomname1 = "Bacchus";
            }
            if (randomnumber1 == 25)
            {
                randomname1 = "Balduran";
            }
            if (randomnumber1 == 26)
            {
                randomname1 = "Bon";
            }
            if (randomnumber1 == 27)
            {
                randomname1 = "Boromir";
            }
            if (randomnumber1 == 28)
            {
                randomname1 = "Bedivere";
            }
            if (randomnumber1 == 29)
            {
                randomname1 = "Beltane";
            }
            if (randomnumber1 == 30)
            {
                randomname1 = "Belgrave";
            }
            if (randomnumber1 == 31)
            {
                randomname1 = "Beowulf";
            }
            if (randomnumber1 == 32)
            {
                randomname1 = "Bootus";
            }
            if (randomnumber1 == 33)
            {
                randomname1 = "Boros";
            }
            if (randomnumber1 == 34)
            {
                randomname1 = "Baldric";
            }
            if (randomnumber1 == 35)
            {
                randomname1 = "Bryan";
            }
            if (randomnumber1 == 36)
            {
                randomname1 = "Baralis";
            }
            if (randomnumber1 == 37)
            {
                randomname1 = "Bolton";
            }
            if (randomnumber1 == 38)
            {
                randomname1 = "Bors";
            }
            if (randomnumber1 == 39)
            {
                randomname1 = "Bohort";
            }
            if (randomnumber1 == 40)
            {
                randomname1 = "Borric";
            }
            if (randomnumber1 == 41)
            {
                randomname1 = "Cadmus";
            }
            if (randomnumber1 == 42)
            {
                randomname1 = "Cadaceus";
            }
            if (randomnumber1 == 43)
            {
                randomname1 = "Calledin";
            }
            if (randomnumber1 == 44)
            {
                randomname1 = "Colin";
            }
            if (randomnumber1 == 45)
            {
                randomname1 = "Caradoc";
            }
            if (randomnumber1 == 46)
            {
                randomname1 = "Caligula";
            }
            if (randomnumber1 == 47)
            {
                randomname1 = "Centronaut";
            }
            if (randomnumber1 == 48)
            {
                randomname1 = "Castor";
            }
            if (randomnumber1 == 49)
            {
                randomname1 = "Celen";
            }
            if (randomnumber1 == 50)
            {
                randomname1 = "Celeus";
            }
            if (randomnumber1 == 51)
            {
                randomname1 = "Centauri";
            }
            if (randomnumber1 == 52)
            {
                randomname1 = "Ceres";
            }
            if (randomnumber1 == 53)
            {
                randomname1 = "Charlemagne";
            }
            if (randomnumber1 == 54)
            {
                randomname1 = "Craig";
            }
            if (randomnumber1 == 55)
            {
                randomname1 = "Commodus";
            }
            if (randomnumber1 == 56)
            {
                randomname1 = "Cimmerion";
            }
            if (randomnumber1 == 57)
            {
                randomname1 = "Croshaux";
            }
            if (randomnumber1 == 58)
            {
                randomname1 = "Cloden";
            }
            if (randomnumber1 == 59)
            {
                randomname1 = "Cassius";
            }
            if (randomnumber1 == 60)
            {
                randomname1 = "Conan";
            }
            if (randomnumber1 == 61)
            {
                randomname1 = "Cervantes";
            }
            if (randomnumber1 == 62)
            {
                randomname1 = "Cronos";
            }
            if (randomnumber1 == 63)
            {
                randomname1 = "Cyrus";
            }
            if (randomnumber1 == 64)
            {
                randomname1 = "Claw";
            }
            if (randomnumber1 == 65)
            {
                randomname1 = "Daedalus";
            }
            if (randomnumber1 == 66)
            {
                randomname1 = "Darius";
            }
            if (randomnumber1 == 67)
            {
                randomname1 = "Damir";
            }
            if (randomnumber1 == 68)
            {
                randomname1 = "Dagath";
            }
            if (randomnumber1 == 69)
            {
                randomname1 = "Duncan";
            }
            if (randomnumber1 == 70)
            {
                randomname1 = "Doombeard";
            }
            if (randomnumber1 == 71)
            {
                randomname1 = "Dirk";
            }
            if (randomnumber1 == 72)
            {
                randomname1 = "Dragan";
            }
            if (randomnumber1 == 73)
            {
                randomname1 = "Dupre";
            }
            if (randomnumber1 == 74)
            {
                randomname1 = "DeeJ";
            }
            if (randomnumber1 == 75)
            {
                randomname1 = "Dambastin";
            }
            if (randomnumber1 == 76)
            {
                randomname1 = "Dougal";
            }
            if (randomnumber1 == 77)
            {
                randomname1 = "Douglas";
            }
            if (randomnumber1 == 78)
            {
                randomname1 = "Drex";
            }
            if (randomnumber1 == 79)
            {
                randomname1 = "Edric";
            }
            if (randomnumber1 == 80)
            {
                randomname1 = "Eric";
            }
            if (randomnumber1 == 81)
            {
                randomname1 = "Edlet";
            }
            if (randomnumber1 == 82)
            {
                randomname1 = "Ederyn";
            }
            if (randomnumber1 == 83)
            {
                randomname1 = "Ewles";
            }
            if (randomnumber1 == 84)
            {
                randomname1 = "Elgin";
            }
            if (randomnumber1 == 85)
            {
                randomname1 = "Ember";
            }
            if (randomnumber1 == 86)
            {
                randomname1 = "Etocles";
            }
            if (randomnumber1 == 87)
            {
                randomname1 = "Evander";
            }
            if (randomnumber1 == 88)
            {
                randomname1 = "Edvard";
            }
            if (randomnumber1 == 89)
            {
                randomname1 = "Edgar";
            }
            if (randomnumber1 == 90)
            {
                randomname1 = "Faustus";
            }
            if (randomnumber1 == 91)
            {
                randomname1 = "Feargal";
            }
            if (randomnumber1 == 92)
            {
                randomname1 = "Fergus";
            }
            if (randomnumber1 == 93)
            {
                randomname1 = "Falstaff";
            }
            if (randomnumber1 == 94)
            {
                randomname1 = "Foulbeard";
            }
            if (randomnumber1 == 95)
            {
                randomname1 = "Faunus";
            }
            if (randomnumber1 == 96)
            {
                randomname1 = "Fenris";
            }
            if (randomnumber1 == 97)
            {
                randomname1 = "Fuego";
            }
            if (randomnumber1 == 98)
            {
                randomname1 = "Frey";
            }
            if (randomnumber1 == 99)
            {
                randomname1 = "Fiston";
            }
            if (randomnumber1 == 100)
            {
                randomname1 = "Farcicles";
            }
            if (randomnumber1 == 101)
            {
                randomname1 = "Fargle";
            }
            if (randomnumber1 == 102)
            {
                randomname1 = "Fexham";
            }
            if (randomnumber1 == 103)
            {
                randomname1 = "Fundanis";
            }
            if (randomnumber1 == 104)
            {
                randomname1 = "Falcor";
            }
            if (randomnumber1 == 105)
            {
                randomname1 = "Garrick";
            }
            if (randomnumber1 == 106)
            {
                randomname1 = "Garret";
            }
            if (randomnumber1 == 107)
            {
                randomname1 = "Graham";
            }
            if (randomnumber1 == 108)
            {
                randomname1 = "Galahad";
            }
            if (randomnumber1 == 109)
            {
                randomname1 = "Galen";
            }
            if (randomnumber1 == 110)
            {
                randomname1 = "Guus";
            }
            if (randomnumber1 == 111)
            {
                randomname1 = "Gregory";
            }
            if (randomnumber1 == 112)
            {
                randomname1 = "Gareth";
            }
            if (randomnumber1 == 113)
            {
                randomname1 = "Gilbert";
            }
            if (randomnumber1 == 114)
            {
                randomname1 = "Gawain";
            }
            if (randomnumber1 == 115)
            {
                randomname1 = "Galron";
            }
            if (randomnumber1 == 116)
            {
                randomname1 = "Goon";
            }
            if (randomnumber1 == 117)
            {
                randomname1 = "Genghis";
            }
            if (randomnumber1 == 118)
            {
                randomname1 = "Geraint";
            }
            if (randomnumber1 == 119)
            {
                randomname1 = "Gildor";
            }
            if (randomnumber1 == 120)
            {
                randomname1 = "Glavius";
            }
            if (randomnumber1 == 121)
            {
                randomname1 = "Goran";
            }
            if (randomnumber1 == 122)
            {
                randomname1 = "Gorion";
            }
            if (randomnumber1 == 123)
            {
                randomname1 = "Guido";
            }
            if (randomnumber1 == 124)
            {
                randomname1 = "Geoffrey";
            }
            if (randomnumber1 == 125)
            {
                randomname1 = "Gus";
            }
            if (randomnumber1 == 126)
            {
                randomname1 = "Gunther";
            }
            if (randomnumber1 == 127)
            {
                randomname1 = "Gwydion";
            }
            if (randomnumber1 == 128)
            {
                randomname1 = "Horrordine";
            }
            if (randomnumber1 == 129)
            {
                randomname1 = "Hephaiston";
            }
            if (randomnumber1 == 130)
            {
                randomname1 = "Hubrix";
            }
            if (randomnumber1 == 131)
            {
                randomname1 = "Hades";
            }
            if (randomnumber1 == 132)
            {
                randomname1 = "Hagan";
            }
            if (randomnumber1 == 133)
            {
                randomname1 = "Hamish";
            }
            if (randomnumber1 == 134)
            {
                randomname1 = "Hagar";
            }
            if (randomnumber1 == 135)
            {
                randomname1 = "Hathor";
            }
            if (randomnumber1 == 136)
            {
                randomname1 = "Halfdan";
            }
            if (randomnumber1 == 137)
            {
                randomname1 = "Hebrus";
            }
            if (randomnumber1 == 138)
            {
                randomname1 = "Hercules";
            }
            if (randomnumber1 == 139)
            {
                randomname1 = "Hector";
            }
            if (randomnumber1 == 140)
            {
                randomname1 = "Heimdall";
            }
            if (randomnumber1 == 141)
            {
                randomname1 = "Hellman";
            }
            if (randomnumber1 == 142)
            {
                randomname1 = "Hephasteus";
            }
            if (randomnumber1 == 143)
            {
                randomname1 = "Horus";
            }
            if (randomnumber1 == 144)
            {
                randomname1 = "Hrothgar";
            }
            if (randomnumber1 == 145)
            {
                randomname1 = "Heracles";
            }
            if (randomnumber1 == 146)
            {
                randomname1 = "Huorn";
            }
            if (randomnumber1 == 147)
            {
                randomname1 = "Herodotus";
            }
            if (randomnumber1 == 148)
            {
                randomname1 = "Icarus";
            }
            if (randomnumber1 == 149)
            {
                randomname1 = "Igthorn";
            }
            if (randomnumber1 == 150)
            {
                randomname1 = "Iolo";
            }
            if (randomnumber1 == 151)
            {
                randomname1 = "Ironside";
            }
            if (randomnumber1 == 152)
            {
                randomname1 = "Ivan";
            }
            if (randomnumber1 == 153)
            {
                randomname1 = "Illium";
            }
            if (randomnumber1 == 154)
            {
                randomname1 = "Ivor";
            }
            if (randomnumber1 == 155)
            {
                randomname1 = "Ides";
            }
            if (randomnumber1 == 156)
            {
                randomname1 = "Imbelayo";
            }
            if (randomnumber1 == 157)
            {
                randomname1 = "Ithag";
            }
            if (randomnumber1 == 158)
            {
                randomname1 = "Japhet";
            }
            if (randomnumber1 == 159)
            {
                randomname1 = "Joseph";
            }
            if (randomnumber1 == 160)
            {
                randomname1 = "Jack";
            }
            if (randomnumber1 == 161)
            {
                randomname1 = "Jute";
            }
            if (randomnumber1 == 162)
            {
                randomname1 = "James";
            }
            if (randomnumber1 == 163)
            {
                randomname1 = "Jerrod";
            }
            if (randomnumber1 == 164)
            {
                randomname1 = "Jove";
            }
            if (randomnumber1 == 165)
            {
                randomname1 = "Jupiter";
            }
            if (randomnumber1 == 166)
            {
                randomname1 = "Jacob";
            }
            if (randomnumber1 == 167)
            {
                randomname1 = "Jeremiah";
            }
            if (randomnumber1 == 168)
            {
                randomname1 = "Julius";
            }
            if (randomnumber1 == 169)
            {
                randomname1 = "Jagger";
            }
            if (randomnumber1 == 170)
            {
                randomname1 = "Jacob";
            }
            if (randomnumber1 == 171)
            {
                randomname1 = "Johann";
            }
            if (randomnumber1 == 172)
            {
                randomname1 = "John";
            }
            if (randomnumber1 == 173)
            {
                randomname1 = "Jochum";
            }
            if (randomnumber1 == 174)
            {
                randomname1 = "Joost";
            }
            if (randomnumber1 == 175)
            {
                randomname1 = "Jaxxus";
            }
            if (randomnumber1 == 176)
            {
                randomname1 = "Kay";
            }
            if (randomnumber1 == 177)
            {
                randomname1 = "Kedalion";
            }
            if (randomnumber1 == 178)
            {
                randomname1 = "Kilwich";
            }
            if (randomnumber1 == 179)
            {
                randomname1 = "Kronos";
            }
            if (randomnumber1 == 180)
            {
                randomname1 = "Kaleb";
            }
            if (randomnumber1 == 181)
            {
                randomname1 = "Kaledwych";
            }
            if (randomnumber1 == 182)
            {
                randomname1 = "Kragen";
            }
            if (randomnumber1 == 183)
            {
                randomname1 = "Kraag";
            }
            if (randomnumber1 == 184)
            {
                randomname1 = "Kriemhild";
            }
            if (randomnumber1 == 185)
            {
                randomname1 = "Kraken";
            }
            if (randomnumber1 == 186)
            {
                randomname1 = "Kordax";
            }
            if (randomnumber1 == 187)
            {
                randomname1 = "Kurgan";
            }
            if (randomnumber1 == 188)
            {
                randomname1 = "Krull";
            }
            if (randomnumber1 == 189)
            {
                randomname1 = "Koth";
            }
            if (randomnumber1 == 190)
            {
                randomname1 = "Karadwyn";
            }
            if (randomnumber1 == 191)
            {
                randomname1 = "Lorenzo";
            }
            if (randomnumber1 == 192)
            {
                randomname1 = "Lambast";
            }
            if (randomnumber1 == 193)
            {
                randomname1 = "Lohalt";
            }
            if (randomnumber1 == 194)
            {
                randomname1 = "Lavariel";
            }
            if (randomnumber1 == 195)
            {
                randomname1 = "Lancelot";
            }
            if (randomnumber1 == 196)
            {
                randomname1 = "Leonard";
            }
            if (randomnumber1 == 197)
            {
                randomname1 = "Leonidas";
            }
            if (randomnumber1 == 198)
            {
                randomname1 = "Lionel";
            }
            if (randomnumber1 == 199)
            {
                randomname1 = "Leon";
            }
            if (randomnumber1 == 200)
            {
                randomname1 = "Lysander";
            }
            if (randomnumber1 == 201)
            {
                randomname1 = "Larkspur";
            }
            if (randomnumber1 == 202)
            {
                randomname1 = "Latan";
            }
            if (randomnumber1 == 203)
            {
                randomname1 = "Lear";
            }
            if (randomnumber1 == 204)
            {
                randomname1 = "Leif";
            }
            if (randomnumber1 == 205)
            {
                randomname1 = "Lichas";
            }
            if (randomnumber1 == 206)
            {
                randomname1 = "Lohegren";
            }
            if (randomnumber1 == 207)
            {
                randomname1 = "Loki";
            }
            if (randomnumber1 == 208)
            {
                randomname1 = "Louis";
            }
            if (randomnumber1 == 209)
            {
                randomname1 = "Lute";
            }
            if (randomnumber1 == 210)
            {
                randomname1 = "Ludwig";
            }
            if (randomnumber1 == 211)
            {
                randomname1 = "Leopold";
            }
            if (randomnumber1 == 212)
            {
                randomname1 = "Lycus";
            }
            if (randomnumber1 == 213)
            {
                randomname1 = "Lendolin";
            }
            if (randomnumber1 == 214)
            {
                randomname1 = "Lastravaine";
            }
            if (randomnumber1 == 215)
            {
                randomname1 = "Luke";
            }
            if (randomnumber1 == 216)
            {
                randomname1 = "Mabon";
            }
            if (randomnumber1 == 217)
            {
                randomname1 = "Maybor";
            }
            if (randomnumber1 == 218)
            {
                randomname1 = "Malagant";
            }
            if (randomnumber1 == 218)
            {
                randomname1 = "Matheus";
            }
            if (randomnumber1 == 219)
            {
                randomname1 = "Mayhew";
            }
            if (randomnumber1 == 220)
            {
                randomname1 = "Mador";
            }
            if (randomnumber1 == 221)
            {
                randomname1 = "Magius";
            }
            if (randomnumber1 == 222)
            {
                randomname1 = "Mandrake";
            }
            if (randomnumber1 == 223)
            {
                randomname1 = "Manfred";
            }
            if (randomnumber1 == 224)
            {
                randomname1 = "Maravaine";
            }
            if (randomnumber1 == 225)
            {
                randomname1 = "Mabon";
            }
            if (randomnumber1 == 226)
            {
                randomname1 = "Maximus";
            }
            if (randomnumber1 == 227)
            {
                randomname1 = "Mohammed";
            }
            if (randomnumber1 == 228)
            {
                randomname1 = "Mercertes";
            }
            if (randomnumber1 == 229)
            {
                randomname1 = "Merlin";
            }
            if (randomnumber1 == 230)
            {
                randomname1 = "Midas";
            }
            if (randomnumber1 == 231)
            {
                randomname1 = "Mordred";
            }
            if (randomnumber1 == 232)
            {
                randomname1 = "Mordraneth";
            }
            if (randomnumber1 == 233)
            {
                randomname1 = "Midgaard";
            }
            if (randomnumber1 == 234)
            {
                randomname1 = "Morton";
            }
            if (randomnumber1 == 235)
            {
                randomname1 = "Minos";
            }
            if (randomnumber1 == 236)
            {
                randomname1 = "Marius";
            }
            if (randomnumber1 == 237)
            {
                randomname1 = "Milamber";
            }
            if (randomnumber1 == 238)
            {
                randomname1 = "Moss";
            }
            if (randomnumber1 == 239)
            {
                randomname1 = "Nasir";
            }
            if (randomnumber1 == 240)
            {
                randomname1 = "Niles";
            }
            if (randomnumber1 == 241)
            {
                randomname1 = "Negus";
            }
            if (randomnumber1 == 242)
            {
                randomname1 = "Nain";
            }
            if (randomnumber1 == 243)
            {
                randomname1 = "Nogorth";
            }
            if (randomnumber1 == 244)
            {
                randomname1 = "Naus";
            }
            if (randomnumber1 == 245)
            {
                randomname1 = "Neptune";
            }
            if (randomnumber1 == 246)
            {
                randomname1 = "Nimrod";
            }
            if (randomnumber1 == 248)
            {
                randomname1 = "Norns";
            }
            if (randomnumber1 == 249)
            {
                randomname1 = "Numenor";
            }
            if (randomnumber1 == 250)
            {
                randomname1 = "Nage";
            }
            if (randomnumber1 == 251)
            {
                randomname1 = "Nyx";
            }
            if (randomnumber1 == 252)
            {
                randomname1 = "Odin";
            }
            if (randomnumber1 == 253)
            {
                randomname1 = "Owain";
            }
            if (randomnumber1 == 254)
            {
                randomname1 = "Owen";
            }
            if (randomnumber1 == 255)
            {
                randomname1 = "Otis";
            }
            if (randomnumber1 == 256)
            {
                randomname1 = "Oliver";
            }
            if (randomnumber1 == 257)
            {
                randomname1 = "Oscar";
            }
            if (randomnumber1 == 258)
            {
                randomname1 = "Odgar";
            }
            if (randomnumber1 == 259)
            {
                randomname1 = "Oderic";
            }
            if (randomnumber1 == 260)
            {
                randomname1 = "Odysseus";
            }
            if (randomnumber1 == 261)
            {
                randomname1 = "Ovid";
            }
            if (randomnumber1 == 262)
            {
                randomname1 = "Olaf";
            }
            if (randomnumber1 == 263)
            {
                randomname1 = "Ogier";
            }
            if (randomnumber1 == 264)
            {
                randomname1 = "Orlando";
            }
            if (randomnumber1 == 265)
            {
                randomname1 = "Octavius";
            }
            if (randomnumber1 == 266)
            {
                randomname1 = "Orpheus";
            }
            if (randomnumber1 == 267)
            {
                randomname1 = "Orion";
            }
            if (randomnumber1 == 268)
            {
                randomname1 = "Otto";
            }
            if (randomnumber1 == 269)
            {
                randomname1 = "Ogbert";
            }
            if (randomnumber1 == 270)
            {
                randomname1 = "Ogg";
            }
            if (randomnumber1 == 271)
            {
                randomname1 = "Ophion";
            }
            if (randomnumber1 == 272)
            {
                randomname1 = "Phranc";
            }
            if (randomnumber1 == 273)
            {
                randomname1 = "Palamedes";
            }
            if (randomnumber1 == 274)
            {
                randomname1 = "Phaeton";
            }
            if (randomnumber1 == 275)
            {
                randomname1 = "Pan";
            }
            if (randomnumber1 == 276)
            {
                randomname1 = "Paul";
            }
            if (randomnumber1 == 277)
            {
                randomname1 = "Peleus";
            }
            if (randomnumber1 == 278)
            {
                randomname1 = "Percival";
            }
            if (randomnumber1 == 279)
            {
                randomname1 = "Perdix";
            }
            if (randomnumber1 == 280)
            {
                randomname1 = "Pliny";
            }
            if (randomnumber1 == 281)
            {
                randomname1 = "Po";
            }
            if (randomnumber1 == 282)
            {
                randomname1 = "Phelot";
            }
            if (randomnumber1 == 283)
            {
                randomname1 = "Philip";
            }
            if (randomnumber1 == 284)
            {
                randomname1 = "Pheredin";
            }
            if (randomnumber1 == 285)
            {
                randomname1 = "Perseus";
            }
            if (randomnumber1 == 286)
            {
                randomname1 = "Pluto";
            }
            if (randomnumber1 == 287)
            {
                randomname1 = "Proton";
            }
            if (randomnumber1 == 288)
            {
                randomname1 = "Primus";
            }
            if (randomnumber1 == 289)
            {
                randomname1 = "Plato";
            }
            if (randomnumber1 == 290)
            {
                randomname1 = "Pollux";
            }
            if (randomnumber1 == 291)
            {
                randomname1 = "Priam";
            }
            if (randomnumber1 == 292)
            {
                randomname1 = "Poseidon";
            }
            if (randomnumber1 == 293)
            {
                randomname1 = "Proteus";
            }
            if (randomnumber1 == 294)
            {
                randomname1 = "Pug";
            }
            if (randomnumber1 == 295)
            {
                randomname1 = "Pondain";
            }
            if (randomnumber1 == 296)
            {
                randomname1 = "Pericles";
            }
            if (randomnumber1 == 297)
            {
                randomname1 = "Pyramus";
            }
            if (randomnumber1 == 298)
            {
                randomname1 = "Python";
            }
            if (randomnumber1 == 299)
            {
                randomname1 = "Pyrrhic";
            }
            if (randomnumber1 == 300)
            {
                randomname1 = "Pilkington";
            }
            if (randomnumber1 == 301)
            {
                randomname1 = "Polygon";
            }
            if (randomnumber1 == 302)
            {
                randomname1 = "Pavel";
            }
            if (randomnumber1 == 303)
            {
                randomname1 = "Prometheus";
            }
            if (randomnumber1 == 300)
            {
                randomname1 = "Rubicon";
            }
            if (randomnumber1 == 301)
            {
                randomname1 = "Rastan";
            }
            if (randomnumber1 == 302)
            {
                randomname1 = "Ragnarok";
            }
            if (randomnumber1 == 303)
            {
                randomname1 = "Radoslav";
            }
            if (randomnumber1 == 304)
            {
                randomname1 = "Rasputin";
            }
            if (randomnumber1 == 305)
            {
                randomname1 = "Remus";
            }
            if (randomnumber1 == 306)
            {
                randomname1 = "Rattus";
            }
            if (randomnumber1 == 307)
            {
                randomname1 = "Rhodin";
            }
            if (randomnumber1 == 308)
            {
                randomname1 = "Roland";
            }
            if (randomnumber1 == 309)
            {
                randomname1 = "Rinaldo";
            }
            if (randomnumber1 == 310)
            {
                randomname1 = "Robert";
            }
            if (randomnumber1 == 311)
            {
                randomname1 = "Robin";
            }
            if (randomnumber1 == 312)
            {
                randomname1 = "Rodomont";
            }
            if (randomnumber1 == 313)
            {
                randomname1 = "Rauros";
            }
            if (randomnumber1 == 314)
            {
                randomname1 = "Romulus";
            }
            if (randomnumber1 == 315)
            {
                randomname1 = "Rattax";
            }
            if (randomnumber1 == 316)
            {
                randomname1 = "Raith";
            }
            if (randomnumber1 == 317)
            {
                randomname1 = "Raul";
            }
            if (randomnumber1 == 318)
            {
                randomname1 = "Rodriguez";
            }
            if (randomnumber1 == 319)
            {
                randomname1 = "Roberto";
            }
            if (randomnumber1 == 320)
            {
                randomname1 = "Rivan";
            }
            if (randomnumber1 == 321)
            {
                randomname1 = "Rios";
            }
            if (randomnumber1 == 322)
            {
                randomname1 = "Rufus";
            }
            if (randomnumber1 == 323)
            {
                randomname1 = "Rat";
            }
            if (randomnumber1 == 324)
            {
                randomname1 = "Rattis";
            }
            if (randomnumber1 == 325)
            {
                randomname1 = "Rastus";
            }
            if (randomnumber1 == 326)
            {
                randomname1 = "Segallion";
            }
            if (randomnumber1 == 327)
            {
                randomname1 = "Saladin";
            }
            if (randomnumber1 == 328)
            {
                randomname1 = "Scythus";
            }
            if (randomnumber1 == 329)
            {
                randomname1 = "Sagan";
            }
            if (randomnumber1 == 330)
            {
                randomname1 = "Sertan";
            }
            if (randomnumber1 == 331)
            {
                randomname1 = "Samhin";
            }
            if (randomnumber1 == 332)
            {
                randomname1 = "Samson";
            }
            if (randomnumber1 == 333)
            {
                randomname1 = "Saracen";
            }
            if (randomnumber1 == 334)
            {
                randomname1 = "Saturn";
            }
            if (randomnumber1 == 335)
            {
                randomname1 = "Stephen";
            }
            if (randomnumber1 == 336)
            {
                randomname1 = "Simon";
            }
            if (randomnumber1 == 337)
            {
                randomname1 = "Simian";
            }
            if (randomnumber1 == 338)
            {
                randomname1 = "Sod";
            }
            if (randomnumber1 == 339)
            {
                randomname1 = "Sangreal";
            }
            if (randomnumber1 == 340)
            {
                randomname1 = "Spheracles";
            }
            if (randomnumber1 == 341)
            {
                randomname1 = "Seti";
            }
            if (randomnumber1 == 342)
            {
                randomname1 = "Siegfried";
            }
            if (randomnumber1 == 343)
            {
                randomname1 = "Severn";
            }
            if (randomnumber1 == 344)
            {
                randomname1 = "Sandor";
            }
            if (randomnumber1 == 345)
            {
                randomname1 = "Sevinius";
            }
            if (randomnumber1 == 346)
            {
                randomname1 = "Sigmund";
            }
            if (randomnumber1 == 347)
            {
                randomname1 = "Sextus";
            }
            if (randomnumber1 == 348)
            {
                randomname1 = "Sirius";
            }
            if (randomnumber1 == 349)
            {
                randomname1 = "Silas";
            }
            if (randomnumber1 == 350)
            {
                randomname1 = "Skuld";
            }
            if (randomnumber1 == 351)
            {
                randomname1 = "Sophocles";
            }
            if (randomnumber1 == 352)
            {
                randomname1 = "Skaven";
            }
            if (randomnumber1 == 353)
            {
                randomname1 = "Saradoc";
            }
            if (randomnumber1 == 354)
            {
                randomname1 = "Skaythe";
            }
            if (randomnumber1 == 355)
            {
                randomname1 = "Titan";
            }
            if (randomnumber1 == 356)
            {
                randomname1 = "Taliesin";
            }
            if (randomnumber1 == 357)
            {
                randomname1 = "Tantalus";
            }
            if (randomnumber1 == 358)
            {
                randomname1 = "Tyson";
            }
            if (randomnumber1 == 359)
            {
                randomname1 = "Theodred";
            }
            if (randomnumber1 == 360)
            {
                randomname1 = "Tomas";
            }
            if (randomnumber1 == 361)
            {
                randomname1 = "Thor";
            }
            if (randomnumber1 == 362)
            {
                randomname1 = "Tauron";
            }
            if (randomnumber1 == 363)
            {
                randomname1 = "Torg";
            }
            if (randomnumber1 == 364)
            {
                randomname1 = "Teucer";
            }
            if (randomnumber1 == 365)
            {
                randomname1 = "Theseus";
            }
            if (randomnumber1 == 366)
            {
                randomname1 = "Thucydides";
            }
            if (randomnumber1 == 367)
            {
                randomname1 = "Thargaan";
            }
            if (randomnumber1 == 368)
            {
                randomname1 = "Tyrian";
            }
            if (randomnumber1 == 369)
            {
                randomname1 = "Tyrus";
            }
            if (randomnumber1 == 370)
            {
                randomname1 = "Tigor";
            }
            if (randomnumber1 == 371)
            {
                randomname1 = "Troy";
            }
            if (randomnumber1 == 372)
            {
                randomname1 = "Thomas";
            }
            if (randomnumber1 == 373)
            {
                randomname1 = "Ulysses";
            }
            if (randomnumber1 == 374)
            {
                randomname1 = "Uthof";
            }
            if (randomnumber1 == 375)
            {
                randomname1 = "Usk";
            }
            if (randomnumber1 == 376)
            {
                randomname1 = "Utgaard";
            }
            if (randomnumber1 == 377)
            {
                randomname1 = "Uther";
            }
            if (randomnumber1 == 378)
            {
                randomname1 = "Urth";
            }
            if (randomnumber1 == 379)
            {
                randomname1 = "Ulvaine";
            }
            if (randomnumber1 == 380)
            {
                randomname1 = "Ucypher";
            }
            if (randomnumber1 == 381)
            {
                randomname1 = "Uwaine";
            }
            if (randomnumber1 == 382)
            {
                randomname1 = "Umber";
            }
            if (randomnumber1 == 383)
            {
                randomname1 = "Ultravaine";
            }
            if (randomnumber1 == 384)
            {
                randomname1 = "Valiant";
            }
            if (randomnumber1 == 385)
            {
                randomname1 = "Val";
            }
            if (randomnumber1 == 386)
            {
                randomname1 = "Vortex";
            }
            if (randomnumber1 == 387)
            {
                randomname1 = "Voltar";
            }
            if (randomnumber1 == 388)
            {
                randomname1 = "Valdarin";
            }
            if (randomnumber1 == 389)
            {
                randomname1 = "Vincento";
            }
            if (randomnumber1 == 390)
            {
                randomname1 = "Vaughn";
            }
            if (randomnumber1 == 391)
            {
                randomname1 = "Vraynes";
            }
            if (randomnumber1 == 392)
            {
                randomname1 = "Vlades";
            }
            if (randomnumber1 == 393)
            {
                randomname1 = "Vladimir";
            }
            if (randomnumber1 == 394)
            {
                randomname1 = "Vader";
            }
            if (randomnumber1 == 395)
            {
                randomname1 = "Vedas";
            }
            if (randomnumber1 == 396)
            {
                randomname1 = "Volk";
            }
            if (randomnumber1 == 397)
            {
                randomname1 = "Vulcan";
            }
            if (randomnumber1 == 398)
            {
                randomname1 = "Vortigern";
            }
            if (randomnumber1 == 399)
            {
                randomname1 = "Viridian";
            }
            if (randomnumber1 == 400)
            {
                randomname1 = "Wain";
            }
            if (randomnumber1 == 401)
            {
                randomname1 = "Woden";
            }
            if (randomnumber1 == 402)
            {
                randomname1 = "Wolfington";
            }
            if (randomnumber1 == 403)
            {
                randomname1 = "Wolfus";
            }
            if (randomnumber1 == 404)
            {
                randomname1 = "Worthington";
            }
            if (randomnumber1 == 405)
            {
                randomname1 = "Wilhelm";
            }
            if (randomnumber1 == 406)
            {
                randomname1 = "Will";
            }
            if (randomnumber1 == 407)
            {
                randomname1 = "Warwick";
            }
            if (randomnumber1 == 408)
            {
                randomname1 = "Warriv";
            }
            if (randomnumber1 == 409)
            {
                randomname1 = "Worluck";
            }
            if (randomnumber1 == 410)
            {
                randomname1 = "Woe";
            }
            if (randomnumber1 == 411)
            {
                randomname1 = "Wulfgar";
            }
            if (randomnumber1 == 412)
            {
                randomname1 = "Wolfred";
            }
            if (randomnumber1 == 414)
            {
                randomname1 = "Xanthus";
            }
            if (randomnumber1 == 415)
            {
                randomname1 = "Xanfar";
            }
            if (randomnumber1 == 416)
            {
                randomname1 = "Xavier";
            }
            if (randomnumber1 == 417)
            {
                randomname1 = "Xan";
            }
            if (randomnumber1 == 418)
            {
                randomname1 = "Xaal";
            }
            if (randomnumber1 == 419)
            {
                randomname1 = "Xonthar";
            }
            if (randomnumber1 == 420)
            {
                randomname1 = "Xander";
            }
            if (randomnumber1 == 421)
            {
                randomname1 = "Xerxces";
            }
            if (randomnumber1 == 422)
            {
                randomname1 = "Yves";
            }
            if (randomnumber1 == 423)
            {
                randomname1 = "Ymir";
            }
            if (randomnumber1 == 424)
            {
                randomname1 = "York";
            }
            if (randomnumber1 == 425)
            {
                randomname1 = "Yudas";
            }
            if (randomnumber1 == 426)
            {
                randomname1 = "Ylith";
            }
            if (randomnumber1 == 427)
            {
                randomname1 = "Yames";
            }
            if (randomnumber1 == 428)
            {
                randomname1 = "Yid";
            }
            if (randomnumber1 == 429)
            {
                randomname1 = "Yaviere";
            }
            if (randomnumber1 == 430)
            {
                randomname1 = "Yuvantes";
            }
            if (randomnumber1 == 431)
            {
                randomname1 = "Yondar";
            }
            if (randomnumber1 == 432)
            {
                randomname1 = "Yarris";
            }
            if (randomnumber1 == 433)
            {
                randomname1 = "Zoltan";
            }
            if (randomnumber1 == 434)
            {
                randomname1 = "Zuul";
            }
            if (randomnumber1 == 436)
            {
                randomname1 = "Zendar";
            }
            if (randomnumber1 == 437)
            {
                randomname1 = "Zachariah";
            }
            if (randomnumber1 == 438)
            {
                randomname1 = "Zac";
            }
            if (randomnumber1 == 439)
            {
                randomname1 = "Zax";
            }
            if (randomnumber1 == 440)
            {
                randomname1 = "Zounds";
            }
            if (randomnumber1 == 441)
            {
                randomname1 = "Zephyr";
            }
            if (randomnumber1 == 442)
            {
                randomname1 = "Zendavastus";
            }
            if (randomnumber1 == 443)
            {
                randomname1 = "Zeus";
            }
            if (randomnumber1 == 444)
            {
                randomname1 = "Zorro";
            }
            if (randomnumber1 == 445)
            {
                randomname1 = "Zander";
            }
            if (randomnumber1 == 446)
            {
                randomname1 = "Zeth";
            }
            if (randomnumber1 == 447)
            {
                randomname1 = "Queso";
            }
            if (randomnumber1 == 448)
            {
                randomname1 = "Quintus";
            }
            if (randomnumber1 == 449)
            {
                randomname1 = "Quo Vadis";
            }
            if (randomnumber1 == 450)
            {
                randomname1 = "Quivalen";
            }
            if (randomnumber1 == 451)
            {
                randomname1 = "Quodric";
            }
            if (randomnumber1 == 452)
            {
                randomname1 = "Questron";
            }
            if (randomnumber1 == 453)
            {
                randomname1 = "Quiche";
            }
            if (randomnumber1 == 454)
            {
                randomname1 = "Quajar";
            }
            if (randomnumber1 == 455)
            {
                randomname1 = "Bonsai";
            }
            if (randomnumber1 == 456)
            {
                randomname1 = "Banzai";
            }
            if (randomnumber1 == 457)
            {
                randomname1 = "Tinheart";
            }
            if (randomnumber1 == 458)
            {
                randomname1 = "Catapult";
            }
            if (randomnumber1 == 459)
            {
                randomname1 = "Dog";
            }
            if (randomnumber1 == 460)
            {
                randomname1 = "deGroos";
            }
            if (randomnumber1 == 461)
            {
                randomname1 = "Inigo";
            }
            if (randomnumber1 == 462)
            {
                randomname1 = "Fezzick";
            }
            if (randomnumber1 == 463)
            {
                randomname1 = "Vizzini";
            }
            if (randomnumber1 == 464)
            {
                randomname1 = "Morte";
            }
            if (randomnumber1 == 465)
            {
                randomname1 = "Stag";
            }
            if (randomnumber1 == 466)
            {
                randomname1 = "Bear";
            }
            if (randomnumber1 == 467)
            {
                randomname1 = "Irongaze";
            }
            if (randomnumber1 == 468)
            {
                randomname1 = "Frostmourne";
            }
            if (randomnumber1 == 469)
            {
                randomname1 = "Shadowmoor";
            }
            if (randomnumber1 == 470)
            {
                randomname1 = "Rottcast";
            }
            if (randomnumber1 == 471)
            {
                randomname1 = "Darktomb";
            }
            if (randomnumber1 == 472)
            {
                randomname1 = "Windchill";
            }
            if (randomnumber1 == 473)
            {
                randomname1 = "Vaguilis";
            }
            if (randomnumber1 == 474)
            {
                randomname1 = "Cowardheart";
            }
            if (randomnumber1 == 475)
            {
                randomname1 = "Steelknee";
            }
            if (randomnumber1 == 476)
            {
                randomname1 = "Fearbones";
            }
            if (randomnumber1 == 477)
            {
                randomname1 = "Borat";
            }
            if (randomnumber1 == 478)
            {
                randomname1 = "Judas";
            }
            if (randomnumber1 == 479)
            {
                randomname1 = "Brimstone";
            }
            if (randomnumber1 == 480)
            {
                randomname1 = "Lock";
            }
            if (randomnumber1 == 481)
            {
                randomname1 = "Tautis";
            }
            if (randomnumber1 == 482)
            {
                randomname1 = "Boniface";
            }
            if (randomnumber1 == 483)
            {
                randomname1 = "Sextus";
            }
            if (randomnumber1 == 484)
            {
                randomname1 = "Silius";
            }
            if (randomnumber1 == 485)
            {
                randomname1 = "Silas";
            }
            if (randomnumber1 == 486)
            {
                randomname1 = "Sawyer";
            }
            if (randomnumber1 == 487)
            {
                randomname1 = "Stirling";
            }
            if (randomnumber1 == 488)
            {
                randomname1 = "Scruff";
            }
            if (randomnumber1 == 489)
            {
                randomname1 = "Biff";
            }
            if (randomnumber1 == 490)
            {
                randomname1 = "Tacitus";
            }
            if (randomnumber2 == 1)
            {
                randomname2 = " raj Thandir";
            }
            if (randomnumber2 == 2)
            {
                randomname2 = " Apocolypto";
            }
            if (randomnumber2 == 3)
            {
                randomname2 = " Gregorian";
            }
            if (randomnumber2 == 4)
            {
                randomname2 = " the Slug";
            }
            if (randomnumber2 == 5)
            {
                randomname2 = " das Swine";
            }
            if (randomnumber2 == 6)
            {
                randomname2 = " Wolfnswine";
            }
            if (randomnumber2 == 7)
            {
                randomname2 = " duPopebox";
            }
            if (randomnumber2 == 8)
            {
                randomname2 = " Oates";
            }
            if (randomnumber2 == 9)
            {
                randomname2 = " Sturt";
            }
            if (randomnumber2 == 10)
            {
                randomname2 = " van Daemon";
            }
            if (randomnumber2 == 11)
            {
                randomname2 = " the Soulreaver";
            }
            if (randomnumber2 == 12)
            {
                randomname2 = " the Deserter";
            }
            if (randomnumber2 == 13)
            {
                randomname2 = " the Condemned";
            }
            if (randomnumber2 == 14)
            {
                randomname2 = " the Lost";
            }
            if (randomnumber2 == 15)
            {
                randomname2 = " the Reclaimed";
            }
            if (randomnumber2 == 16)
            {
                randomname2 = " Sauerkraut";
            }
            if (randomnumber2 == 17)
            {
                randomname2 = " McBane";
            }
            if (randomnumber2 == 18)
            {
                randomname2 = " Castelwine";
            }
            if (randomnumber2 == 19)
            {
                randomname2 = " Montserrat";
            }
            if (randomnumber2 == 20)
            {
                randomname2 = " Mercury";
            }
            if (randomnumber2 == 21)
            {
                randomname2 = " Kronos";
            }
            if (randomnumber2 == 22)
            {
                randomname2 = " of Shackleford";
            }
            if (randomnumber2 == 23)
            {
                randomname2 = " Yoshi";
            }
            if (randomnumber2 == 24)
            {
                randomname2 = " Hihatchi";
            }
            if (randomnumber2 == 25)
            {
                randomname2 = " Miyamoto";
            }
            if (randomnumber2 == 26)
            {
                randomname2 = " Wang Chung";
            }
            if (randomnumber2 == 27)
            {
                randomname2 = " Sakura";
            }
            if (randomnumber2 == 28)
            {
                randomname2 = " Nakata";
            }
            if (randomnumber2 == 29)
            {
                randomname2 = " Kurosawa";
            }
            if (randomnumber2 == 30)
            {
                randomname2 = " Shigeru";
            }
            if (randomnumber2 == 31)
            {
                randomname2 = " Ashen Shugar";
            }
            if (randomnumber2 == 32)
            {
                randomname2 = " Daltigoth";
            }
            if (randomnumber2 == 33)
            {
                randomname2 = " Greensleeves";
            }
            if (randomnumber2 == 34)
            {
                randomname2 = " Mog";
            }
            if (randomnumber2 == 35)
            {
                randomname2 = " Pug";
            }
            if (randomnumber2 == 36)
            {
                randomname2 = " Offal";
            }
            if (randomnumber2 == 37)
            {
                randomname2 = " the Pieman";
            }
            if (randomnumber2 == 38)
            {
                randomname2 = " the Butcher";
            }
            if (randomnumber2 == 39)
            {
                randomname2 = " the Baker";
            }
            if (randomnumber2 == 40)
            {
                randomname2 = " the Candlestick Maker";
            }
            if (randomnumber2 == 41)
            {
                randomname2 = " Seabones";
            }
            if (randomnumber2 == 42)
            {
                randomname2 = " the Inebriated";
            }
            if (randomnumber2 == 43)
            {
                randomname2 = " the Emotional";
            }
            if (randomnumber2 == 44)
            {
                randomname2 = " the Vile";
            }
            if (randomnumber2 == 45)
            {
                randomname2 = " the Legionnaire";
            }
            if (randomnumber2 == 46)
            {
                randomname2 = " the Knife";
            }
            if (randomnumber2 == 47)
            {
                randomname2 = " the Blade";
            }
            if (randomnumber2 == 48)
            {
                randomname2 = " the Shield";
            }
            if (randomnumber2 == 49)
            {
                randomname2 = " the Blackheart";
            }
            if (randomnumber2 == 50)
            {
                randomname2 = " the Brave";
            }
            if (randomnumber2 == 51)
            {
                randomname2 = " the Bold";
            }
            if (randomnumber2 == 52)
            {
                if (dna.Charisma > 15)
                {
                    randomname2 = " the Charismatic";
                }
                else if (dna.Speed < 5)
                {
                    randomname2 = " the Unpopular";
                }
                else
                {
                    randomname2 = " the Destroyer";
                }
            }
            if (randomnumber2 == 53)
            {
                randomname2 = " the Blackadder";
            }
            if (randomnumber2 == 54)
            {
                randomname2 = " the Foul";
            }
            if (randomnumber2 == 55)
            {
                randomname2 = " the Dark";
            }
            if (randomnumber2 == 56)
            {
                randomname2 = " the Red";
            }
            if (randomnumber2 == 57)
            {
                randomname2 = " the Black";
            }
            if (randomnumber2 == 58)
            {
                randomname2 = " the Blue";
            }
            if (randomnumber2 == 59)
            {
                randomname2 = " the Fiend";
            }
            if (randomnumber2 == 60)
            {
                randomname2 = " the Gruff";
            }
            if (randomnumber2 == 61)
            {
                randomname2 = " the Surly";
            }
            if (randomnumber2 == 62)
            {
                randomname2 = " the Sour";
            }
            if (randomnumber2 == 63)
            {
                randomname2 = " the Happy";
            }
            if (randomnumber2 == 64)
            {
                randomname2 = " the Arrogant";
            }
            if (randomnumber2 == 65)
            {
                randomname2 = " the Vain";
            }
            if (randomnumber2 == 66)
            {
                randomname2 = " the Unruly";
            }
            if (randomnumber2 == 67)
            {
                randomname2 = " the Young";
            }
            if (randomnumber2 == 68)
            {
                randomname2 = " the Elder";
            }
            if (randomnumber2 == 69)
            {
                randomname2 = " the Noble";
            }
            if (randomnumber2 == 70)
            {
                randomname2 = " the First";
            }
            if (randomnumber2 == 71)
            {
                randomname2 = " the Last";
            }
            if (randomnumber2 == 72)
            {
                if (dna.Vitality > 15)
                {
                    randomname2 = " the Robust";
                }
                else if (dna.Vitality < 5)
                {
                    randomname2 = " the Sickly";
                }
                else
                {
                    randomname2 = " the Naysayer";
                }
            }
            if (randomnumber2 == 73)
            {
                randomname2 = " the Drunkard";
            }
            if (randomnumber2 == 74)
            {
                if (dna.Speed > 15)
                {
                    randomname2 = " the Athlete";
                }
                else if (dna.Speed < 5)
                {
                    randomname2 = " the Sluggish";
                }
                else
                {
                    randomname2 = " the Trojan";
                }
            }
            if (randomnumber2 == 75)
            {
                randomname2 = " the Boorish";
            }
            if (randomnumber2 == 76)
            {
                randomname2 = " the Ponderous";
            }
            if (randomnumber2 == 77)
            {
                if (dna.Strength > 20)
                {
                    randomname2 = " the Giant";
                }
                else if (dna.Strength < 10)
                {
                    randomname2 = " the Dwarf";
                }
                else
                {
                    randomname2 = " the Bard";
                }
            }
            if (randomnumber2 == 78)
            {
                randomname2 = " the Nasty";
            }
            if (randomnumber2 == 79)
            {
                randomname2 = " the Slayer";
            }
            if (randomnumber2 == 80)
            {
                randomname2 = " the Traitor";
            }
            if (randomnumber2 == 81)
            {
                randomname2 = " the Deadly";
            }
            if (randomnumber2 == 82)
            {
                randomname2 = " the Goat";
            }
            if (randomnumber2 == 83)
            {
                randomname2 = " the Hawk";
            }
            if (randomnumber2 == 84)
            {
                randomname2 = " the Lion";
            }
            if (randomnumber2 == 85)
            {
                randomname2 = " the Pig";
            }
            if (randomnumber2 == 86)
            {
                randomname2 = " the Boar";
            }
            if (randomnumber2 == 87)
            {
                randomname2 = " the Monkey";
            }
            if (randomnumber2 == 88)
            {
                randomname2 = " the Bear";
            }
            if (randomnumber2 == 89)
            {
                randomname2 = " the Elk";
            }
            if (randomnumber2 == 90)
            {
                randomname2 = " the Dog";
            }
            if (randomnumber2 == 91)
            {
                randomname2 = " the Wolf";
            }
            if (randomnumber2 == 92)
            {
                randomname2 = " the Falcon";
            }
            if (randomnumber2 == 93)
            {
                randomname2 = " the Whale";
            }
            if (randomnumber2 == 94)
            {
                randomname2 = " the Tiger";
            }
            if (randomnumber2 == 95)
            {
                randomname2 = " the Dragon";
            }
            if (randomnumber2 == 96)
            {
                randomname2 = " the Worm";
            }
            if (randomnumber2 == 97)
            {
                randomname2 = " the Macaque";
            }
            if (randomnumber2 == 98)
            {
                randomname2 = " the Vague";
            }
            if (randomnumber2 == 99)
            {
                randomname2 = " the Master";
            }
            if (randomnumber2 == 101)
            {
                randomname2 = " the Shark";
            }
            if (randomnumber2 == 102)
            {
                randomname2 = " the Serious";
            }
            if (randomnumber2 == 103)
            {
                randomname2 = " the Bastard";
            }
            if (randomnumber2 == 104)
            {
                randomname2 = " the Fool";
            }
            if (randomnumber2 == 105)
            {
                randomname2 = " the Confessor";
            }
            if (randomnumber2 == 106)
            {
                randomname2 = " the Pretender";
            }
            if (randomnumber2 == 107)
            {
                randomname2 = " the Lionheart";
            }
            if (randomnumber2 == 108)
            {
                randomname2 = " the Craven";
            }
            if (randomnumber2 == 109)
            {
                randomname2 = " the Buffoon";
            }
            if (randomnumber2 == 110)
            {
                randomname2 = " the Rat";
            }
            if (randomnumber2 == 111)
            {
                randomname2 = " the Proud";
            }
            if (randomnumber2 == 112)
            {
                randomname2 = " the Fat";
            }
            if (randomnumber2 == 113)
            {
                randomname2 = " the Stenchly";
            }
            if (randomnumber2 == 114)
            {
                randomname2 = " the Unwashed";
            }
            if (randomnumber2 == 115)
            {
                randomname2 = " the Titan";
            }
            if (randomnumber2 == 116)
            {
                randomname2 = " the Rich";
            }
            if (randomnumber2 == 117)
            {
                randomname2 = " the Poor";
            }
            if (randomnumber2 == 118)
            {
                randomname2 = " the Rude";
            }
            if (randomnumber2 == 119)
            {
                randomname2 = " the Kind";
            }
            if (randomnumber2 == 120)
            {
                randomname2 = " the Ugly";
            }
            if (randomnumber2 == 121)
            {
                randomname2 = " the Handsome";
            }
            if (randomnumber2 == 122)
            {
                randomname2 = " the Insane";
            }
            if (randomnumber2 == 123)
            {
                randomname2 = " the Lesser";
            }
            if (randomnumber2 == 124)
            {
                randomname2 = " the Worthy";
            }
            if (randomnumber2 == 125)
            {
                randomname2 = " the Unworthy";
            }
            if (randomnumber2 == 126)
            {
                randomname2 = " the Fox";
            }
            if (randomnumber2 == 127)
            {
                randomname2 = " the Reclusive";
            }
            if (randomnumber2 == 128)
            {
                randomname2 = " the Great";
            }
            if (randomnumber2 == 129)
            {
                randomname2 = " the Nervous";
            }
            if (randomnumber2 == 130)
            {
                randomname2 = " the Mighty";
            }
            if (randomnumber2 == 131)
            {
                randomname2 = " the Noobhammer";
            }
            if (randomnumber2 == 132)
            {
                randomname2 = " the Mean";
            }
            if (randomnumber2 == 133)
            {
                randomname2 = " the Clumsy";
            }
            if (randomnumber2 == 134)
            {
                randomname2 = " the Widowmaker";
            }
            if (randomnumber2 == 135)
            {
                randomname2 = " the Hillarious";
            }
            if (randomnumber2 == 136)
            {
                randomname2 = " the Outrageous";
            }
            if (randomnumber2 == 137)
            {
                randomname2 = " the Unready";
            }
            if (randomnumber2 == 138)
            {
                randomname2 = " the Gentle";
            }
            if (randomnumber2 == 139)
            {
                randomname2 = " the Violent";
            }
            if (randomnumber2 == 140)
            {
                randomname2 = " the Camp";
            }
            if (randomnumber2 == 141)
            {
                randomname2 = " the Reckless";
            }
            if (randomnumber2 == 142)
            {
                randomname2 = " the Stinky";
            }
            if (randomnumber2 == 143)
            {
                randomname2 = " the Noob";
            }
            if (randomnumber2 == 144)
            {
                randomname2 = " the Chivalrous";
            }
            if (randomnumber2 == 145)
            {
                randomname2 = " the Rogue";
            }
            if (randomnumber2 == 146)
            {
                randomname2 = " the Fiery";
            }
            if (randomnumber2 == 147)
            {
                randomname2 = " the Insolent";
            }
            if (randomnumber2 == 148)
            {
                randomname2 = " the Scruffy";
            }
            if (randomnumber2 == 149)
            {
                randomname2 = " the Vague";
            }
            if (randomnumber2 == 150)
            {
                randomname2 = " the Hapless";
            }
            if (randomnumber2 == 151)
            {
                randomname2 = " the Invincible";
            }
            if (randomnumber2 == 152)
            {
                randomname2 = " the Gladiator";
            }
            if (randomnumber2 == 153)
            {
                randomname2 = " the Wonderful";
            }
            if (randomnumber2 == 154)
            {
                randomname2 = " the Fantastic";
            }
            if (randomnumber2 == 155)
            {
                randomname2 = " the Tremendous";
            }
            if (randomnumber2 == 156)
            {
                randomname2 = " the Braggart";
            }
            if (randomnumber2 == 157)
            {
                randomname2 = " the Righteous";
            }
            if (randomnumber2 == 158)
            {
                randomname2 = " the Blessed";
            }
            if (randomnumber2 == 159)
            {
                randomname2 = " the Tainted";
            }
            if (randomnumber2 == 160)
            {
                randomname2 = " of the North";
            }
            if (randomnumber2 == 161)
            {
                randomname2 = " of the South";
            }
            if (randomnumber2 == 162)
            {
                randomname2 = " of the West";
            }
            if (randomnumber2 == 163)
            {
                randomname2 = " of the East";
            }
            if (randomnumber2 == 164)
            {
                randomname2 = " deLyon";
            }
            if (randomnumber2 == 165)
            {
                randomname2 = " duPont";
            }
            if (randomnumber2 == 166)
            {
                randomname2 = " deSavona";
            }
            if (randomnumber2 == 167)
            {
                randomname2 = " deBeers";
            }
            if (randomnumber2 == 168)
            {
                randomname2 = " deGlaives";
            }
            if (randomnumber2 == 169)
            {
                randomname2 = " duChamp";
            }
            if (randomnumber2 == 170)
            {
                randomname2 = " deCorbin";
            }
            if (randomnumber2 == 171)
            {
                randomname2 = " deSeiss";
            }
            if (randomnumber2 == 172)
            {
                randomname2 = " MacAngus";
            }
            if (randomnumber2 == 173)
            {
                randomname2 = " McArgyle";
            }
            if (randomnumber2 == 174)
            {
                randomname2 = " MacLeod";
            }
            if (randomnumber2 == 175)
            {
                randomname2 = " McGregor";
            }
            if (randomnumber2 == 176)
            {
                randomname2 = " Moroney";
            }
            if (randomnumber2 == 177)
            {
                randomname2 = " McFergal";
            }
            if (randomnumber2 == 176)
            {
                randomname2 = " McFergus";
            }
            if (randomnumber2 == 177)
            {
                randomname2 = " MacCray";
            }
            if (randomnumber2 == 178)
            {
                randomname2 = " O\'Seamus";
            }
            if (randomnumber2 == 179)
            {
                randomname2 = " O\'Shannon";
            }
            if (randomnumber2 == 180)
            {
                randomname2 = " O\'Loughlin";
            }
            if (randomnumber2 == 181)
            {
                randomname2 = " O\'Malley";
            }
            if (randomnumber2 == 182)
            {
                randomname2 = " O\'Craig";
            }
            if (randomnumber2 == 183)
            {
                randomname2 = " O\'Leary";
            }
            if (randomnumber2 == 184)
            {
                randomname2 = " O\'Loch";
            }
            if (randomnumber2 == 185)
            {
                randomname2 = " O\'Donahue";
            }
            if (randomnumber2 == 186)
            {
                randomname2 = " bin Salaad";
            }
            if (randomnumber2 == 187)
            {
                randomname2 = " Atlas";
            }
            if (randomnumber2 == 188)
            {
                randomname2 = " the Conquerer";
            }
            if (randomnumber2 == 189)
            {
                randomname2 = " the Brutal";
            }
            if (randomnumber2 == 190)
            {
                randomname2 = " the Unholy";
            }
            if (randomnumber2 == 191)
            {
                randomname2 = " the Protector";
            }
            if (randomnumber2 == 192)
            {
                randomname2 = " the Confessor";
            }
            if (randomnumber2 == 193)
            {
                randomname2 = " the Magnificent";
            }
            if (randomnumber2 == 194)
            {
                randomname2 = " Firestone";
            }
            if (randomnumber2 == 195)
            {
                randomname2 = " the Wanderer";
            }
            if (randomnumber2 == 196)
            {
                randomname2 = " Worthington";
            }
            if (randomnumber2 == 197)
            {
                randomname2 = " Tudor";
            }
            if (randomnumber2 == 198)
            {
                randomname2 = " Chaucer";
            }
            if (randomnumber2 == 199)
            {
                randomname2 = " Yorksley";
            }
            if (randomnumber2 == 200)
            {
                randomname2 = " Jeeves";
            }
            if (randomnumber2 == 201)
            {
                randomname2 = " Jeavons";
            }
            if (randomnumber2 == 202)
            {
                randomname2 = " Barclay";
            }
            if (randomnumber2 == 203)
            {
                randomname2 = " Sheffield";
            }
            if (randomnumber2 == 204)
            {
                randomname2 = " Cheshire";
            }
            if (randomnumber2 == 205)
            {
                randomname2 = " Birmingham";
            }
            if (randomnumber2 == 206)
            {
                randomname2 = " Westley";
            }
            if (randomnumber2 == 207)
            {
                randomname2 = " Morte Rigis";
            }
            if (randomnumber2 == 208)
            {
                randomname2 = " Benoit";
            }
            if (randomnumber2 == 209)
            {
                randomname2 = " Nooblet";
            }
            if (randomnumber2 == 210)
            {
                randomname2 = " Randell";
            }
            if (randomnumber2 == 211)
            {
                randomname2 = " Garrett";
            }
            if (randomnumber2 == 212)
            {
                randomname2 = " Anderssen";
            }
            if (randomnumber2 == 213)
            {
                randomname2 = " Svensson";
            }
            if (randomnumber2 == 214)
            {
                randomname2 = " Ivanovic";
            }
            if (randomnumber2 == 215)
            {
                randomname2 = " Sargaard";
            }
            if (randomnumber2 == 216)
            {
                randomname2 = " Rose";
            }
            if (randomnumber2 == 217)
            {
                randomname2 = " Oakley";
            }
            if (randomnumber2 == 218)
            {
                randomname2 = " Huntley";
            }
            if (randomnumber2 == 219)
            {
                randomname2 = " Byron";
            }
            if (randomnumber2 == 220)
            {
                randomname2 = " Geltham";
            }
            if (randomnumber2 == 221)
            {
                randomname2 = " Longshanks";
            }
            if (randomnumber2 == 222)
            {
                randomname2 = " Longsword";
            }
            if (randomnumber2 == 223)
            {
                randomname2 = " Greataxe";
            }
            if (randomnumber2 == 224)
            {
                randomname2 = " Hammerfall";
            }
            if (randomnumber2 == 225)
            {
                randomname2 = " McNess";
            }
            if (randomnumber2 == 226)
            {
                randomname2 = " Crownguard";
            }
            if (randomnumber2 == 227)
            {
                randomname2 = " Greataxe";
            }
            if (randomnumber2 == 228)
            {
                randomname2 = " Pagan";
            }
            if (randomnumber2 == 229)
            {
                randomname2 = " Everhart";
            }
            if (randomnumber2 == 230)
            {
                randomname2 = " Condor";
            }
            if (randomnumber2 == 231)
            {
                randomname2 = " Valentine";
            }
            if (randomnumber2 == 232)
            {
                randomname2 = " Gruffet";
            }
            if (randomnumber2 == 233)
            {
                randomname2 = " Wainwright";
            }
            if (randomnumber2 == 234)
            {
                randomname2 = " Mason";
            }
            if (randomnumber2 == 235)
            {
                randomname2 = " Asimov";
            }
            if (randomnumber2 == 236)
            {
                randomname2 = " Vandross";
            }
            if (randomnumber2 == 237)
            {
                randomname2 = " VonDarkmoor";
            }
            if (randomnumber2 == 238)
            {
                randomname2 = " Dingo";
            }
            if (randomnumber2 == 239)
            {
                randomname2 = " raj Ahten";
            }
            if (randomnumber2 == 240)
            {
                randomname2 = " Majere";
            }
            if (randomnumber2 == 241)
            {
                randomname2 = " Knightley";
            }
            if (randomnumber2 == 242)
            {
                randomname2 = " Knightsbridge";
            }
            if (randomnumber2 == 243)
            {
                randomname2 = " Bastin";
            }
            if (randomnumber2 == 244)
            {
                randomname2 = " Woolridge";
            }
            if (randomnumber2 == 245)
            {
                randomname2 = " Moncrieff";
            }
            if (randomnumber2 == 246)
            {
                randomname2 = " Sterling";
            }
            if (randomnumber2 == 247)
            {
                randomname2 = " Broadsword";
            }
            if (randomnumber2 == 248)
            {
                randomname2 = " Claymore";
            }
            if (randomnumber2 == 249)
            {
                randomname2 = " Raleigh";
            }
            if (randomnumber2 == 250)
            {
                randomname2 = " Chevalier";
            }
            if (randomnumber2 == 251)
            {
                randomname2 = " Sherwood";
            }
            if (randomnumber2 == 252)
            {
                randomname2 = " Locksley";
            }
            if (randomnumber2 == 253)
            {
                randomname2 = " Swift";
            }
            if (randomnumber2 == 254)
            {
                randomname2 = " Fleetfoot";
            }
            if (randomnumber2 == 255)
            {
                randomname2 = " Valorum";
            }
            if (randomnumber2 == 256)
            {
                randomname2 = " Maximum";
            }
            if (randomnumber2 == 257)
            {
                randomname2 = " Imperator";
            }
            if (randomnumber2 == 258)
            {
                randomname2 = " Honorum";
            }
            if (randomnumber2 == 259)
            {
                randomname2 = " Romulus";
            }
            if (randomnumber2 == 260)
            {
                randomname2 = " Cragmyre";
            }
            if (randomnumber2 == 261)
            {
                randomname2 = " Insidious";
            }
            if (randomnumber2 == 262)
            {
                randomname2 = " Knavely";
            }
            if (randomnumber2 == 263)
            {
                randomname2 = " Crow";
            }
            if (randomnumber2 == 264)
            {
                randomname2 = " Thunderfist";
            }
            if (randomnumber2 == 265)
            {
                randomname2 = " Thunderpants";
            }
            if (randomnumber2 == 266)
            {
                randomname2 = " Stormheart";
            }
            if (randomnumber2 == 267)
            {
                randomname2 = " Ryker";
            }
            if (randomnumber2 == 268)
            {
                randomname2 = " Shardstrike";
            }
            if (randomnumber2 == 269)
            {
                randomname2 = " Helmguard";
            }
            if (randomnumber2 == 270)
            {
                randomname2 = " Injade";
            }
            if (randomnumber2 == 271)
            {
                randomname2 = " Eddengarth";
            }
            if (randomnumber2 == 272)
            {
                randomname2 = " Drakondier";
            }
            if (randomnumber2 == 273)
            {
                randomname2 = " Ironsides";
            }
            if (randomnumber2 == 269)
            {
                randomname2 = " Helmguard";
            }
            if (randomnumber2 == 270)
            {
                randomname2 = " Injade";
            }
            if (randomnumber2 == 271)
            {
                randomname2 = " Eddengarth";
            }
            if (randomnumber2 == 272)
            {
                randomname2 = " Drakondier";
            }
            if (randomnumber2 == 273)
            {
                randomname2 = " Ironsides";
            }
            if (randomnumber2 == 274)
            {
                randomname2 = " Sanchez";
            }
            if (randomnumber2 == 275)
            {
                randomname2 = " Vicente";
            }
            if (randomnumber2 == 276)
            {
                randomname2 = " Cervantes";
            }
            if (randomnumber2 == 277)
            {
                randomname2 = " Yarris";
            }
            if (randomnumber2 == 278)
            {
                randomname2 = " Pascall";
            }
            if (randomnumber2 == 279)
            {
                randomname2 = " Helm";
            }
            if (randomnumber2 == 280)
            {
                randomname2 = " Hellspawn";
            }
            if (randomnumber2 == 281)
            {
                randomname2 = " Hellrider";
            }
            if (randomnumber2 == 282)
            {
                randomname2 = " Boron";
            }
            if (randomnumber2 == 283)
            {
                randomname2 = " Gorgon";
            }
            if (randomnumber2 == 284)
            {
                randomname2 = " Griffon";
            }
            if (randomnumber2 == 285)
            {
                randomname2 = " Basilisk";
            }
            if (randomnumber2 == 286)
            {
                randomname2 = " Pudding";
            }
            if (randomnumber2 == 287)
            {
                randomname2 = " Efreeti";
            }
            if (randomnumber2 == 288)
            {
                randomname2 = " Manticore";
            }
            if (randomnumber2 == 289)
            {
                randomname2 = " Salamander";
            }
            if (randomnumber2 == 290)
            {
                randomname2 = " Boron";
            }
            if (randomnumber2 == 291)
            {
                randomname2 = " Scorpion";
            }
            if (randomnumber2 == 292)
            {
                randomname2 = " Spectre";
            }
            if (randomnumber2 == 293)
            {
                randomname2 = " the Toad";
            }
            if (randomnumber2 == 294)
            {
                randomname2 = " Shirley";
            }
            if (randomnumber2 == 295)
            {
                randomname2 = " Wyvern";
            }
            if (randomnumber2 == 296)
            {
                randomname2 = " Wolvesbane";
            }
            if (randomnumber2 == 297)
            {
                randomname2 = " Kingsfoil";
            }
            if (randomnumber2 == 298)
            {
                randomname2 = " Kingsley";
            }
            if (randomnumber2 == 299)
            {
                randomname2 = " Jeavons-Fellows";
            }
            if (randomnumber2 == 300)
            {
                randomname2 = " Cardwell";
            }
            if (randomnumber2 == 301)
            {
                randomname2 = " the Inconsolable";
            }
            if (randomnumber2 == 302)
            {
                randomname2 = " Black";
            }
            if (randomnumber2 == 303)
            {
                randomname2 = " Brown";
            }
            if (randomnumber2 == 304)
            {
                randomname2 = " Jadar";
            }
            if (randomnumber2 == 305)
            {
                randomname2 = " Boon";
            }
            if (randomnumber2 == 306)
            {
                randomname2 = " Francesco";
            }
            if (randomnumber2 == 307)
            {
                randomname2 = " Francis";
            }
            if (randomnumber2 == 308)
            {
                randomname2 = " Silverlode";
            }
            if (randomnumber2 == 309)
            {
                randomname2 = " Silverlight";
            }
            if (randomnumber2 == 310)
            {
                randomname2 = " son of " + randomname1;
            }
            if (randomnumber2 == 311)
            {
                randomname2 = " Mac" + randomname1;
            }
            if (randomnumber2 == 312)
            {
                randomname2 = " son of " + randomname1;
            }
            if (randomnumber2 == 313)
            {
                randomname2 = " Mc" + randomname1;
            }
            if (randomnumber2 == 314)
            {
                randomname2 = " Sr";
            }
            if (randomnumber2 == 315)
            {
                randomname2 = " Jr";
            }
            if (randomnumber2 == 316)
            {
                randomname2 = " II";
            }
            if (randomnumber2 == 317)
            {
                randomname2 = " III";
            }
            if (randomnumber2 == 318)
            {
                randomname2 = " IV";
            }
            if (randomnumber2 == 319)
            {
                randomname2 = " V";
            }
            if (randomnumber2 == 320)
            {
                randomname2 = " VI";
            }
            if (randomnumber2 == 321)
            {
                randomname2 = " VII";
            }
            if (randomnumber2 == 322)
            {
                randomname2 = " VIII";
            }
            if (randomnumber2 == 323)
            {
                randomname2 = " IX";
            }
            if (randomnumber2 == 324)
            {
                randomname2 = " the Unscrupulous";
            }
            if (randomnumber2 == 325)
            {
                randomname2 = " the Complainer";
            }
            if (randomnumber2 == 326)
            {
                randomname2 = " Wheatgrass";
            }
            if (randomnumber2 == 327)
            {
                randomname2 = " Bearpaw";
            }
            if (randomnumber2 == 328)
            {
                randomname2 = " Darksoul";
            }
            if (randomnumber2 == 329)
            {
                randomname2 = " Lightbringer";
            }
            if (randomnumber2 == 330)
            {
                randomname2 = " Galvatron";
            }
            if (randomnumber2 == 331)
            {
                randomname2 = " Bronzehawk";
            }
            if (randomnumber2 == 332)
            {
                randomname2 = " Thunderslate";
            }
            if (randomnumber2 == 333)
            {
                randomname2 = " Wolf";
            }
            if (randomnumber2 == 334)
            {
                randomname2 = " the Terror";
            }
            if (randomnumber2 == 335)
            {
                randomname2 = " the Cowled";
            }
            if (randomnumber2 == 336)
            {
                randomname2 = " the Philosophical";
            }
            if (randomnumber2 == 337)
            {
                randomname2 = " Dash";
            }
            if (randomnumber2 == 338)
            {
                randomname2 = " Flash";
            }
            if (randomnumber2 == 339)
            {
                randomname2 = " Flashheart";
            }
            if (randomnumber2 == 340)
            {
                randomname2 = " Lock";
            }
            if (randomnumber2 == 341)
            {
                randomname2 = " Steele";
            }
            if (randomnumber2 == 342)
            {
                randomname2 = " Tautis";
            }
            if (randomnumber2 == 343)
            {
                randomname2 = " Boniface";
            }
            if (randomnumber2 == 344)
            {
                randomname2 = " Ultramarine";
            }
            if (randomnumber2 == 345)
            {
                randomname2 = " Saintslayer";
            }
            if (randomnumber2 == 346)
            {
                randomname2 = " Glazebru";
            }
            if (randomnumber2 == 347)
            {
                randomname2 = " Mycenius";
            }
            if (randomnumber2 == 348)
            {
                randomname2 = " Baleful";
            }
            if (randomnumber2 == 349)
            {
                randomname2 = " Ogryn";
            }
            if (randomnumber2 == 350)
            {
                randomname2 = " Painbringer";
            }
            if (randomnumber2 == 350)
            {
                randomname2 = " Bucket";
            }
            if (randomnumber2 == 351)
            {
                randomname2 = " Wagon";
            }
            if (randomnumber2 == 352)
            {
                randomname2 = " Barrel";
            }
            if (randomnumber2 == 353)
            {
                randomname2 = " Beer";
            }
            if (randomnumber2 == 354)
            {
                randomname2 = " Boot";
            }
            if (randomnumber2 == 355)
            {
                randomname2 = " Table";
            }
            if (randomnumber2 == 356)
            {
                randomname2 = " Rain";
            }
            if (randomnumber2 == 357)
            {
                randomname2 = " Sharktooth";
            }
            if (randomnumber2 == 358)
            {
                randomname2 = " Husk";
            }
            if (randomnumber2 == 359)
            {
                randomname2 = " the Lazy Eyed";
            }
            if (randomnumber2 == 360)
            {
                randomname2 = " the Braggart";
            }
            return randomprefix1 + randomname1 + randomname2;
        }
    }
}
