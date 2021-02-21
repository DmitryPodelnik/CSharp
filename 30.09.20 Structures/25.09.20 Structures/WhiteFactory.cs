using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._09._20_Structures
{
    struct WhiteFactory : AbstractFactory
    {
        public Diamond CreateDiamond(Size size, Point point)
        {
            return new WhiteDiamond(size, point);
        }

        public Polygon CreatePolygon(Size size, Point point)
        {
            return new WhitePolygon(size, point);
        }

        public Rectangle CreateRectangle(Size size, Point point)
        {
            return new WhiteRectangle(size, point);
        }

        public Trapezoid CreateTrapezoid(Size size, Point point)
        {
            return new WhiteTrapezoid(size, point);
        }

        public Triangle CreateTriangle(Size size, Point point)
        {
            return new WhiteTriangle(size, point);
        }
    }
}
