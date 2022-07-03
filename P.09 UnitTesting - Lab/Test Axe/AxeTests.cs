using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Test1()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy =  new Dummy(10,10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
        }
        [Test]
        public void Test2()
        {
            Axe axe = new Axe(10, -10);
            Dummy dummy = new Dummy(10, 10);

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException);
        }
    }
}