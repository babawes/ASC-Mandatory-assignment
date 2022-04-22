using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ASC_Mandatory_assignment.Interfaces;

namespace ASC_Mandatory_assignment
{
    /// <summary>
    /// This class is for creatures in the world, they have a certain amount of MaxHitPoints and CurrentHitPoints, They can carry a CurrentWeapon and CurrentArmor.
    /// They have a position in the coordinate grid. They can Loot(WorldObject), which equips weapon and armor contained inside
    /// It has methods to Hit(Creature) and to ReceiveHit(int). The hit takes the AttackValue of the CurrentWeapon and hits a target Creature,
    /// The targeted Creature then calculates how much damage its armor mitigates. Both events are traced, so they can be logged as a sort of CombatLog
    /// It has a State Diseased, which causes it to deal half as much damage
    /// </summary>
    public class Creature  : ICreature
    {
        #region Properties
        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public string Name { get; set; }
        public Position CurrentPosition { get; set; }
        public AttackItem CurrentWeapon { get; set; }
        public DefenseItem CurrentArmor { get; set; }
        public bool Diseased { get; set; }
        public bool Dead { get; set; }
        private TraceSource CombatTrace;

        #endregion

        #region Methods

        /// <summary>
        /// This method will hit another target Creature with the CurrentWeapon, if no weapon is equipped the unarmed damage will be 1
        /// </summary>
        /// <param name="creature">This parameter is the target creature for the hit</param>
        public void Hit(Creature creature)
        {
            int attackValue;
            if (CurrentWeapon != null)
            {
                attackValue = this.CurrentWeapon.AttackValue;
            }
            else
            {
                attackValue = 1;
            }
            if (Diseased)
            {
                attackValue = attackValue / 2;
            }
            creature.ReceiveHit(attackValue);
            CombatTrace.TraceEvent(TraceEventType.Information, 1, $"{this.Name} attacked {creature.Name} with {this.CurrentWeapon.Name} for {attackValue} damage");
        }

        /// <summary>
        /// This method will loot a given WorldObject if it is Lootable, it will automatically equip the LootableWeapon and LootableDefenseItem
        /// </summary>
        /// <param name="item">The WorldObject to loot</param>
        public void Loot(WorldObject item)
        {
            if (item.Lootable)
            {
                if (CurrentWeapon != null)
                {
                    CurrentWeapon = item.LootableWeapon;
                }

                if (CurrentArmor != null)
                {
                    CurrentArmor = item.LootableDefenseItem;
                }

            }
        }


        /// <summary>
        /// This is the method for a creature to take a hit, the incoming UnmitigatedDamage is reduced by the DefenseValue of the CurrentArmor
        /// </summary>
        /// <param name="UnmitigatedDamage"></param>
        public void ReceiveHit(int UnmitigatedDamage)
        {
            int ActualDamage;
            if (CurrentArmor != null)
            {
                ActualDamage = UnmitigatedDamage - this.CurrentArmor.DefenseValue;
            }
            else
            {
                ActualDamage = UnmitigatedDamage;
            }
            if (ActualDamage < 0)
            {
                ActualDamage = 0;
            }
            this.CurrentHitPoints = this.CurrentHitPoints - (ActualDamage);
            CombatTrace.TraceEvent(TraceEventType.Information, 2, $"{this.Name} took {ActualDamage} damage, their armor mitigated up to {this.CurrentArmor.DefenseValue} damage");
            if (CurrentHitPoints <= 0)
            {
                Dead = true;
                CurrentWeapon.Update();
                CurrentArmor.Update();
                CombatTrace.TraceEvent(TraceEventType.Information, 3, $"{this.Name} hit points dropped to {this.CurrentHitPoints} and they died");

            }

        }


        #endregion

    }
}
