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

        Domain.Entity.ColorCodeIEC60062_2016 codes = new Domain.Entity.ColorCodeIEC60062_2016();
        List<Domain.Entity.ColorCodeIEC60062_2016> colortable = new List<Domain.Entity.ColorCodeIEC60062_2016>();


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


        [TestMethod]
        public void CalculateOhmValue()
        {
            List<Domain.Entity.Resistor> resistors = Domain.Entity.Resistor.LoadResistorData();
            Services.UseCase.ResistorActions resistorActions = new Services.UseCase.ResistorActions();

            int result = resistorActions.CalculateOhmValue("red", "blue", "red", "gold");


        }

    }
}
