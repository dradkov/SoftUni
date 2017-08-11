namespace Skeleton.Tests
{
    using System;
    using NUnit.Framework;
    using Skeleton.Interfaces;
    using Moq;

    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void CheckHeroGainsXPWhenTargetDies()
        {

            // Arrange
            IWeapon fakeAxe = new Axe(10, 10);
            ITarget fakeDummy = new Dummy(10, 10);
            var hero = new Hero("Gosho", fakeAxe);
            var experience = hero.Experience;

            //Act
            hero.Attack(fakeDummy);


            //Assert
            Assert.AreEqual((experience + 10), hero.Experience);

        }

        [Test]
        public void CheckHeroIfTargetIsAlliveNoIncreaseExperiance()
        {
            Mock<IWeapon> fakeAxe = new Mock<IWeapon>();
            Mock<ITarget> fakeDummy = new Mock<ITarget>();

            Mock<IWeapon> weapon = new Mock<IWeapon>();
            Mock<ITarget> target = new Mock<ITarget>();
            target.Setup(t => t.IsDead()).Returns(true);
            target.Setup(t => t.GiveExperience()).Throws(new InvalidOperationException("Target is not dead."));

            Hero hero = new Hero("Dimitar", weapon.Object);

            Exception ex = Assert.Throws<InvalidOperationException>(() => hero.Attack(target.Object));
            Assert.AreEqual("Target is not dead.", ex.Message);

        }


    }

  
}
