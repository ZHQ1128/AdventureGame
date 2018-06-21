using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGameAssignment.Models
{
    class Graphic
    {
        protected static int origRow;
        protected static int origCol;
        public static List<Monster> mList = Monster.MonsterList();
        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
        public static void User(User user)
        {
            // Clear the screen, then save the top and left coordinates.
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            WriteAt("+", 0, 0);
            WriteAt("|", 0, 1);
            WriteAt("|", 0, 2);
            WriteAt("|", 0, 3);
            WriteAt("+", 0, 4);
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (user.Shield == null)
            {
                WriteAt($"User: {user.Name}", 2, 1);
                WriteAt($"HP: {user.HP}/100 | Gold: {user.Gold} | EXP: {user.EXP} ", 2, 2);
                WriteAt($"Weapon: {user.Weapon.Name} | Attack Range: {user.Weapon.AttackRange}", 2, 3);
            }
            else
            {
                WriteAt($"User: {user.Name}", 2, 1);
                WriteAt($"HP: {user.HP}/{100 + user.Shield.HP} | Gold: {user.Gold} | EXP: {user.EXP} ", 2, 2);
                WriteAt($"Weapon: {user.Weapon.Name} | Attack Range: {user.Weapon.AttackRange} | Shield: {user.Shield.Name}", 2, 3);
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            // Draw the bottom side, from left to right.
            WriteAt("----------------------------------------------------------------", 1, 4); // 数字不要动， 加---即可延长

            // Draw the right side, from bottom to top. 如果需要更长，20改成30
            WriteAt("+", 65, 4);
            WriteAt("|", 65, 3);
            WriteAt("|", 65, 2);
            WriteAt("|", 65, 1);
            WriteAt("+", 65, 0);
            // Draw the top side, from right to left.
            WriteAt("----------------------------------------------------------------", 1, 0); // 数字不要动， 加---即可延长
            Console.ResetColor();
            WriteAt("",0,4);
            Console.WriteLine();
        }
        public static void StoryBgn(User user)
        {
            User(user);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            WriteAt("+", 0, 1);
            WriteAt("|", 0, 2);
            WriteAt("|", 0, 3);
            WriteAt("|", 0, 4);
            WriteAt("|", 0, 5);
            WriteAt("|", 0, 6);
            WriteAt("|", 0, 7);
            WriteAt("|", 0, 8);
            WriteAt("|", 0, 9);
            WriteAt("|", 0, 10);
            WriteAt("|", 0, 11);
            WriteAt("|", 0, 12);
            WriteAt("|", 0, 13);
            WriteAt("|", 0, 14);
            WriteAt("+", 0, 15);
            WriteAt("The princess Elisa has been prisoned by the monsters in the forest for decades. There have been", 1, 3);
            WriteAt("some young men tried to fight with the monsters and to rescue the princess, but no one could make", 1, 5);
            WriteAt("it. The King monster is giant and no man could ever beat him, please try everything to kill him", 1, 7);
            WriteAt("and free the princess.", 1, 9);
            WriteAt("We wish you luck and now enter any key to start your journey...", 1,12);

            // Draw the bottom side, from left to right.
            WriteAt("----------------------------------------------------------------------------------------------------", 1, 15); // 数字不要动， 加---即可延长

            // Draw the right side, from bottom to top. 如果需要更长，20改成30

            WriteAt("+", 100, 15);
            WriteAt("|", 100, 14);
            WriteAt("|", 100, 13);
            WriteAt("|", 100, 12);
            WriteAt("|", 100, 11);
            WriteAt("|", 100, 10);
            WriteAt("|", 100, 9);
            WriteAt("|", 100, 8);
            WriteAt("|", 100, 7);
            WriteAt("|", 100, 6);
            WriteAt("|", 100, 5);
            WriteAt("|", 100, 4);
            WriteAt("|", 100, 3);
            WriteAt("|", 100, 2);
            WriteAt("+", 100, 1);

            // Draw the top side, from right to left.
            WriteAt("---------------------------------------------------------------------------------------------------", 1, 1); // 数字不要动， 加---即可延长

            Console.ResetColor();
            WriteAt("", 0, 16);
            Console.WriteLine();
        }

        // 3 story endings
        public static void StoryEnd(User user, Monster mst)
        {
            User(user);
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            WriteAt("+", 0, 1);
            WriteAt("|", 0, 2);
            WriteAt("|", 0, 3);
            WriteAt("|", 0, 4);
            WriteAt("|", 0, 5);
            WriteAt("|", 0, 6);
            WriteAt("|", 0, 7);
            WriteAt("|", 0, 8);
            WriteAt("+", 0, 9);

            if (mst == null)
            {
                WriteAt("You haven't met a single monster yet and you want to quit now?!... Fine, it's your decision,", 1, 3);
                WriteAt("we respect it...We are still grateful for your participation and we will be waiting here as", 1, 5);
                WriteAt("usual to welcome the next hero whoever wants to take the adventure.", 1, 7);
            }
            else if (user.HP == 0)
            {
                WriteAt("Too sad the young man got killed by the monsters, he has tried his best though...", 1, 3);
                WriteAt("The princess Elisa is still waiting for someone to save her.", 1, 5);
                WriteAt("And we'll be waiting here too...", 1, 7);
            }
            else if (mst.Num == 21 && mst.HP == 0)
                {
                Console.ForegroundColor = ConsoleColor.Gray;
                WriteAt("The king monster was finally dead and the princess Elise could go back to her palace. The brave young", 1, 3);
                WriteAt("man got badly injured during the battle but the princess took good care of him. They end up marrying", 1, 5);
                WriteAt("and then live happily ever after...Sorry for such a boring ending:)", 1, 7);
                Console.ResetColor();
            }
            else
            {
                WriteAt("Young man, so glad to see you are back alive. We understand, the king monster is just too tough", 1, 3);
                WriteAt("and hard to be killed. We are too old to fight for our princess, but we will be here waiting for", 1, 5);
                WriteAt("other heroes like you to rescue her. Hopefully she will be free soon...", 1, 7);
            }

            // Draw the bottom side, from left to right.
            WriteAt("----------------------------------------------------------------------------------------------------", 1, 9); 
            WriteAt("+", 100, 9);
            WriteAt("|", 100, 8);
            WriteAt("|", 100, 7);
            WriteAt("|", 100, 6);
            WriteAt("|", 100, 5);
            WriteAt("|", 100, 4);
            WriteAt("|", 100, 3);
            WriteAt("|", 100, 2);
            WriteAt("+", 100, 1);
            WriteAt("---------------------------------------------------------------------------------------------------", 1, 1); 
            Console.ResetColor();
            WriteAt("", 0, 10);
            Console.WriteLine();
        }  
        public static void Store(User user)
        {
            User(user);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            WriteAt("+", 0, 1);
            WriteAt("|", 0, 2);
            WriteAt("|", 0, 3);
            WriteAt("|", 0, 4);
            WriteAt("|", 0, 5);
            WriteAt("|", 0, 6);
            WriteAt("|", 0, 7);
            WriteAt("|", 0, 8);
            WriteAt("|", 0, 9);
            WriteAt("|", 0, 10);
            WriteAt("|", 0, 11);
            WriteAt("|", 0, 12);
            WriteAt("|", 0, 13);
            WriteAt("|", 0, 14);
            WriteAt("|", 0, 15);
            WriteAt("|", 0, 16);
            WriteAt("|", 0, 17);
            WriteAt("|", 0, 18);
            WriteAt("|", 0, 19);
            WriteAt("|", 0, 20);
            WriteAt("|", 0, 21);
            WriteAt("|", 0, 22);
            WriteAt("|", 0, 23);
            WriteAt("|", 0, 24);
            WriteAt("|", 0, 25);
            WriteAt("+", 0, 26);
            WriteAt($"Welcome {StartMenu.user.Name}!", 2, 2);
            WriteAt("I have both offensive and defensive items for sale. Read the list below for more details and feel", 2, 4);
            WriteAt("free to buy whatever you want from the list.", 2, 5);
            WriteAt("Oops! Everytime you kill 3 monsters, your EXP value will be increased by 1. Once your EXP value is", 2, 8);
            WriteAt("equal to or higher than 3, one secret item will be unlocked for you. Good Luck!", 2, 9);
            WriteAt("Offensive Items:", 2, 11);
            for (int i = 1; i < Weapon.weapons.Count(); i++)
            {
                WriteAt($"|", 12, 12 + i);
                WriteAt($"|", 32, 12 + i);
                WriteAt($"|", 59, 12 + i);
                WriteAt($"{i}. {Weapon.weapons[i].Name}", 2, 12 + i);  // omit the first (auto equipped) item from the weapon list
                WriteAt($"Price: {Weapon.weapons[i].Price} Gold", 15, 12 + i);
                WriteAt($"Attack Range: {Weapon.weapons[i].AttackRange}", 35, 12 + i);
                //WriteAt($"{i + 1}. {Weapon.weapons[i].Name}", 2, 16);  // testing
            }

            WriteAt("Defensive Items:", 2, 17);
            for (int i = 0; i < Shield.shields.Count(); i++)
            {
                WriteAt($"|", 20, 19 + i);
                WriteAt($"|", 40, 19 + i);
                WriteAt($"|", 51, 19 + i);
                WriteAt($"{i + Weapon.weapons.Count()}. {Shield.shields[i].Name}", 2, 19 + i);
                WriteAt($"Price: {Shield.shields[i].Price} Gold", 23, 19 + i);
                WriteAt($"HP: {Shield.shields[i].HP}", 43, 19 + i);
                //WriteAt($"{i + 1}. {Weapon.weapons[i].Name}", 2, 22);  // testing
            }
            WriteAt($"{Weapon.weapons.Count()+ Shield.shields.Count()}. Leaving the store...", 2, 24);
            // Draw the bottom side, from left to right.
            WriteAt("---------------------------------------------------------------------------------------------------", 1, 26); // 数字不要动， 加---即可延长
            // Draw the right side, from bottom to top. 如果需要更长，20改成30
            WriteAt("+", 100, 26);
            WriteAt("|", 100, 25);
            WriteAt("|", 100, 24);
            WriteAt("|", 100, 23);
            WriteAt("|", 100, 22);
            WriteAt("|", 100, 21);
            WriteAt("|", 100, 20);
            WriteAt("|", 100, 19);
            WriteAt("|", 100, 18);
            WriteAt("|", 100, 17);
            WriteAt("|", 100, 16);
            WriteAt("|", 100, 15);
            WriteAt("|", 100, 14);
            WriteAt("|", 100, 13);
            WriteAt("|", 100, 12);
            WriteAt("|", 100, 11);
            WriteAt("|", 100, 10);
            WriteAt("|", 100, 9);
            WriteAt("|", 100, 8);
            WriteAt("|", 100, 7);
            WriteAt("|", 100, 6);
            WriteAt("|", 100, 5);
            WriteAt("|", 100, 4);
            WriteAt("|", 100, 3);
            WriteAt("|", 100, 2);
            WriteAt("+", 100, 1);
            // Draw the top side, from right to left.
            WriteAt("---------------------------------------------------------------------------------------------------", 1, 1); // 数字不要动， 加---即可延长
            Console.ResetColor();
            WriteAt("", 0, 25);
            Console.WriteLine();
        }
        public static void Forest(User user)
        {
            User(user);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            WriteAt("+", 0, 1);
            WriteAt("|", 0, 2);
            WriteAt("|", 0, 3);
            WriteAt("|", 0, 4);
            WriteAt("|", 0, 5);
            WriteAt("|", 0, 6);
            WriteAt("|", 0, 7);
            WriteAt("|", 0, 8);
            WriteAt("|", 0, 9);
            WriteAt("+", 0, 10);
            WriteAt("There are many monsters living in this forest, they all serve in the King monster's army. The", 2, 3);
            WriteAt("princess Elisa is prisoned in a castle nearby the morass, where the King monster lives. Only the", 2, 4);
            WriteAt("king monster has the key to the castle, so you need to kill the king monster to save the princess.", 2, 5);
            WriteAt("I would recommend you to start fighting with the easy ones, it's not a good idea that you go", 2, 7); 
            WriteAt("fighting with the king monster before you equiped yourself with a good weapon and shield...", 2, 8);
            // Draw the bottom side, from left to right.
            WriteAt("---------------------------------------------------------------------------------------------------", 1, 10); // 数字不要动， 加---即可延长
            // Draw the right side, from bottom to top. 如果需要更长，20改成30
            WriteAt("+", 100, 10);
            WriteAt("|", 100, 9);
            WriteAt("|", 100, 8);
            WriteAt("|", 100, 7);
            WriteAt("|", 100, 6);
            WriteAt("|", 100, 5);
            WriteAt("|", 100, 4);
            WriteAt("|", 100, 3);
            WriteAt("|", 100, 2);
            WriteAt("+", 100, 1);

            // Draw the top side, from right to left.
            WriteAt("---------------------------------------------------------------------------------------------------", 1, 1); // 数字不要动， 加---即可延长

            Console.ResetColor();
            WriteAt("", 0, 11);
            Console.WriteLine();
        }
        public static void Tavern(User user)
        {
            User(user);
            Console.ForegroundColor = ConsoleColor.Blue;
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            WriteAt("+", 0, 1);
            WriteAt("|", 0, 2);
            WriteAt("|", 0, 3);
            WriteAt("|", 0, 4);
            WriteAt("|", 0, 5);
            WriteAt("|", 0, 6);
            WriteAt("|", 0, 7);
            WriteAt("|", 0, 8);
            WriteAt("|", 0, 9);
            WriteAt("+", 0, 10);
            WriteAt($"Hey {StartMenu.user.Name}!", 2, 3);
            WriteAt("Welcome to the Tavern Hall.", 2, 4);
            WriteAt("Every time you visit the Tavern Hall, your health will be fully restored,", 2, 5);
            WriteAt("Enjoy your stay here.", 2, 6);
            // Draw the bottom side, from left to right.
            WriteAt("---------------------------------------------------------------------------------------------------", 1, 10); // 数字不要动， 加---即可延长
            // Draw the right side, from bottom to top. 如果需要更长，20改成30
            WriteAt("+", 100, 10);
            WriteAt("|", 100, 9);
            WriteAt("|", 100, 8);
            WriteAt("|", 100, 7);
            WriteAt("|", 100, 6);
            WriteAt("|", 100, 5);
            WriteAt("|", 100, 4);
            WriteAt("|", 100, 3);
            WriteAt("|", 100, 2);
            WriteAt("+", 100, 1);

            // Draw the top side, from right to left.
            WriteAt("---------------------------------------------------------------------------------------------------", 1, 1); // 数字不要动， 加---即可延长

            Console.ResetColor();
            WriteAt("", 0, 11);
            Console.WriteLine();
        }
        public static void MonsterGraphic(Monster mst, User user)
        {
            User(user);
            Console.ForegroundColor = ConsoleColor.White;
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;
            WriteAt("+", 0, 0);
            WriteAt("|", 0, 1);
            WriteAt("|", 0, 2);
            //WriteAt("|", 66, 8);
            //WriteAt("|", 66, 9);
            WriteAt("+", 0, 3);
            WriteAt($"Monster: {mst.Name}", 2,1);
            if (mst.Num==21)
            {
                WriteAt($"HP: {mst.HP}/150 | Attack Range: {mst.AttackRange}", 2, 2);
            }
            else
            {
                var obj = mList.Single(m => m.Num == mst.Num);
                WriteAt($"HP: {mst.HP}/{obj.HP} | Attack Range: {mst.AttackRange}", 2, 2);
            }
            // Draw the bottom side, from left to right.
            WriteAt("----------------------------------------------------------------", 1,3); // 数字不要动， 加---即可延长
            // Draw the right side, from bottom to top. 如果需要更长，20改成30
            WriteAt("+", 65, 3);
            //WriteAt("|", 120, 5);
            //WriteAt("|", 120, 4);
            //WriteAt("|", 120, 3);
            WriteAt("|", 65, 2);
            WriteAt("|", 65, 1);
            WriteAt("+", 65, 0);
            // Draw the top side, from right to left.
            WriteAt("----------------------------------------------------------------", 1,0); // 数字不要动， 加---即可延长

            Console.ResetColor();
            WriteAt("", 0, 4);
            Console.WriteLine();
        }
        public static void NewItemNotice(User user)
        {
            Console.ForegroundColor = ConsoleColor.White;
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            WriteAt("+", 0, 0);
            WriteAt("|", 0, 1);
            WriteAt("|", 0, 2);
            WriteAt("+", 0, 3);
            Console.ForegroundColor = ConsoleColor.Magenta;
            WriteAt($"<-NEW ITEM UNLOCKED->", 2, 1);
            Console.ResetColor();
            //WriteAt($"HP: {user.HP}/100  |  Gold: {user.Gold}  |  EXP: {user.EXP}  |  Weapon: {user.Weapon.Name}", 2, 2);
            WriteAt("Go to Store to check it up!", 2, 2);
            Console.ForegroundColor = ConsoleColor.White;
            WriteAt("------------------------------", 1, 3);
            WriteAt("+", 31, 3);
            WriteAt("|", 31, 2);
            WriteAt("|", 31, 1);
            WriteAt("+", 31, 0);
            WriteAt("------------------------------", 1, 0); 
            Console.ResetColor();
            WriteAt("", 0, 4);
            Console.WriteLine();
        }
        public static void Damage(User user, Monster mst)
        {
            Console.ForegroundColor = ConsoleColor.White;
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            WriteAt("+", 0, 0);
            WriteAt("|", 0, 1);
            WriteAt("|", 0, 2);
            WriteAt("+", 0, 3);
            WriteAt($"{mst.Name} got {user.Weapon.Attack} damage.", 2, 1);
            //WriteAt($"HP: {user.HP}/100  |  Gold: {user.Gold}  |  EXP: {user.EXP}  |  Weapon: {user.Weapon.Name}", 2, 2);
            WriteAt($"{user.Name} got {mst.Attack} damage.", 2, 2);
            WriteAt("------------------------------", 1, 3);
            WriteAt("+", 31, 3);
            WriteAt("|", 31, 2);
            WriteAt("|", 31, 1);
            WriteAt("+", 31, 0);
            WriteAt("------------------------------", 1, 0);
            Console.ResetColor();
            WriteAt("", 0, 4);
            Console.WriteLine();
        }
    }

}
