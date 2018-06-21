using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalGameAssignment.Models
{
    class Forest
    {

        public List<Monster> monsterList = Monster.MonsterList();
        //public int Num { get; set; }
        public int Count { get; set; }
        int count = 0;
        Random rand = new Random();
        public void Location(User user, Monster mst)
        {
            Sound.ForestMusic();
            Graphic.Forest(user);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("1. By the lake: low level monsters\n2. By the hill: Medium level monsters\n3. By the valley: high level monster\n4. " +
                "By the grave: General monsters\n5. By the morass: King monster\n6. Cancel");
            bool mstChoice = Int32.TryParse(Console.ReadLine(), out int mstNum);
            //Num = mstNum;
            //Sound.LocationMusic(mstNum);
            Sound.BattleMusic();
            switch (mstNum)
            {
                case 1:
                    {
                        Monster mstLow = monsterList[rand.Next(0, 7)]; // to fight with a random low level monster
                        Battle(user, mstLow, user.Weapon);
                    }
                    break;
                case 2:
                    {
                        Monster mstMedium = monsterList[rand.Next(7, 13)]; // to fight with a random medium level monster
                        Battle(user, mstMedium, user.Weapon);
                    }
                    break;
                case 3:
                    {
                        Monster mstHigh = monsterList[rand.Next(13, 17)];
                        Battle(user, mstHigh, user.Weapon);
                    }
                    break;
                case 4:
                    {
                        Monster mstHigher = monsterList[rand.Next(17, 20)];
                        Battle(user, mstHigher, user.Weapon);
                    }
                    break;
                case 5:
                    {
                        Monster mstBoss = monsterList[20];
                        Battle(user, mstBoss, user.Weapon);
                    }
                    break;
                case 6:
                    {
                        // Sound.LocationMusic(6) error. Fixed
                        StartMenu.entrance.EntranceBase(user, mst);
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Invalid input. Enter a number between 1 and 6"); //不要readkey()
                        Location(user, mst);
                    }
                    break;
            }

        }
        public void Battle(User user, Monster mst, Weapon weapon)
        {     
            string mstAtkRange = mst.AttackRange.Replace(" ", "");
            string userAtkRange = user.Weapon.AttackRange.Replace(" ", "");
            int userNum = 0;
            do
            {
                Graphic.MonsterGraphic(mst, user);
                Console.WriteLine("1. Make attack");
                Console.WriteLine("2  Walk away");
                // Console.WriteLine("3. Change equipment");
                Console.WriteLine("3. Quit Game");
                bool userChoice = Int32.TryParse(Console.ReadLine(), out userNum);
                switch (userNum)
                {
                    case 1:
                        {
                            Sound.WeaponAtkSnd(user);

                            //Can't get regex work, so I'm using string methods to collect the two sepearatly integers from a string formated like "(9 - 23)".
                            int mstAtkMin = Convert.ToInt32(mstAtkRange.Substring(1, mstAtkRange.IndexOf("-") - 1));
                            int mstAtkMax = Convert.ToInt32(mstAtkRange.Substring(mstAtkRange.IndexOf("-") + 1, mstAtkRange.IndexOf(")") - mstAtkRange.IndexOf("-") - 1));
                            // Console.WriteLine("Min:" + mstAtkMin + "Max:" + mstAtkMax + "!");  // for testing
                            mst.Attack = rand.Next(mstAtkMin, mstAtkMax);

                            int userAtkMin = Convert.ToInt32(userAtkRange.Substring(1, userAtkRange.IndexOf("-") - 1));
                            int userAtkMax = Convert.ToInt32(userAtkRange.Substring(userAtkRange.IndexOf("-") + 1, userAtkRange.IndexOf(")") - userAtkRange.IndexOf("-") - 1));
                            //Console.WriteLine("Min:" + userAtkMin + "Max:" + userAtkMax + "!");  // for testing
                            user.Weapon.Attack = rand.Next(userAtkMin, userAtkMax);

                            Graphic.Damage(user, mst);
                            Console.ReadKey();  //如果想实现连击，需要去掉这个，但是去掉后，cw 不显示！！

                            user.HP -= mst.Attack;
                            mst.HP -= user.Weapon.Attack;
                            if (mst.HP <= 0)
                            {
                                if (user.HP < 0)   // to avoid negative user HP value.
                                {
                                    user.HP = 1;  // When the user and monster die at the same time, I set the user win and set user's HP value to 1.
                                }
                                user.Gold += mst.Gold;
                                mst.HP = 0;
                                Sound.BattleWin();
                                // Graphic.MonsterGraphic(mst, user);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You Won");
                                Console.ResetColor();
                                Console.ReadKey();
                                count += 1;
                                while (count == 3)
                                {
                                    count = 0;
                                    user.EXP += 1;
                                    if (user.EXP == 3)
                                    {
                                        Shield.shields.Add(new Shield { Name = "Gold Shield", Price = 200, HP = 100 });
                                        Graphic.NewItemNotice(user);
                                        Console.ReadKey();
                                    }
                                    break;
                                }
                                if (mst.Name == "King Monster")
                                {
                                    mst.HP = 0;
                                    // monsterList.Remove(mst);
                                    Graphic.StoryEnd(user, mst);
                                    Console.ReadKey();
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    var obj = Graphic.mList.Single(m => m.Num == mst.Num);
                                    mst.HP = obj.HP;
                                    StartMenu.entrance.EntranceBase(user, mst);
                                }

                            }
                            else if (user.HP <= 0)
                            {
                                user.HP = 0;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You die");
                                Console.ResetColor();
                                Sound.BattleFail();
                                //Console.ReadKey();

                                Console.WriteLine("Do you want to start over? Y/N");
                                string userAnswer = Console.ReadLine().ToLower();
                                bool keepLooping = true;
                                do
                                {
                                    switch (userAnswer)
                                    {
                                        case "y":
                                            {
                                                user.HP = 100;   // initial user state
                                                user.Gold = 20;
                                                user.Weapon = Weapon.Stick;
                                                user.EXP = 0;
                                                user.Shield = null;
                                                Console.WriteLine("Let's start over and kill all the monsters...");
                                                Console.ReadKey();
                                                StartMenu.entrance.EntranceBase(user, mst);
                                                //keepLooping = false;
                                            }
                                            break;
                                        case "n":
                                            {
                                                Console.WriteLine($"Press any key to quit...");
                                                Console.ReadKey();
                                                Graphic.StoryEnd(user, mst);
                                                Environment.Exit(0);
                                            }
                                            break;
                                        default:
                                            {
                                                Console.WriteLine("Invalid input. Do you want to start over? Y/N\n");
                                                userAnswer = Console.ReadLine().ToLower();
                                            }
                                            break;
                                    }
                                } while (keepLooping);
                            }
                            // Console.ReadKey();
                            Sound.BattleMusic();
                        }
                        break;
                    case 2:
                        {
                            //to check if user's Max attack is greater than the monsters “Max attack” 
                            int userAtkMax2 = Convert.ToInt32(userAtkRange.Substring(userAtkRange.IndexOf("-") + 1, userAtkRange.IndexOf(")") - userAtkRange.IndexOf("-") - 1));
                            int mstAtkMax2 = Convert.ToInt32(mstAtkRange.Substring(mstAtkRange.IndexOf("-") + 1, mstAtkRange.IndexOf(")") - mstAtkRange.IndexOf("-") - 1));
                            if (userAtkMax2 > mstAtkMax2)
                            {
                                Console.WriteLine("I don't want to waste time on you little poor thing, I'm going away now...");
                                Console.ReadKey();
                                //StartMenu.entrance.EntranceBase(user);
                                Location(user, mst);
                            }
                            else
                            {
                                Sound.CantRunAway();
                                Console.WriteLine("You can't ran away at this moment...");
                                Console.ReadKey();
                                Battle(user, mst, weapon);
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Confirm to quit the game? Y/N\n");
                            string userAnswer = Console.ReadLine().ToLower();
                            bool keepLooping = true;
                            do
                            {
                                if (userAnswer == "y")
                                {
                                    Graphic.StoryEnd(user, mst);
                                    Environment.Exit(0);
                                }
                                else if (userAnswer == "n")
                                {
                                    Battle(user, mst, weapon);
                                    //keepLooping = false;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Confirm to quit the game? Y/N\n");
                                    userAnswer = Console.ReadLine().ToLower();
                                }
                            } while (keepLooping);
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid input. Enter a number between 1 and 4");
                            Battle(user, mst, weapon);
                        }
                        break;
                }
            } while (userNum != 4);
        }
    }
}