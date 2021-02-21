using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._09._20_Structures
{
    struct RedFactory : AbstractFactory
    {
        public Diamond CreateDiamond(Size size, Point point)
        {
            return new RedDiamond(size, point);
        }

        public Polygon CreatePolygon(Size size, Point point)
        {
            return new RedPolygon(size, point);
        }

        public Rectangle CreateRectangle(Size size, Point point)
        {
            return new RedRectangle(size, point);
        }

        public Trapezoid CreateTrapezoid(Size size, Point point)
        {
            return new RedTrapezoid(size, point);
        }

        public Triangle CreateTriangle(Size size, Point point)
        {
            return new RedTriangle(size, point);
        }
    }
}
