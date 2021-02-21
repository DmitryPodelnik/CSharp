using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._09._20_Interfaces
{
    class Door : IPart
    {
        public void Completed()
        {
            Console.WriteLine("Door was built");
        }
        public override string ToString()
        {
            return "Door";
        }
    }
}
