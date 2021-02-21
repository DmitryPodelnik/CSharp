using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._09._20_Structures
{
    interface AbstractFactory
    {
        Diamond CreateDiamond(Size size, Point point);
        Polygon CreatePolygon(Size size, Point point);
        Rectangle CreateRectangle(Size size, Point point);
        Trapezoid CreateTrapezoid(Size size, Point point);
        Triangle CreateTriangle(Size size, Point point);
    }
}
