using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASC_Mandatory_assignment.Interfaces;

namespace ASC_Mandatory_assignment
{
    /// <summary>
    /// The position a WorldObject or a Creature has, X and Y coordinates as int
    /// </summary>
    public class Position : IPosition
    {
        #region Properties

        public int X { get; set; }
        public int Y { get; set; }

        #endregion

        public Position()
        {
            
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
