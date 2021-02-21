using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._09._20_Interfaces
{
    class HouseTeam : IWorker
    {
        private House _house = new House();

        public HouseTeam()
        {
            Reset();
        }

        public void Reset()
        {
            _house = new House();
        }

        public void BuildBasement(uint count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Basement part = new Basement();
                _house.Add(part);
                part.Completed();
            }
        }
        public void BuildWall(uint count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Wall part = new Wall();
                _house.Add(part);
                part.Completed();
            }
        }
        public void BuildDoor(uint count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Door part = new Door();
                _house.Add(part);
                part.Completed();
            }
        }
        public void BuildWindow(uint count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Window part = new Window();
                _house.Add(part);
                part.Completed();
            }
        }
        public void BuildRoof(uint count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Roof part = new Roof();
                _house.Add(part);
                part.Completed();
            }
        }
        public House GetHouse()
        {
            House result = _house;

            Reset();

            return result;
        }
    }
}
