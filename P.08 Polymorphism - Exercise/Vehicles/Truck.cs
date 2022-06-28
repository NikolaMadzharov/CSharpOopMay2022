using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm) : base(fuelQuantity, fuelConsumptionPerKm) 
        {
        }
        
        

        public override double fuelConsumptionPerKm => base.fuelConsumptionPerKm + 1.6;
        public override double fuelConsumption => base.fuelQuantity * 0.95;
    }

}
