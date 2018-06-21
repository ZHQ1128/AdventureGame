using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGameAssignment.Models
{
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Gold { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int EXP { get; set; }
        public Weapon Weapon { get; set; }
        public Shield Shield { get; set; }

        public User(string name)
        {
            this.Name = name;
            this.HP = 100;
            this.Gold = 200;
            this.Weapon = Weapon.Stick;
            this.Shield = null;
            //this.EXP = 2;
        }
    }
}
