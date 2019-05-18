using SaS2.Gear.Armour;
using SaS2.Gear.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2
{
    public static class StaticHelper
    {
        public static int breastplate_dval = 16;
        public static int helmet_dval = 10;
        public static int shinguard_dval = 6;
        public static int greaves_dval = 3;
        public static int shoulderguard_dval = 8;
        public static int gauntlet_dval = 5;
        public static int boot_dval = 2;
        public static int shield_dval = 12;

        public static int GetArmourValue(Type type)
        {
            var @switch = new Dictionary<Type, int>
            {
                {typeof(Breastplate),breastplate_dval },
                {typeof(Helmet),helmet_dval },
                {typeof(Shinguard),shinguard_dval },
                {typeof(Greaves),greaves_dval },
                {typeof(Shoulderguard),shoulderguard_dval },
                {typeof(Gauntlet),gauntlet_dval },
                {typeof(Boot),boot_dval },
                {typeof(Shield),shield_dval },
            };
            return @switch[type];
        }
        public static int GetArmourValue(ArmourType type)
        {
            switch (type)
            {
                case ArmourType.UNDEFINED:
                    return 0;
                case ArmourType.BOOT:
                    return boot_dval;
                case ArmourType.SHINGUARD:
                    return shinguard_dval;
                case ArmourType.GREAVES:
                    return greaves_dval;
                case ArmourType.BREASTPLATE:
                    return breastplate_dval;
                case ArmourType.GAUNTLET:
                    return gauntlet_dval;
                case ArmourType.SHOULDERGUARD:
                    return shoulderguard_dval;
                case ArmourType.HELMET:
                    return helmet_dval;
                case ArmourType.SHIELD:
                    return shield_dval;
                default:
                    return 0;
            }
        }

        public static object GetEnum(Type type, string name)
        {
            name = name.ToUpper();
            return Enum.Parse(type, name);
        }
        public static ArmourSet GetArmourSet(string name) => (ArmourSet)GetEnum(typeof(ArmourSet), name);
        public static ArmourType GetArmourType(string name) => (ArmourType)GetEnum(typeof(ArmourType), name);
        public static WeaponType GetWeaponType(string name) => (WeaponType)GetEnum(typeof(WeaponType), name);

        public static Type GetArmourType(ArmourType type)
        {
            switch (type)
            {
                case ArmourType.UNDEFINED:
                    return null;
                case ArmourType.BOOT:
                    return typeof(Boot);
                case ArmourType.SHINGUARD:
                    return typeof(Shinguard);
                case ArmourType.GREAVES:
                    return typeof(Greaves);
                case ArmourType.BREASTPLATE:
                    return typeof(Breastplate);
                case ArmourType.GAUNTLET:
                    return typeof(Gauntlet);
                case ArmourType.SHOULDERGUARD:
                    return typeof(Shoulderguard);
                case ArmourType.HELMET:
                    return typeof(Helmet);
                case ArmourType.SHIELD:
                    return typeof(Shield);
                default:
                    return null;
            }
        }

        public static string FirstToUpper(this string s)
        {
            StringBuilder stringBuilder = new StringBuilder(s);
            stringBuilder[0] = char.ToUpper(stringBuilder[0]);
            return stringBuilder.ToString();
        }
    }
}
