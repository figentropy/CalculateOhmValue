using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ColorCodeIEC60062_2016
    {
        public string color { get; set; }
        public int digit { get; set; }
        public double multiplier { get; set; }
        public double tolerance { get; set; }
    }
}
