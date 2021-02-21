using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._10._20_Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            Car car1 = new SportCar(1);
            Car car2 = new SportCar(2);
            Car car3 = new Sedan(3);
            Car car4 = new Truck(4);
            Car car5 = new Bus(5);


            try
            {
                game.AddCar(car1);
                game.AddCar(car2);
                game.AddCar(car3);
                game.AddCar(car4);
                game.AddCar(car5);

                game.StartGame();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
    }
}
