using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        public override double fuelConsumptionPerKm => base.fuelConsumptionPerKm + 1.60;
        public override void Refuel(double km)
        {
            km *= 0.95;
            base.Refuel(km);
        }
    }

}
