using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._09._20_Structures
{
    struct RedDiamond : Diamond
    {
        private Size _size;
        private Point _point;

        public RedDiamond(Size size, Point point)
        {
            _size = size;
            _point = point;
        }
        public void Draw()
        {
            Console.ForegroundColor = (ConsoleColor)Colors.RED;
            Console.SetCursorPosition((int)_point.X, (int)_point.Y);
            for (int i = 0; i < _size.Height; i++)
            {
                for (int j = 0; j < _size.Width; j++)
                {
                    if (i <= _size.Width / 2)
                    {
                        // Верхняя половина ромба
                        if (j >= (_size.Width / 2) - i && j <= (_size.Width / 2) + i)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    else
                    {
                        // Нижняя половина ромба
                        if (j >= (_size.Width / 2) + i - _size.Width + 1 && j <= (_size.Width / 2) - i + _size.Width - 1)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.SetCursorPosition((int)_point.X, (int)++_point.Y);
            }
            Console.ResetColor();
        }
    }
}
