using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGameAssignment.Models
{
    class Monster
    {
        public int Num { get; set; }
        public string Name { get; set; }
        public int Attack { get; set; }
        public string AttackRange { get; set; }
        public int HP { get; set; }
        public int Gold { get; set; }
        //public event Sound { get; set; }

       // 根据level分开列monster lists
        public static List<Monster> MonsterList()
        {
            Random rand = new Random();
            var monsterList = new List<Monster>();
            // Sorry for the boring monster names :(((((
            //low level
            monsterList.Add(new Monster { Num = 1, Name = "Monster1", Attack = 0, Gold = rand.Next(10, 15), HP = 15, AttackRange = "(1 - 4)" });
            monsterList.Add(new Monster { Num = 2, Name = "Monster2", Attack = 0, Gold = rand.Next(11, 16), HP = 20, AttackRange = "(2 - 5)" });
            monsterList.Add(new Monster { Num = 3, Name = "Monster3", Attack = 0, Gold = rand.Next(12, 17), HP = 25, AttackRange = "(3 - 6)" });
            monsterList.Add(new Monster { Num = 4, Name = "Monster4", Attack = 0, Gold = rand.Next(13, 18), HP = 30, AttackRange = "(2 - 6)" });
            monsterList.Add(new Monster { Num = 5, Name = "Monster5", Attack = 0, Gold = rand.Next(14, 29), HP = 35, AttackRange = "(4 - 7)" });
            monsterList.Add(new Monster { Num = 6, Name = "Monster6", Attack = 0, Gold = rand.Next(15, 20), HP = 40, AttackRange = "(5 - 7)" });
            monsterList.Add(new Monster { Num = 7, Name = "Monster7", Attack = 0, Gold = rand.Next(16, 20), HP = 45, AttackRange = "(4 - 8)" });
            //medium level
            monsterList.Add(new Monster { Num = 8, Name = "Monster8", Attack = 0, Gold = rand.Next(20, 25), HP = 50, AttackRange = "(5 - 10)" });
            monsterList.Add(new Monster { Num = 9, Name = "Monster9", Attack = 0, Gold = rand.Next(21, 25), HP = 55, AttackRange = "(10 - 15)" });
            monsterList.Add(new Monster { Num = 10, Name = "Monster10", Attack = 0, Gold = rand.Next(22, 26), HP = 60, AttackRange = "(10 - 20)" });
            monsterList.Add(new Monster { Num = 11, Name = "Monster11", Attack = 0, Gold = rand.Next(23, 27), HP = 65, AttackRange = "(12 - 20)" });
            monsterList.Add(new Monster { Num = 12, Name = "Monster12", Attack = 0, Gold = rand.Next(24, 28), HP = 70, AttackRange = "(15 - 20)" });
            monsterList.Add(new Monster { Num = 13, Name = "Monster13", Attack = 0, Gold = rand.Next(25, 29), HP = 75, AttackRange = "(18 - 22)" });
            // high level
            monsterList.Add(new Monster { Num = 14, Name = "Monster14", Attack = 0, Gold = rand.Next(30, 35), HP = 80, AttackRange = "(18 - 25)" });
            monsterList.Add(new Monster { Num = 15, Name = "Monster15", Attack = 0, Gold = rand.Next(31, 36), HP = 85, AttackRange = "(25 - 28)" });
            monsterList.Add(new Monster { Num = 16, Name = "Monster16", Attack = 0, Gold = rand.Next(32, 37), HP = 85, AttackRange = "(25 - 30)" });
            monsterList.Add(new Monster { Num = 17, Name = "Monster17", Attack = 0, Gold = rand.Next(32, 38), HP = 85, AttackRange = "(25 - 30)" });
            // General monster
            monsterList.Add(new Monster { Num = 18, Name = "Monster18", Attack = 0, Gold = rand.Next(40, 45), HP = 90, AttackRange = "(30 - 35)" });
            monsterList.Add(new Monster { Num = 19, Name = "Monster19", Attack = 0, Gold = rand.Next(45, 50), HP = 95, AttackRange = "(35 - 40)" });
            monsterList.Add(new Monster { Num = 20, Name = "Monster20", Attack = 0, Gold = rand.Next(50, 55), HP = 100, AttackRange = "(40 - 45)" });
            // Boss
            monsterList.Add(new Monster { Num = 21, Name = "King Monster", Attack = 0, Gold = rand.Next(55, 70), HP = 150, AttackRange = "(50 - 75)" });

            return monsterList;
        }

        //public static Dictionary<string, int> mstAttackValue = Monster.MstAttackValue();
        //public static Dictionary<string, int> MstAttackValue()
        //{
        //    Random rand = new Random();
        //    var dictionary = new Dictionary<string, int>();
        //    dictionary.Add("Mini Monster", rand.Next(1, 5));
        //    dictionary.Add("Small Monster", rand.Next(3, 7));
        //    dictionary.Add("Medium Monster", rand.Next(5, 10));
        //    dictionary.Add("Medium-Large Monster", rand.Next(8, 12));
        //    dictionary.Add("Large Monster", rand.Next(15, 20));
        //    dictionary.Add("Boss Monster", rand.Next(30, 50));
        //    return dictionary;
        //}
    }
}
