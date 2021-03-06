﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PairProgramingGame.Attack;
namespace PairProgramingGame.Enemies
{
    public class Leatherface : IEnemy
    {
        public string Name { get; } = "Leatherface";
        public int Health { get; set; } = 100;
        public int PointValue { get; } = 800;
        public void Weakness(Attack attack)
        {
            if (attack.Type == AttackType.Trick || attack.Type == AttackType.Sword)
            {
                Health -= 100;
            }
            if (attack.Type == AttackType.Cross || attack.Type == AttackType.Fire || attack.Type == AttackType.Water || attack.Type == AttackType.Knives)
            {
                Console.WriteLine("Leatherface is invulnerable to the attack");
                Health -= 0;
            }
        }
        public Attack Attack()
        {
            Console.WriteLine("Leatherface cut you with his Chainsaw");
            return new Attack(10);
        }
    }
}
