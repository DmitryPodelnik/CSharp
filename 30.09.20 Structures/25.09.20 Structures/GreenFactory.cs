using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._09._20_Structures
{
    struct GreenFactory : AbstractFactory
    {
        public Diamond CreateDiamond(Size size, Point point)
        {
            return new GreenDiamond(size, point);
        }

        public Polygon CreatePolygon(Size size, Point point)
        {
            return new GreenPolygon(size, point);
        }

        public Rectangle CreateRectangle(Size size, Point point)
        {
            return new GreenRectangle(size, point);
        }

        public Trapezoid CreateTrapezoid(Size size, Point point)
        {
            return new GreenTrapezoid(size, point);
        }

        public Triangle CreateTriangle(Size size, Point point)
        {
            return new GreenTriangle(size, point);
        }
    }
}
