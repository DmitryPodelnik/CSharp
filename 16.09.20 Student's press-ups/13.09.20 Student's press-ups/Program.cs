using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _13._09._20_Student_s_press_ups
{
    class Program
    {
        public class Student
        {
            private short _grade;
            public DateTime _arriveTime { get; }
            public string _name { get; }

            public Student(string name, DateTime arriveTime, short grade)
            {
                _name = name;
                _arriveTime = arriveTime;
                _grade = grade;
            }
        }
        public class Lesson
        {
            private string _name;
            private DateTime _time;
            private Student[] _students;

            public Lesson(string name, DateTime time, Student[] students)
            {
                _name = name;
                _time = time;
                _students = students;
            }
            public void CalculatePressUps()
            {
                TimeSpan interval = new TimeSpan();
                string intervalInfo;
                double minutes;

                for (int i = 0; i < _students.Length; i++)
                {
                    if (_time < _students[i]._arriveTime)
                    {
                        interval = _students[i]._arriveTime - _time;
                        intervalInfo = interval.Minutes.ToString();
                        minutes = int.Parse(intervalInfo);
                        int resultPressUps = (int)Math.Ceiling(minutes / 10) * 10;
                        Console.WriteLine($"{_students[i]._name} have to press-up {resultPressUps} times!\n");
                    }
                    else
                    {
                        Console.WriteLine($"{_students[i]._name} came to lesson on time!\n");
                    }
                }             
            }
        }

        static void Main(string[] args)
        {
            Student[] students = new Student[5]
            {
                new Student("Dmitry", new DateTime(2020,9,15,8,58,0), 12),
                new Student("Vlad", new DateTime(2020,9,15,8,55,0), 8),
                new Student("Andrew", new DateTime(2020,9,15,9,5,0), 10),
                new Student("John", new DateTime(2020,9,15,8,52,0), 11),
                new Student("Kanye", new DateTime(2020,9,15,9,16,0), 7)
            };

            DateTime dateMath = new DateTime(2020, 9, 15, 9, 0, 0);

            Lesson math = new Lesson("Math", dateMath, students);
            math.CalculatePressUps();
        }


    }
}
