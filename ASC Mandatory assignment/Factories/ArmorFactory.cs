using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC_Mandatory_assignment.Factories
{
    /// <summary>
    /// A factory class for creating a DefenseItem with a given Name in a given World, the DefenseValue is randomly generated
    /// </summary>
    public class ArmorFactory : IItemFactory
    {
        /// <summary>
        /// Generates a DefenseItem with a random DefenseValue
        /// </summary>
        /// <param name="name">The Name for the DefenseItem</param>
        /// <param name="world">The World in which it is generated</param>
        /// <returns></returns>
        public IItem CreateItem(string name, World world)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            int defenseValue = rand.Next(1 - 10);
            
            DefenseItem newDefenseItem = new DefenseItem(defenseValue, name, world);
            return newDefenseItem;
        }
    }
}
