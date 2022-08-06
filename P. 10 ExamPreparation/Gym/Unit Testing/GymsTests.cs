namespace Gyms.Tests
{
    using System;

    using NUnit.Framework;

    public class GymsTests
    {

        [Test]
        public void validConstructor()
        {
            var gym = new Gym("Trakia", 10);

            Assert.AreEqual(10,gym.Capacity);

            Assert.AreEqual(0,gym.Count);

            Assert.AreEqual("Trakia",gym.Name);
        }

        [Test]
        public void invalidGymName()
        {
            

            Assert.Throws<ArgumentNullException>((() => new Gym("", 1230)));
            //throw new ArgumentNullException(nameof(value), "Invalid gym name.");
        }

        [Test]

        public void InvalidGymCapacityException()
        {
            //throw new ArgumentException("Invalid gym capacity.");

            Assert.Throws<ArgumentException>((() => new Gym("Trakia", -10)));
        }
        [Test]
        public void ShouldIncreateTheValueOfAthltes()
        {
            var gym = new Gym("Trakia",10);

            var athelete = new Athlete("Ivan Petrov");

            gym.AddAthlete(athelete);

            Assert.AreEqual(1,gym.Count);
            // public int Count => this.athletes.Count;vvvvv
        }

        [Test]
        public void TheGymIsFull()
        {

            var gym = new Gym("Trakia", 1);

            var athelete = new Athlete("PESHO");

            var athelete2 = new Athlete("Ivan");

            gym.AddAthlete(athelete);



            Assert.Throws<InvalidOperationException>((() => gym.AddAthlete(athelete2)));
            //throw new InvalidOperationException("The gym is full.");

        }

        [Test]
        public void RemoveAthelte()
        {


            //throw new InvalidOperationException($"The athlete {fullName} doesn't exist.");

            var gym = new Gym("Trakia", 10);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Ivan"));


        }

        [Test]
        public void RemoveAtheleShouldDEcreaseTheCount()
        {

            var gym = new Gym("trakia", 10);

            var athlete = new Athlete("Ivan");

            gym.AddAthlete(athlete);

           gym.RemoveAthlete("Ivan");

            Assert.AreEqual(0,gym.Count);
        }

        [Test]

        public void IsInjuredAtheleteShouldReturnTheAthlete()
        {
            var gym = new Gym("Trakia", 10);

            var athlete = new Athlete("Ivan");

            gym.AddAthlete(athlete);

            var injuredAthlete = gym.InjureAthlete("Ivan");

            Assert.IsNotNull(injuredAthlete);

            Assert.AreEqual(true,injuredAthlete.IsInjured);
        }

        [Test]
        //throw new InvalidOperationException($"The athlete {fullName} doesn't exist.");
        public void IsInjuredAthelete()
        {
            var gym = new Gym("Trakia", 10);

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Ivan"));
        }



    }
}
