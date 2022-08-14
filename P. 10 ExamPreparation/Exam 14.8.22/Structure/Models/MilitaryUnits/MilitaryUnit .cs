namespace PlanetWars.Models.MilitaryUnits
{
    using System;

    using PlanetWars.Models.MilitaryUnits.Contracts;

    public abstract class MilitaryUnit:IMilitaryUnit
    {
        private double cost;

        private  int enduranceLevel;

        public MilitaryUnit(double cost)
        {
            this.Cost=cost;
            this.EnduranceLevel = 1;
        }

        public double Cost
        {
            get => this.cost;
           private set => this.cost = value;
        }

        public int EnduranceLevel
        {
            get => this.enduranceLevel;
           private set =>
               this.enduranceLevel = value;
               
           
        }

        public void IncreaseEndurance()
        {
            this.EnduranceLevel += 1;
            if (this.EnduranceLevel>=20)
            {
                this.EnduranceLevel = 20;
                throw new ArgumentException("Endurance level cannot exceed 20 power points.");
            }
        }
    }
}