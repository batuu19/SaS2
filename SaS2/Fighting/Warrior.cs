using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Fighting
{
    public class Warrior : Character
    {
        #region attack multipiers
        private double powerMul = 0.33;
        private double normalMul = 0.5;
        private double quickMul = 0.66;
        private double bashMul = 0.2;
        private double tauntMul = 0.33;
        private double bombardMul = 0.6;
        private double snipeMul = 0.9;
        private double magickaMul = 0.5;
        #endregion

        #region GetPercentage
        private int GetPercentage(int stat1, int stat2, double mul)
        {
            var p = (int)Math.Round((stat1 + 9) / (stat2 + 9) * 100 * mul);
            return MathHelper.ClampPercentage(p);
        }
        public int GetPowerPercentage(Warrior defender) => GetPercentage(DNA.Attack, defender.DNA.Defence, powerMul);
        public int GetNormalPercentage(Warrior defender) => GetPercentage(DNA.Attack, defender.DNA.Defence, normalMul);
        public int GetQuickPercentage(Warrior defender) => GetPercentage(DNA.Attack, defender.DNA.Defence, quickMul);
        public int GetBashPercentage(Warrior defender) => GetPercentage(DNA.Attack, defender.DNA.Defence, bashMul);
        public int GetTauntPercentage(Warrior defender) => GetPercentage(DNA.Charisma, defender.DNA.Charisma, tauntMul);
        public int GetBombardPercentage(Warrior defender) => GetPercentage(DNA.Attack, defender.DNA.Defence, bombardMul);
        public int GetSnipePercentage(Warrior defender) => GetPercentage(DNA.Attack, defender.DNA.Defence, snipeMul);
        public int GetMagickaPercentage(Warrior defender) => GetPercentage(DNA.Magicka, defender.DNA.Magicka, magickaMul);
        public int GetPercentage(AttackType attackType, Warrior defender)
        {
            switch (attackType)
            {
                case AttackType.POWER:

                    return GetPowerPercentage(defender);
                case AttackType.NORMAL:
                    return GetNormalPercentage(defender);
                case AttackType.QUICK:
                    return GetQuickPercentage(defender);
                case AttackType.BASH:
                    return GetBashPercentage(defender);
                case AttackType.TAUNT:
                    return GetTauntPercentage(defender);
                case AttackType.BOMBARD:
                    return GetBombardPercentage(defender);
                case AttackType.SNIPE:
                    return GetSnipePercentage(defender);
                case AttackType.MAGICKA:
                    return GetMagickaPercentage(defender);
                default:
                    return 0;
            }
        }
        #endregion
    }
}
