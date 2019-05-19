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

        Random rnd;
        public Arena(Warrior hero, Warrior villain,FightMode fightMode, Random rnd)
        {
            this.hero = hero;
            this.villain = villain;
            active = hero;
            inactive = villain;
            this.fightMode = fightMode;
            this.rnd = rnd;
        }

        void ChangeActiveWarrior()
        {
            if (active == hero)
            {
                active = villain;
                inactive = hero;
            }
            else
            {
                active = hero;
                inactive = villain;
            }
        }
        public bool NextMove()
        {
            FightAction action = new FightAction();
            
                int i = 0,choice = 0;
                Console.WriteLine($"Choose action for {active.Name}");
                i = 0;
                var values = Enum.GetValues(typeof(FightActionType));
                foreach (var v in values)
                {
                    Console.WriteLine($"[{i}] {Enum.GetName(typeof(FightActionType), v).ToLower().FirstToUpper()}");
                    i++;
                }
                choice = int.Parse(Console.ReadLine());

                var type = (FightActionType)values.GetValue(choice);
                action.Type = type;
                if (type == FightActionType.ATTACK)
                {
                    Console.WriteLine("Choose attack type");
                    i = 0;
                    var attacks = FightHelpers.GetAvailableAttacks(false, true, true);
                    foreach (var a in attacks)
                    {
                        Console.WriteLine($"[{i}] {Enum.GetName(typeof(AttackType), a).ToLower().FirstToUpper()}({Attack.GetPercentage(a, hero, villain)}% chance)");
                        i++;
                    }
                    choice = int.Parse(Console.ReadLine());
                    action.AttackType = attacks[choice];
                }

            active.MakeAction(action, inactive, rnd);

            if (fightMode == FightMode.CHAMPIONSHIP)
                return hero.State != WarriorState.DEAD && villain.State != WarriorState.DEAD;
            else
                return hero.State == WarriorState.ALIVE && hero.State == WarriorState.ALIVE;
        }
    }
}
