using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle:IVehicle
    {
        private double fuelquantity;
        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm,double tankCapacity)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumptionPerKm = fuelConsumptionPerKm;
            this.tankCapacity = tankCapacity;
        }


        public double fuelQuantity
        { get => fuelQuantity;
           set
            {
                if (value > tankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
           

        }

        public  double tankCapacity { get; set; }

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
        public bool canHeRefuel(double km) => this.fuelQuantity + km >= this.tankCapacity;

        public bool IsItEmpty { get; set; }

        public virtual void Refuel(double km)
        {
            if (km<=0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (canHeRefuel(km))
            {
            this.fuelQuantity+=km;

            }
           
        }

        
    }
}
