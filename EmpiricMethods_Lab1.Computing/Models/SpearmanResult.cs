using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricMethods_Lab1.Computing.Models
{
    public class SpearmanResult : CorrelationResult
    {
        public SpearmanResult(double coefficient, int n) : base(coefficient, n)
        {

        }
        public override CorrelationResult ComputeStatistics()
        {
            Statistics = Value * Math.Sqrt(N - 2) / Math.Sqrt(1 - Math.Pow(Value, 2));
            return this;
        }
    }
}
