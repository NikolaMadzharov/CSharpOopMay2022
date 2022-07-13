using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Utilities;
using Formula1.Models.Contracts;

namespace Formula1
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private readonly ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get { return raceName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) ||value.Length<5)
                {
                    throw new ArgumentException(String.Format( ExceptionMessages.InvalidRaceName, value));
                }
                raceName = value; 
            } 
        }

        public int NumberOfLaps { get { return numberOfLaps; } 
            private set 
            {
                if (value<1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidLapNumbers,value));
                }
                numberOfLaps = value; 
            } 
        }

        public bool TookPlace { get;  set; } = false;

        public ICollection<IPilot> Pilots => pilots;

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Then {RaceName} race has:");
            sb.AppendLine($"Participants: {Pilots.Count}");
            sb.AppendLine($"Number of laps: {NumberOfLaps}");
            sb.AppendLine($"Took place: {(TookPlace ? "Yes" : "No")}");

            return sb.ToString().Trim();
        }
    }
}
