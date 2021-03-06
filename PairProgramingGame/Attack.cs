﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PairProgramingGame
{
    public class Attack
    {
        public enum AttackType { Fire = 1, Water, Trick, Cross, Sword, Knives, Heal }
        public int Damage;
        public AttackType Type;
        public string Name { get; set; }
        //Attack the enemy
        public Attack(string type)
        {
            Type = GetTheAttackType(type);
        }

        //Attack the user
        public Attack(int damage)
        {
            Damage = damage;
        }

        private AttackType GetTheAttackType(string attackName)
        {
            AttackType attackType = AttackType.Water;
            switch (attackName)
            {
                case "Fire":
                    attackType = AttackType.Fire;
                    break;
                case "Water":
                    attackType = AttackType.Water;
                    break;
                case "Trick":
                    attackType = AttackType.Trick;
                    break;
                case "Cross":
                    attackType = AttackType.Cross;
                    break;
                case "Sword":
                    attackType = AttackType.Sword;
                    break;
                case "Knives":
                    attackType = AttackType.Knives;
                    break;
                default:
                    attackType = AttackType.Heal;
                    break;
            }
            return attackType;
        }
    }
}
