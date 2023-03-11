using DataAnalysis1.Computing.Computing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricMethods_Lab1.Computing.Models
{
    public class RatioResult : CorrelationResult
    {
        public int K { get; set; }
        public RatioResult(double coefficient, int n, int k) : base(coefficient, n)
        {
            K = k;
        }

        public override double Criteria
        {
            get
            {
                var quantileComputing = new SeriesQuantileComputing();
                return quantileComputing.ComputePhisherQuantile(1 - Alpha, K - 1, N - K);
            }
        }

        public override CorrelationResult ComputeStatistics()
        {
            Statistics = Value * Value / (K - 1) / ((1 - Value * Value) / (N - K));
            return this;
        }

        public override CorrelationResult Summarize()
        {
            if (Statistics is null)
            {
                Summary = string.Empty;
                return this;
            }
            
            Summary = Statistics <= Criteria ? DataProcessing.Models.Summary.Insignificant : DataProcessing.Models.Summary.Significant;

            return this;
        }
    }
}
