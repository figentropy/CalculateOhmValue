using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;



namespace UnitTest.OhmCalculator
{

    [TestClass]
    public class UnitTest2
    {

        //Domain.Entity.ColorCodeIEC60062_2016 codes = new Domain.Entity.ColorCodeIEC60062_2016();
        //List<Domain.Entity.ColorCodeIEC60062_2016> colortable = new List<Domain.Entity.ColorCodeIEC60062_2016>();


        [TestInitialize]
        public void Initialize()
        {
            //colortable.Add(new Domain.Entity.ColorCodeIEC60062_2016 { color = "Pink", multiplier = -3 });
            //colortable.Add(new Domain.Entity.ColorCodeIEC60062_2016 { color = "Silver", multiplier = -2, tolerance = 10 });
            //colortable.Add(new Domain.Entity.ColorCodeIEC60062_2016 { color = "Gold", multiplier = -1, tolerance = 5 });
            //colortable.Add(new Domain.Entity.ColorCodeIEC60062_2016 { color = "Black", digit = 0, multiplier = 0});
            //colortable.Add(new Domain.Entity.ColorCodeIEC60062_2016 { color = "Brown", digit = 1, multiplier = 1, tolerance = 1 });
            //colortable.Add(new Domain.Entity.ColorCodeIEC60062_2016 { color = "Red", digit = 2, multiplier = 2, tolerance = 2 });
            //colortable.Add(new Domain.Entity.ColorCodeIEC60062_2016 { color = "Orange", digit = 3, multiplier = 3 });
            //colortable.Add(new Domain.Entity.ColorCodeIEC60062_2016 { color = "Yellow", digit = 4, multiplier = 4, tolerance = 5 });
            //colortable.Add(new Domain.Entity.ColorCodeIEC60062_2016 { color = "Green", digit = 5, multiplier = 5, tolerance = 5 });
            //colortable.Add(new Domain.Entity.ColorCodeIEC60062_2016 { color = "Blue", digit = 6, multiplier = 6, tolerance = 5 });
            //colortable.Add(new Domain.Entity.ColorCodeIEC60062_2016 { color = "Violet", digit = 7, multiplier = 7, tolerance = .1 });
            //colortable.Add(new Domain.Entity.ColorCodeIEC60062_2016 { color = "Grey", digit = 8, multiplier = 8, tolerance = .05 });
            //colortable.Add(new Domain.Entity.ColorCodeIEC60062_2016 { color = "White", digit = 9, multiplier = 9 });

        }


        [TestMethod]
        public void TestMethod1()
        {
            List<Domain.Entity.Resistor> lstresistor = Domain.Entity.Resistor.LoadResistorData();


            Domain.Entity.Resistor rs = lstresistor.Where(p => p.Name.ToLower() == "red").SingleOrDefault();


            if (lstresistor.Where(p => p.Name.ToLower() == "red").ToList().Count == 0)

            for (int i = 0; i < lstresistor.Count; i++)
            {

                    
                if (lstresistor[i].Name.ToLower() == "red") Console.WriteLine("Red");

            }
            


            
        }



        /// Calculates 2 digit ohm value based on 4 color band resistor values. A 5-6 band resistor would require 5-6 colors.
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal multiplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        /// <returns>Two digit ohm value referencing significant band colors only.</returns>
        //        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)


        [TestMethod]
        public void CalculateOhmValue()
        {
            List<Domain.Entity.Resistor> resistors = Domain.Entity.Resistor.LoadResistorData();
            //Services.UseCase.ResistorActions resistorActions = new Services.UseCase.ResistorActions();

            //int result = resistorActions.CalculateOhmValue("red", "blue", "red", "gold");


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
            List<string> colors = new List<string>() { "Brown", "Red", "Orange", "Yellow", "Green", "Blue", "Violet", "Gray", "Gold", "Silver","White" };
            double multiplier = 0;

            for (int i = 0; i < colors.Count; i++)
            {
                multiplier = resistor.GetTolerance(colors[i]);

                Assert.IsTrue(multiplier != -33);
            }

        }




        [TestMethod]
        public void TestGetMaxResistanceWithKnownValue()
        {
            Services.UseCase.ResistorComputations resistor = new Services.UseCase.ResistorComputations(new Infrastructure.ExceptionManager.DatabaseLogger());
            double maxResistance = 0;

                maxResistance = resistor.GetMaxResistance(10.0, 10);

                Assert.IsTrue(maxResistance == 11);

        }


        [TestMethod]
        public void TestGetMinResistanceWithKnownValue()
        {
            Services.UseCase.ResistorComputations resistor = new Services.UseCase.ResistorComputations(new Infrastructure.ExceptionManager.DatabaseLogger());
            double maxResistance = 0;

            maxResistance = resistor.GetMinResistance(10.0, 10);

            Assert.IsTrue(maxResistance == 9);

        }







    }
}
