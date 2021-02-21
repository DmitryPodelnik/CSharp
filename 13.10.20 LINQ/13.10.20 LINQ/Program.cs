using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._10._20_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> library = new List<Book>();

            Book book1 = new Book("1", "2", "2000", "1", "1", "Author1", "Author1");
            Book book2 = new Book("2", "2", "2000", "1", "1", "Author2", "Author2");
            Book book3 = new Book("3", "3", "2001", "2", "1", "Author3", "Author3");
            Book book4 = new Book("4", "2", "2000", "1", "3", "Author1", "Author1");
            Book book5 = new Book("5", "4", "2002", "1", "1", "Author2", "Author2");
            Book book6 = new Book("6", "2", "2001", "2", "3", "Author1", "Author1");
            Book book7 = new Book("7", "2", "2003", "1", "1", "Author1", "Author1");
            Book book8 = new Book("8", "1", "2004", "1", "2", "Author3", "Author3");
            Book book9 = new Book("9", "1", "2005", "3", "2", "Author1", "Author1");
            Book book10 = new Book("10", "2", "2003", "3", "1", "Author2", "Author2");

            List<Student> students = new List<Student>();

            Student student1 = new Student("Ivan", "Ivanov");
            Student student2 = new Student("Petr", "Petrov");
            Student student3 = new Student("Dmitry", "Dmitrievich");
            Student student4 = new Student("Alexander", "Alexandrovich");
            Student student5 = new Student("Alexey", "Alexeevich");

            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
            students.Add(student4);
            students.Add(student5);

            AddBook(library, ref book1);
            AddBook(library, ref book2);
            AddBook(library, ref book3);
            AddBook(library, ref book4);
            AddBook(library, ref book5);
            AddBook(library, ref book6);
            AddBook(library, ref book7);
            AddBook(library, ref book8);
            AddBook(library, ref book9);
            AddBook(library, ref book10);

            ///1
            /*
            var subset = library
                         .Where(p => p.Category == "1")
                         .Select(p => p);

             foreach (var p in subset)
            {
                Console.WriteLine(p.ToString());
            }
            */

            ///2
            /*
            var subset = library
                .Where(p => p.AuthorFirstName == "Author1")
                .Select(p => new { p.Name, p.Quantity });

             foreach (var p in subset)
            {
                Console.WriteLine(p.ToString());
            }
            */

            ///3
            /*
            var subset = library
                .OrderBy(p => p.YearPress)
                .Select(p => p);

             foreach (var p in subset)
            {
                Console.WriteLine(p.ToString());
            }
            */

            ///4
            /*
            var subset = library
                .OrderBy(p => p.Press)
                .ThenBy(p => p.YearPress)
                .Select(p => p);

             foreach (var p in subset)
            {
                Console.WriteLine(p.ToString());
            }
            */

            ///5
            /*
            var subset = library
                .Where(p => p.Press == "1")
                .Select(p => p.Quantity).Sum();
            Console.WriteLine(subset);
            */

            ///6
            /*
            var subset = library
               .OrderBy(p => p.YearPress)
               .Select(p => p).First();

            Console.WriteLine(subset);
            */

            ///7
            /*
            var subset = library
                .Select(p => p.Category).Distinct();

            foreach (var p in subset)
            {
                Console.WriteLine(p.ToString());
            }
            */

            ///8
            /*
            var subset = library
                .Where(p => p.AuthorLastName == "Author1")
                .Select(p => p).Union(
                         library
                .Where(p => p.AuthorLastName == "Author2")
                .Select(p => p)
                ).Select(p => p.YearPress);

            foreach (var p in subset)
            {
                Console.WriteLine(p.ToString());
            }
            */

            ///9
            /*
            var res = library
                .GroupBy(c => c.Category)
                .Select(g => new { Category = g.Key, Book = g });

            foreach (var p in res)
            {
                Console.WriteLine("Category: {0}", p.Category);
                foreach (var book in p.Book)
                {
                    Console.WriteLine(book);
                }
            }
            */

            ///10
            /*
            var res = library
                .Where(p => p.Press == "1")
                .GroupBy(p => p.AuthorLastName)
                .Select(g => new { AuthorLastName = g.Key, Book = g });

            foreach (var bG in res)
            {
                Console.WriteLine(bG.AuthorLastName);
                foreach (var book in bG.Book)
                {
                    Console.WriteLine(book);
                }
            }
            */

            book1.AddStudent(student1);
            book1.AddStudent(student2);
            book2.AddStudent(student3);
            book2.AddStudent(student4);
            book3.AddStudent(student5);
            book3.AddStudent(student1);
            book4.AddStudent(student2);
            book4.AddStudent(student3);
            book5.AddStudent(student4);
            book5.AddStudent(student5);
            book6.AddStudent(student1);
            book6.AddStudent(student2);
            book7.AddStudent(student3);
            book7.AddStudent(student4);
            book8.AddStudent(student5);
            book8.AddStudent(student1);
            book9.AddStudent(student2);
            book9.AddStudent(student3);
            book10.AddStudent(student4);
            book10.AddStudent(student5);

            ///11
            /*
            var res = library
                .GroupBy(p => p.Name)
                .Select(g => new { Name = g.Key, Students = g });

            foreach (var bG in res)
            {
                Console.WriteLine($"Book Name: {bG.Name}");
                foreach (var book in bG.Students)
                {
                    for (int i = 0; i < book.Students.Count; i++)
                    {
                        Console.WriteLine(book.Students[i]);
                    }
                }
            }
            */
        }
        static void AddBook(List<Book> library, ref Book book)
        {
            library.Add(book);
            book.Quantity++;
        }
    }
}
