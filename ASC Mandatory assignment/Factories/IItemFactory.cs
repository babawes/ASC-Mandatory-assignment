using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC_Mandatory_assignment.Factories
{
    public interface IItemFactory
    {
        public IItem CreateItem(string name, World world);
    }
}
