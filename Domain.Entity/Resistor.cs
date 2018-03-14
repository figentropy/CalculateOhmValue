using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;



namespace Domain.Entity
{
    /// Class for resistor
    /// </summary>
    public class Resistor
    {
        /// <summary>
        /// Flag for uneused color detection
        /// </summary>
        public const int NO_COLOR = -4;

        /// <summary>
        /// Prefixes used for unit conversion
        /// </summary>
        public static readonly List<string> PREFIXES = new List<string>() { "", "k", "M", "G" };


        /// <summary>
        /// Band color
        /// </summary>
        public Brush Color { set; get; }

        /// <summary>
        /// Band color name
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Band digit (used for counting resistance base)
        /// </summary>
        public int Digit { set; get; }


        /// <summary>
        /// Band resistance multiplier
        /// </summary>
        public int Multiplier { set; get; }

        /// <summary>
        /// Band color Tolerance value
        /// </summary>
        public double Tolerance { set; get; }


        public double Resistance { set; get; }


        public double MaxResistance { set; get; }


        public double MinResistance
        {
            get
            {
                return (this.Tolerance / 100) * this.Resistance;
            }
            set
            {
                this.MinResistance = value;
            }
        }



        /// <summary>
        /// public constructor
        /// </summary>
        /// <param name="color"></param>
        /// <param name="name"></param>
        /// <param name="digit"></param>
        /// <param name="multiplier"></param>
        /// <param name="tolerance"></param>
        /// <param name="tempco"></param>
        public Resistor(Brush color, string name, int digit, int multiplier,
            double tolerance)
        {
            Color = color;
            Name = name;
            Digit = digit;
            Multiplier = multiplier;
            Tolerance = tolerance;
        }


        /// <summary>
        /// Default constructor
        /// </summary>
        public Resistor() { }


        /// <summary>
        /// Creates resistor band collection
        /// </summary>
        /// <returns></returns>
        public static List<Resistor> LoadResistorData()
        {
            List<Resistor> datamap = new List<Resistor>()
            {
                new Resistor(Brushes.Black,"Black",0,0,NO_COLOR),
                new Resistor(Brushes.Brown,"Brown",1,1,1),
                new Resistor(Brushes.Red,"Red",2,2,2),
                new Resistor(Brushes.Orange,"Orange",3,3,3),
                new Resistor(Brushes.Yellow,"Yellow",4,4,4),
                new Resistor(Brushes.Green,"Green",5,5,0.5),
                new Resistor(Brushes.Blue,"Blue",6,6,0.25),
                new Resistor(Brushes.Violet,"Violet",7,7,0.1),
                new Resistor(Brushes.Gray,"Gray",8,8,0.05),
                new Resistor(Brushes.White,"White",9,9,NO_COLOR),
                new Resistor(Brushes.Gold,"Gold",NO_COLOR,-1,5),
                new Resistor(Brushes.Silver,"Silver",NO_COLOR,-2,10),
                new Resistor(Brushes.White,"None",NO_COLOR,NO_COLOR,20)
            };
            return datamap;
        }



        public static string UnitConversion(long resistance)
        {
            double i = resistance;
            int index = 0;

            while (i >= 1000)
            {
                i /= 1000;
                ++index;
            }

            return i.ToString() + " " + PREFIXES[index] + "Ω";

        }

    }
}

