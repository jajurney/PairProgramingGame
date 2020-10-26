using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PairProgramingGame.Attack;

namespace PairProgramingGame.Enemies
{
    public class Vorhees : IEnemy
    {
        public string Name { get; } = "Jason Vorhees";

        public int Health { get; set; } = 100;

        public int PointValue { get; } = 1000;


        public void Weakness(Attack attack)
        {
            if (attack.Type == AttackType.Water)
            {
                Health -= 100;
            }
            if (attack.Type == AttackType.Fire || attack.Type == AttackType.Cross || attack.Type == AttackType.Trick)
            {
                Health -= 0;
            }
            if (attack.Type == AttackType.Sword)
            {
                Health -= 50;
            }
        }
        public Attack Attack()
        {
            Console.WriteLine("Jason cut you with his Machete");
            return new Attack(10);
        }


    }
}
