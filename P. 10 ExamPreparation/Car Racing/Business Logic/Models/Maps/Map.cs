using System;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using CarRacing.Models;

namespace CarRacing.Models.Maps
{
    public class Map:IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable()==true&&racerTwo.IsAvailable()==false)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);

            }
            else if (racerOne.IsAvailable()==false&&racerOne.IsAvailable()==true)
            {
                return string.Format(OutputMessages.RacerWinsRace, racerTwo.Username, racerOne.Username);

            }
            else if (racerOne.IsAvailable()==false&&racerTwo.IsAvailable()==false)
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }

            double racerOneChanceOfWinning = 0;
            double racerTwoChanceOfWinning = 0;
            if (racerOne.RacingBehavior== "strict" && racerTwo.RacingBehavior== "aggressive")
            {
                racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.2;
                racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.1;
            }
            if (racerOne.RacingBehavior == "aggressive" && racerTwo.RacingBehavior == "strict")
            {
                racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.1;
                racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.2;
            }

            if (racerOneChanceOfWinning>racerTwoChanceOfWinning)
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username,
                    racerOne.Username);
            }
                return string.Format(OutputMessages.RacerWinsRace, racerTwo.Username, racerOne.Username,
                    racerTwo.Username);
            

        }
        
    }
}