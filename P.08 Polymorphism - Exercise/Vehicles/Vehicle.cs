using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public virtual double fuelQuantity { get; set; }

        public virtual double  fuelConsumptionPerKm { get; set; }

        public virtual double fuelConsumption { get; set; }

        public bool IsItEnoughFuel(double km) => this.fuelQuantity - (km * fuelConsumptionPerKm) >= 0;
        public void Drive(double km)
        {
            if (IsItEnoughFuel(km))
            {
                this.fuelQuantity -= km * fuelConsumptionPerKm;
            }
            
        }
        public virtual void Refuel(double km)
        {
            this.fuelQuantity+=km;
        }
    }
}
