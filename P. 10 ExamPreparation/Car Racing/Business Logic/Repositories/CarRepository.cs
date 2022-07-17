using System;
using System.Collections.Generic;
using System.Linq;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class CarRepository:IRepository<ICar>
    {
        private readonly List<ICar> cars;

        public CarRepository()
        {
            cars= new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models =>cars;
        public void Add(ICar model)
        {
           // ICar car = cars.FirstOrDefault(x => x.Model.GetType() == model.GetType());
            //if (car==null)
            //{
              //  throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            // }
            //cars.Add(car);
             if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }
            cars.Add(model);
        }

        public bool Remove(ICar model)
        {
            return cars.Remove(model);
            // ICar car = cars.FirstOrDefault(x => x.Model.GetType() == model.GetType());
            // return cars.Remove(car);
        }

        public ICar FindBy(string property)
        {
            return cars.FirstOrDefault(x => x.VIN == property);
            // return cars.FirstOrDefault(x => x.VIN == property);
        }
    }
}