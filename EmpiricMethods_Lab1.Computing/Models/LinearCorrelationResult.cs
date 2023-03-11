using DataAnalysis1.Computing.Computing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricMethods_Lab1.Computing.Models
{
    public class LinearCorrelationResult
    {
        public int K { get; set; }
        public int N { get; set; }
        public LinearCorrelationResult(double pearsonValue, double ratioValue, int k, int n)
        {
            PearsonValue = pearsonValue;
            RatioValue = ratioValue;
            K = k;
            N = n;
        }
        public double Alpha => 0.05;
        public double PearsonValue { get; set; }
        public double RatioValue { get; set; }
        public double Statistics { get; set; }
        public string Summary { get; set; }
        public bool IsLinear => Summary == "Equal";
        public double Criteria
        { 
            get
            {
                var quantileComputing = new SeriesQuantileComputing();
                return quantileComputing.ComputePhisherQuantile(1 - Alpha, K - 2, N - K);
            } 
        }

        public LinearCorrelationResult ComputeStatistics()
        {
            Statistics = (RatioValue * RatioValue - PearsonValue * PearsonValue) / (K - 2) / ((1 - RatioValue * RatioValue) / (N - K));
            return this;
        }

        public LinearCorrelationResult Summarize()
        {
            Summary = Statistics <= Criteria ? "Equal" : "Not Equal";
            return this;
        }
    }
}
