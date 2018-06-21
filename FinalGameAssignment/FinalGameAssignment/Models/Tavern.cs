using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGameAssignment.Models
{
    class Tavern
    {
        public void Healing(User user, Monster mst)
        {
            Graphic.Tavern(user);
            Sound.TavernMusic();
            Console.ForegroundColor = ConsoleColor.Blue;
            if (user.Shield != null)
            {
                user.HP = 100 + user.Shield.HP;
                   Console.WriteLine($"Your Health is fully restored. Your HP value: {100 + user.Shield.HP}\n");
                   Console.ReadKey();
                   StartMenu.entrance.EntranceBase(user, mst);
            }
            else
            {
                user.HP = 100;
                    Console.WriteLine($"Your Health is fully restored. Your HP value: 100\n");
                    Console.ReadKey();
                    StartMenu.entrance.EntranceBase(user, mst);
            }
            Sound.StopMusic();
        }
    }
}
