using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _23._09._20_Interfaces
{
    class TeamLeader
    {
        private IWorker _team;

        public IWorker Team
        {
            set
            {
                _team = value;
            }
        }
        public void BuildFullFeaturedHouse()
        {
            _team.BuildBasement(1);
            _team.BuildWall(4);
            _team.BuildDoor(1);
            _team.BuildWindow(4);
            _team.BuildRoof(1);
        }

    }
}
