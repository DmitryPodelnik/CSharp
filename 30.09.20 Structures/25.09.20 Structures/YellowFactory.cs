using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._09._20_Structures
{
    struct YellowFactory : AbstractFactory
    {
        public Diamond CreateDiamond(Size size, Point point)
        {
            return new YellowDiamond(size, point);
        }

        public Polygon CreatePolygon(Size size, Point point)
        {
            return new YellowPolygon(size, point);
        }

        public Rectangle CreateRectangle(Size size, Point point)
        {
            return new YellowRectangle(size, point);
        }

        public Trapezoid CreateTrapezoid(Size size, Point point)
        {
            return new YellowTrapezoid(size, point);
        }

        public Triangle CreateTriangle(Size size, Point point)
        {
            return new YellowTriangle(size, point);
        }
    }
}
