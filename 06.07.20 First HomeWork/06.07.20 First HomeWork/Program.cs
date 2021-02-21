using System;
using System.Collections.Generic;

namespace _06._07._20_First_HomeWork
{
    class Program
    {
        class Order
        {
            public string productName;
            public int productCount;

            public Order(string product, int count)
            {
                productName = product;
                productCount = count;
            }
        }

        static void Main(string[] args)
        {
            Exercise2();
        }

        static void GuessTheWord()
        {
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
        static void Exercise1()
        {
            try
            {
                Random random = new Random();

                int[] arr = new int[20];

                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = random.Next(1, 20);
                    Console.Write("{0} \t", arr[i]);
                }
                Console.WriteLine();

                ///1
                
                Console.WriteLine("Enter a number which you want to find in the array: ");

                int number = int.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine();

                int num = 0;

                while(num != -1)
                {
                    num = Array.IndexOf(arr, number, num);
                    if (num != -1)
                    {
                        Console.Write("{0} \t", num);
                        num++;
                    }

                }
                

                ///2
                /*

                Console.WriteLine();
                Console.WriteLine();

                Array.Sort(arr);
                Array.Reverse(arr, 10, 10);

                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write("{0} \t", arr[i]);
                }
                */

                ///3
                /*
                 
                Console.WriteLine();
                Console.WriteLine();

                Array.Resize(ref arr, 25);

                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write("{0} \t", arr[i]);
                }

                */

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Exercise2()
        {
            try
            {
                List<string> names = new List<string>();

                Order[] orders = new Order[8]
                {
                    new Order("Lemon", 3),
                    new Order("Apple", 2),
                    new Order("Lemon", 5),
                    new Order("Apple", 1),
                    new Order("Pineapple", 3),
                    new Order("Orange", 8),
                    new Order("Pineapple", 8),
                    new Order("Orange", 8)
                };

                names.Add(orders[0].productName);

                int count = 0;

                for (int i = 1, check = 0; i < orders.Length; i++)
                {
                    for (int j = 0; j < names.Count; j++)
                    { 
                        if (orders[i].productName == names[j])
                        {
                            check++;
                            break;
                        }
                    }
                    if (check == 0)
                    {
                        names.Add(orders[i].productName);
                    }
                    check = 0;
                }

                for (int i = 0; i < names.Count; i++)
                {
                    for (int j = 0; j < orders.Length; j++) 
                    {
                        if (orders[j].productName == names[i])
                        {
                            count += orders[j].productCount;
                        }
                    }
                    Console.Write("{0} \t", names[i]);
                    Console.Write("{0}", count);
                    Console.WriteLine();
                    count = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
