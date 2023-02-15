using EmpiricMethods_Lab1.DataProcessing.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAnalysis1.Computing.Computing;
using EmpiricMethods_Lab1.Computing.Models;

namespace EmpiricMethods_Lab1.Computing.Computing
{
    public class CorrelationCoefficientComputing
    {
        public double Alpha => 0.05;

        public CorrelationResult Pearson(VariationalSeries xSource, VariationalSeries ySource)
        {
            var quantileComputing = new SeriesQuantileComputing();
            var xSourcePointEstimation = new PointEstimationCharacteristicsComputing(xSource);
            var ySourcePointEstimation = new PointEstimationCharacteristicsComputing(ySource);
            var generalPointEstimation = new PointEstimationCharacteristicsComputing(xSource * ySource);

            var coefficient = (generalPointEstimation.ComputeAverage() - xSourcePointEstimation.ComputeAverage() * ySourcePointEstimation.ComputeAverage()) 
                                        / xSourcePointEstimation.ComputeStandartDeviation() * ySourcePointEstimation.ComputeStandartDeviation();
           
            var interval = ComputeIntervalForPearson(coefficient, xSource.Series.Count);
            var tStatistics = coefficient * Math.Sqrt(xSource.Series.Count - 2) / Math.Sqrt(1 - Math.Pow(coefficient, 2));

            return new CorrelationResult
            {
                Value = coefficient,
                Interval = interval,
                Statistics = tStatistics,
                Summary = Math.Abs(tStatistics) <= quantileComputing.ComputeStudentQuantile(1 - Alpha / 2, xSource.Series.Count - 2) ? "Significant" : "Insignificant"
            };
        }

        private Tuple<double, double> ComputeIntervalForPearson(double coefficient, int n)
        {
            var quantileComputing = new SeriesQuantileComputing();

            var firstItem = coefficient + (coefficient * (1 - Math.Pow(coefficient, 2)) / (2 * n)) 
                - quantileComputing.ComputeNormalSeriesQuantile(1 - Alpha / 2) * (1 - Math.Pow(coefficient, 2) / Math.Sqrt(n - 1));

            var secondItem = coefficient + (coefficient * (1 - Math.Pow(coefficient, 2)) / (2 * n))
                + quantileComputing.ComputeNormalSeriesQuantile(1 - Alpha / 2) * (1 - Math.Pow(coefficient, 2) / Math.Sqrt(n - 1));

            return Tuple.Create(firstItem, secondItem);
        }

        public CorrelationResult Spearman(VariationalSeries xSource, VariationalSeries ySource)
        {
            var xRanks = xSource.Rank();
            var yRanks = ySource.Rank();
            var coefficient = Pearson(xRanks, yRanks);
            return coefficient;
        }
    }
}
