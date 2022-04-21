﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC_Mandatory_assignment
{

    public interface Item
    {
        public Creature Wearer { get; set; }

        public string Name { get; set; }
        public World World { get; set; }

        public void Update();

    }
}
