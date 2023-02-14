using DataAnalysis1.DataSource;
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
    }
}
