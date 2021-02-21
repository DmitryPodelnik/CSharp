using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05._10._20_Delegates
{
    class Truck : Car
    {
        public event Notify DriveNotify;
        public event Notify FinishNotify;
        public Truck(int id)
        {
            Weight = 5000;
            MaxSpeed = 0;
            Mileage = 0;
            Speed = 0;
            Id = id;
            FinishNotify += DisplayMessage;
            DriveNotify += DisplayMessage;
        }
        public override int Drive()
        {
            if (Speed == 0)
            {
                DriveNotify?.Invoke($"Car with {Id} id drove!");
            }
            int tempValue = Game.random.Next() % 20;
            Speed += tempValue;
            MaxSpeed = Speed;
            Mileage += tempValue;
            if (Mileage >= 100)
            {
                Finish();
                return Id;
            }
            return -1;
        }
        public override void Finish()
        {
            Game.IsFinished = true;
            FinishNotify?.Invoke($"Car with {Id} id finished the race!");
            Thread.Sleep(2000);
        }
    }
}
