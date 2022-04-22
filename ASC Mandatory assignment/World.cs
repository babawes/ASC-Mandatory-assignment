using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;
using ASC_Mandatory_assignment.Interfaces;

namespace ASC_Mandatory_assignment
{
    /// <summary>
    /// The world contains a List of Creatures and a List of WorldObjects, it also has the bounds defined by MaxX and MaxY.
    /// </summary>
    public class World : IWorld
    {
        #region Properties

        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public List<Creature> CreaturesInWorld { get; set; }
        public List<WorldObject> WorldObjectsInWorld { get; set; }
        #endregion

        //The MaxX and MaxY coordinated are configured in the XML file
        public World()
        {
            XmlDocument configDoc = new XmlDocument();
            configDoc.Load(@"C:\Users\babaw\OneDrive\Skrivebord\Sem 4\ASC\ASC Mandatory assignment\ASC Mandatory assignment\WorldConfig.xml");
            Console.WriteLine(configDoc.InnerText);
            XmlNode xxNode = configDoc.DocumentElement.SelectSingleNode("MaxX");
            if (xxNode != null)
            {
                string xxStr = xxNode.InnerText.Trim();
                Console.WriteLine(xxStr);
                MaxX = Convert.ToInt32(xxStr);
            }

            XmlNode xyNode = configDoc.DocumentElement.SelectSingleNode("MaxY");
            if (xyNode != null)
            {
                string xyStr = xyNode.InnerText.Trim();
                MaxY = Convert.ToInt32(xyStr);
            }
        }
    }
}
