using System;

namespace NeedForSpeed 
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle sportCar = new SportCar(150, 100);
            sportCar.Drive(8);
            Console.WriteLine(sportCar.Fuel);
            Console.WriteLine(sportCar.FuelConsumption);
        }
    }
}
