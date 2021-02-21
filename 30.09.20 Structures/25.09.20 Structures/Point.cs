using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._09._20_Structures
{
    struct Point
    {
        private double _x;
        private double _y;

        public double X
        {
            get => _x;
            set => _x = value;
        }
        public double Y
        {
            get => _y;
            set => _y = value;
        }
        public Point(double x, double y) 
        {
            _x = x;
            _y = y;
        }
    }
}
