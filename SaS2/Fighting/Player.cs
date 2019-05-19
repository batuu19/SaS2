using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Fighting
{
    public class Player : AbstractPlayer
    {
        Hero hero;
        Warrior warrior;
        public Player(Hero hero)
        {
            this.hero = hero;
        }

        public void BeginFight()
        {
            warrior = Character.CopyToWarrior(hero);
        }
        public override FightAction GetFightAction(Warrior enemy)
        {
            FightAction action = new FightAction();

            int i = 0, choice = 0;
            Console.WriteLine($"Choose action for {hero.Name}");
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
                    Console.WriteLine($"[{i}] {Enum.GetName(typeof(AttackType), a).ToLower().FirstToUpper()}({Attack.GetPercentage(a, warrior, enemy)}% chance)");
                    i++;
                }
                choice = int.Parse(Console.ReadLine());
                action.AttackType = attacks[choice];
            }
            return action;
        }
    }
}
