using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC_Mandatory_assignment.Interfaces
{
    public interface IWorld
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public List<Creature> CreaturesInWorld { get; set; }
        public List<WorldObject> WorldObjectsInWorld { get; set; }


    }
}
