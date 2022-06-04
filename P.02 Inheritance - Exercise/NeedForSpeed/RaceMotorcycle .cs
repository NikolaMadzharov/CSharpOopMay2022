using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle  : Motorcycle
    {
        public RaceMotorcycle(int hoursePower, double fuel) : base(hoursePower, fuel)
        {
        }
        public override double FuelConsumption => 8;

    }
}
