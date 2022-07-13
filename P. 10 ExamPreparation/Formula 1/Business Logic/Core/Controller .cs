using Formula1.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System.Linq;

namespace Formula1.Core
{
    public class Controller : IController


    {
        private readonly PilotRepository pilotRepository;
        private readonly FormulaOneCarRepository formulaOneCarRepository;
        private readonly RaceRepository raceRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            formulaOneCarRepository = new FormulaOneCarRepository();
            raceRepository = new RaceRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);
            if (pilot== null || pilot.Car!=null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            IFormulaOneCar formulaOneCar = formulaOneCarRepository.FindByName(carModel);
            if (formulaOneCar==null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            pilot.AddCar(formulaOneCar);
            formulaOneCarRepository.Remove(formulaOneCar);

            return String.Format(OutputMessages.SuccessfullyPilotToCar,pilotName,formulaOneCar.GetType().Name,carModel);

        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRepository.FindByName(raceName);
            if (race== null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            IPilot pilot = pilotRepository.FindByName(pilotFullName);
            if (pilot== null || !pilot.CanRace||race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage,pilotFullName));
            }
            race.Pilots.Add(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace,pilotFullName,race);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            
            if (formulaOneCarRepository.FindByName(model)!=null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            
            if (type!= "Ferrari" && type!= "Williams")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar,type));
            }
            IFormulaOneCar car = null;
            if (type=="Ferrari")
            {
                car =  new Ferrari(model,horsepower,engineDisplacement);
            }
            else if (type=="Williams")
            {
               car = new Williams(model,horsepower,engineDisplacement);
            }
            
           formulaOneCarRepository.Add(car);
            return string.Format(OutputMessages.SuccessfullyCreateCar,type,model);
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot= pilotRepository.FindByName(fullName);
            if (pilot!=null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            pilotRepository.Add(new Pilot(fullName));
            return string.Format(OutputMessages.SuccessfullyCreatePilot,fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            
            if (raceRepository.FindByName(raceName)!=null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            raceRepository.Add(new Race(raceName, numberOfLaps));
            return string.Format(OutputMessages.SuccessfullyCreateRace,raceName);
        }

        public string PilotReport()
        {
            StringBuilder info = new StringBuilder();
            foreach (var pilot in pilotRepository.Models.OrderByDescending(x=>x.NumberOfWins))
            {
                info.AppendLine(pilot.ToString());
            }
            return info.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var race in raceRepository.Models.Where(x => x.TookPlace == true))
            {
                stringBuilder.AppendLine(race.RaceInfo());
            }
            return stringBuilder.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            IRace race =  raceRepository.FindByName(raceName);
            if (race==null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (race.Pilots.Count<3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }
            List<IPilot> pilots = race.Pilots.OrderByDescending(x=>x.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
            pilots[0].WinRace();
            race.TookPlace = true;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.PilotFirstPlace, pilots[0].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotSecondPlace, pilots[1].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotThirdPlace, pilots[2].FullName, raceName));

            return sb.ToString().Trim();
        }
    }
}
