using System;
using System.Linq;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine().Split();

            double fuelQuantity = double.Parse(carInput[1]);

            double fuelRate = double.Parse(carInput[2]);

            Car car = new Car(fuelQuantity, fuelRate);

            string[] truckInput = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInput[1]);

            double truckFuelRate = double.Parse(truckInput[2]);
            Truck truck = new Truck(truckFuelQuantity, truckFuelRate);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();
                string action = cmd[0];
                string type = cmd[1];
                double distance = double.Parse(cmd[2]);
                if (action=="Drive")
                {
                    if (type=="Car")
                    {
                        if (car.IsItEnoughFuel(distance))
                        {
                            car.Drive(distance);
                            Console.WriteLine($"Car travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine($"Car needs refueling");
                        }
                    }
                    else
                    {
                        if (truck.IsItEnoughFuel(distance))
                        {
                            truck.Drive(distance);
                            Console.WriteLine($"Truck travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine($"Truck needs refueling");
                        }
                    }
                }
                else
                {
                    if (type=="Car")
                    {
                        car.Refuel(distance);
                    }
                    else
                    {
                        truck.Refuel(distance);
                    }
                }
            }
            Console.WriteLine($"Car: {car.fuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.fuelQuantity:f2}");
        }
    }
}
