using System;

namespace CarRacing.Models.Cars
{
    public class TunedCar:Car
    {
        public TunedCar(string make, string model, string vin, int hoursepower) : base(make, model, vin, hoursepower, 65,7.5)
        {
        }

        public override void Drive()
        {
            base.Drive();
            HorsePower -= (int)Math.Ceiling(HorsePower * 0.3);
        }
    }
}