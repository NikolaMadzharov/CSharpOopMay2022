using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Core
{
    public class Controller:IController
    {
        private readonly IRepository<IEquipment> equipmentRepository;
        private readonly ICollection<IGym> gymCollection;

        public Controller()
        {
            equipmentRepository = new EquipmentRepository();
            gymCollection = new List<IGym>();
        }
        public string AddGym(string gymType, string gymName)
        {

            IGym gym = null;
            if (gymType== "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType== "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            gymCollection.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);

        }
        public string AddEquipment(string equipmentType)
        {
            IEquipment typEquipment = null;
            if (equipmentType== "BoxingGloves")
            {
                typEquipment = new BoxingGloves();
            }
            else if (equipmentType== "Kettlebell")
            {
                typEquipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            equipmentRepository.Add(typEquipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = equipmentRepository.FindByType(equipmentType);
            if (equipment == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            else
            {   
                gymCollection.First(x=>x.Name==gymName).AddEquipment(equipment);
            }

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = gymCollection.First(x => x.Name == gymName);

            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            Type type = Type.GetType($"Gym.Models.Athletes.{athleteType}");
            object[] args = new object[]
            {
                athleteName,
                motivation,
                numberOfMedals
            };

            Athlete instance = null;
            try
            {
                instance = Activator.CreateInstance(type, args) as Athlete;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }

            if (instance.AllowedGym != gym.GetType().Name)
            {
                return OutputMessages.InappropriateGym;
            }

            gym.AddAthlete(instance);
            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);


        }

        public string TrainAthletes(string gymName)
        {
            ICollection<IAthlete> athletes = gymCollection.First(x => x.Name == gymName).Athletes;
            foreach (var athlete in athletes)
            {
                athlete.Exercise();
            }

            return string.Format(OutputMessages.AthleteExercise, athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym GYM = gymCollection.First(x => x.Name == gymName);
            return  string.Format(OutputMessages.EquipmentTotalWeight,gymName,GYM.EquipmentWeight );
        }

        public string Report()
        {
            StringBuilder info = new StringBuilder();
            foreach (var athlete in gymCollection)
            {
                info.AppendLine(athlete.GymInfo());
            }
            return info.ToString().TrimEnd();
        }
    }
}
