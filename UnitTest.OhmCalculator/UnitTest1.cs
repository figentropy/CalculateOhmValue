using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entity;



namespace UnitTest.OhmCalculator
{
    [TestClass]
    public class Class1
    {



        [TestMethod]
        public void TryShootBug()
        {
            // Arrange
            // Act
            // Assert 

            //Bug bug = new Bug();

            //gun.FireAt(bug);

            //Assert.IsTrue(bug.IsDead());
            //Assert.IsTrue(gun.HasAmmo());
        }



        [TestInitialize]
        public void Initialize()
        {
            //gun = new Raygun();
        }

        [TestCleanup]
        public void Cleanup()
        {
            //gun.Recharge();
        }




        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void TryMakingHeapsOfGuns()
        {

            //Raygun[] guns = new Raygun[5];
            //Bug bug = new Bug();

            //guns[5].FireAt(bug);

        }

    }

}
