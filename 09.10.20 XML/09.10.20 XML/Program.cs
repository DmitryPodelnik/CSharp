using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _09._10._20_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            try
            {
                menu.ChooseAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
