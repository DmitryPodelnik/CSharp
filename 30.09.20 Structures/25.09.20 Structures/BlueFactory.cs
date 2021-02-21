using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._09._20_Structures
{
    struct BlueFactory : AbstractFactory
    {
        public Diamond CreateDiamond(Size size, Point point)
        {
            return new BlueDiamond(size, point);
        }

        public Polygon CreatePolygon(Size size, Point point)
        {
            return new BluePolygon(size, point);
        }

        public Rectangle CreateRectangle(Size size, Point point)
        {
            return new BlueRectangle(size, point);
        }

        public Trapezoid CreateTrapezoid(Size size, Point point)
        {
            return new BlueTrapezoid(size, point);
        }

        public Triangle CreateTriangle(Size size, Point point)
        {
            return new BlueTriangle(size, point);
        }
    }
}
