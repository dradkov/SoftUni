namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DummyTests
    {
        private const int dummyHealth = 10;
        private const int dummyExperiance = 10;

        private Dummy dummy;

        [SetUp]
        public void StartTesting()
        {
            this.dummy = new Dummy(dummyHealth, dummyExperiance);

        }

        [Test]
        public void CheckDummyLosesHealthIfAttacked()
        {
            // Arrange
            this.dummy.TakeAttack(10);

            //Assert
            Assert.AreEqual(0,this.dummy.Health, "Dummy Health Doesn't work correctly");

        }

        [Test]
        public void CheckDeadDummyThrowsExceptionIfAttacked()
        {
            // Arrange
            this.dummy = new Dummy(0,dummyExperiance);

            //Act
            var ex = Assert.Throws<InvalidOperationException>(() => this.dummy.TakeAttack(10));

            //Assert
            Assert.AreEqual("Dummy is dead.",ex.Message);
        }


        [Test]
        public void CheckDeadDummyCanGiveXP()
        {

            //Act
            var ex = Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());

            //Assert
            Assert.AreEqual("Target is not dead.", ex.Message);
        }

        [Test]
        public void CheckAlliveDummyCannnotGiveXP()
        {

            // Arrange
            this.dummy = new Dummy(0, dummyExperiance);

            //Act
            dummy.GiveExperience();

            //Assert
            Assert.AreEqual(10,dummy.GiveExperience());
        }
    }
}
