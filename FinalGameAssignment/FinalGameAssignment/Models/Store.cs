using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGameAssignment.Models
{
    class Store
    {
        public Forest forest = new Forest();

        public void ChooseItem(User user, Monster mst)
        {
            Graphic.User(user);
            Graphic.Store(user);
            Sound.StoreMusic();
            Random rand = new Random();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nSelect your option listed above:");
            //Console.WriteLine($"SHield ITem numners: {Shield.shields.Count()}"); // for testing
            bool itemChoice = Int32.TryParse(Console.ReadLine(), out int itemN);
            switch (itemN)
            {
                case 1:
                    {
                        var sWeapon = Weapon.weapons.Single(w => w.Name == "Sword");
                        BuyWeapon(user, sWeapon, mst);
                    }
                    break;

                case 2:
                    {
                        var aWeapon = Weapon.weapons.Single(w => w.Name == "Axe");
                        BuyWeapon(user, aWeapon, mst);
                    }
                    break;

                case 3:
                    {
                        var mWeapon = Weapon.weapons.Single(w => w.Name == "Mace");
                        BuyWeapon(user, mWeapon, mst);
                    }
                    break;
                case 4:
                    {
                        var wShield = Shield.shields.Single(w => w.Name == "Wooden Shield");
                        BuyShield(user, wShield, mst);
                    }
                    break;

                case 5:
                    {
                        var bShield = Shield.shields.Single(w => w.Name == "Bronze Shield");
                        BuyShield(user, bShield, mst);
                    }
                    break;
                case 6:
                    {
                        var sShield = Shield.shields.Single(w => w.Name == "Silver Shield");
                        BuyShield(user, sShield, mst);
                    }
                    break;

                case 7:
                    {
                        if (Shield.shields.Count() == 3)
                        {
                            StartMenu.entrance.EntranceBase(user, mst);
                        }
                        else
                        {
                            var gShield = Shield.shields.Single(w => w.Name == "Gold Shield");
                            BuyShield(user, gShield, mst);
                        }
                    }
                    break;
                case 8:
                    {
                        if (Shield.shields.Count() == 4)
                        {
                            StartMenu.entrance.EntranceBase(user, mst);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 1 and 7.");
                            Console.ReadKey();
                            ChooseItem(user, mst);
                        }
                    }
                    break;

                default:
                    {
                        if (Shield.shields.Count() == 3)
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 1 and 7.");

                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 1 and 8.");
                        }
                       // Console.ReadKey();
                        ChooseItem(user, mst);
                    }
                    break;
            }
            Console.ResetColor();
            Sound.StopMusic();
        }

        public void BuyWeapon(User user, Weapon weapon, Monster mst)
        {
            if (user.Gold < weapon.Price)
            {
                Console.WriteLine("You don't have enough gold to buy this item\n");
                Console.WriteLine("Do you want to earn some gold by killing the monsters? Y/N\n");
                string userAnswer = Console.ReadLine().ToLower();
                bool keepLooping = true;
                do
                {
                    switch (userAnswer)
                    {
                        case "y":
                            {
                                Console.WriteLine("Going to the forest to fight monsters...");
                                Console.ReadKey();
                                //Sound.StopMusic();
                                forest.Location(user, mst);
                                keepLooping = false;
                            }
                            break;
                        case "n":
                            {
                                Console.WriteLine("Okay! Press any key to go back...");
                                Console.ReadKey();
                                ChooseItem(user, mst);
                                keepLooping = false;
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Invalid input. Do you want to earn some gold by killing the monsters? Y/N\n");
                                userAnswer = Console.ReadLine().ToLower();
                            }
                            break;
                    }
                } while (keepLooping);
            }
            else
            {
                Console.WriteLine("Confirm to purchase? Y/N");
                string userAnswer = Console.ReadLine().ToLower();
                bool keepLooping = true;
                do
                {
                    switch (userAnswer)
                    {
                        case "y":
                            {
                                // To avoid plusing shield's HP again when user has already 
                                //equiped this shield and with full HP!
                                if (user.Weapon != weapon)
                                {
                                    user.Gold -= weapon.Price;
                                    user.Weapon = weapon;
                                    //userItems.UserWList(user, weapon);
                                    //Console.WriteLine($"Name:{user.Name} HP: {user.HP} Gold: {user.Gold}");
                                    Console.WriteLine($"You bought a weapon: {user.Weapon.Name}, Attack Range: {user.Weapon.AttackRange}");
                                    Console.ReadKey();
                                    StartMenu.entrance.EntranceBase(user, mst);
                                }
                                else if (user.Weapon == weapon)
                                {
                                    Console.WriteLine("You are equipped with this weapon, don't waste your gold.");
                                    Console.ReadKey();
                                    ChooseItem(user, mst);
                                }
                                keepLooping = false;
                            }
                            break;
                        case "n":
                            {
                                Console.WriteLine("Purchase canceled. Press any key to continue...");
                                Console.ReadKey();
                                ChooseItem(user, mst);
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Invalid input. Confirm to purchase? Y/N");
                                userAnswer = Console.ReadLine().ToLower();
                            }
                            break;
                    }
                } while (keepLooping);
            }
        }

        public void BuyShield(User user, Shield shield, Monster mst)
        {
            if (user.Gold < shield.Price)
            {
                Console.WriteLine("You don't have enough gold to buy this item\n");
                Console.WriteLine("Do you want to earn some gold by killing the monsters? Y/N");
                string userAnswer = Console.ReadLine().ToLower();
                bool keepLooping = true;
                do
                {
                    switch (userAnswer)
                    {
                        case "y":
                            {
                                Console.WriteLine("Press any key to go forest and fight with monsters...");
                                Console.ReadKey();
                                forest.Location(user, mst);
                                keepLooping = false;
                            }
                            break;
                        case "n":
                            {
                                Console.WriteLine("Okay! Press any key to go back...");
                                Console.ReadKey();
                                ChooseItem(user, mst);
                                keepLooping = false;
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Invalid input. Do you want to earn some gold by killing the monsters? Y/N");
                                userAnswer = Console.ReadLine().ToLower();
                            }
                            break;
                    }
                } while (keepLooping);
            }
            else
            {
                Console.WriteLine("Confirm to purchase? Y/N");
                string userAnswer = Console.ReadLine().ToLower();
                bool keepLooping = true;
                do
                {
                    switch (userAnswer)
                    {
                        case "y":
                            {
                                // To avoid plusing shield's HP again when user has already 
                                //equiped this shield and with full HP!
                                if (user.Shield == null)
                                {
                                    user.Gold -= shield.Price;
                                    user.Shield = shield;
                                    user.HP += shield.HP;
                                    Console.WriteLine($"You bought a shield: {user.Shield.Name} HP: {user.Shield.HP}");
                                    Console.ReadKey();
                                    StartMenu.entrance.EntranceBase(user, mst);
                                }
                                else if (user.Shield == shield) 
                                {
                                    Console.WriteLine("You are equipped with this shield, don't waste your gold.");
                                    Console.ReadKey();
                                    ChooseItem(user, mst);
                                }
                                else  // user.Shield != shield 
                                {
                                    user.Gold -= shield.Price;  // Important!!!
                                    user.HP -= user.Shield.HP; // when changing shield, remove the old shield's HP value first
                                    user.Shield = shield;  // then add the new shield's HP value
                                    user.HP += shield.HP;  // to avoiding overlapping two shields' HP values
                                    Console.WriteLine($"You bought a shield: {user.Shield.Name} HP: {user.Shield.HP}");
                                    Console.ReadKey();
                                    StartMenu.entrance.EntranceBase(user, mst);
                                }
                                keepLooping = false;
                            }
                            break;
                        case "n":
                            {
                                Console.WriteLine("Purchase canceled. Press any key to continue...");
                                //Console.ReadKey();
                                ChooseItem(user, mst);
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Invalid input. Confirm to purchase? Y/N");
                                userAnswer = Console.ReadLine().ToLower();
                            }
                            break;
                    }
                } while (keepLooping);
            }
        }
    }
}
