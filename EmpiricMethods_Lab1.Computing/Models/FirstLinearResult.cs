using DataAnalysis1.Computing.Computing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricMethods_Lab1.Computing.Models
{
    public class FirstLinearResult : ParameterResult
    {
        public FirstLinearResult(double value, double residualVariance, int n) : base(value, residualVariance, n)
        {
        }

        public override ParameterResult ComputeStd(double std, double avg = 1)
        {
            var varianceOfA0 = ResidualVariance / N * (1 + Math.Pow(avg, 2) / Math.Pow(std, 2));
            Std = Math.Sqrt(varianceOfA0);
            return this;
        }
    }
}
