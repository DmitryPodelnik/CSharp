using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double_linked_list_28._09._20
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<int> list = new List<int>();
                list.AddItem(5);
                list.AddItem(7);
                list.AddItem(6);
                list.AddItem(9);
                list.Print();
                list.ReversePrint();

                Console.WriteLine("Add items");
                list.AddItem(10);
                list.AddItem(20);
                list.AddItem(30);
                list.Print();
                list.ReversePrint();

                Console.WriteLine("Remove at");
                list.RemoveAt(5);
                list.Print();
                list.ReversePrint();
                Console.Write("\n\n");

                List<int> list3 = new List<int>();
                list3 = list;
                Console.WriteLine("Copy list: ");
                list3.Print();
                list3.ReversePrint();
                Console.Write("\n\n");

                List<int> list5 = new List<int>();
                list5.AddItem(1);
                list5.Print();
                list5.RemoveAt(0);
                Console.Write("\n\n");
                list5.Print();
                list5.ReversePrint();

                List<int> list7 = new List<int>();
                list7 = (List<int>)list.Clone();
                list7.Print();
                list7.ReversePrint();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
