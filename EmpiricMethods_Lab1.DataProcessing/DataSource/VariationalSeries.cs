using DataAnalysis1.DataSource;
using EmpiricMethods_Lab1.DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EmpiricMethods_Lab1.DataProcessing.DataSource
{
    public class VariationalSeries : BaseSeries<double>
    {
        public bool IsFirst { get; set; }
        public VariationalSeries()
        {
            Series = new List<double>();
        }
        public VariationalSeries(string path, bool isFirst)
        {
            Series = new List<double>();
            IsFirst = isFirst;
            InitSeries(path);
        }
        public override void InitSeries(string path)
        {
            using (TextReader reader = File.OpenText(path))
            {
                string text = reader.ReadToEnd();
                string[] bits = text.Split(' ', '\r', '\n', '\t');

                var findingStrings = bits.Where(b => !string.IsNullOrEmpty(b)).ToArray();

                for (int i = 0; i < findingStrings.Length; i++)
                {
                    double res = 0;

                    if ((IsFirst ? (i % 2 == 0) : (i % 2 != 0)) && double.TryParse(findingStrings[i], out res))
                    {
                        Series.Add(res);
                    }
                }
            }
        }

        public static VariationalSeries operator*(VariationalSeries first, VariationalSeries second)
        {
            var series = new VariationalSeries();
            
            if(first.Series.Count > second.Series.Count)
            {
                for (int i = 0; i < first.Series.Count; i++)
                {
                    series.Series.Add(first.Series[i] * second.Series[i]);
                }

                return series;
            }

            for (int i = 0; i < second.Series.Count; i++)
            {
                series.Series.Add(first.Series[i] * second.Series[i]);
            }

            return series;
        }

        public VariationalSeries Rank()
        {
            var valueRanks = new List<ValueRank>();

            for (int i = 0; i < Series.Count; i++)
            {
                var valueRank = new ValueRank
                {
                    Rank = null,
                    Value = Series[i]
                };

                valueRanks.Add(valueRank);
            }

            for (int i = 0; i < valueRanks.Count(); i++)
            {
                valueRanks[i].Rank = i + 1;
            }

            var finalList = new List<ValueRank>();
            var repetableValues = new List<ValueRank>();
            var rankDivider = 1;
            var rankSum = 0.0;

            foreach (var value in valueRanks)
            {
                if (!finalList.Select(e => e.Value).Contains(value.Value))
                {
                    finalList.Add(value);
                }
                else
                {
                    rankSum += (double)value.Rank;
                    rankDivider++;
                    repetableValues.Add(new ValueRank
                    {
                        Value = value.Value,
                        Rank = rankSum / rankDivider
                    });
                    rankSum = 0;
                }
            }

            foreach (var criteria in repetableValues
                                .OrderBy(e => e.Rank)
                                .Distinct(new SignRankCriteriaComparer()))
            {
                finalList.First(e => e.Value == criteria.Value).Rank = criteria.Rank;
            }

            var resultSeries = new VariationalSeries();
            resultSeries.Series = finalList.Select(e => (double)e.Rank).ToList();
            return resultSeries;
        }
    }

    public class SignRankCriteriaComparer : IEqualityComparer<ValueRank>
    {
        public bool Equals(ValueRank x, ValueRank y)
        {
            return x.Value == y.Value;
        }

        public int GetHashCode(ValueRank obj)
        {
            return obj.Value.GetHashCode();
        }
    }
}
