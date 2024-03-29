﻿using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Repositories.Contracts;
using Formula1.Models.Contracts;
using System.Linq;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> models;

        public PilotRepository()
        {
            models = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => models.AsReadOnly();

        public void Add(IPilot model)
        {
            models.Add(model);
        }

        public IPilot FindByName(string name)
        {
            return models.FirstOrDefault(x=>x.FullName==name);
        }

        public bool Remove(IPilot model)
        {
            return models.Remove(model);
        }
    }
}
