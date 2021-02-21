using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._09._20_Interfaces
{
    class Window : IPart
    {
        public void Completed()
        {
            Console.WriteLine("Window was built");
        }
        public override string ToString()
        {
            return "Window";
        }
    }
}
