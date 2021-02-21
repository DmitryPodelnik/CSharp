using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._09._20_Interfaces
{
    interface IWorker
    {
        void Reset();
        void BuildBasement(uint count = 1);
        void BuildWall(uint count = 1);
        void BuildDoor(uint count = 1);
        void BuildWindow(uint count = 1);
        void BuildRoof(uint count = 1);
    }
}
