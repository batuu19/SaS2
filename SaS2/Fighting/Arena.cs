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
    }
}
