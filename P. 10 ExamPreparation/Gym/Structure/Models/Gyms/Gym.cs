using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipments;
        private List<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipments = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name { get { return name; } 
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value; 
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => equipments.Select(x=>x.Weight).Sum();

        public ICollection<IEquipment> Equipment => equipments;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity == 0)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughSize);
            }
            athletes.Add(athlete);
            Capacity--;
        }

        public void AddEquipment(IEquipment equipment)
        {
          equipments.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder info =  new StringBuilder();
            info.AppendLine($"{name} is a {name.GetType()}:");
            if (athletes.Any())
            {
                foreach (var athlete in Athletes)
                {
                    info.AppendLine($"Athletes: {athlete.FullName}");
                }
            }
            else
            {
                info.AppendLine("No athletes");         
            }
            info.AppendLine($"Equipment total count: {equipments.Count}");
            info.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");
            return info.ToString().Trim();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return Athletes.Remove(athlete);
        }
    }
}
