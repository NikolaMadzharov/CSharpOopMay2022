using System.Collections.Generic;
using System.Linq;

using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;

public class WeaponRepository : IRepository<IWeapon>
{
    private readonly List<IWeapon> weapons;

    public WeaponRepository()
    {
        weapons = new List<IWeapon>();
    }
    public IReadOnlyCollection<IWeapon> Models
    {
        get => weapons.AsReadOnly();
    }
    public void AddItem(IWeapon model)
    {
        weapons.Add(model);
    }

    public IWeapon FindByName(string name)
    {
        var weapon = weapons.FirstOrDefault(x => GetType().Name == name);
        return weapon;
    }

    public bool RemoveItem(string name)
    {
        var remoteWeapon = weapons.FirstOrDefault(x => GetType().Name == name);
        return weapons.Remove(remoteWeapon);
    }
}