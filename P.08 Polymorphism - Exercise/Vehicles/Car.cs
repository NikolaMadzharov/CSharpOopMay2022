using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm) : base(fuelQuantity, fuelConsumptionPerKm) 
        { 
        }
       

        public override double fuelConsumptionPerKm => base.fuelConsumptionPerKm + 0.90;
    }
}
