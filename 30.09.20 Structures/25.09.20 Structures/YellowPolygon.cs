using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _25._09._20_Structures
{
    struct YellowPolygon : Polygon
    {
        private Size _size;
        private Point _point;

        public YellowPolygon(Size size, Point point)
        {
            _size = size;
            _point = point;
        }
        public void Draw()
        {
            Console.ForegroundColor = (ConsoleColor)Colors.YELLOW;
            Console.SetCursorPosition((int)_point.X, (int)_point.Y);
            Console.WriteLine("Polygon");
            Console.SetCursorPosition((int)_point.X, (int)++_point.Y);
            Console.ResetColor();
        }
    }
}
