using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC_Mandatory_assignment.Interfaces
{
    public interface ICreature
    {
        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public string Name { get; set; }
        public Position CurrentPosition { get; set; }
        public AttackItem CurrentWeapon { get; set; }
        public DefenseItem CurrentArmor { get; set; }
        public bool Diseased { get; set; }
        public bool Dead { get; set; }

        public void Hit(Creature creature);
        public void Loot(WorldObject item);

        public void ReceiveHit(int UnmitigatedDamage);


    }
}
