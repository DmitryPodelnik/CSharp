using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _10._09._20
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise4();
        }

        static void Exercise1()
        {
            try
            {
                string str1 = "А роза упала на лапу Азора";
                Console.WriteLine(str1);
                Console.WriteLine();

                str1 = str1.Replace(" ", "");
                Console.Write(str1);
                Console.WriteLine();
                Console.WriteLine();

                str1 = str1.ToLower();
                Console.Write(str1);
                Console.WriteLine();
                Console.WriteLine();

                char[] arr = new char[100];
                arr = str1.ToCharArray();
                Array.Reverse(arr);
                Console.Write(arr);
                Console.WriteLine();
                Console.WriteLine();

                string str2 = new string(arr);

                Console.WriteLine(str2);
                Console.WriteLine(str1);

                if (str1.Equals(str2) == true)
                {
                    Console.WriteLine("The string is a palindrom");
                }
                else
                {
                    Console.WriteLine("The string is not a palindrom");
                }
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
                string str1 = "Hello, world!!! 12345432";
                Console.WriteLine(str1);
                Console.WriteLine();

                int countDigits = 0;
                int countCharacters = 0;
                int countPunctuation = 0;

                foreach (var el in str1)
                {
                    if (char.IsLetter(el))
                    {
                        countCharacters++;
                    }
                    else if (char.IsDigit(el))
                    {
                        countDigits++;
                    }
                    else if (char.IsPunctuation(el))
                    {
                        countPunctuation++;
                    }
                }

                Console.WriteLine("Amount of characters in the string: {0}", countCharacters);
                Console.WriteLine("Amount of digits in the string: {0}", countDigits);
                Console.WriteLine("Amount of punctuations in the string: {0}", countPunctuation);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Exercise3()
        {
            try
            {
                //string[] str2 = new string[20];
                //char[] arr = new char[100];

                //while (index != -1)
                //{
                //    index = str.IndexOf(' ', index);
                //    if (index != -1)
                //    {
                //        str.CopyTo(index, arr, 0, str.IndexOf(' ', index + 1) - index);
                //        str2[i] = new string(arr);
                //        Console.Write("{0} \t", index);
                //        index++;
                //        i++;
                //    }
                //}

                //for (int j = 0; j < i; j++)
                //{
                //    Console.WriteLine(str2[j]);
                //}

                string str = Console.ReadLine();
                char delimiter = ' ';
                string[] substrings = str.Split(delimiter);

                foreach (var substring in substrings)
                {
                    Console.WriteLine(substring);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
        static void Exercise4()
        {
            try
            {
                string str = Console.ReadLine();
                str = str.Replace(" ", "");

                if (str.Length == 0)
                {
                    Console.WriteLine("String is null");
                }
                else
                {
                    Console.WriteLine("String is not null");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
