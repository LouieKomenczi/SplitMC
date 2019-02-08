using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace split
{
    class Task 
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public bool firstoff { get; set; }
        public bool lastoff { get; set; }
        public bool packing { get; set; }
        public bool closeBox { get; set; }

        public Task(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public int TrueWeight()
        {
            int w=0;
            if (firstoff) w += Weight;
            if (lastoff) w += Weight / 2;
            if (packing) w += Weight;
            if (closeBox) w += Weight;
            return w;
        }

    }
}
