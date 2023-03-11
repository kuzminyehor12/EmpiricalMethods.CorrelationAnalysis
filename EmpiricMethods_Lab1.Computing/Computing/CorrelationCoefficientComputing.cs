using EmpiricMethods_Lab1.DataProcessing.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAnalysis1.Computing.Computing;
using EmpiricMethods_Lab1.Computing.Models;
using EmpiricMethods_Lab1.DataProcessing.Models;
using EmpiricMethods_Lab1.Computing.Extensions;
using DataAnalysis1.Computing;

namespace EmpiricMethods_Lab1.Computing.Computing
{
    public class CorrelationCoefficientComputing
    {
        public VariationalSeries XSource { get; }
        public VariationalSeries YSource { get; }
        public int N => XSource.Series.Count;
        public int K => (int)Math.Round(1 + 1.44 * Math.Log(N));
        public CorrelationCoefficientComputing(
            VariationalSeries xSource, 
            VariationalSeries ySource)
        {
            XSource = xSource;
            YSource = ySource;
        }
        public CorrelationResult Pearson()
        {
            var xSourcePointEstimation = new PointEstimationCharacteristicsComputing(XSource);
            var ySourcePointEstimation = new PointEstimationCharacteristicsComputing(YSource);
            var generalPointEstimation = new PointEstimationCharacteristicsComputing(XSource * YSource);

            var coefficient = (generalPointEstimation.ComputeAverage() - xSourcePointEstimation.ComputeAverage() * ySourcePointEstimation.ComputeAverage()) 
                                        / (xSourcePointEstimation.ComputeStandartDeviation(true) * ySourcePointEstimation.ComputeStandartDeviation(true));

            var result = new PearsonResult(coefficient, N);
            return result
                    .ComputeInterval()
                    .ComputeStatistics()
                    .Summarize();
        }
        public CorrelationResult Spearman()
        {
            var xRanks = XSource.Rank();
            var yRanks = YSource.Rank();

            var rankPairsSpearman =
                Enumerable.Zip(xRanks, yRanks,
                    (x, y) => new KeyValuePair<ValueRank, ValueRank>(x, y)).OrderBy(x => x.Key.Rank).ToList();

            var sortedXRanks = rankPairsSpearman.Select(x => x.Key).ToList();
            var sortedYRanks = rankPairsSpearman.Select(x => x.Value).ToList();

            double coefficient = 0;
            CorrelationResult result;

            for (int i = 0; i < xRanks.Count; i++)
            {
                if (xRanks[i].HasBundle || yRanks[i].HasBundle)
                {
                    coefficient = SpearmanWithBundles(sortedXRanks, sortedYRanks);
                    result = new SpearmanResult(coefficient, N);

                    return result
                           .ComputeInterval()
                           .ComputeStatistics()
                           .Summarize();
                }
            }

            coefficient = SpearmanWithoutBundles(sortedXRanks, sortedYRanks);
            result = new SpearmanResult(coefficient, N);

            return result
                   .ComputeInterval()
                   .ComputeStatistics()
                   .Summarize();
        }

        private double SpearmanWithBundles(List<ValueRank> xRanks, List<ValueRank> yRanks)
        {
            var xBundles = xRanks.Where(r => r.HasBundle).Distinct(new SignRankCriteriaComparer()).ToList();
            var yBundles = yRanks.Where(r => r.HasBundle).Distinct(new SignRankCriteriaComparer()).ToList();
            double aSum = 0, bSum = 0;

            for (int j = 0; j < xBundles.Count; j++)
            {
                aSum += Math.Pow(xBundles[j].AmountInBundle, 3) - xBundles[j].AmountInBundle;
            }

            double a = (double)1 / 12 * aSum;

            for (int k = 0; k < yBundles.Count; k++)
            {
                bSum += Math.Pow(yBundles[k].AmountInBundle, 3) - yBundles[k].AmountInBundle;
            }

            double b = (double)1 / 12 * bSum;

            double sum = 0;

            for (int i = 0; i < N; i++)
            {
                sum += Math.Pow((double)(xRanks[i].Rank - yRanks[i].Rank), 2);
            }

            var coefficient = ((double)1 / 6 * N * (Math.Pow(N, 2) - 1) - sum - a - b) /
                Math.Sqrt(((double)1 / 6 * N * (Math.Pow(N, 2) - 1) - 2 * a) * ((double)1 / 6 * N * (Math.Pow(N, 2) - 1) - 2 * b));

            return coefficient;
        }

        private double SpearmanWithoutBundles(List<ValueRank> xRanks, List<ValueRank> yRanks)
        {
            double sum = 0;

            for (int i = 0; i < xRanks.Count; i++)
            {
                sum += Math.Pow((double)(xRanks[i].Rank - yRanks[i].Rank), 2);
            }

            var coefficient = 1.0 - (6.0 / (xRanks.Count * (Math.Pow(xRanks.Count, 2) - 1.0))) * sum;
            return coefficient;
        }

