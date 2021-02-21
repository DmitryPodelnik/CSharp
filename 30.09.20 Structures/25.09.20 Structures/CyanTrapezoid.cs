using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._09._20_Structures
{
    struct CyanTrapezoid : Trapezoid
    {
        private Size _size;
        private Point _point;

        public CyanTrapezoid(Size size, Point point)
        {
            _size = size;
            _point = point;
        }
        public void Draw()
        {
            Console.ForegroundColor = (ConsoleColor)Colors.CYAN;
            Console.SetCursorPosition((int)_point.X, (int)_point.Y);
            Console.WriteLine("Trapezoid");
            Console.SetCursorPosition((int)_point.X, (int)++_point.Y);
            Console.ResetColor();
        }
    }
}
