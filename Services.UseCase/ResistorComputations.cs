using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;



namespace Services.UseCase
{


    public class ResistorComputations : Domain.Entity.Resistor,IOhmValueCalculator
    {

        #region Private class variables

        // Exception Manager local instance
        private readonly IExceptionManager logger;


        #endregion


        #region  Class Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <remarks>
        /// Passing in an exception manager is one way to do exception management.  Another way would
        /// be to use DI or AOP (aspect oriented programming) to eliminate all the try/catches everywhere.
        /// </remarks>
        /// <param name="exceptionManager">Passes in an exception manager.</param>
        public ResistorComputations(IExceptionManager exceptionManager)
        {
            logger = exceptionManager;

        }


        #endregion




        #region  Class Capabilities

        /// <summary>
        /// Calculates 2 digit ohm value based on 4 color band resistor values. A 5-6 band resistor would require 5-6 colors.
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal multiplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        /// <returns>Two digit ohm value referencing significant band colors only.</returns>
        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            try
            {
                List<Domain.Entity.Resistor> lstresistor = Domain.Entity.Resistor.LoadResistorData();
                Domain.Entity.Resistor banda = lstresistor.Where(p => p.Name.ToLower() == bandAColor.ToLower()).SingleOrDefault();
                Domain.Entity.Resistor bandb = lstresistor.Where(p => p.Name.ToLower() == bandBColor.ToLower()).SingleOrDefault();
                int ohmValue = 0;



                ohmValue = Convert.ToInt32(banda.Digit.ToString() + bandb.Digit.ToString());


                return ohmValue;

            }
            catch (Exception ex)
            {
                logger.Handle(ex);

                return -33;
            }

           

        }
        

        /// <summary>
        /// Determines multiplier based on color value
        /// </summary>
        /// <param name="color"></param>
        /// <returns>Returns multiplier of color.</returns>
        public double GetMultiplier(string color)
        {
            try
            {
                List<Domain.Entity.Resistor> lstresistor = Domain.Entity.Resistor.LoadResistorData();
                Domain.Entity.Resistor bandc = lstresistor.Where(p => p.Name.ToLower() == color.ToLower()).SingleOrDefault();


                return bandc.Multiplier;

            }
            catch (Exception ex)
            {
                logger.Handle(ex);

                return -33;
            }

        }


        /// <summary>
        /// Calculates resistance based on ohm value and multiplier
        /// </summary>
        /// <param name="ohmValue">Ohm value</param>
        /// <param name="multiplier">Multiplier value</param>
        /// <returns>Returns computed resistance as double.</returns>
        public double GetResistance(double ohmValue, double multiplier)
        {
            try
            {
                return Math.Round((ohmValue * Math.Pow(10, multiplier)), 3);

            }
            catch (Exception ex)
            {
                logger.Handle(ex);

                return -33;
            }

        }


        
        /// <summary>
        /// Determines tolerance value based on color.
        /// </summary>
        /// <param name="color">Name of color (e.g. Red, Green...)</param>
        /// <returns>Returns tolerance as a double</returns>
        public double GetTolerance(string color)
        {
            try
            {
                List<Domain.Entity.Resistor> lstresistor = Domain.Entity.Resistor.LoadResistorData();

                Domain.Entity.Resistor banda = lstresistor.Where(p => p.Name.ToLower() == color.ToLower() && p.Tolerance != Domain.Entity.Resistor.NO_COLOR).SingleOrDefault();

                return banda.Tolerance;

            }
            catch (Exception ex)
            {
                logger.Handle(ex);

                return -33;
            }
        }


        /// <summary>
        /// Calculates the maximum resistance
        /// </summary>
        /// <param name="resistance">Resistance as double</param>
        /// <param name="tolerance">Tolerance as double</param>
        /// <returns>Returns max resistance as a double</returns>
        public double GetMaxResistance(double resistance, double tolerance)
        {
            try
            {
                List<Domain.Entity.Resistor> lstresistor = LoadResistorData();
                double maxresistance = 0.0;

                
                maxresistance = Math.Round(resistance + (resistance * (tolerance / 100)),6);
                

                return maxresistance;

            }
            catch (Exception ex)
            {
                logger.Handle(ex);

                return -33;
            }
        }


        /// <summary>
        /// Computes the minimum resistance value
        /// </summary>
        /// <param name="resistance">Resistance as a double</param>
        /// <param name="tolerance">Tolerance as a double</param>
        /// <returns>Returns minimum resistance value</returns>
        public double GetMinResistance(double resistance, double tolerance)
        {
            try
            {
                List<Domain.Entity.Resistor> lstresistor = LoadResistorData();
                double minresistance = 0.0;

                minresistance = Math.Round(resistance - (resistance * (tolerance / 100)),6);

                
                
                return minresistance;

            }
            catch (Exception ex)
            {
                logger.Handle(ex);

                return -33;
            }

        }




        /// <summary>
        /// 
        /// Computes all the values (resistance, tolerance, max resistance, min resistance) for display within a user interface.
        /// 
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal multiplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        /// <returns>Returns a tuple containing all values required by the UI for display purposes</returns>
        public (double resistance, double tolerance, double maxresistance, double minresistance) GetAllComputedValues(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            try
            {
                double resistance = -1;
                double multiplier = 0;
                double tolerance = 0;
                double maxresistance = 0;
                double minresistance = 0;
                int ohmValue = 0;


                ohmValue = CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

                multiplier = GetMultiplier(bandCColor);

                resistance = GetResistance(ohmValue, multiplier);

                tolerance = GetTolerance(bandDColor);

                maxresistance = GetMaxResistance(resistance, tolerance);

                minresistance = GetMinResistance(resistance, tolerance);

                return (resistance: resistance, tolerance: tolerance, maxresistance: maxresistance, minresistance: minresistance);

            }
            catch (Exception ex)
            {
                logger.Handle(ex);

                return (resistance: -1, tolerance: -1, maxresistance: -1, minresistance: -1);

            }
        }


        #endregion


    }
}

