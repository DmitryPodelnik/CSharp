using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._09._20_Guess_the_word
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            Console.WriteLine("Guess the number from 0 to 100");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            int minValue = 0;
            int maxValue = 100;
            int answer;
            bool active = true;

            do
            {
                Console.Write("Your number is less than ");
                Console.WriteLine(maxValue);

                answer = int.Parse(Console.ReadLine());

                switch (answer)
                {
                    case 1:

                        if (maxValue - minValue == 1)
                        {
                            Console.Write("Your number is ");
                            Console.WriteLine(minValue);
                            System.Threading.Thread.Sleep(5000);
                            active = false;
                            break;
                        }

                        maxValue -= (int)(maxValue - minValue) / 2;
                        Console.Write(minValue);
                        Console.Write(" - ");
                        Console.WriteLine(maxValue);


                        break;

                    case 0:

                        int temp = minValue;
                        minValue = maxValue;
                        maxValue += (maxValue - temp) / 2;
                        Console.Write(minValue);
                        Console.Write(" - ");
                        Console.WriteLine(maxValue);

                        break;
                }

            } while (active == true);
            */


            int choice;
            do
            {
                int leftpoint = 1;
                int rightpoint = 1000;
                int middle;
                int result = -1;
                int count = 0;
                while (leftpoint <= rightpoint)
                {
                    if (rightpoint == leftpoint)
                    {
                        result = leftpoint;
                        break;
                    }
                    middle = (leftpoint + rightpoint) / 2;
                    Console.Write("Your number is bigger than ");
                    Console.Write(middle);
                    Console.WriteLine("?");
                    Console.WriteLine("1.YES");
                    Console.WriteLine("0.NO");

                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:

                            leftpoint = middle + 1;
                            break;
                        case 0:

                            rightpoint = middle;
                            break;
                    }
                    count++;
                }
                Console.Clear();
                Console.Write("Your number is ");
                Console.WriteLine(result);
                Console.Write("Amount of tries = ");
                Console.WriteLine(count);
                Console.WriteLine("Do you want to continue?");

                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:

                        choice = 0;
                        Console.Clear();
                        break;
                    case 0:
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadKey();
                        System.Environment.Exit(1);
                        System.Threading.Thread.Sleep(1000);
                        break;
                }
            } while (choice == 0);
        }
    }
}
