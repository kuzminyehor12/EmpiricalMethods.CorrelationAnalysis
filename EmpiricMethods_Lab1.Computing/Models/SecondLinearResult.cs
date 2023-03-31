using DataAnalysis1.Computing.Computing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricMethods_Lab1.Computing.Models
{
    public class SecondLinearResult : ParameterResult
    {
        public SecondLinearResult(double value, double residualVariance, int n) : base(value, residualVariance, n)
        {
        }

        public override ParameterResult ComputeStd(double std, double avg = 1)
        {
            var varianceOfA1 = ResidualVariance / (N * Math.Pow(std, 2));
            Std = Math.Sqrt(varianceOfA1);
            return this;
        }
    }
}
