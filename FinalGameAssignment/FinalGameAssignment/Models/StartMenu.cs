using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalGameAssignment.CustomExceptions;

namespace FinalGameAssignment.Models
{
    class StartMenu
    {
        public static Entrance entrance = new Entrance();
        public static User user;
        public static void StartProgram()
        {
            bool keepGoing = true;
            Console.WriteLine("Please give your character a name before you start your adventure.\n" +
                "(Your user name cannot be longer than 15 characters)");
            string userInput = Console.ReadLine();
            do
            {
                if (userInput.Length > 15|| userInput == ""||userInput.Contains("\t"))
                {
                    Console.WriteLine("Invalid user name, please enter a name not longer than 15 characters.");
                    userInput = Console.ReadLine();
                    Console.ReadKey();
                }
                else
                { 
                    user = new User(userInput);
                    Graphic.User(user);
                    keepGoing = false;
                }
            } while (keepGoing);
            
            Console.WriteLine("Would you like to give your character an age? Y/N");
            string userAnswer = Console.ReadLine().ToLower();
            bool keepLooping = true;
            do
            {
                switch (userAnswer)
                {
                    case "y":
                        {
                            Console.WriteLine($"Please set an age for your character");
                            bool ageCheck = Int32.TryParse(Console.ReadLine(), out int age);
                            do
                            {
                               // if (ageCheck != false && age > 0 && age <=100)
                               if (ageCheck != false && age > 0)
                               {
                                    user.Age = age;
                                    Console.WriteLine($"Great! Your character's age has set as {age}");
                                    Console.ReadKey();
                                    keepLooping = false;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a number");
                                    ageCheck = Int32.TryParse(Console.ReadLine(), out age);
                                    //Console.ReadKey();
                                }
                            } while (keepLooping);
                            keepLooping = false;
                        }
                        break;
                    case "n":
                        {
                            Console.WriteLine("Okay, skip setting age...");
                            Console.ReadKey();
                            keepLooping = false;
                        }                     
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid input. Would you like to give your character an age? Y/N");
                            userAnswer = Console.ReadLine().ToLower();
                        }
                        break;
                }
            } while (keepLooping);

           // Graphic.User(user, weapon);
            Graphic.StoryBgn(user);
            Console.ReadKey();
            Monster mst = null;
            entrance.EntranceBase(user, mst);
        }
    }
}


//4.Inventory
