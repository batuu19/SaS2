using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Fighting
{
    public class AI : AbstractPlayer
    {
        Warrior warrior;
        public AI(Character character)
        {
            warrior = Character.CopyToWarrior(warrior);
        }
        public AI(Warrior warrior)
        {
            this.warrior = warrior;
        }

        public override FightAction GetFightAction(Warrior enemy)
        {
            return new FightAction()
            {
                Type = FightActionType.ATTACK,
                AttackType = AttackType.QUICK,
            };
        }
    }
}
