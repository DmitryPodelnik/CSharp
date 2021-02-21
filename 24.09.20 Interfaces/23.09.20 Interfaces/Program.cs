using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._09._20_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamLeader director = new TeamLeader();
            HouseTeam team = new HouseTeam();

            director.Team = team;

            director.BuildFullFeaturedHouse();
            Console.WriteLine(team.GetHouse().ListParts());
        }
    }
}
