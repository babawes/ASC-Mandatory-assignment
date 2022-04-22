using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC_Mandatory_assignment.Factories
{
    public class WeaponFactory : IItemFactory
    {
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
