using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProgramingGame
{
    public class User
    {
        public int PointsValue = 0;
        public int Health = 100;
        
        public void Weakness(Attack attack)
        {
            Health -= attack.Damage;
        }

        public void Heal()
        {
            if(Health >= 95)
            {
                Console.WriteLine("You can't heal. Your health is too full. Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Random rand = new Random();
                int result = rand.Next(1, 4);
                if (result == 1 || result == 2)
                {
                    Health += 10;
                    Console.WriteLine("Success, you gained 10 health.\n" +
                        "Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    Health += -20;
                    Console.WriteLine("Oh No! Healing failed, enemy attacked you and you lost 20 Health\n" +
                        "Press any key to continue");
                    Console.ReadKey();
                }
            }
        }
    }
}