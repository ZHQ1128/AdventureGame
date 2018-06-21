using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGameAssignment.Models
{
    class Weapon
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Attack { get; set; }
        public string AttackRange { get; set; }
        public static Weapon Stick = new Weapon { Name = "Stick", Price = 0, Attack = 0, AttackRange = "(2 - 5)" };

        public static List<Weapon> weapons = WeaponList();
        public static List<Weapon> WeaponList()
        {
            var weaponList = new List<Weapon>();
            weaponList.Add(new Weapon { Name = "Stick", Price = 0, Attack = 0, AttackRange = "(2 - 7)" });
            weaponList.Add(new Weapon { Name = "Sword", Price = 20, Attack = 0, AttackRange = "(8 - 15)" });
            weaponList.Add(new Weapon { Name = "Axe", Price = 60, Attack = 0, AttackRange = "(15 - 30)" });
            weaponList.Add(new Weapon { Name = "Mace", Price = 100, Attack = 0, AttackRange = "(45 - 55)" });
            return weaponList;
        }
    }
}
