using DataAnalysis1.Computing.Computing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricMethods_Lab1.Computing.Models
{
    public class KendallResult : CorrelationResult
    {
        public KendallResult(double coefficient, int n) : base(coefficient, n) 
        {

        }

        public override CorrelationResult ComputeStatistics()
        {
            Statistics = 3 * Value * Math.Sqrt(N * (N - 1)) / Math.Sqrt(2 * (2 * N + 5));
            return this;
        }

        public override double Criteria
        {
            get
            {
                var quantileComputing = new SeriesQuantileComputing();
                return quantileComputing.ComputeNormalSeriesQuantile(1 - Alpha / 2);
            }
        }

        public override CorrelationResult Summarize()
        {
            if (Statistics is null)
            {
                Summary = string.Empty;
                return this;
            }

            Summary = Math.Abs((double)Statistics) <=  Criteria ? DataProcessing.Models.Summary.Insignificant : DataProcessing.Models.Summary.Significant;

            return this;
        }
    }
}
