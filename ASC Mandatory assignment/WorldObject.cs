using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ASC_Mandatory_assignment.Interfaces;

namespace ASC_Mandatory_assignment
{
    /// <summary>
    /// A WorldObject such as a chest, it Contains an AttackItem LootableWeapon, and a DefenseItem LootableDefenseItem.
    /// It also has a Position, a Name, and 2 booleans that define if it is Lootable and Removable
    /// </summary>
    public class WorldObject : IWorldObject
    {
        #region Properties

        public bool Lootable { get; set; }
        public string Name { get; set; }
        public bool Removable { get; set; }
        public Position CurrentPosition { get; set; }
        public AttackItem LootableWeapon { get; set; }
        public DefenseItem LootableDefenseItem { get; set; }

        #endregion

        public WorldObject()
        {
            
        }
        
        public WorldObject(string name, Position position)
        {
            Name = name;
            CurrentPosition = position;
            LootableDefenseItem = null;
            LootableWeapon = null;
            Lootable = true;
            Removable = true;

        }
        
        
    }
}
