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
        Random rnd;
        public AI(Character character, Random rnd)
        {
            warrior = Character.CopyToWarrior(warrior);
            this.rnd = rnd;
        }
        public AI(Warrior warrior, Random rnd)
        {
            this.warrior = warrior;
            this.rnd = rnd;
        }

        public override FightAction GetFightAction(Warrior enemy)
        {
            var action = new FightAction();
            action.Type = FightActionType.ATTACK;

            Attack attack = new Attack(AttackType.POWER, warrior, enemy);

            var powerP = Attack.GetPercentage(AttackType.POWER, warrior, enemy);
            var normalP = Attack.GetPercentage(AttackType.NORMAL, warrior, enemy);
            var quickP = Attack.GetPercentage(AttackType.QUICK, warrior, enemy);

            if(powerP == 99)
            {
                action.AttackType = AttackType.POWER;
                return action;
            }

            var powerDecision = attack.MaxDamage * powerP;
            var normalDecision = ((attack.MaxDamage + attack.MinDamage) / 2) * normalP;//TODO better decision?
            var quickDecision = attack.MinDamage * quickP;

            int max = Math.Max(powerDecision, Math.Max(normalDecision, quickDecision));
            if (max == powerDecision) action.AttackType = AttackType.POWER;
            if (max == normalDecision) action.AttackType = AttackType.NORMAL;
            if (max == quickDecision) action.AttackType = AttackType.QUICK;

            return action;
        }
    }
}
