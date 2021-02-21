using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._09._20_Structures
{
    public enum Colors
    {
        RED = ConsoleColor.Red,
        GREEN = ConsoleColor.Green,
        BLUE = ConsoleColor.Blue,
        YELLOW = ConsoleColor.Yellow,
        CYAN = ConsoleColor.Cyan,
        WHITE = ConsoleColor.White
    };

    class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application(new BlueFactory());

            Size size = new Size(11, 11);
            Point point = new Point(25, 5);

            app.CreateTriangle(size, point);
            app.Paint();
        }
    }
}
