using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC_Mandatory_assignment.Interfaces
{
    public interface IWorldObject
    {
        public bool Lootable { get; set; }
        public string Name { get; set; }
        public bool Removable { get; set; }
        public Position CurrentPosition { get; set; }
        public AttackItem LootableWeapon { get; set; }
        public DefenseItem LootableDefenseItem { get; set; }



    }
}
