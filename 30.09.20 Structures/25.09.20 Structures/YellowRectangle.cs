using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._09._20_Structures
{
    struct YellowRectangle : Rectangle
    {
        private Size _size;
        private Point _point;


        public YellowRectangle(Size size, Point point)
        {
            _size = size;
            _point = point;
        }
        public void Draw()
        {
            Console.ForegroundColor = (ConsoleColor)Colors.YELLOW;
            Console.SetCursorPosition((int)_point.X, (int)_point.Y);
            for (int i = 0; i < _size.Height; i++)
            {
                for (int j = 0; j < _size.Width; j++)
                {
                    Console.Write("*");
                }
                Console.SetCursorPosition((int)_point.X, (int)++_point.Y);
            }
            Console.ResetColor();
        }
    }
}
