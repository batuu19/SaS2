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
        public WarriorState State { get; set; } = WarriorState.ALIVE;
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
            var beginValue = value;
            WarriorState warriorState = WarriorState.ALIVE;
            if(Armour > 0)
            {
                var armourRemaining = Armour;
                Armour -= value;
                if (Armour <= 0)
                {
                    value -= armourRemaining;//deal damage to armour, take all armour and next deal damage to hitpoints
                    warriorState = WarriorState.NO_ARMOUR;
                }
                else value = 0;
            }
            if(value > 0)
            {
                Hitpoints -= value;
                if (Hitpoints <= 0) warriorState = WarriorState.DEAD;
            }
            Console.WriteLine($"{attacker.Name} deals {beginValue} damage to {Name} leaving {Armour} armour,{Hitpoints} hitpoints left");
            State = warriorState;
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
        public void MakeAction(FightAction action, Warrior other, Random rnd)
        {
            Console.WriteLine($"{Name} is doing action {Enum.GetName(typeof(FightActionType),action.Type)}");
            switch (action.Type)
            {
                case FightActionType.MOVE:
                    {
                        Move(action.MoveType);
                        break;
                    }
                case FightActionType.ATTACK:
                    {
                        AttackWarrior(action.AttackType,other,rnd);
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
        public void AttackWarrior(AttackType type,Warrior defender,Random rnd)
        {
            Console.WriteLine($"{Name} attacks {defender.Name} with {Enum.GetName(typeof(AttackType),type)} attack");
            Attack attack = new Attack(type, this, defender);
            int damage = 0;
            damage = Attack.GetDamage(type,this,defender,rnd);
            var diceroll = rnd.Next(1, 100);
            if(diceroll > 100 - attack.Percentage)
            {
                var state = defender.TakeDamage(this, DamageMethod.NORMAL, damage);
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
