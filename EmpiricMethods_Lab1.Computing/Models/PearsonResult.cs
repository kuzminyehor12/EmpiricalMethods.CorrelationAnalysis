using DataAnalysis1.Computing.Computing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricMethods_Lab1.Computing.Models
{
    public class PearsonResult : CorrelationResult
    {
        public PearsonResult(double coefficient, int n) : base(coefficient, n)
        {

        }

        public override CorrelationResult ComputeInterval()
        {
            var quantileComputing = new SeriesQuantileComputing();

            var firstItem = Value + (Value * (1 - Math.Pow(Value, 2)) / (2 * N))
                - quantileComputing.ComputeNormalSeriesQuantile(1 - Alpha / 2) * ((1 - Math.Pow(Value, 2)) / Math.Sqrt(N - 1));

            var secondItem = Value + (Value * (1 - Math.Pow(Value, 2)) / (2 * N))
                + quantileComputing.ComputeNormalSeriesQuantile(1 - Alpha / 2) * ((1 - Math.Pow(Value, 2)) / Math.Sqrt(N - 1));

            Interval = Tuple.Create(firstItem, secondItem);
            return this;
        }

        public override CorrelationResult ComputeStatistics()
        {
            Statistics = Value * Math.Sqrt(N - 2) / Math.Sqrt(1 - Math.Pow(Value, 2));
            return this;
        }
    }
}
