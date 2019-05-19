using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Fighting
{
    public class Arena
    {
        readonly Warrior hero;
        readonly Warrior villain;
        Warrior active;
        Warrior inactive;
        int crowdInteres = 0;
        FightMode fightMode;

        AbstractPlayer activePlayer;
        AbstractPlayer inactivePlayer;

        Random rnd;

        Player human;
        AI computer;
        public Arena(Hero hero, Warrior villain, FightMode fightMode, Random rnd)
        {
            this.hero = Character.CopyToWarrior(hero);
            this.villain = villain;
            active = this.hero;
            inactive = villain;
            this.fightMode = fightMode;
            this.rnd = rnd;
            human = new Player(hero);
            computer = new AI(villain);
            activePlayer = human;
            inactivePlayer = computer;
        }

        void SwapActive()
        {
            if (active == hero)
            {
                active = villain;
                inactive = hero;
                activePlayer = computer;
                inactivePlayer = human;
            }
            else
            {
                active = hero;
                inactive = villain;
                activePlayer = human;
                inactivePlayer = computer;
            }
        }
        public void Begin()
        {
            human.BeginFight();
            Console.WriteLine(GetInfo(true, true, true));
        }
        public bool NextMove()
        {
            var action = activePlayer.GetFightAction(inactive);

            active.MakeAction(action, inactive, rnd);

            var end = (
            (fightMode == FightMode.CHAMPIONSHIP &&
                (hero.State == WarriorState.DEAD || villain.State == WarriorState.DEAD))
                ||
            (fightMode == FightMode.DUEL &&
                (hero.State != WarriorState.ALIVE || hero.State != WarriorState.ALIVE))
                );
            if (!end)
            {
                SwapActive();
                return true;
            }
            else return false;
        }
        public void Finish()
        {
            inactive.Death();
        }
        public string GetInfo(bool viewInGameStats = true, bool viewDNAStats = false, bool viewEq = false)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Gladiators:");
            sb.AppendLine("You vs Him");
            sb.AppendLine($"Name: {hero.Name} - {villain.Name}");
            sb.AppendLine($"Level: {hero.Level} - {villain.Level}");
            if (viewInGameStats)
            {
                sb.AppendLine($"Stamina: {hero.Stamina}/{hero.StaminaMax} - {villain.Stamina}/{villain.StaminaMax}");
                sb.AppendLine($"Stamina: {hero.Hitpoints}/{hero.HitpointsMax} - {villain.Hitpoints}/{villain.HitpointsMax}");
                sb.AppendLine($"Stamina: {hero.Armour}/{hero.ArmourMax} - {villain.Armour}/{villain.ArmourMax}");
            }
            if (viewDNAStats)
            {
                sb.AppendLine($"Strength: {hero.DNA.Strength   } - {villain.DNA.Strength   }");
                sb.AppendLine($"Speed   : {hero.DNA.Speed      } - {villain.DNA.Speed      }");
                sb.AppendLine($"Attack  : {hero.DNA.Attack     } - {villain.DNA.Attack     }");
                sb.AppendLine($"Defence : {hero.DNA.Defence    } - {villain.DNA.Defence    }");
                sb.AppendLine($"Vitality: {hero.DNA.Vitality   } - {villain.DNA.Vitality   }");
                sb.AppendLine($"Charisma: {hero.DNA.Charisma   } - {villain.DNA.Charisma   }");
                sb.AppendLine($"Stamina : {hero.DNA.Stamina    } - {villain.DNA.Stamina    }");
                sb.AppendLine($"Magicka : {hero.DNA.Magicka    } - {villain.DNA.Magicka    }");
            }
            if (viewEq)
            {
                sb.Append($"{hero.Equipment.Weapon.Name}({hero.Equipment.Weapon.MinDamage} - {hero.Equipment.Weapon.MaxDamage}) -");
                sb.Append($"{villain.Equipment.Weapon.Name}({villain.Equipment.Weapon.MinDamage} - {villain.Equipment.Weapon.MaxDamage})\n");
                var heroArmour = hero.Equipment.ArmourItems;
                var villainArmour = villain.Equipment.ArmourItems;
                for(int i = 0; i < heroArmour.Count; i++)
                {
                    sb.AppendLine($"{heroArmour[i].Name}({heroArmour[i].ArmourValue}) - {villainArmour[i].Name}({villainArmour[i].ArmourValue})");
                }

            }
            return sb.ToString();
        }
    }
}
