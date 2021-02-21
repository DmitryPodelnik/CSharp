using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._10._20_XML
{
    class Movie
    {
        private string _name;
        private string _year;
        private string _genre;
        private string _duration;

        public string Name
        {
            get => _name;
            set
            {
                try
                {
                    if (value.Length == 0)
                    {
                        throw new ArgumentNullException("String cannot be null.");
                    }
                    _name = value;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public string Year
        {
            get => _year;
            set
            {
                try
                {
                    if (Int32.Parse(value) <= 0)
                    {
                        throw new ArgumentNullException("Year must be bigger than 0.");
                    }
                    _year = value;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public string Genre
        {
            get => _genre;
            set
            {
                try
                {
                    if (value.Length == 0)
                    {
                        throw new ArgumentNullException("String cannot be null.");
                    }
                    _genre = value;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public string Duration
        {
            get => _duration;
            set
            {
                try
                {
                    if (Int32.Parse(value) <= 0)
                    {
                        throw new ArgumentNullException("Duration must be bigger than 0.");
                    }
                    _duration = value;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public Movie() { }
        public Movie(string name, string year, string genre, string duration)
        {
            Name = name;
            Year = year;
            Genre = genre;
            Duration = duration;
        }
    }
}
