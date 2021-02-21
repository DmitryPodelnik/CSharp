using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _13._10._20_LINQ
{
    class Book 
    {
        private List<Student> _students = new List<Student>();

        public string Name { get; set; }
        public string Press { get; set; }
        public string YearPress { get; set; }
        public string Category { get; set; }
        public string Theme { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public int Quantity { get; set; }
        public List<Student> Students
        {
            get => _students;
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public Book(string name, string press, string yearPress, string category, string theme, string authorLastName, string authorFirstName)
        {
            Name = name;
            Press = press;
            YearPress = yearPress;
            Category = category;
            Theme = theme;
            AuthorLastName = authorLastName;
            AuthorFirstName = authorFirstName;
        }
        public override string ToString()
        {
            return string.Format("Name={0}, Press={1}, YearPress={2}, Category={3}, Theme={4}, AuthorLastName={5}, AuthorFirstName={6}, Quantity={7}",
              Name, Press, YearPress, Category, Theme, AuthorLastName, AuthorFirstName, Quantity);
        }

        
    }
}
