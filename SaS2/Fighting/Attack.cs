using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Fighting
{
    public class Attack
    {
        public AttackType Type { get; set; }
        public int MaxDamage { get; set; }
        public int MinDamage { get; set; }
        public int Percentage { get; set; }
        public int CriticalHit { get; set; }

        #region Percentages
        private static double powerMul = 0.33;
        private static double normalMul = 0.5;
        private static double quickMul = 0.66;
        private static double bashMul = 0.2;
        private static double tauntMul = 0.33;
        private static double bombardMul = 0.6;
        private static double snipeMul = 0.9;
        private static double magickaMul = 0.5;

        private static int GetPercentage(int stat1, int stat2, double mul)
        {
            var p = (int)Math.Round((double)(stat1 + 9) / (stat2 + 9) * 100 * mul);
            return MathHelper.ClampPercentage(p);
        }
        public static int GetChargePercentage  (Warrior attacker, Warrior defender) => GetPercentage(attacker.DNA.Attack, defender.DNA.Defence, powerMul);
        public static int GetPowerPercentage   (Warrior attacker,Warrior defender) => GetPercentage(attacker.DNA.Attack, defender.DNA.Defence, powerMul);
        public static int GetNormalPercentage  (Warrior attacker,Warrior defender) => GetPercentage(attacker.DNA.Attack, defender.DNA.Defence, normalMul);
        public static int GetQuickPercentage   (Warrior attacker,Warrior defender) => GetPercentage(attacker.DNA.Attack, defender.DNA.Defence, quickMul);
        public static int GetBashPercentage    (Warrior attacker,Warrior defender) => GetPercentage(attacker.DNA.Attack, defender.DNA.Defence, bashMul);
        public static int GetTauntPercentage   (Warrior attacker,Warrior defender) => GetPercentage(attacker.DNA.Charisma, defender.DNA.Charisma, tauntMul);
        public static int GetBombardPercentage (Warrior attacker,Warrior defender) => GetPercentage(attacker.DNA.Attack, defender.DNA.Defence, bombardMul);
        public static int GetSnipePercentage   (Warrior attacker,Warrior defender) => GetPercentage(attacker.DNA.Attack, defender.DNA.Defence, snipeMul);
        public static int GetMagickaPercentage (Warrior attacker,Warrior defender) => GetPercentage(attacker.DNA.Magicka, defender.DNA.Magicka, magickaMul);
        public static int GetPercentage(AttackType attackType, Warrior attacker, Warrior defender)
        {
            switch (attackType)
            {
                case AttackType.CHARGE:
                    return GetChargePercentage(attacker, defender);
                case AttackType.POWER:
                    return GetPowerPercentage(attacker, defender);
                case AttackType.NORMAL:
                    return GetNormalPercentage(attacker, defender);
                case AttackType.QUICK:
                    return GetQuickPercentage(attacker, defender);
                case AttackType.BASH:
                    return GetBashPercentage(attacker, defender);
                case AttackType.TAUNT:
                    return GetTauntPercentage(attacker, defender);
                case AttackType.BOMBARD:
                    return GetBombardPercentage(attacker, defender);
                case AttackType.SNIPE:
                    return GetSnipePercentage(attacker, defender);
                case AttackType.MAGICKA:
                    return GetMagickaPercentage(attacker, defender);
                case AttackType.GRIEVOUS:
                    return 100;//TODO: check how much percentage
                default:
                    return 0;
            }
        }
        #endregion

        public Attack(AttackType type,Warrior attacker,Warrior defender)
        {
            Type = type;
            MaxDamage = attacker.Equipment.Weapon.MaxDamage;
            MinDamage = attacker.Equipment.Weapon.MinDamage;
            Percentage = GetPercentage(type, attacker, defender);
            //TODO critical hit
        }
    }
}
