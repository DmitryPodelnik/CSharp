using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._10._20_Delegates
{
    delegate void Notify(string message);
    abstract class Car
    {
        private int _speed;
        private int _mileage;



        public int MaxSpeed { get; set; }
        public Car()
        {
            _speed = 0;
            _mileage = 0;  
        }
        public int Id { get; set; }

        public int Speed
        {
            get => _speed;
            set
            {
                if (_speed < 0)
                {
                    throw new ArgumentException("You entered incorrect speed!");
                }
                _speed = value;
            }
        }
        public int Weight { get; set; }
        public int Mileage
        {
            get => _mileage;
            set
            {
                if (_mileage < 0)
                {
                    throw new ArgumentException("You entered incorrect mileage!");
                }
                _mileage = value;
            }
        }

        abstract public int Drive();
        abstract public void Finish();
        protected static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
