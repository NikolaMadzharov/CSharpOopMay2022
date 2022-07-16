using System;
using System.Linq;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Cars
{
    public abstract class Car:ICar
    {
        private string make;
        private string model;
        private string vin;
        private int hoursepower;
        private double fuelavailable;
        private double fuelconsumptionperrace;

        protected Car(string make, string model, string vin, int hoursepower,double fuelavailable, double fuelconsumptionperrace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = vin;
            this.HorsePower = hoursepower;
            FuelAvailable = fuelavailable;
            this.FuelConsumptionPerRace = fuelconsumptionperrace;
        }
        public string Make
        {
            get { return make; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                }
                make = value;
            }
        }
        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                }
                model = value;
            }
        }
        public string VIN
        {
            get { return vin; }
            private set
            {
                if (value.Length!=17)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                }
                vin = value;
            }
        }
        public int HorsePower
        {
            get { return hoursepower; }
            protected set
            {
                if (value<0)
                {
                    throw new ArgumentException((ExceptionMessages.InvalidCarHorsePower));
                }
                hoursepower = value;
            }
        }
        public double FuelAvailable
        {
            get { return fuelavailable; }
            private set
            {
                if (value<0)
                {
                    value = 0;
                }
                fuelavailable=value;
            }
        }
        public double FuelConsumptionPerRace
        {
            get { return fuelconsumptionperrace; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException((ExceptionMessages.InvalidCarFuelConsumption));
                }
                fuelconsumptionperrace= value;
            }
        }
        public virtual void Drive()
        {
            FuelAvailable -= FuelConsumptionPerRace;
            // to do tuner cars
        }
    }
}