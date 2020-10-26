using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PairProgramingGame.Attack;

namespace PairProgramingGame.Enemies
{
    public class Krueger : IEnemy
    {
        public string Name { get; } = "Freddy Kreuger";
        
        public int Health { get; set; } = 100;

        public int PointValue { get; } = 2000;

     
        public void Weakness(Attack attack)
        {
            if(attack.Type == AttackType.Fire)
            {
                Health -= 100;
            }
            else if (attack.Type == AttackType.Water || attack.Type == AttackType.Cross || attack.Type == AttackType.Trick)
            {
                Health -= 0;
            }
            else
            {
                Health -= 50;
            }
        }
        public Attack Attack()
        {
            Console.WriteLine("Freddy slashed you with his claws");
            return new Attack(20);
        }


    }
}
