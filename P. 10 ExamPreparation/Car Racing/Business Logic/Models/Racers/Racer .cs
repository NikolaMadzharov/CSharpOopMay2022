using System;
using System.Text;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Racers
{
    public abstract class Racer:IRacer
    {
        private string username;
        private string racingbehavior;
        private int drivingexperience;
        private ICar car;

        public Racer(string username, string racingbehavior, int drivingexperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingbehavior;
            this.DrivingExperience = drivingexperience;
            this.Car = car;
        }


        public string Username
        {
            get { return username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }
                username = value;
            }
        }
        public string RacingBehavior
        {
            get { return racingbehavior; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }
                racingbehavior = value;

            }
        }
        public int DrivingExperience
        {
            get { return drivingexperience; }
            protected set
            {
                if (value<0||value>100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                drivingexperience = value;
            }
        }
        public ICar Car
        {
            get { return car; }
            private set
            {
                if (value==null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }
                car = value;
            }
        }

        public abstract void Race();
       

        public bool IsAvailable()
        {
            if (car.FuelAvailable>=car.FuelConsumptionPerRace)
            {
                return true;
            }

            return false;
        }
        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"{this.GetType().Name}: {Username}");
            text.AppendLine($"--Driving behavior: {RacingBehavior}");
            text.AppendLine($"--Driving experience: {DrivingExperience}");
            text.AppendLine($"--Car: {Car.Make} {Car.Model} ({Car.VIN})");
            return text.ToString().Trim();
        }
    }
}