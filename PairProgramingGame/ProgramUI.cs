using PairProgramingGame.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PairProgramingGame
{
    public class ProgramUI
    {
        User user = new User();

        List<IEnemy> room = new List<IEnemy>();

        public void Run()
        {
            int score = 0;
            bool alive = true;
            IEnemy enemy;

            GameRules();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            AddEnemiesToRoom();

            //Console.WriteLine("Enter user name: ");
            //user.Name = Console.ReadLine();

            //While the user is alive
            while (alive && score < 10000)
            {
                Console.Clear();

                if (user.Health == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    alive = false;
                    bool visible = true;
                    do
                    {
                        //Press Ctrl + C to Quit
                        string alert = visible ? "ALERT! ALERT!! ALERT!!!" : "";
                        visible = !visible;
                        Console.Clear();
                        Console.WriteLine("You died, now you'll be one of us forever!\n" +
                            "Press Ctrl + C to end the game");

                        Thread.Sleep(300);
                    } while (true);

                 
                }

                enemy = GetRandomEnemy();
                                
                //while the enemy is alive
                while (enemy.Health > 0 && user.Health > 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Your total score is: " + score);

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Your Health is: " + user.Health);
                    Console.ForegroundColor = ConsoleColor.Black;


                    Console.WriteLine($"Your enemy is: {enemy.Name}");
                    Console.WriteLine($"Enemy health: {enemy.Health}");

                    string attackType = DisplayAttackOptions();

                    //Attack the enemy
                    enemy.Weakness(new Attack(attackType));

                    if (attackType == "Heal")
                    {
                        user.Heal();
                    }

                    else
                    {
                        //Attack the user
                        if (enemy.Health > 0)
                        {

                            user.Weakness(enemy.Attack());
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Monster Attacked you, new Health is: " + user.Health);
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }
                        else //(enemy.Health == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;

                            Console.WriteLine("You killed the monster");

                            score += enemy.PointValue;
                            Console.WriteLine("Your total score is " + score);
                            Console.WriteLine("Press any key to continue through the house");
                            Console.ReadKey();
                            enemy.Health = 100;

                            break;
                        }
                    }

                    Console.Clear();
                }


            }

            if (score >= 10000)
            {
                Console.WriteLine("Phew you killed all the monsters and have escaped the Haunted House.");
            }
            Console.WriteLine("Game Ended.");

        }

        //Display game rules and instructions
        private void GameRules()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("While trick or treating, you stumble upon a haunted house.\n" +
                "As you enter the door slams behind you.\n" +
                "The only way to escape is to get through the house.\n" +
                "Beware monsters are lurking to attack.\n" +
                "You must kill the monster to get to the next room\n" +
                "Hint: Each monster has their own weaknesses but are unharmed by some attacks.");
        }

        //Add enemies to room
        private void AddEnemiesToRoom()
        {
            IEnemy demon = new Demon();
            IEnemy skeletions = new Skeletons();
            IEnemy leatherface = new Leatherface();
            IEnemy vorhees = new Vorhees();
            IEnemy krueger = new Krueger();


            room.Add(demon);
            room.Add(skeletions);
            room.Add(leatherface);
            room.Add(vorhees);
            room.Add(krueger);
        }

        //Get random enemy
        private IEnemy GetRandomEnemy()
        {
            Random rand = new Random();
            int randomIndex = rand.Next(room.Count);
            return room[randomIndex];
        }

        //Display Attack options
        private string DisplayAttackOptions()
        {
            string[] attackOptionsList = { "1. Fire", "2. Water", "3. Trick", "4. Cross", "5. Sword", "6. Knives", "7. Attempt to Heal" };
            string attackType = "";
            int attackOption = 0;

            //Display attack option list
            foreach (string option in attackOptionsList)
            {
                Console.WriteLine($"{option}\n");
            }

            //Make sure the input is integer and between 1 to 7
            do
            {
                Console.WriteLine("Enter your attack option from the list: ");

            } while ((!int.TryParse(Console.ReadLine(), out attackOption)) || (attackOption < 1) || (attackOption > 7));

            switch (attackOption)
            {
                case 1:
                    attackType = "Fire";
                    break;
                case 2:
                    attackType = "Water";
                    break;
                case 3:
                    attackType = "Trick";
                    break;
                case 4:
                    attackType = "Cross";
                    break;
                case 5:
                    attackType = "Sword";
                    break;
                case 6:
                    attackType = "Knives";
                    break;
                case 7:
                    attackType = "Heal";
                    break;
                default:
                    Console.WriteLine("Enter the correct attack type");
                    //Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }


            return attackType;
        }

    }
}