        public CorrelationResult Kendall()
        {
            var xRanks = XSource.Rank();
            var yRanks = YSource.Rank();

            double coefficient = 0;
            CorrelationResult result;

            for (int i = 0; i < xRanks.Count; i++)
            {
                if (xRanks[i].HasBundle || yRanks[i].HasBundle)
                {
                    coefficient = KendallWithBundles(xRanks, yRanks);
                    result = new KendallResult(coefficient, N);

                    return result
                           .ComputeInterval()
                           .ComputeStatistics()
                           .Summarize();
                }
            }

            coefficient = KendallWithoutBundles(yRanks);
            result = new KendallResult(coefficient, N);

            return result
                   .ComputeInterval()
                   .ComputeStatistics()
                   .Summarize();
        }

        private double KendallWithBundles(List<ValueRank> xRanks, List<ValueRank> yRanks)
        {
            double sum = 0;
            var sortedXRanks = new List<ValueRank>(xRanks);
            var sortedYRanks = yRanks.RelationalSort(sortedXRanks);

            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (sortedYRanks[i].Rank > sortedYRanks[j].Rank && sortedXRanks[i] != sortedXRanks[j])
                    {
                        sum -= 1;
                    }
                    else if (sortedYRanks[i].Rank < sortedYRanks[j].Rank && sortedXRanks[i] != sortedXRanks[j])
                    {
                        sum += 1;
                    }
                }
            }

            var xBundles = xRanks.Where(r => r.HasBundle).Distinct(new SignRankCriteriaComparer()).ToList();
            var yBundles = yRanks.Where(r => r.HasBundle).Distinct(new SignRankCriteriaComparer()).ToList();
            double aSum = 0, bSum = 0;

            for (int j = 0; j < xBundles.Count(); j++)
            {
                aSum += xBundles[j].AmountInBundle * (xBundles[j].AmountInBundle - 1);
            }

            double c = 0.5 * aSum;

            for (int k = 0; k < yBundles.Count(); k++)
            {
                bSum += yBundles[k].AmountInBundle * (yBundles[k].AmountInBundle - 1);
            }

            double d = 0.5 * bSum;
            var coefficient = sum / Math.Sqrt((0.5 * N * (N - 1) - c) * (0.5 * N * (N - 1) - d));
            return coefficient;
        }

        private double KendallWithoutBundles(List<ValueRank> yRanks)
        {
            double sum = 0;

            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (yRanks[i].Rank < yRanks[j].Rank)
                    {
                        sum += 1;
                    }
                    else if(yRanks[i].Rank > yRanks[j].Rank)
                    {
                        sum -= 1;
                    }
                }
            }
            
            var coefficient = 2 * sum / (N * (N - 1));
            return coefficient;
        }

        public CorrelationResult CorrelationRatio()
        {
            var dict = GetSourceToRatio()
                       .OrderBy(pair => pair.Key);

            var yAverages = dict
                            .Select(kvp => kvp.Value.Average())
                            .ToList();

            var yAvg = dict
                        .Select((pair, index) => pair.Value.Count * yAverages[index])
                        .Sum() / N;

            var stdYAvg = dict
                          .Select((pair, index) => pair.Value.Count * Math.Pow(yAverages[index] - yAvg, 2))
                          .Sum();

            var stdY = dict.Sum(pair => pair.Value.Sum(val => Math.Pow(val - yAvg, 2)));

            var coefficient = Math.Sqrt(stdYAvg / stdY);
            var result = new RatioResult(coefficient, N, K);

            return result
                   .ComputeInterval()
                   .ComputeStatistics()
                   .Summarize();
        }

        public Dictionary<double, IList<double>> GetSourceToRatio()
        {
            var classComputing = new ClassSegregationComputing(XSource, K);
            var averages = classComputing.ClassList.ComputeAverages();
            var dict = new Dictionary<double, IList<double>>();

            for (int i = 0; i < Math.Min(XSource.Series.Count, YSource.Series.Count); i++)
            {
                for (int l = 0; l < classComputing.ClassList.Count; l++)
                {
                    if (classComputing.ClassList[l].Contains(XSource.Series[i]))
                    {
                        if (dict.ContainsKey(averages[l]))
                        {
                            dict[averages[l]].Add(YSource.Series[i]);
                        }
                        else
                        {
                            var yList = new List<double> { YSource.Series[i] };
                            dict.Add(averages[l], yList);
                        }
                    }
                }
            }

            return dict;
        }

        public LinearCorrelationResult PearsonToRatio()
        {
            var dict = GetSourceToRatio();
            var newDict = new List<(double, double)>();

            foreach (var key in dict.Keys)
            {
                foreach (var value in dict[key])
                {
                    newDict.Add((key, value));
                }
            }

            var xSeries = new VariationalSeries(newDict.Select(x => x.Item1));
            var ySeries = new VariationalSeries(newDict.Select(x => x.Item2));

            var xComputing = new PointEstimationCharacteristicsComputing(xSeries);
            var yComputing = new PointEstimationCharacteristicsComputing(ySeries);
            var xyComputing = new PointEstimationCharacteristicsComputing(xSeries * ySeries);

            var coefficient = (xyComputing.ComputeAverage() - xComputing.ComputeAverage() * yComputing.ComputeAverage())
                                      / (xComputing.ComputeStandartDeviation() * yComputing.ComputeStandartDeviation());

            var ratio = CorrelationRatio().Value;

            var result = new LinearCorrelationResult(coefficient, ratio, K, N);
            return result
                    .ComputeStatistics()
                    .Summarize();
        }
    }
}
