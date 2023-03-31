using DataAnalysis1.Computing.Computing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricMethods_Lab1.Computing.Models
{
    public class FTestResult
    {
        public double Alpha => 0.05;
        public int N { get; }
        public FTestResult(double value, int n)
        {
            Value = value;
            N = n;
        }
        public double Value { get; set; }
        public double Criteria
        {
            get 
            {
                var quantileComputing = new SeriesQuantileComputing();
                return quantileComputing.ComputePhisherQuantile(1 - Alpha, 1, N - 2);
            }
        }
        public string Summary
        {
            get
            {
                return Value <= Criteria ? DataProcessing.Models.Summary.Insignificant : DataProcessing.Models.Summary.Significant;
            }
        }
    }
}
