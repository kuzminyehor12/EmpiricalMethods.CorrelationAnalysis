using DataAnalysis1.Computing.Computing;
using EmpiricMethods_Lab1.DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricMethods_Lab1.Computing.Models
{
    public abstract class ParameterResult
    {
        public const double Alpha = 0.05;
        public double Value { get; }
        public double ResidualVariance { get; }
        public int N { get; }
        public virtual double Criteria
        {
            get
            {
                var quantileComputing = new SeriesQuantileComputing();
                return quantileComputing.ComputeStudentQuantile(1 - Alpha / 2, N - 2);
            }
        }
        public virtual Tuple<double, double> Interval { get; set; }
        public virtual double Statistics { get; set; }
        public virtual double Std { get; set; }
        public virtual string Summary { get; set; }

        public ParameterResult(double value, double residualVariance, int n)
        {
            Value = value;
            ResidualVariance = residualVariance;
            N = n;
        }

        public abstract ParameterResult ComputeStd(double std, double avg = 1);

        public virtual ParameterResult ComputeInterval()
        {
            var quantileComputing = new SeriesQuantileComputing();
            var inf = Value - quantileComputing.ComputeStudentQuantile(1 - Alpha / 2, N - 2) * Std;
            var sup = Value + quantileComputing.ComputeStudentQuantile(1 - Alpha / 2, N - 2) * Std;
            Interval = Tuple.Create(inf, sup);
            return this;
        }

        public virtual ParameterResult ComputeStatstics()
        {
            Statistics = Value / Std;
            return this;
        }

        public virtual ParameterResult Summarize()
        {
            Summary = Math.Abs(Statistics) <= Criteria ? NullEqual.Equal : NullEqual.NotEqual;
            return this;
        }
    }
}
