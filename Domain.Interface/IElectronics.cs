using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    interface IElectronics
    {
        /// <summary>
        /// Band digit (used for counting resistance base)
        /// </summary>
        int Digit { set; get; }

        /// <summary>
        /// Band resistance multiplier
        /// </summary>
        int Multiplier { set; get; }

        /// <summary>
        /// Band color Tolerance value
        /// </summary>
        double Tolerance { set; get; }

    }
}
