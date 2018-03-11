using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Services.UseCase
{

    public class ResistorActions : Domain.Interface.IOhmValueCalculator
    {
        //Brush mybrush;

        public Domain.Entity.ColorCodes bandcolors = new Domain.Entity.ColorCodes();
        public double resistance { get; set; }
        public int tolerance { get; set; }
        public double multiplier { get; set; }
        public int ohmValue { get; set; }



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
            List<Domain.Entity.Resistor> lstresistor = Domain.Entity.Resistor.LoadResistorData();
            Domain.Entity.Resistor bandc = lstresistor.Where(p => p.Name.ToLower() == color.ToLower()).SingleOrDefault();

            this.multiplier = bandc.Multiplier;

            return bandc.Multiplier;

        }

        public double GetResistance()
        {

            return this.resistance = Math.Round((double)(ohmValue * Math.Pow(10, multiplier)),3);

        }


        public double GetTolerance(string color)
        {
            try
            {
                List<Domain.Entity.Resistor> lstresistor = Domain.Entity.Resistor.LoadResistorData();

                Domain.Entity.Resistor banda = lstresistor.Where(p => p.Name.ToLower() == color.ToLower() && p.Tolerance != Domain.Entity.Resistor.NO_COLOR).SingleOrDefault();

                return banda.Tolerance;

            }
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }
        }






    }
}

