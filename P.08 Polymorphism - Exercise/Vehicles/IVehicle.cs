using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IVehicle
    {
        public double fuelQuantity { get; set; }

        public  double fuelConsumptionPerKm { get; set; }
        public void Drive(double kms);

        public void Refuel(double kms);

        public bool IsItEnoughFuel(double kms);

    }
}
