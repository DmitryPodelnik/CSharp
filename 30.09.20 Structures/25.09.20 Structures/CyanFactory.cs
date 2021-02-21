using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._09._20_Structures
{
    struct CyanFactory : AbstractFactory
    {
        public Diamond CreateDiamond(Size size, Point point)
        {
            return new CyanDiamond(size, point);
        }

        public Polygon CreatePolygon(Size size, Point point)
        {
            return new CyanPolygon(size, point);
        }

        public Rectangle CreateRectangle(Size size, Point point)
        {
            return new CyanRectangle(size, point);
        }

        public Trapezoid CreateTrapezoid(Size size, Point point)
        {
            return new CyanTrapezoid(size, point);
        }

        public Triangle CreateTriangle(Size size, Point point)
        {
            return new CyanTriangle(size, point);
        }
    }
}
