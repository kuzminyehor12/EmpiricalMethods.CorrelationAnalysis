using DataAnalysis1.Computing.Computing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricMethods_Lab1.Computing.Models
{
    public abstract class CorrelationResult
    {
        public CorrelationResult(double coefficient, int n)
        {
            Value = coefficient;
            N = n;
            Statistics = null;
            Interval = null;
        }
        public double Alpha => 0.05;
        public int N { get; }
        public virtual double Value { get; }
        public virtual Tuple<double, double> Interval { get; protected set; }
        public virtual double? Statistics { get; protected set; }
        public virtual string Summary { get; protected set; }
        public virtual bool ContactExists => Summary == DataProcessing.Models.Summary.Significant;
        public virtual double Criteria
        {
            get
            {
                var quantileComputing = new SeriesQuantileComputing();
                return quantileComputing.ComputeStudentQuantile(1 - Alpha / 2, N - 2);
            }
        }
        public virtual CorrelationResult ComputeInterval()
        {
            return this;
        }

        public virtual CorrelationResult ComputeStatistics()
        {
            return this;
        }

        public virtual CorrelationResult Summarize()
        {
            if (Statistics is null)
            {
                Summary = string.Empty;
                return this;
            }

            Summary = Math.Abs((double)Statistics) <= Criteria ? DataProcessing.Models.Summary.Insignificant : DataProcessing.Models.Summary.Significant;

            return this;
        }
    }
}
