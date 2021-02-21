using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Threading;

namespace _09._10._20_XML
{
    class MovieRepository
    {
        List<Movie> _movies = new List<Movie>();

        public bool OpenFile()
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("movies.xml");

                // получаем корневой элемент
                XmlElement xRoot = xDoc.DocumentElement;

                // обход всех узлов в корневом элементе
                foreach (XmlNode xnode in xRoot)
                {
                    Movie newMovie = new Movie();

                    // получаем атрибут name
                    if (xnode.Attributes.Count > 0)
                    {
                        XmlNode attr = xnode.Attributes.GetNamedItem("name");
                        if (attr != null)
                        {
                            //Console.WriteLine(attr.Value);
                            newMovie.Name = attr.Value;
                        }
                    }
                    // обходим все дочерние узлы элемента movie
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        // если узел - year
                        if (childnode.Name == "year")
                        {
                            //Console.WriteLine($"Year: {childnode.InnerText}");
                            newMovie.Year = childnode.InnerText;
                        }
                        // если узел genre
                        if (childnode.Name == "genre")
                        {
                            //Console.WriteLine($"Genre: {childnode.InnerText}");
                            newMovie.Genre = childnode.InnerText;
                        }
                        // если узел duration
                        if (childnode.Name == "duration")
                        {
                            //Console.WriteLine($"Duration: {childnode.InnerText}");
                            newMovie.Duration = childnode.InnerText;
                        }
                    }
                    _movies.Add(newMovie);
                }
                Console.WriteLine("The file has been successfully readed!");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
        public bool Save()
        {
            try
            {
                DeleteAllXmlNodes();

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("movies.xml");
                XmlElement xRoot = xDoc.DocumentElement;

                foreach (var movie in _movies)
                {
                    // создаем новый элемент movie
                    XmlElement userElem = xDoc.CreateElement("movie");
                    // создаем атрибут name
                    XmlAttribute nameAttr = xDoc.CreateAttribute("name");
                    // создаем элементы year, genre и duration
                    XmlElement yearElem = xDoc.CreateElement("year");
                    XmlElement genreElem = xDoc.CreateElement("genre");
                    XmlElement durationElem = xDoc.CreateElement("duration");
                    // создаем текстовые значения для элементов и атрибута
                    XmlText nameText = xDoc.CreateTextNode(movie.Name);
                    XmlText yearText = xDoc.CreateTextNode(movie.Year);
                    XmlText genreText = xDoc.CreateTextNode(movie.Genre);
                    XmlText durationText = xDoc.CreateTextNode(movie.Duration);

                    //добавляем узлы
                    nameAttr.AppendChild(nameText);
                    yearElem.AppendChild(yearText);
                    genreElem.AppendChild(genreText);
                    durationElem.AppendChild(durationText);
                    userElem.Attributes.Append(nameAttr);
                    userElem.AppendChild(yearElem);
                    userElem.AppendChild(genreElem);
                    userElem.AppendChild(durationElem);
                    xRoot.AppendChild(userElem);
                }
                xDoc.Save("movies.xml");
                Console.WriteLine("The file has been successfully saved!");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
        public bool AddMovie(string name, string year, string genre, string duration)
        {
            try
            {
                _movies.Add(new Movie(name, year, genre, duration));
                Console.WriteLine("A movie has been successfully added!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
        public bool AddMovie(Movie movie)
        {
            try
            {
                if (movie is null)
                {
                    throw new ArgumentNullException("Object cannot be null");
                }
                _movies.Add(movie);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
        public bool EditMovie(string name, string year)
        {
            try
            {
                int index = SearchMovie(name, year);
                if (index == -1)
                {
                    throw new IndexOutOfRangeException("Index cannot be -1");
                }

                Console.Clear();
                Console.WriteLine("Enter a new name: ");
                _movies[index].Name = Console.ReadLine();
                Console.WriteLine("Enter a new year: ");
                _movies[index].Year = Console.ReadLine();
                Console.WriteLine("Enter a new genre: ");
                _movies[index].Genre = Console.ReadLine();
                Console.WriteLine("Enter a new duration: ");
                _movies[index].Duration = Console.ReadLine();
                Console.WriteLine("A movie has been successfully edited!");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
        public bool DeleteMovie(string name, string year)
        {
            try
            {
                int index = SearchMovie(name, year);
                if (index == -1)
                {
                    throw new IndexOutOfRangeException("Index cannot be -1");
                }

                _movies.RemoveAt(index);
                Console.WriteLine("A movie has been successfully deleted!");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
        public void ShowAllMovies()
        {
            foreach (var movie in _movies)
            {
                Console.WriteLine($"Name: {movie.Name}");
                Console.WriteLine($"Year: {movie.Year}");
                Console.WriteLine($"Genre: { movie.Genre}");
                Console.WriteLine($"Duration: {movie.Duration}");
                Console.WriteLine();
            }
        }
        private int SearchMovie(string name, string year)
        {
            int index = 0;

            for (int i = 0; i < _movies.Count; i++)
            {
                if (_movies[i].Name.Equals(name) && _movies[i].Year.Equals(year))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
        private void DeleteAllXmlNodes()
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("movies.xml");

                // получаем корневой элемент
                XmlElement xRoot = xDoc.DocumentElement;

                xRoot.RemoveAll();
                xDoc.Save("movies.xml");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
