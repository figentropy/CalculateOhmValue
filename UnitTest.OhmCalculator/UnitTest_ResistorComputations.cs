using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;



namespace UnitTest.OhmCalculator
{

    [TestClass]
    public class UnitTest_ResistorComputations
    {


        [TestInitialize]
        public void Initialize()
        {

        }

        

        [TestMethod]
        public void CalculateOhmValue()
        {
            Services.UseCase.ResistorComputations resistor = new Services.UseCase.ResistorComputations(new Infrastructure.ExceptionManager.DatabaseLogger());
            Dictionary<string, int> banda = new Dictionary<string, int>();
            Dictionary<string, int> bandb = new Dictionary<string, int>();
            int result = 0; 

            // Assign test data
            banda.Add("Brown", 1);
            banda.Add("Red", 2);
            banda.Add("Orange", 3);
            banda.Add("Yellow", 4);
            banda.Add("Green", 5);
            banda.Add("Blue", 6);
            banda.Add("Violet", 7);
            banda.Add("Gray", 8);
            banda.Add("White", 9);

            bandb.Add("Black", 0);
            bandb.Add("Brown", 1);
            bandb.Add("Red", 2);
            bandb.Add("Orange", 3);
            bandb.Add("Yellow", 4);
            bandb.Add("Green", 5);
            bandb.Add("Blue", 6);
            bandb.Add("Violet", 7);
            bandb.Add("Gray", 8);
            bandb.Add("White", 9);


            for (int i = 0; i < banda.Count; i++)
            {
                result = resistor.CalculateOhmValue(banda.ElementAt(i).Key, "blue", "red", "gold");

                Assert.IsTrue(result == Convert.ToInt32(banda.ElementAt(i).Value.ToString() + "6"));
            }

            for (int i = 0; i < bandb.Count; i++)
            {
                result = resistor.CalculateOhmValue("blue",bandb.ElementAt(i).Key, "red", "gold");

                Assert.IsTrue(result == Convert.ToInt32("6" + bandb.ElementAt(i).Value.ToString() ));
            }




        }

        [TestMethod]
        public void TestAllValidMultiplierColors()
        {
            Services.UseCase.ResistorComputations resistor = new Services.UseCase.ResistorComputations(new Infrastructure.ExceptionManager.DatabaseLogger());
            List<string> colors = new List<string>() { "Black", "Brown", "Red", "Orange", "Yellow", "Green", "Blue", "Violet", "Gray", "White", "Gold", "Silver" };
            double multiplier = 0;

            for (int i = 0; i < colors.Count; i++)
            {
                multiplier = resistor.GetMultiplier(colors[i]);

                Assert.IsTrue(multiplier != -33);
            }



        }



        [TestMethod]
        public void TestAllValidToleranceColors()
        {
            Services.UseCase.ResistorComputations resistor = new Services.UseCase.ResistorComputations(new Infrastructure.ExceptionManager.DatabaseLogger());
            List<string> colors = new List<string>() { "Brown", "Red", "Orange", "Yellow", "Green", "Blue", "Violet", "Gray", "Gold", "Silver" };
            double multiplier = 0;

            for (int i = 0; i < colors.Count; i++)
            {
                multiplier = resistor.GetTolerance(colors[i]);

                Assert.IsTrue(multiplier != -33);
            }

        }




        [TestMethod]
        public void TestGetMaxResistance_WithKnownValue()
        {
            Services.UseCase.ResistorComputations resistor = new Services.UseCase.ResistorComputations(new Infrastructure.ExceptionManager.DatabaseLogger());
            double maxResistance = 0;

                maxResistance = resistor.GetMaxResistance(10.0, 10);

                Assert.IsTrue(maxResistance == 11);

        }


        [TestMethod]
        public void TestGetMinResistance_WithKnownValue()
        {
            Services.UseCase.ResistorComputations resistor = new Services.UseCase.ResistorComputations(new Infrastructure.ExceptionManager.DatabaseLogger());
            double maxResistance = 0;

            maxResistance = resistor.GetMinResistance(10.0, 10);

            Assert.IsTrue(maxResistance == 9);

        }



        [TestMethod]
        public void TestResistance_WithKnownValue()
        {
            Services.UseCase.ResistorComputations resistor = new Services.UseCase.ResistorComputations(new Infrastructure.ExceptionManager.DatabaseLogger());
            double resistance = 0;

            resistance = resistor.GetResistance(26, 0);

            Assert.IsTrue(resistance == 26);

        }






    }
}
