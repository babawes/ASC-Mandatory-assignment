using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC_Mandatory_assignment.Factories
{
    /// <summary>
    /// /// A factory class for creating an AttackItem with a given Name in a given World, the AttackValue and AttackRange are randomly generated
    /// </summary>
    public class WeaponFactory : IItemFactory
    {
        /// <summary>
        /// Generates an AttackItem with a random AttackValue and AttackRange
        /// </summary>
        /// <param name="name">The name of the AttackItem</param>
        /// <param name="world">The World in which it is generated</param>
        /// <returns></returns>
        public IItem CreateItem(string name, World world)
        {
            var rand = new Random();
            int attackValue = rand.Next(1 - 10);
            int attackRange = rand.Next(1 - 3);
            AttackItem newAttackItem = new AttackItem(attackValue, attackRange, name, world);
            return newAttackItem;
        }
    }
}
