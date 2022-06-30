using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IVehicle
    {
        public double fuelquantity { get;  }

        public  double fuelConsumptionPerKm { get; set; }


        public void Drive(double km);

        public void Refuel(double km);

        public bool IsItEnoughFuel(double km);

        public double tankCapacity { get; set; }

        public bool IsItEmpty { get; set; }

        public bool canHeRefuel(double km);
    }
}
