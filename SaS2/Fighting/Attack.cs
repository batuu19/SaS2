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
        private double powerMul = 0.33;
        private double normalMul = 0.5;
        private double quickMul = 0.66;
        private double bashMul = 0.2;
        private double tauntMul = 0.33;
        private double bombardMul = 0.6;
        private double snipeMul = 0.9;
        private double magickaMul = 0.5;

        private int GetPercentage(int stat1, int stat2, double mul)
        {
            var p = (int)Math.Round((double)(stat1 + 9) / (stat2 + 9) * 100 * mul);
            return MathHelper.ClampPercentage(p);
        }
        public int GetChargePercentage  (Warrior attacker, Warrior defender) => GetPercentage(attacker.DNA.Attack, defender.DNA.Defence, powerMul);
        public int GetPowerPercentage   (Warrior attacker,Warrior defender) => GetPercentage(attacker.DNA.Attack, defender.DNA.Defence, powerMul);
        public int GetNormalPercentage  (Warrior attacker,Warrior defender) => GetPercentage(attacker.DNA.Attack, defender.DNA.Defence, normalMul);
        public int GetQuickPercentage   (Warrior attacker,Warrior defender) => GetPercentage(attacker.DNA.Attack, defender.DNA.Defence, quickMul);
        public int GetBashPercentage    (Warrior attacker,Warrior defender) => GetPercentage(attacker.DNA.Attack, defender.DNA.Defence, bashMul);
        public int GetTauntPercentage   (Warrior attacker,Warrior defender) => GetPercentage(attacker.DNA.Charisma, defender.DNA.Charisma, tauntMul);
        public int GetBombardPercentage (Warrior attacker,Warrior defender) => GetPercentage(attacker.DNA.Attack, defender.DNA.Defence, bombardMul);
        public int GetSnipePercentage   (Warrior attacker,Warrior defender) => GetPercentage(attacker.DNA.Attack, defender.DNA.Defence, snipeMul);
        public int GetMagickaPercentage (Warrior attacker,Warrior defender) => GetPercentage(attacker.DNA.Magicka, defender.DNA.Magicka, magickaMul);
        public int GetPercentage(AttackType attackType, Warrior attacker, Warrior defender)
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
