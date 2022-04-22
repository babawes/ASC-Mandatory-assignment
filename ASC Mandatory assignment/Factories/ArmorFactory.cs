using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC_Mandatory_assignment.Factories
{
    public class ArmorFactory : IItemFactory
    {
        public IItem CreateItem(string name, World world)
        {
            var rand = new Random();
            int defenseValue = rand.Next(1 - 10);
            
            DefenseItem newDefenseItem = new DefenseItem(defenseValue, name, world);
            return newDefenseItem;
        }
    }
}
