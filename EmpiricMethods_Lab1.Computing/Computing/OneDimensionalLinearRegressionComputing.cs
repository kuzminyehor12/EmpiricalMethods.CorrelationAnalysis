using DataAnalysis1.Computing.Computing;
using EmpiricMethods_Lab1.Computing.Models;
using EmpiricMethods_Lab1.DataProcessing.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricMethods_Lab1.Computing.Computing
{
    public class OneDimensionalLinearRegressionComputing
    {
        public VariationalSeries XSource { get; }
        public VariationalSeries YSource { get; }

        public double Alpha => 0.05;

        public VariationalSeries Balances
        {
            get
            {
                var a0Value = FirstLinearValue;
                var a1Value = SecondLinearValue;
                var balances = new List<double>();

                for (int i = 0; i < Math.Min(XSource.Series.Count, N); i++)
                {
                    balances.Add(YSource.Series[i] - (a0Value + a1Value * XSource.Series[i]));
                }

                return new VariationalSeries(balances);
            }
        }

        public double FirstLinearValue { get; }

        public double SecondLinearValue { get; }

        public int N => YSource.Series.Count;
        public OneDimensionalLinearRegressionComputing(
            VariationalSeries xSource, 
            VariationalSeries ySource)
        {
            XSource = xSource;
            YSource = ySource;

            var correlationComputing = new CorrelationCoefficientComputing(XSource, YSource);
            var xSourcePointEstimation = new PointEstimationCharacteristicsComputing(XSource);
            var ySourcePointEstimation = new PointEstimationCharacteristicsComputing(YSource);
            var pearson = correlationComputing.Pearson();
            SecondLinearValue = pearson.Value * (ySourcePointEstimation.ComputeStandartDeviation(true) / xSourcePointEstimation.ComputeStandartDeviation(true));

            var a1 = SecondLinearValue;
            var xAvg = xSourcePointEstimation.ComputeAverage();
            var yAvg = ySourcePointEstimation.ComputeAverage();
            FirstLinearValue = yAvg - a1 * xAvg;
        }

        public ParameterResult FirstLinearParameter()
        {
            var xSourcePointEstimation = new PointEstimationCharacteristicsComputing(XSource);
            var value = FirstLinearValue;
            var resuidalVariance = ResidualVariance();
            var result = new FirstLinearResult(value, resuidalVariance, N);
            var avg = xSourcePointEstimation.ComputeAverage();
            var std = xSourcePointEstimation.ComputeStandartDeviation(true);
            return result
                .ComputeStd(std, avg)
                .ComputeInterval()
                .ComputeStatstics()
                .Summarize();
        }

        public ParameterResult SecondLinearParameter()
        {
            var xSourcePointEstimation = new PointEstimationCharacteristicsComputing(XSource);
            var value = SecondLinearValue;
            var resuidalVariance = ResidualVariance();
            var result = new SecondLinearResult(value, resuidalVariance, N);
            var std = xSourcePointEstimation.ComputeStandartDeviation(true);
            return result
                .ComputeStd(std)
                .ComputeInterval()
                .ComputeStatstics()
                .Summarize();
        }

        public double ResidualVariance()
        {
            double sumOfSquaredErrors = 0;
            var a0 = FirstLinearValue;
            var a1 = SecondLinearValue;

            for (int i = 0; i < Math.Min(XSource.Series.Count, N); i++)
            {
                sumOfSquaredErrors += Math.Pow(YSource.Series[i] - (a0 + a1 * XSource.Series[i]), 2);
            }

            return (double)1 / (N - 2) * sumOfSquaredErrors;
        }
 
        public FTestResult FTest()
        {
            var a0 = FirstLinearValue;
            var a1 = SecondLinearValue;
            var ySourcePointEstimation = new PointEstimationCharacteristicsComputing(YSource);
            double sum = 0;

            for (int i = 0; i < Math.Min(XSource.Series.Count, N); i++)
            {
                sum += Math.Pow(a0 + a1 * XSource.Series[i] - ySourcePointEstimation.ComputeAverage(), 2);
            }

            var residualVariance = ResidualVariance();
            var f = sum / residualVariance;

            return new FTestResult(f, N);
        }

        public double CoefficientOfDetermination()
        {
            var correlationComputing = new CorrelationCoefficientComputing(XSource, YSource);
            var pearson = correlationComputing.Pearson();
            return Math.Pow(pearson.Value, 2) * 100 / 100;
        }

        public bool Normality()
        {
            var balancesComputing = new PointEstimationCharacteristicsComputing(Balances);
            var stdComputing = new StandartDeviationComputing(Balances);
            var quantileComputing = new SeriesQuantileComputing();

            var skewness = balancesComputing.ComputeSkewnessCoefficient();
            var kurtosis = balancesComputing.ComputeKurtosisCoefficient();
            var skewnessStd = stdComputing.ComputeForSkewness();
            var kurtosisStd = stdComputing.ComputeForKurtosis();
            var skewnessStatistics = skewness / skewnessStd;
            var kurtosisStatistics = kurtosis / kurtosisStd;

            var criteria = quantileComputing.ComputeStudentQuantile(1 - Alpha / 2, N - 1);
            return Math.Abs(skewnessStatistics) <= criteria && Math.Abs(kurtosisStatistics) <= criteria;
        }

        public List<Tuple<double, double>> RegressionIntervals()
        {
            var regressionIntervals = new List<Tuple<double, double>>();
            var a0Value = FirstLinearValue;
            var a1Value = SecondLinearValue;
            var quantileComputing = new SeriesQuantileComputing();
            var criteria = quantileComputing.ComputeStudentQuantile(1 - Alpha / 2, N - 2);
            var sortedXSource = XSource.Series.OrderBy(n => n);

            for (int i = 0; i < N; i++)
            {
                var regressionValue = a0Value + a1Value * sortedXSource.ElementAt(i);
                var regressionStd = RegressionStandardDeviation(sortedXSource.ElementAt(i));
                var inf = regressionValue - criteria * regressionStd;
                var sup = regressionValue + criteria * regressionStd;
                regressionIntervals.Add(Tuple.Create(inf, sup));
            }

            return regressionIntervals;
        }

        public List<Tuple<double, double>> ForecastIntervals()
        {
            var forecastIntervals = new List<Tuple<double, double>>();
            var a0Value = FirstLinearValue;
            var a1Value = SecondLinearValue;
            var quantileComputing = new SeriesQuantileComputing();
            var criteria = quantileComputing.ComputeStudentQuantile(1 - Alpha / 2, N - 2);
            var residualVariance = ResidualVariance();
            var sortedXSource = XSource.Series.OrderBy(n => n);

           for (int i = 0; i < N; i++)
           {
               var regressionValue = a0Value + a1Value * sortedXSource.ElementAt(i);
               var regressionStd = RegressionStandardDeviation(sortedXSource.ElementAt(i));
               var forecastStd = Math.Sqrt(Math.Pow(regressionStd, 2) + residualVariance);
               var inf = regressionValue - criteria * forecastStd;
               var sup = regressionValue + criteria * forecastStd;
               forecastIntervals.Add(Tuple.Create(inf, sup));
           }

            return forecastIntervals;
        }
        public double RegressionStandardDeviation(double x)
        {
            var a1 = SecondLinearParameter();
            var residualVariance = ResidualVariance();
            var avg = XSource.Series.Average();
            return Math.Sqrt(residualVariance / N + Math.Pow(a1.Std * (x - avg), 2));
        }
    }
}
