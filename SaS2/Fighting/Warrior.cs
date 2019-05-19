using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Fighting
{
    public class Warrior : Character
    {
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
        public WarriorState TakeDamage(Warrior attacker, DamageMethod method, int value)
        {
            Console.WriteLine($"{attacker.Name} deals {value} damage to {Name}");
            WarriorState warriorState = WarriorState.ALIVE;
            if(Armour > 0)
            {
                var armourRemaining = Armour;
                Armour -= value;
                if (armourRemaining <= 0)
                {
                    value -= armourRemaining;//deal damage to armour, take all armour and next deal damage to hitpoints
                    warriorState = WarriorState.NO_ARMOUR;
                }
            }
            if(value > 0)
            {
                Hitpoints -= value;
                if (Hitpoints <= 0) warriorState = WarriorState.DEAD;
            }
            return warriorState;
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
        public void BlockDamage(DamageMethod method)
        {
            Console.WriteLine($"{Name} Blocked attack!");
        }
        public bool MakeAction(FightAction action, Warrior other, Random rnd)
        {
            Console.WriteLine($"action {Enum.GetName(typeof(FightActionType),action.Type)}");
            switch (action.Type)
            {
                case FightActionType.MOVE:
                    {
                        Move(action.MoveType);
                        break;
                    }
                case FightActionType.ATTACK:
                    {
                        Attack(action.AttackType,other,rnd);
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
            return true;
        }
        public void Attack(AttackType type,Warrior defender,Random rnd)
        {
            Attack attack = new Attack(type, this, defender);
            int damage = 0;
            switch (type)
            {
                case AttackType.POWER:
                    damage = attack.MaxDamage;
                    break;
                case AttackType.NORMAL:
                    damage = rnd.Next(attack.MinDamage, attack.MaxDamage);
                    break;
                case AttackType.QUICK:
                    damage = attack.MinDamage;
                    break;
                case AttackType.BASH:
                    damage = (int)Math.Ceiling(attack.MinDamage / 2.0);
                    break;
                case AttackType.TAUNT:
                    damage = (int)Math.Round((this.DNA.Charisma * 2.5) - (defender.DNA.Charisma * 0.25));
                    break;
                case AttackType.BOMBARD:
                    damage = rnd.Next(attack.MinDamage, attack.MaxDamage);
                    break;
                case AttackType.SNIPE:
                    damage = attack.MinDamage;
                    break;
                case AttackType.GRIEVOUS:
                    damage = (int)Math.Round(attack.MaxDamage * 1.5);
                    break;
                case AttackType.MAGICKA:
                    //TODO
                    break;
                case AttackType.CHARGE:
                    damage = rnd.Next(attack.MinDamage, attack.MaxDamage);
                    break;
                default:
                    damage = 0;
                    break;
            }
            var diceroll = rnd.Next(1, 100);
            if(diceroll > 100 - attack.Percentage)
            {
                defender.TakeDamage(this, DamageMethod.NORMAL, damage);
            }
            else
            {
                defender.BlockDamage(DamageMethod.NORMAL);
            }
        }
        public void Move(MoveType type)
        {

        }
    }


}
