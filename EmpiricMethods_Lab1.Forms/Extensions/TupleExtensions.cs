using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricMethods_Lab1.Forms.Extensions
{
    public static class TupleExtensions
    {
        public static string ToStringFormatted(this Tuple<double, double> tuple, string format)
        {
            if(tuple is null)
            {
                return "-";
            }

            return "(" + tuple.Item1.ToString(format) + ", " + tuple.Item2.ToString(format) + ")";
        }
    }
}
