namespace DataBase.Tests
{
    using System;
    using _01.DataBase.Models;
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class DBTests
    {


        private Database database;

        [SetUp]
        public void StartTesting()
        {
            this.database = new Database(1,2,3);
        }


        [Test]
        public void CheckNewElementAtStorage()
        {
      
            //Assert
            Assert.AreEqual(3, this.database.Count, "DB doesn't register elements correctly");

        }

        [Test]
        public void CheckForZeroCountAtStorage()
        {
            //Arrange
            var db = new Database();


            //Assert
            Assert.AreEqual(0, db.Count, "DB doesn't count elements correctly");

        }

        [Test]
        public void CheckAddMethodInDbClass()
        {

            //Act
            this.database.Add(1);

            //Assert
            Assert.AreEqual(4,  this.database.Count);

        }

        [Test]
        public void CheckAddMethodInDbClassIfCurrentElementAddAtPossition17()
        {
            //Arrange
           var db = new Database(Enumerable.Range(0, 16).ToArray());


            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => db.Add(1));
            Assert.AreEqual("The Storage reach Max Capacity",ex.Message);

        }

        [Test]
        public void CheckRemoveMethodinDbClass()
        {


            //Act
            this.database.Remove();


            //Assert
            Assert.AreEqual(2, this.database.Count);
        }

        [Test]
        public void CheckRemoveLastElementInStorage()
        {

            //Assert
            Assert.That((this.database.Remove() == 3), "Removing last Element is Incorrect");

        }

        [Test]
        public void TryToInitializeNewStorageWithMoreThanCapacityStorage()
        {
            try
            {
                var db = new Database(Enumerable.Range(0, 17).ToArray());
            }
            catch (Exception ex)
            {
               
               Assert.AreEqual("The Storage reach Max Capacity",ex.Message);
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void CheckRemoveMethodIfCountIsZero()
        {
            //Arrange
            var db = new Database();


            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => db.Remove());
            Assert.AreEqual("The Storage is Empty",ex.Message);

        }

        [Test]
        public void CheckFetchMethodReturnsCorrectCollection()
        {
            //Arrange
            var numbersInCollection = Enumerable.Range(0, 16).ToArray();
            var db = new Database(numbersInCollection);
          
            //Act
            var returnedCollection = db.Fetch();

            //Assert
            Assert.IsTrue(numbersInCollection.SequenceEqual(returnedCollection),"The Collection is Incorrect");

        }

        [Test]
        public void CheckFetchMethodReturnsEmptyCollection()
        {
            //Arrange
            var db = new Database();
            var numberInColection = new int[0];

            //Act
            var returnedCollection = db.Fetch();

            //Assert
            Assert.IsTrue(numberInColection.SequenceEqual(returnedCollection), "The Collection is Incorrect");

        }

    }
}
