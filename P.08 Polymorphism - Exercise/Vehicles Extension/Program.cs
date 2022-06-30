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

            double tankCapacityCar = double.Parse(carInput[3]);

            Car car = new Car(fuelQuantity, fuelRate,tankCapacityCar);

            string[] truckInput = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInput[1]);

            double truckFuelRate = double.Parse(truckInput[2]);
            double tankCapacityTruck = double.Parse(truckInput[3]);
            Truck truck = new Truck(truckFuelQuantity, truckFuelRate,tankCapacityTruck);
            string[] busInput = Console.ReadLine().Split();

            double busFuelQuantity = double.Parse(busInput[1]);

            double busFuelRate = double.Parse(busInput[2]);

            double busTankCapacity = double.Parse(busInput[3]);

            Bus bus = new Bus(busFuelQuantity, busFuelRate,busTankCapacity);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] cmd = Console.ReadLine().Split();
                    string action = cmd[0];
                    string type = cmd[1];
                    double distance = double.Parse(cmd[2]);

                    IVehicle currVehicle = null;
                    if (type == "Car")
                    {
                        currVehicle = car;
                    }
                    else if (type == "Truck")
                    {
                        currVehicle = truck;
                    }
                    else
                    {
                        currVehicle = bus;
                    }

                    if (action == "Drive")
                    {


                        if (currVehicle.IsItEnoughFuel(distance))
                        {
                            currVehicle.Drive(distance);
                            Console.WriteLine($"{type} travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine($"{type} needs refueling");
                        }


                    }
                    else if (action == "DriveEmpty")
                    {
                        bus.IsItEmpty = true;
                        bus.Drive(distance);
                        bus.IsItEmpty = false;
                    }
                    else
                    {
                        if (currVehicle.canHeRefuel(distance))
                        {
                            currVehicle.Refuel(distance);
                        }
                        else
                        {
                            Console.WriteLine($"Cannot fit {distance} fuel in the tank");
                        }


                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }    
               
            }
            Console.WriteLine($"Car: {car.fuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.fuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.fuelQuantity:f2}");
        }
    }
}
