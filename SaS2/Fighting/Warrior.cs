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

        public int Hitpoints { get; private set; }
        public int Stamina { get; private set; }
        public int Armour { get; private set; }
        public Direction FacingDirection { get; set; }
        public int MovementSpeed => 0;//TODO
        public int Position { get; set; }
        public bool IsPlayer { get; set; }
        public void Init()
        {
            Hitpoints = HitpointsMax;
            Stamina = StaminaMax;
            Armour = ArmourMax;
        }
        public void CheckStats()
        {
            Hitpoints = MathHelper.Clamp(Hitpoints, 0, HitpointsMax);
            Stamina = MathHelper.Clamp(Stamina, 0, StaminaMax);
            Armour = MathHelper.Clamp(Armour, 0, ArmourMax);
        }
        //fight functions
        public void DamageWarrior(Warrior attacker, DamageMethod method, int value)
        {
            Console.WriteLine($"{attacker.Name} deals {value} damage to {Name}");
        }
        public void RemoveArmour()
        {
            throw new NotImplementedException();
        }
        public void Death()
        {
            if (IsPlayer) Console.WriteLine("You lost");
            else Console.WriteLine("You won");
            Console.Read();
            //TODO: get out of arena
        }
        public void Blocked()
        {
            Console.WriteLine("Blocked!");
        }
        public void MakeAction(FightActionType action, Warrior attacker, Random rnd)
        {
            int damage;
            int criticalHit;
            int diceroll = rnd.Next(1, 100);
            int rollneeded;
            switch (action)
            {
                case FightActionType.MOVE:
                    {

                        break;
                    }
                case FightActionType.ATTACK:
                    {
                        damage = MinDamage;
                        criticalHit = rnd.Next(-20, 20);
                        //rollneeded = 100 - GetQuickPercentage();
                        break;
                    }
                case FightActionType.WINCROWD:
                    {
                        break;
                    }
                case FightActionType.REST:
                    {
                        break;
                    }
                case FightActionType.SWAP:
                    {
                        break;
                    }
                case FightActionType.PSYCHE_UP:
                    {
                        break;
                    }
                case FightActionType.CAST_SPELL:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        public void Attack(ActionAttack action,Warrior attacker,Random rnd)
        {

        }
        public void Move(ActionMove action)
        {

        }
    }


}
