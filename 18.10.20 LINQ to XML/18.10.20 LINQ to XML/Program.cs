using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Xml.Linq;
using System.Globalization;

namespace _18._10._20_LINQ_to_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument document = XDocument.Load("bookstore.xml");


            ///1
            /*
            var res = document.Descendants("book")
               .Where(p => p.Attribute("style").Value.Equals("autobiography")).Descendants("author")
               .Select(p => new
               {
                  FirstName = p.Element("first-name").Value,
                  LastName = p.Element("last-name").Value,
                  Award = p.Element("award").Value,
               });

            foreach (var item in res)
            {
                Console.WriteLine($"First Name: {item.FirstName}");
                Console.WriteLine($"Last Name: {item.LastName}");
                Console.WriteLine($"Award: {item.Award}");
            }
            */

            ///2
            /*
            var res = document.Descendants("author")
               .Where(p => p.Element("first-name").Value == "Joe" && p.Element("last-name").Value == "Bob")
               .Select(p => new
               {
                   Award = p.Element("award").Value
               });

            foreach (var item in res)
            {
                Console.Write("Awards: ");
                Console.Write($"{item.Award}, ");
            }
            */

            ///3
            /*
            var res = document.Descendants("book")
               .Where(p => double.Parse(p.Element("price").Value, CultureInfo.InvariantCulture) < 30).Descendants("author")
               .Select(p => new
               {
                   FirstName = p.Element("first-name").Value,
                   LastName = p.Element("last-name").Value,
                   Award = p.Element("award").Value,
               });


            foreach (var item in res)
            {
                Console.WriteLine($"First Name: {item.FirstName}");
                Console.WriteLine($"Last Name: {item.LastName}");
                Console.WriteLine($"Award: {item.Award}\n");
            }
            */

            ///4
            /*
            var res = document.Descendants("author")
               .Where(p => p.Element("last-name").Value == "Bob")
               .Select(p => new
               {
                   FirstName = p.Element("first-name").Value,
                   LastName = p.Element("last-name").Value
               });

            foreach (var item in res)
            {
                Console.WriteLine($"First Name: {item.FirstName}");
                Console.WriteLine($"Last Name: {item.LastName}\n");
            }
            */

        }
    }
}
