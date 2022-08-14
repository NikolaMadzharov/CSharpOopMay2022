


namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Repositories.Contracts;

    using System.Collections.Generic;
    using System.Linq;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;
        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => this.models.AsReadOnly();

        public void AddItem(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveItem(string name)
        {
            var item = this.models.FirstOrDefault(x => x.GetType().ToString() == name);
            if (item == null)
            {
                return false;
            }
            this.models.Remove(item);
            return true;
        }
    }
}