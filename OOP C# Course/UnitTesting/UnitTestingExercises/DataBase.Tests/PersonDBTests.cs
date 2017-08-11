namespace DataBase.Tests
{
    using System;
    using NUnit.Framework;
    using _01.DataBase.Models;

    [TestFixture]
    public class PersonDBTests
    {

        private PeopleDataBase dataBase;

        [SetUp]
        public void StartTesting()
        {
            this.dataBase = new PeopleDataBase(new Person(12, "Ivan"), new Person(44, "Gosho"));
        }


        [Test]
        public void CheckNewPersonAtStorage()
        {

            //Assert
            Assert.AreEqual(2, this.dataBase.Count, "DataBase Constructor doesn't work correctly");


        }

        [Test]
        public void CheckAddMethod()
        {

            //Act
            dataBase.Add(new Person(007, "Sretan"));

            //Assert
            Assert.AreEqual(3, this.dataBase.Count, "Add Method doesn't work correctly");

        }

        [Test]
        public void CheckAddMethodIfExistingId()
        {
            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => this.dataBase.Add(new Person(12, "Ptkan")));
            Assert.AreEqual("The Person Already Exist", ex.Message);

        }
        [Test]
        public void CheckAddMethodIfExistingUserName()
        {
            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => this.dataBase.Add(new Person(10, "Ivan")));
            Assert.AreEqual("The Person Already Exist", ex.Message);

        }

        [Test]
        public void CheckRemoveMethod()
        {

            //Act
            this.dataBase.Remove();

            //Assert
            Assert.AreEqual(1, dataBase.Count, "Remove Method doesn't work correctly");
        }

        [Test]
        public void CheckRemoveMethodIfIsEmpty()
        {

            //Arrange
            var db = new PeopleDataBase();

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => db.Remove());
            Assert.AreEqual("The Storage is Empty", ex.Message);

        }

        [Test]
        public void CheckFindByUserNameMethod()
        {
            //Arrange
            var result = this.dataBase.FindByUsername("Ivan");

            //Assert
             Assert.IsNotNull(result);           
        }

        [Test]
        public void CheckFindByUserNameNotExcistindException()
        {
           
            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => this.dataBase.FindByUsername("Dimi"));
            Assert.AreEqual("The Person doesn't exist", ex.Message);

        }
        [Test]
        public void CheckFindByUserNameNullArgumentException()
        {
            //Assert
            var ex = Assert.Throws<ArgumentNullException>(() => this.dataBase.FindByUsername(string.Empty));
            Assert.AreEqual("Username cannot be empty!", ex.Message);

        }

        [Test]
        public void CheckFindByIdMethod()
        {
            //Arrange
            var result = this.dataBase.FindById(12);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CheckFindByIdMethodDoesntExistException()
        {
           //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => this.dataBase.FindById(123));
            Assert.AreEqual("The Person doesn't exist", ex.Message);

        }
        [Test]
        public void CheckFindByIdMethodNegativeIdException()
        {
            //Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => this.dataBase.FindById(-12));
            Assert.AreEqual("Username cannot be negative!", ex.Message);

        }

    }
}
