namespace CarRacing.Models.Cars
{
    public class SuperCar:Car
    {
        public SuperCar(string make, string model, string vin, int hoursepower) : base(make, model, vin, hoursepower,80, 10)
        {
        }

        
    }
}