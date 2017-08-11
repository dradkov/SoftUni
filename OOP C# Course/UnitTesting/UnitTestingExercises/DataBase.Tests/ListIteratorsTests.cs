namespace DataBase.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using _01.DataBase.Models;

    [TestFixture]
    public class ListIteratorsTests
    {

        private ListIterator<string> listIterator;


        [SetUp]
        public void StartTesting()
        {
            this.listIterator = new ListIterator<string>(new List<string>(){"Jordan","Messi","Ronaldo"});
        }


        [Test]
        public void TestConstructorWithNullCollection()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => this.listIterator = new ListIterator<string>(null));
        }

        [Test]
        public void CheckMoveMethodIsPossible()
        {

            for (int i = 0; i < 2; i++)
            {
                bool result = this.listIterator.Move();

                Assert.IsTrue(result);
            }

        }
        [Test]
        public void CheckMoveMethodIsNotPossible()
        {

            for (int i = 0; i < 0; i++)
            {
                bool result = this.listIterator.Move();

                Assert.IsFalse(result);
            }

        }
        [Test]
        public void CheckMoveMethodIfCollectionIsEmpty()
        {
            //Arrange
           var list = new ListIterator<string>(new string[0]);

           //Act
           var result= list.Move();

            Assert.IsFalse(result);

        }
        [Test]
        public void CheckHasNextMethod()
        {
            //Act
            var result= this.listIterator.HasNext();


            //Assert
            Assert.IsTrue(result);

        }
        [Test]
        public void CheckHasNextMethodIfItIsAtLastIndex()
        {

            //Act
            this.listIterator.Move();
            this.listIterator.Move();
            var result = this.listIterator.HasNext();

            //Assert
            Assert.IsFalse(result);

        }
        [Test]
        public void CheckHasNextMethodIfItIsEmptyCollection()
        {
            //Arrange
           this.listIterator = new ListIterator<string>(new string[0]);

            //Act        
            var result = this.listIterator.HasNext();

            //Assert
            Assert.IsFalse(result);

        }

        [Test]
        public void CheckPrintMethod()
        {
           
            //Act        
            var result = this.listIterator.Print();

            //Assert
            Assert.AreEqual("Jordan", result);

        }
        [Test]
        public void CheckPrintMethodWithEmptyCollection()
        {
            //Arrange
            this.listIterator = new ListIterator<string>(new string[0]);   

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.listIterator.Print());

        }

    }
}
