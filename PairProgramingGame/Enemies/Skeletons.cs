using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PairProgramingGame.Attack;
namespace PairProgramingGame.Enemies
{
    class Skeletons : IEnemy
    {
        public string Name { get; } = "Skeletons";
        public int Health { get; set; } = 100;
        public int PointValue { get; } = 100;
        public void Weakness(Attack attack)
        {
            if (attack.Type == AttackType.Fire || attack.Type == AttackType.Sword || attack.Type == AttackType.Water)
            {
                Health -= 100;
            }
            if (attack.Type == AttackType.Cross || attack.Type == AttackType.Trick)
            {
                Console.WriteLine("Skeleton is invulnerable to the attack");
                Health -= 0;
            }
        }
        public Attack Attack()
        {
            Console.WriteLine("You were attacked by bones!");
            return new Attack(5);
        }
    }
}
