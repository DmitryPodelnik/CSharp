using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._10._20_XML
{
    enum Actions
    {
        OPENFILE = 1,
        SAVE,
        ADDMOVIE,
        EDITMOVIE,
        DELETEMOVIE,
        SHOWALLMOVIES,
        EXIT
    };
    class Menu
    {
        private MovieRepository _movieRepository = new MovieRepository();

        public void ShowMenu()
        {
            Console.WriteLine("1. Open File");
            Console.WriteLine("2. Save");
            Console.WriteLine("3. Add Movie");
            Console.WriteLine("4. Edit Movie");
            Console.WriteLine("5. Delete Movie");
            Console.WriteLine("6. Show all movies in the repository");
            Console.WriteLine("7. EXIT");
        }
        public void ChooseAction()
        {
            Actions action;
            string name;
            string year;

            do
            {
                ShowMenu();
                action = (Actions)Int32.Parse(Console.ReadLine());

                switch (action)
                {
                    case Actions.OPENFILE:

                        Console.Clear();
                        _movieRepository.OpenFile();
                        action = 0;

                        break;

                    case Actions.SAVE:

                        Console.Clear();
                        _movieRepository.Save();
                        action = 0;

                        break;

                    case Actions.ADDMOVIE:

                        Movie movie = new Movie();

                        Console.Clear();
                        Console.WriteLine("Enter a name: ");
                        movie.Name = Console.ReadLine();
                        Console.WriteLine("Enter a year: ");
                        movie.Year = Console.ReadLine();
                        Console.WriteLine("Enter a genre: ");
                        movie.Genre = Console.ReadLine();
                        Console.WriteLine("Enter a duration: ");
                        movie.Duration = Console.ReadLine();
                        _movieRepository.AddMovie(movie);
                        action = 0;

                        break;

                    case Actions.EDITMOVIE:

                        Console.Clear();
                        Console.WriteLine("Enter a name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter a year: ");
                        year = Console.ReadLine();
                        _movieRepository.EditMovie(name, year);
                        action = 0;

                        break;

                    case Actions.DELETEMOVIE:

                        Console.Clear();
                        Console.WriteLine("Enter a name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter a year: ");
                        year = Console.ReadLine();
                        _movieRepository.DeleteMovie(name, year);
                        action = 0;

                        break;

                    case Actions.SHOWALLMOVIES:

                        Console.Clear();
                        _movieRepository.ShowAllMovies();
                        Console.ReadKey();
                        action = 0;

                        break;

                    case Actions.EXIT:

                        Console.Clear();
                        System.Environment.Exit(1);
                        System.Threading.Thread.Sleep(1000);

                        break;
                }
                Console.Clear();
            } while (action != Actions.ADDMOVIE && action != Actions.DELETEMOVIE && action != Actions.EDITMOVIE
                   && action != Actions.OPENFILE && action != Actions.SAVE && action != Actions.SHOWALLMOVIES);
        }

    }
}
