using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC_Mandatory_assignment
{
    /// <summary>
    /// Interface for the Item class, both AttackItem and DefenseItem inherit from this
    /// </summary>
    public interface IItem
    {
        public Creature Wearer { get; set; }

        public string Name { get; set; }
        public World World { get; set; }

        /// <summary>
        /// An observer of the Dead state of the Creature who is Wearer of the item, if the Dead state of the Wearer becomes true after getting hit to 0 CurrentHitPoints this will be
        /// called, and a WorldObject containing the IItem will be created at the position of the Dead Wearer. It will also unequip the item from the Wearer
        /// </summary>
        public void Update();

    }
}
