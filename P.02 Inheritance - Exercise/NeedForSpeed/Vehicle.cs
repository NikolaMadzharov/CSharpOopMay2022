using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle( int hoursePower, double fuel)
        {
            Fuel = fuel;
            HoursePower = hoursePower;
        }

        public virtual double FuelConsumption => 1.25;

        public double Fuel { get; set; }
        public int HoursePower { get; set; }



        public virtual void Drive(double kilometers)
        {
            if (this.Fuel-(kilometers*FuelConsumption)>=0)
            {
                this.Fuel -= kilometers*FuelConsumption;
            }
        }
    }
}
