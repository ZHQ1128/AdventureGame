using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGameAssignment.Models
{
    class Entrance
    {
        public Store store = new Store();
        public Forest forest = new Forest();
        public Tavern tavern = new Tavern();
        public void EntranceBase(User user, Monster mst)
        {
            Graphic.User(user);
            Sound.StopMusic();
            //Graphic.Entrance();
            Console.WriteLine("1. Forest: To fight with monsters\n2. Store: To buy equipment\n3. Tavern Hall: To restore health\n4. Quit Game\n");
            bool userInput = Int32.TryParse(Console.ReadLine(), out int userAnswer);
            switch (userAnswer)
            {
                case 1:
                    forest.Location(user, mst);
                    break;
                case 2:
                    store.ChooseItem(user, mst);
                    break;
                case 3:
                    tavern.Healing(user, mst);
                    break;
                case 4:
                    {
                        Console.WriteLine("Confirm to quit the game? Y/N");
                        string confirmAnswer = Console.ReadLine().ToLower();
                        bool keepLooping = true;
                        do
                        {
                            switch (confirmAnswer)
                            {
                                case "y":
                                    {
                                        Graphic.StoryEnd(user, mst);
                                        Environment.Exit(0);
                                    }
                                    break;
                                case "n":
                                    {
                                        EntranceBase(user, mst);

                                    }
                                    break;
                                default:
                                    {
                                        Console.WriteLine("Confirm to quit the game? Y/N");
                                        confirmAnswer = Console.ReadLine().ToLower();
                                    }
                                    break;
                            }
                        } while (keepLooping);
                    }
                    break;  
                default:
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                    Console.ReadKey();  //不能删，不然需要error handling
                    EntranceBase(user, mst);
                    break;
            }
        }
    }
}
