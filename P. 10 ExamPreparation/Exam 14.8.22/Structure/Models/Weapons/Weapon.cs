namespace PlanetWars.Models.Weapons
{
    using System;
    

    using PlanetWars.Models.Weapons.Contracts;

    public abstract class Weapon:IWeapon
    {
        private  int destructionLevel;

        private  double price;

        public Weapon(int destructionLevel,double price)
        {
            this.Price=price;


            this.DestructionLevel=destructionLevel;
        }

        public double Price
        {
            get => this.price;

            private set
            {
                this.price = value;
            }
        }

        public int DestructionLevel
        {
            get => this.destructionLevel;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Destruction level cannot be zero or negative.");
                }
                if (value >= 10)
                {
                    throw new ArgumentException("Destruction level cannot exceed 10 power points.");
                }
                this.destructionLevel = value;
            }
        }
    }
}