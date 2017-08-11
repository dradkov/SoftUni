namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;


    [TestFixture]
    public class AxeTests
    {

        private const int axeHealth = 10;
        private const int axeDurability = 10;
        private const int dummyHealth = 10;
        private const int dummyExperiance = 10;


        private Axe axe;
        private Dummy dummy;


        [SetUp]
        public void StartTest()
        {
            this.axe = new Axe(axeHealth,axeDurability);
            this.dummy = new Dummy(dummyHealth, dummyExperiance);
        }


        [Test]
        public void CheckAxeLosesDurabilityAfterEachAttack()
        {
           
            //Act
            this.axe.Attack(dummy);

            //Assert
            Assert.AreEqual(9, this.axe.DurabilityPoints);

        }

        [Test]
        public void CheckAxeAttackingWithABrokenWeapon()
        {
            // Arrange
            this.axe = new Axe(axeHealth, 0);
          
            //Act
            var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));

            //Assert
            Assert.AreEqual("Axe is broken.",ex.Message);
        }
    }
}
