using System;
using System.Collections.Generic;
using System.Text;
using Gym.Models.Equipment.Contracts;
using Gym.Utilities.Messages;


namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        protected Equipment(double weight, decimal price)
        {
            Weight = weight;
            Price = price;
        }

        public double Weight { get; protected set; }

        public decimal Price { get; protected set; }
    }
}
