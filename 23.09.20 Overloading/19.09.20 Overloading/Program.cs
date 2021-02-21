using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19._09._20_Overloading
{
    class Program
    {
        static void Main(string[] args)
        {
          
                Date date1 = new Date();
                date1.printTime();
                Console.WriteLine();

                Date date2 = new Date(2020, 2, 29);
                date2.printTime();
                Console.WriteLine();

                Date date3 = new Date(2012, 12);
                date3.printTime();
                Console.WriteLine();

                Date date4 = Date.getCurrentDate();
                date4.printTime();
                Console.WriteLine();

                try
                {
                    date2.Year = 2021;
                    date2.printTime();
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                  Console.WriteLine(ex.Message);
                }

                date2.AddYears(5);
                date2.printTime();
                Console.WriteLine();

                Date date5 = new Date(2020, 3, 31);
                date5.printTime();
                Console.WriteLine();

                date5.AddMonths(1);
                date5.printTime();
                Console.WriteLine();

                Date date6 = new Date(2020, 2, 25);
                date6.printTime();
                Console.WriteLine();

                date6.AddDays(6);
                date6.printTime();
                Console.WriteLine();

                Date date7 = new Date(2021, 1, 29);
                date7.printTime();
                Console.WriteLine();

                date7.AddMonths(1);
                date7.printTime();
                Console.WriteLine();
                Console.WriteLine(date7.ToString());

                Date d1 = new Date(1996, 6, 3);
                Date d2 = new Date(1996, 12, 6);
                Date d3 = new Date(1996, 10, 12);

                TimeSpan diff1 = d2 - d1;
                Console.WriteLine($"d2 - d1 = {diff1.TotalDays} days");

                Date d4 = d2 - diff1;
                Console.WriteLine($"d2 - diff1 = {d4.Year}/{d4.Month}/{d4.Day}");

                Date d5 = d2 + diff1;
                Console.WriteLine($"d2 + diff1 = {d5.Year}/{d5.Month}/{d5.Day}");

            if (d1 == d2)
            {
                Console.WriteLine($"Dates {d1.Year}/{d1.Month}/{d1.Day} and {d2.Year}/{d2.Month}/{d2.Day} are equal!");
            }
            else
            {
                Console.WriteLine($"Dates {d1.Year}/{d1.Month}/{d1.Day} and {d2.Year}/{d2.Month}/{d2.Day} are not equal!");
            }

            if (d1 > d2)
            {
                Console.WriteLine($"Date: {d1.Year}/{d1.Month}/{d1.Day} is bigger than Date: {d2.Year}/{d2.Month}/{d2.Day}!");
            }
            else
            {
                Console.WriteLine($"Date: {d1.Year}/{d1.Month}/{d1.Day} is not bigger than Date: {d2.Year}/{d2.Month}/{d2.Day}!");
            }
        }
    }
}
