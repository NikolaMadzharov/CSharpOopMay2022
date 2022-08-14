using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    using System.Runtime.InteropServices.ComTypes;

    public class Tests
    {
        [Test]
        public void constructorWithValidData()
        {

            var planet = new Planet("Earth", 1000);

            Assert.AreEqual("Earth",planet.Name);

            Assert.AreEqual(1000,planet.Budget);

            Assert.AreEqual(0,planet.Weapons.Count);

        }

    
        [Test]
        public void ComstrictorWithNullorEmptyNameShouldThrowArgumentNullException()
        {



            Assert.Throws<ArgumentException>(() => new Planet("", 10));
            Assert.Throws<ArgumentException>(() => new Planet(null, 10));

        }

        [Test]
        public void ComstrictorWithZeroOrNegativeShouldThrowArgumentException()
        {



           
            Assert.Throws<ArgumentException>(() => new Planet("Earth", -5));

        }

        [Test]
        public void WeaponCountShouldIncrease()
        {
            var weapon = new Weapon("Ak47", 100, 100);

            var planet = new Planet("Earth", 1000);

            planet.AddWeapon(weapon);

            Assert.AreEqual(1,planet.Weapons.Count);

        }

        [Test]
        public void BudgetMethodShouldIncreateValue()
        {
            var planet = new Planet("Earth", 1000);

            planet.Profit(25);

            Assert.AreEqual(1025,planet.Budget);
        }

        [Test]
        public void ShouldThrowAnError()
        {

            var planet = new Planet("Earth", 1000);



            Assert.Throws<InvalidOperationException>((() => planet.SpendFunds(10000)));
        }

        [Test]
        public void ShouldDecreaseTheValueOfTheBudget()
        {

            var planet = new Planet("Earth", 1000);

            planet.SpendFunds(900);

            Assert.AreEqual(100,planet.Budget);
        }

        [Test]
        public void AddWeaponShoudReturnCorectValue()
        {

            var weapon = new Weapon("Ak47", 100, 100);

            var planet = new Planet("Earth", 1000);
            
            planet.AddWeapon(weapon);

            Assert.AreEqual(1,planet.Weapons.Count);
        }

        [Test]
        public void AddWeaponInvalidData()
        {

            var weapon = new Weapon("Ak47", 100, 100);

            var planet = new Planet("Earth", 1000);

            planet.AddWeapon(weapon);

            Assert.Throws<InvalidOperationException>((() => planet.AddWeapon(new Weapon("Ak47", 100, 100))));

        }

        [Test]
        public void RemoveWeapon()
        {
            var weapon = new Weapon("Ak47", 100, 100);

            var planet = new Planet("Earth", 1000);

            planet.AddWeapon(weapon);

            planet.RemoveWeapon("Ak47");

            Assert.AreEqual(0,planet.Weapons.Count);

        }

        [Test]
        public void UpgradeWeaponInvalidData()
        {
            var weapon = new Weapon("Ak47", 100, 100);

            var planet = new Planet("Earth", 1000);

            Assert.Throws<InvalidOperationException>((() => planet.UpgradeWeapon("asfa")));

        }

        [Test]
        public void DestructOpponentWithValidData()
        {

            var planet = new Planet("Earth", 1000);

            var planetOpononent = new Planet("Mars", 100000);

            Assert.Throws<InvalidOperationException>((() => planet.DestructOpponent(planetOpononent)));
        }

      
        [Test]
        public void DestructOpponentTest2()
        {
           var planet= new Planet("Eart", 10);
            var weapon = new Weapon("AK47", 50, 10);

            Planet p2 = new Planet("Bobo", 10);
            planet.AddWeapon(weapon);

            Assert.AreEqual($"{p2.Name} is destructed!", planet.DestructOpponent(p2));
        }

        [Test]
        public void weaponConstructorWithValidData()
        {

            var weapon = new Weapon("AK47", 100, 100);

            Assert.AreEqual("AK47",weapon.Name);

            Assert.AreEqual(100,weapon.Price);

            Assert.AreEqual(100,weapon.DestructionLevel);
        }

        [Test]
        public void WeaponWithInvalidPrice()
        {
            Assert.Throws<ArgumentException>((() => new Weapon("AK47", -10, 10)));

        }

        [Test]
        public void IncreaseDestructionLevelWithValidData()
        {

            var weapon = new Weapon("AK47", 100, 100);

            weapon.IncreaseDestructionLevel();

            Assert.AreEqual(101,weapon.DestructionLevel);
        }

        [Test]
        public void upgradeWeapon()
        {
            var weapon = new Weapon("Ak47", 100, 100);

            var planet = new Planet("Earth", 1000);

            planet.AddWeapon(weapon);
            
            planet.UpgradeWeapon("Ak47");

            Assert.AreEqual(101,weapon.DestructionLevel);
        }

        [Test]
        public void IsNuclear()
        {

            var weapon = new Weapon("Ak47", 100, 100);

           

            Assert.AreEqual(true,weapon.IsNuclear);
        }

        [Test]
        public void IsNotNuclear()
        {

            var weapon = new Weapon("Ak47", 100, 9);



            Assert.AreEqual(false, weapon.IsNuclear);
        }


    }
}
