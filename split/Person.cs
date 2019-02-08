using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace split
{
    class Person
    {
        public string Name { get; set; }
        public Task[] task { get; set; }
        public int taskNumber { get; set; }
        

        public Person(string name, Task[] t)
        {
            Name = name;
            task = t;
            taskNumber = 0;
        }

        public int totalWeight()
        {
            int tw=0;
            for (int i = 0; i < task.Length; i++)
            {

                tw += task[i].TrueWeight();

            }
                
               

            return tw;

        }

    }

    
}
