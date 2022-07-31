using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    using System;

    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void TestConstructorIfWorksCorrectly()
        {
            Shop shop = new Shop(2);

            Assert.AreEqual(2,shop.Capacity);
            Assert.AreEqual(0,shop.Count);
        }

        [Test]
        public void InvalidCapacityShouldThrowAnError()
        {


            Assert.Throws<ArgumentException>(() => new Shop(-10));
           
        }

        [Test]
        public void ShouldAdddPhone()
        {
            var shop = new Shop(1);

            Smartphone smartphone = new Smartphone("Nokia", 1);

            shop.Add(smartphone);
            

            Assert.AreEqual(1,shop.Count);
        }

        [Test]
        public void ThePhoneAlreadyExist()
        {

            Shop shop = new Shop(10);

            Smartphone smartphone = new Smartphone("Nokia", 100);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(()=>shop.Add(new Smartphone("Nokia", 100)));
        }
        //throw new InvalidOperationException("The shop is full.");

        [Test]
        public void TheShopIsFull()
        {
            Smartphone smartphone = new Smartphone("Nokia", 1230);

            Shop shop= new Shop(1);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("Iphone",12)));

        }
        //throw new InvalidOperationException($"The phone model {modelName} doesn't exist.");

        [Test]
        public void ShouldThrowAnErrorIfThePhoneDoesNotExist()
        {
            Smartphone smartphone = new Smartphone("Nokia", 100);

            Shop shop= new Shop(10);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("lg"));
        }

        [Test]
        public void TheCountOfThePhonesShouldBeReduced()
        {
            Smartphone smartphone = new Smartphone("Nokia", 100);

            Smartphone lgSmartphone = new Smartphone("LG", 99);

            Shop shop = new Shop(4);

            shop.Add(lgSmartphone);

            shop.Add(smartphone);

            shop.Remove("LG");

            Assert.AreEqual(1,shop.Count);

        }

        //throw new InvalidOperationException($"The phone model {modelName} doesn't exist.");
        [Test]
        public void TestPhoneShouldThrowAnErrorThePhoneDoesNotExist()
        {
            Smartphone smartphone = new Smartphone("Samsung", 100);

            Shop shop = new Shop(10);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Iphone", 10));

        }

        [Test]
        public void PhoneIsLowbattery()
        {
            Smartphone smartphone = new Smartphone("Nokia", 10);

            Shop shop = new Shop(10);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Nokia",20));

        }

        [Test]

        public void ChargePhone()
        {

            //Smartphone smartphone = new Smartphone("Nokia", 100);

            Shop shop = new Shop(10);

            //shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("asoiuhiasoujsfoiluajhiopf"));

        }

    }
}