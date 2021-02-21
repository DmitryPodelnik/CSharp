using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._09._20_Structures
{
    struct WhitePolygon : Polygon
    {
        private Size _size;
        private Point _point;

        public WhitePolygon(Size size, Point point)
        {
            _size = size;
            _point = point;
        }
        public void Draw()
        {
            Console.ForegroundColor = (ConsoleColor)Colors.WHITE;
            Console.SetCursorPosition((int)_point.X, (int)_point.Y);
            Console.WriteLine("Polygon");
            Console.SetCursorPosition((int)_point.X, (int)++_point.Y);
            Console.ResetColor();
        }
    }
}
