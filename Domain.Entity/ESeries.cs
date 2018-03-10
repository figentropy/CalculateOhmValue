using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Domain.Entity
{

    /// <summary>
    /// Class storing information about E series resistor values and tolerances
    /// </summary>
    public class ESeries
    {
        /// <summary>
        /// Name of the serie
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Series tolerance
        /// </summary>
        public double Tolerance { set; get; }

        /// <summary>
        /// Avaliable series values
        /// </summary>
        public List<double> Values { set; get; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tolerance"></param>
        /// <param name="values"></param>
        public ESeries(string name, double tolerance, List<double> values)
        {
            Name = name;
            Tolerance = tolerance;
            Values = values;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ESeries() { }

        /// <summary>
        /// Function returns value closest to desired value based on series values
        /// </summary>
        /// <param name="resistance"></param>
        /// <returns></returns>
        public long GetBestFitValue(long resistance)
        {
            double temp = resistance;
            int divisions = 0;
            while (temp >= 10)
            {
                temp /= 10;
                divisions++;
            }
            double closest = Values.OrderBy(item => Math.Abs(temp - item)).First();

            return (long)(closest * Math.Pow(10, divisions));
        }

        /// <summary>
        /// Formatting information about series to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} - {1} %", Name, Tolerance);
        }

        /// <summary>
        /// Construction Eseries collection
        /// </summary>
        /// <returns></returns>
        public static List<ESeries> LoadEseriesList()
        {
         

            List<ESeries> temp = new List<ESeries>()
                {
                    new ESeries("E6",20,new List<double>() {1.0, 1.5, 2.2, 3.3, 4.7, 6.8}),
                    new ESeries("E12",10,new List<double>(){1.0 ,1.2, 1.5, 1.8, 2.2, 2.7,
                                                            3.3, 3.9, 4.7, 5.6, 6.8, 8.2}),
                    new ESeries("E24",5,new List<double>() {1.0, 1.1, 1.2, 1.3, 1.5, 1.6,
                                                            1.8, 2.0, 2.2, 2.4, 2.7, 3.0,
                                                            3.3, 3.6, 3.9, 4.3, 4.7, 5.1,
                                                            5.6, 6.2, 6.8, 7.5, 8.2, 9.1}),
                    new ESeries("E48",2,new List<double>(){ 1.00, 1.05, 1.10, 1.15, 1.21, 1.27,
                                                            1.33, 1.40, 1.47, 1.54, 1.62, 1.69,
                                                            1.78, 1.87, 1.96, 2.05, 2.15, 2.26,
                                                            2.37, 2.49, 2.61, 2.74, 2.87, 3.01,
                                                            3.16, 3.32, 3.48, 3.65, 3.83, 4.02,
                                                            4.22, 4.42, 4.64, 4.87, 5.11, 5.36,
                                                            5.62, 5.90, 6.19, 6.49, 6.81, 7.15,
                                                            7.50, 7.87, 8.25, 8.66, 9.09, 9.53 }),
                    new ESeries("E96",0.5,new List<double>(){ 1.00, 1.02, 1.05, 1.07, 1.10, 1.13,
                                                              1.15, 1.18, 1.21, 1.24, 1.27, 1.30,
                                                              1.33, 1.37, 1.40, 1.43, 1.47, 1.50,
                                                              1.54, 1,58, 1.62, 1.65, 1.69, 1.74,
                                                              1.78, 1.82, 1.87, 1.91, 1.96, 2.00,
                                                              2.05, 2.10, 2.16, 2.21, 2.26, 2.32,
                                                              2.37, 2.43, 2.49, 2.55, 2.61, 2.67,
                                                              2.74, 2.80, 2.87, 2.94, 3.01, 3.09,
                                                              3.16, 3.24, 3.32, 3.40, 3.48, 3.57,
                                                              3.65, 3.74, 3.83, 3.92, 4.02, 4.12,
                                                              4.22, 4.32, 4.42, 4.53, 4.64, 4.75,
                                                              4.87, 4.99, 5.11, 5.23, 5.36, 5.49,
                                                              5.62, 5.76, 5.90, 6.04, 6.19, 6.34,
                                                              6.49, 6.65, 6,81, 6.98, 7.15, 7.32,
                                                              7.50, 7.68, 7.87, 8.06, 8.25, 8.45,
                                                              8.66, 8.87, 9.09, 9.31, 9.53, 9.76 })
                };


            return temp;
        }
    }
}
