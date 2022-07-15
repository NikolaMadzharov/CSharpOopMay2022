using System;
using System.Collections.Generic;
using System.Text;
using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullname;
        private string motivation;
        private int numberofmedal;

        protected Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            FullName = fullName;
            Motivation = motivation;
            NumberOfMedals = numberOfMedals;
            Stamina = stamina;
        }

        public string FullName { get { return fullname; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }
                fullname = value; 
            } 
        }

        public string Motivation { get { return motivation; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException(ExceptionMessages.InvalidAthleteMotivation);
                }
                motivation = value; 
            } 
        }

        public int Stamina { get;protected set; }

        public int NumberOfMedals { get { return numberofmedal; }
            private set 
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }
                numberofmedal = value;
            }
        }
        public abstract string AllowedGym { get; }
        public abstract void Exercise();
        
    }
}
