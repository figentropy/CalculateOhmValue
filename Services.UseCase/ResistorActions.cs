using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;



namespace Services.UseCase
{


    public class ResistorActions : IOhmValueCalculator
    {
        //Brush mybrush;

        private readonly IExceptionManager logger;

        public Domain.Entity.ColorCodes bandcolors = new Domain.Entity.ColorCodes();
        public double resistance { get; set; }
        public double tolerance { get; set; }
        public double multiplier { get; set; }
        public int ohmValue { get; set; }




        public ResistorActions(IExceptionManager tmpLogger)
        {
            logger = tmpLogger;

        }

        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            List<Domain.Entity.Resistor> lstresistor = Domain.Entity.Resistor.LoadResistorData();
            //List<Domain.Entity.ESeries> lstESeries = Domain.Entity.ESeries.LoadEseriesList();
            //Domain.Entity.ESeries eseries = new Domain.Entity.ESeries();
            Domain.Entity.Resistor banda = lstresistor.Where(p => p.Name.ToLower() == bandAColor.ToLower()).SingleOrDefault();
            Domain.Entity.Resistor bandb = lstresistor.Where(p => p.Name.ToLower() == bandBColor.ToLower()).SingleOrDefault();
            //Domain.Entity.Resistor bandc = lstresistor.Where(p => p.Name.ToLower() == bandCColor.ToLower()).SingleOrDefault();
            //Domain.Entity.Resistor bandd = lstresistor.Where(p => p.Name.ToLower() == bandDColor.ToLower()).SingleOrDefault();
            //double resistance = 0;
            int ohmValue = 0;

            bandcolors.banda = bandAColor;
            bandcolors.bandb = bandBColor;
            bandcolors.bandc = bandCColor;
            bandcolors.bandd = bandDColor;

            ohmValue = Convert.ToInt32(banda.Digit.ToString() + bandb.Digit.ToString());

            this.ohmValue = ohmValue;


            return ohmValue;

            /// -----------------------------------------------------------------------------------------
            /// 
            /// Calculate resistance in ohms based on the band colors in function parameters
            /// 
            /// -----------------------------------------------------------------------------------------

            //if (banda.Digit != Domain.Entity.Resistor.NO_COLOR && banda.Digit != Domain.Entity.Resistor.NO_COLOR && bandc.Multiplier != Domain.Entity.Resistor.NO_COLOR)
            //{
            //    resistance = (double)((banda.Digit * 10 + bandb.Digit) * Math.Pow(10, bandc.Multiplier));
            //}

            /// -----------------------------------------------------------------------------------------


            //resistanceString = Domain.Entity.Resistor.ConvertToResitanceString((long)resistance);

            //var seriesfound = lstESeries.Where(t => t.Tolerance == bandd.Tolerance).SingleOrDefault();

            //eseries.Values = seriesfound.Values;

            //long bestfit = eseries.GetBestFitValue((long)resistance);



            //return (int)resistance;

        }

        //public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        //{
        //    List<Domain.Entity.Resistor> lstresistor = Domain.Entity.Resistor.LoadResistorData();
        //    List<Domain.Entity.ESeries> lstESeries = Domain.Entity.ESeries.LoadEseriesList();
        //    Domain.Entity.ESeries eseries = new Domain.Entity.ESeries();
        //    Domain.Entity.Resistor banda = lstresistor.Where(p => p.Name.ToLower() == bandAColor.ToLower()).SingleOrDefault();
        //    Domain.Entity.Resistor bandb = lstresistor.Where(p => p.Name.ToLower() == bandBColor.ToLower()).SingleOrDefault();
        //    Domain.Entity.Resistor bandc = lstresistor.Where(p => p.Name.ToLower() == bandCColor.ToLower()).SingleOrDefault();
        //    Domain.Entity.Resistor bandd = lstresistor.Where(p => p.Name.ToLower() == bandDColor.ToLower()).SingleOrDefault();

        //    double resistance = 0;



        //    /// -----------------------------------------------------------------------------------------
        //    /// 
        //    /// Calculate resistance in ohms based on the band colors in function parameters
        //    /// 
        //    /// -----------------------------------------------------------------------------------------

        //    if (banda.Digit != Domain.Entity.Resistor.NO_COLOR && banda.Digit != Domain.Entity.Resistor.NO_COLOR && bandc.Multiplier != Domain.Entity.Resistor.NO_COLOR)
        //    {
        //        resistance = (double)((banda.Digit * 10 + bandb.Digit) * Math.Pow(10, bandc.Multiplier));
        //    }

        //    /// -----------------------------------------------------------------------------------------


        //    //resistanceString = Domain.Entity.Resistor.ConvertToResitanceString((long)resistance);

        //    //var seriesfound = lstESeries.Where(t => t.Tolerance == bandd.Tolerance).SingleOrDefault();

        //    //eseries.Values = seriesfound.Values;

        //    //long bestfit = eseries.GetBestFitValue((long)resistance);



        //    return (int)resistance;

        //}


        public double GetMultiplier(string color)
        {
            try
            {
                List<Domain.Entity.Resistor> lstresistor = Domain.Entity.Resistor.LoadResistorData();
                Domain.Entity.Resistor bandc = lstresistor.Where(p => p.Name.ToLower() == color.ToLower()).SingleOrDefault();

                this.multiplier = bandc.Multiplier;

                return bandc.Multiplier;

            }
            catch (Exception ex)
            {
                logger.Handle(ex);

                return -1;
            }

        }

        public double GetResistance()
        {
            try
            {
                return this.resistance = Math.Round((double)(ohmValue * Math.Pow(10, multiplier)), 3);

            }
            catch (Exception ex)
            {
                logger.Handle(ex);

                return -1;
            }

        }


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

                return -1;
            }
        }


        public double GetMaxResistance(double resistance, double tolerance)
        {
            try
            {
                List<Domain.Entity.Resistor> lstresistor = Domain.Entity.Resistor.LoadResistorData();
                double maxresistance = 0.0;

                maxresistance = Math.Round(resistance + (resistance * (tolerance / 100)),6);


                return maxresistance;

            }
            catch (Exception ex)
            {
                logger.Handle(ex);

                return -1;
            }
        }


        public double GetMinResistance(double resistance, double tolerance)
        {
            try
            {
                List<Domain.Entity.Resistor> lstresistor = Domain.Entity.Resistor.LoadResistorData();
                double minresistance = 0.0;

                minresistance = Math.Round(resistance - (resistance * (tolerance / 100)),6);

                
                
                return minresistance;

            }
            catch (Exception ex)
            {
                logger.Handle(ex);

                return -1;
            }

        }


        public (string name, int age) GetStudentInfo(string id)
        {
            return (name:"Annie", age:25);
        }

        public (double resistance, double tolerance, double maxresistance, double minresistance) GetAllComputedValues(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            try
            {
                //double resistance = -1;
                //double multiplier = 0;
                //double tolerance = 0;
                double maxresistance = 0;
                double minresistance = 0;
                int ohmValue = 0;


                ohmValue = CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);
                multiplier = GetMultiplier(bandCColor);
                resistance = GetResistance();
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



    }
}

