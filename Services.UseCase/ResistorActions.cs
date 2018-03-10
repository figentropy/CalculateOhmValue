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
        Brush mybrush;



        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            List<Domain.Entity.Resistor> lstresistor = Domain.Entity.Resistor.LoadResistorData();
            List<Domain.Entity.ESeries> lstESeries = Domain.Entity.ESeries.LoadEseriesList();
            Domain.Entity.ESeries eseries = new Domain.Entity.ESeries();
            Domain.Entity.Resistor banda = lstresistor.Where(p => p.Name.ToLower() == bandAColor.ToLower()).SingleOrDefault();
            Domain.Entity.Resistor bandb = lstresistor.Where(p => p.Name.ToLower() == bandBColor.ToLower()).SingleOrDefault();
            Domain.Entity.Resistor bandc = lstresistor.Where(p => p.Name.ToLower() == bandCColor.ToLower()).SingleOrDefault();
            Domain.Entity.Resistor bandd = lstresistor.Where(p => p.Name.ToLower() == bandDColor.ToLower()).SingleOrDefault();

            long? resistance = null;
            string resistanceString = "";


            /// -----------------------------------------------------------------------------------------
            /// 
            /// Calculate resistance in ohms based on the band colors in function parameters
            /// 
            /// -----------------------------------------------------------------------------------------

            if (banda.Digit != Domain.Entity.Resistor.NO_COLOR && banda.Digit != Domain.Entity.Resistor.NO_COLOR && bandc.Digit != Domain.Entity.Resistor.NO_COLOR)
            {
                resistance = (long)((banda.Digit * 10 + bandb.Digit) * Math.Pow(10, bandc.Multiplier));
            }

            /// -----------------------------------------------------------------------------------------


            //resistanceString = Domain.Entity.Resistor.ConvertToResitanceString((long)resistance);

            //var seriesfound = lstESeries.Where(t => t.Tolerance == bandd.Tolerance).SingleOrDefault();

            //eseries.Values = seriesfound.Values;

            //long bestfit = eseries.GetBestFitValue((long)resistance);



            return (int)resistance;

        }
    }
}

