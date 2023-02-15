using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricMethods_Lab1.Computing.Models
{
    public class CorrelationResult
    {
        public double Value { get; set; }
        public Tuple<double, double> Interval { get; set; }
        public double Statistics { get; set; }
        public string Summary { get; set; }
    }
}
