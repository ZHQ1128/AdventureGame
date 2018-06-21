using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGameAssignment.Models
{
    class Shield
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int HP { get; set; }

        public static List<Shield> shields = ShieldList();
        public static List<Shield> ShieldList()
        {
            var shieldList = new List<Shield>();
                shieldList.Add(new Shield { Name = "Wooden Shield", Price = 20, HP = 10 });
                shieldList.Add(new Shield { Name = "Bronze Shield", Price = 40, HP = 20 });
                shieldList.Add(new Shield { Name = "Silver Shield", Price = 100, HP = 50 });
            return shieldList;
        }
    }
}
