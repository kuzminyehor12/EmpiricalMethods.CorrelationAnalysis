using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricMethods_Lab1.Computing.Extensions
{
    public static class ClassComputingExtensions
    {
        public static IList<double> ComputeAverages(this IList<IList<double>> classes)
        {
            var averages = new List<double>();

            foreach (var c in classes)
            {
                if (!c.Any())
                {
                    averages.Add(0);
                }
                else
                {
                    averages.Add(c.Average());
                }
            }

            return averages;
        }
    }
}
