using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle

    {
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        public override double fuelConsumptionPerKm =>this.IsItEmpty?base.fuelConsumptionPerKm : base.fuelConsumptionPerKm+1.4;
	

	
    }
}
