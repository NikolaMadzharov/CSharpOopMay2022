﻿using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Repositories.Contracts;
using Formula1.Models.Contracts;
using System.Linq;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> models;
        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models => models.AsReadOnly();

       
        public void Add(IFormulaOneCar model)
        {
            models.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return models.FirstOrDefault(x=>x.Model==name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return models.Remove(model);
        }
    }
}
