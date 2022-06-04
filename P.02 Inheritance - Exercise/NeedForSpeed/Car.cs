using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int hoursePower, double fuel) : base(hoursePower, fuel)
        {
        }
        public override double FuelConsumption => 3;
    }
}
