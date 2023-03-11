using DataAnalysis1.DataSource;
using EmpiricMethods_Lab1.DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace EmpiricMethods_Lab1.DataProcessing.DataSource
{
    public class VariationalSeries : BaseSeries<double>
    {
        private readonly CultureInfo Culture = CultureInfo.InvariantCulture;
        private readonly NumberStyles NumberStyles = NumberStyles.Any;
        private const int AUTOMPG_COLUMNS_COUNT = 8;
        public bool IsFirst { get; set; }
        public VariationalSeries()
        {
            Series = new List<double>();
        }
        public VariationalSeries(IEnumerable<double> series)
        {
            Series = series.ToList();
        }
        public VariationalSeries(
            string path, 
            bool isFirst)
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

                    if ((IsFirst ? (i % 2 == 0) : (i % 2 != 0)) && double.TryParse(findingStrings[i], NumberStyles, Culture, out res))
                    {
                        Series.Add(res);
                    }
                }
            }
        }

        public void InitSeries(string path, int index)
        {
            using (TextReader reader = File.OpenText(path))
            {
                string text = reader.ReadToEnd();
                string[] bits = text.Split(' ', '\r', '\n', '\t');

                var findingStrings = bits.Where(b => !string.IsNullOrEmpty(b)).ToArray();

                for (int i = index - 1; i < findingStrings.Length; i += AUTOMPG_COLUMNS_COUNT)
                {
                    double res = 0;

                    if (double.TryParse(findingStrings[i], NumberStyles, Culture, out res))
                    {
                        Series.Add(res);
                    }
                }
            }
        }

        public static VariationalSeries operator*(VariationalSeries first, VariationalSeries second)
        {
            var series = new VariationalSeries();
            
            if(first.Series.Count >= second.Series.Count)
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

        public List<ValueRank> Rank()
        {
            var valueRanks = new List<ValueRank>();

            for (int i = 0; i < Series.Count; i++)
            {
                var valueRank = new ValueRank
                {
                    Rank = null,
                    Value = Series[i],
                    AmountInBundle = 0
                };

                valueRanks.Add(valueRank);
            }

            var sortedValueRanks = valueRanks.OrderBy(v => v.Value).ToList();
            
            for (int i = 0; i < sortedValueRanks.Count(); i++)
            {
                sortedValueRanks[i].Rank = i + 1;
            }

            var finalList = new List<ValueRank>();
            var repetableValues = new List<ValueRank>();
            var rankDivider = 1;
            var rankSum = 0.0;

            foreach (var value in sortedValueRanks)
            {
                if (!finalList.Select(e => e.Value).Contains(value.Value))
                {
                    rankSum = 0;
                    rankDivider = 1;
                    rankSum += (double)value.Rank;
                }
                else
                {
                    rankSum += (double)value.Rank;
                    rankDivider++;
                    repetableValues.Add(new ValueRank
                    {
                        Value = value.Value,
                        AmountInBundle = rankDivider,
                        Rank = rankSum / rankDivider
                    });
                }

                finalList.Add(value);
            }

            foreach (var criteria in repetableValues
                                .OrderByDescending(e => e.AmountInBundle)
                                .Distinct(new SignRankCriteriaComparer()))
            {
                finalList.ForEach(e =>
                {
                    if (e.Value == criteria.Value)
                    {
                        e.Rank = criteria.Rank;
                        e.AmountInBundle = criteria.AmountInBundle;
                    }
                });
            }

            for (int i = 0; i < valueRanks.Count; i++)
            {
                valueRanks[i] = finalList.First(e => valueRanks[i].Value == e.Value);
            }

            return valueRanks;
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
