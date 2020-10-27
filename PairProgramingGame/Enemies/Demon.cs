using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PairProgramingGame.Attack;

namespace PairProgramingGame.Enemies
{
    public class Demon : IEnemy 
    {
        public string Name { get; } = "Demons";

        public int Health { get; set; } = 100;

        public int PointValue { get; } = 200;


        public void Weakness(Attack attack)
        {
                    if (attack.Type == AttackType.Cross)
            {
                Health -= 100;
            }
            else if (attack.Type == AttackType.Water || attack.Type == AttackType.Fire || attack.Type == AttackType.Trick)
            {
                Console.WriteLine("The demon is invulnerable to the attack");
                Health -= 0;
            }
            else if(attack.Type == AttackType.Sword)
            {
                Console.WriteLine("Sword attack did 50% damage to the demon");
                Health -= 50;
            }
        }
        public Attack Attack()
        {
            Console.WriteLine("Demons AHHHH!");
            return new Attack(5);
        }
    }
}
