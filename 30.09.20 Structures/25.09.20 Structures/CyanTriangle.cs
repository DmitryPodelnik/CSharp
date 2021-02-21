using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._09._20_Structures
{
    struct CyanTriangle : Triangle
    {
        private Size _size;
        private Point _point;

        public CyanTriangle(Size size, Point point)
        {
            _size = size;
            _point = point;
        }
        public void Draw()
        {
            Console.ForegroundColor = (ConsoleColor)Colors.CYAN;
            Console.SetCursorPosition((int)_point.X, (int)_point.Y);
            for (int i = 0; i < _size.Height; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (i != _size.Height - 1)
                    {
                        Console.Write('*');
                    }
                    else
                        break;
                }
                Console.WriteLine(i == _size.Width - 1 ? new string('*', (int)_size.Width) : "");
                Console.SetCursorPosition((int)_point.X, (int)++_point.Y);
            }
            Console.ResetColor();
        }
    }
}
