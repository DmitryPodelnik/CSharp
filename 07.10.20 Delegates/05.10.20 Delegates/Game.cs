using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _05._10._20_Delegates
{
    delegate void RaceCondition(string message);
    class Game
    {
        List<Car> _cars = new List<Car>();
        public event RaceCondition RaceCondition;
        static public Random random = new Random();
        private delegate int Drive();

        static public bool IsFinished { get; set; }
        public void AddCar(Car car)
        {
            _cars.Add(car);
        }
        public void ShowCarsCondition()
        {
            foreach (var car in _cars)
            {
                Console.WriteLine($"Car {car.Id}: miles: {car.Mileage}, speed: {car.Speed}");
            }
        }
        public void ShowWinner(int id)
        {
            Console.WriteLine($"Car {_cars[id].Id} is won the race!");
            Console.WriteLine($"Weight: {_cars[id].Weight}, Max Speed: {_cars[id].MaxSpeed}");
        }

        public void StartGame()
        {
            int tempIndex = -1;
            RaceCondition?.Invoke("Race has been started!");
            while (!IsFinished)
            {
                ShowCarsCondition();
                foreach (var car in _cars)
                {
                    Drive drive = car.Drive;
                    tempIndex = drive();
                    if (tempIndex != -1)
                    {
                        break;
                    }
                }
                Thread.Sleep(1000);
                Console.Clear();
            }
            FinishRace(tempIndex - 1);
        }
        public void CarFinishHandle()
        {
            IsFinished = true;
        }
        public void FinishRace(int id)
        {
            Console.Clear();
            ShowWinner(id);
            RaceCondition?.Invoke("Race has been finished");
        }
    }
}
