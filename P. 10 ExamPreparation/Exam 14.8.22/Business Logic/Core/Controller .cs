

namespace PlanetWars.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using PlanetWars.Core.Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;

    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!"
                );
            }


            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");

            }

            if (unitTypeName != "SpaceForces" && unitTypeName != "StormTroopers" && unitTypeName != "AnonymousImpactUnit")
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!"
                );
            }

            

           
          

            IMilitaryUnit unit = null;

            if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!"
                    );
            }



            if (weaponTypeName != "SpaceMissiles" && weaponTypeName != "NuclearWeapon" && weaponTypeName != "BioChemicalWeapon")
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");

            }



            if (planet.Weapons.Any(u => u.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException( $"{weaponTypeName} already added to the Weapons of {planetName}!"
                    );
            }

            IWeapon weapon = null;

            if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return $"{weaponTypeName} added successfully to the Army of {planetName}!";
        }

        public string CreatePlanet(string name, double budget)
        {
            if (this.planets.FindByName(name) != null)
            {
                return $"Planet {name} is already added!";
            }
            
                IPlanet planet = new Planet(name, budget);
                this.planets.AddItem(planet);

                return $"Successfully added Planet: {name}";


        }

       

        public string ForcesReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in this.planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var planetOneByName = this.planets.FindByName(planetOne);
            var planeTwoByName = this.planets.FindByName(planetTwo);

            var planetOneMP = planetOneByName.MilitaryPower;
            var planetTwoMP = planeTwoByName.MilitaryPower;

            IPlanet planetWinner = null;
            IPlanet PlanetLosing = null;

            if (planetOneMP == planetTwoMP)
            {
                if ((planetOneByName.Weapons.Any(w => w.GetType().Name == "NuclearWeapon") && planeTwoByName.Weapons.Any(w => w.GetType().Name == "NuclearWeapon")) || (planetOneByName.Weapons.Any(w => w.GetType().Name != "NuclearWeapon") && planeTwoByName.Weapons.Any(w => w.GetType().Name != "NuclearWeapon")))
                {
                    var budgetPlanetOne = planetOneByName.Budget * 0.5;
                    var budgetPlanetTwo = planeTwoByName.Budget * 0.5;

                    planetOneByName.Spend(budgetPlanetOne);
                    planeTwoByName.Spend(budgetPlanetTwo);

                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }
                else if (planetOneByName.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    planetWinner = planetOneByName;
                    PlanetLosing = planeTwoByName;
                }
                else if (planeTwoByName.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    planetWinner = planeTwoByName;
                    PlanetLosing = planetOneByName;
                }
            }
            else if (planetOneMP > planetTwoMP)
            {
                planetWinner = planetOneByName;
                PlanetLosing = planeTwoByName;
            }
            else if (planetOneMP < planetTwoMP)
            {
                planetWinner = planeTwoByName;
                PlanetLosing = planetOneByName;
            }
            var winnerSlashBudget = planetWinner.Budget * 0.5;
            var loserHalfBudget = PlanetLosing.Budget * 0.5;

            planetWinner.Spend(winnerSlashBudget);
            planetWinner.Profit(loserHalfBudget);

            var loserAss = PlanetLosing.Army.Sum(u => u.Cost) + PlanetLosing.Weapons.Sum(w => w.Price);
            planetWinner.Profit(loserAss);
            this.planets.RemoveItem(PlanetLosing.Name);

            return $"{planetWinner.Name} destructed {PlanetLosing.Name}!";

        }


        public string SpecializeForces(string planetName)
        {
            var planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!"
                );
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException("No units available for upgrade!");
            }

            planet.Spend(1.25);
            planet.TrainArmy();

            return $"{planetName} has upgraded its forces!";

        }
    }
}
