using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ASC_Mandatory_assignment
{
    /// <summary>
    /// This class is for creatures in the world, they have a certain amount of MaxHitPoints and CurrentHitPoints, They can carry a CurrentWeapon and CurrentArmor.
    /// They have a position in the coordinate grid. They can Loot(WorldObject), which equips weapon and armor contained inside
    /// It has methods to Hit(Creature) and to ReceiveHit(int). The hit takes the AttackValue of the CurrentWeapon and hits a target Creature,
    /// The targeted Creature then calculates how much damage its armor mitigates. Both events are traced, so they can be logged as a sort of CombatLog
    /// It has a State Diseased, which causes it to deal half as much damage
    /// </summary>
    public class Creature
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
                attackValue = attackValue/2;
            }
            creature.ReceiveHit(attackValue);
            CombatTrace.TraceEvent(TraceEventType.Information, 1, $"{this.Name} attacked {creature.Name} with {this.CurrentWeapon.Name} for {attackValue} damage");
        }
        
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
            if (CurrentHitPoints<=0)
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
