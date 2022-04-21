using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ASC_Mandatory_assignment
{
    /// <summary>
    /// A DefenseItem such as armor has a DefenseValue which mitigates damage taken 1:1.
    /// It inherits from the abstract class Item
    /// </summary>
    public class DefenseItem : Item
    {
        #region Properties
        public int DefenseValue { get; set; }

        public Creature Wearer { get; set; }
        public string Name { get; set; }
        public World World { get; set; }
        #endregion


        public void Update()
        {
            WorldObject droppedLoot = new WorldObject($"{Wearer.Name}'s dropped armor",
                new Position(Wearer.CurrentPosition.X, Wearer.CurrentPosition.Y));
            droppedLoot.LootableDefenseItem = this;
            World.WorldObjectsInWorld.Add(droppedLoot);
        }
    }
}
