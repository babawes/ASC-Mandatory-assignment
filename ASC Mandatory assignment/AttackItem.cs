using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC_Mandatory_assignment
{
    /// <summary>
    /// An AttackItem is a weapon and has an AttackValue how much damage it does, and an AttackRange how far it can reach or shoot.
    /// It inherits from the abstract class Item
    /// /// The update method is called when the Dead state of the creature wearing it becomes true, and causes it to drop in the world contained in a world object at the dead Creatures position
    /// </summary>
    public class AttackItem : Item
    {
        #region Properties
        public int AttackValue { get; set; }

        public int AttackRange { get; set; }

        public Creature Wearer { get; set; }
        public string Name { get; set; }
        public World World { get; set; }
        #endregion



        public void Update()
        {
            WorldObject droppedLoot = new WorldObject($"{Wearer.Name}'s dropped weapon",
                new Position(Wearer.CurrentPosition.X, Wearer.CurrentPosition.Y));
            droppedLoot.LootableWeapon = this;
            World.WorldObjectsInWorld.Add(droppedLoot);
            Wearer.CurrentWeapon = null;
            Wearer = null;
        }


    }
}
