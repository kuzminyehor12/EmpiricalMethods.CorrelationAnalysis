using EmpiricMethods_Lab1.Computing.Computing;
using EmpiricMethods_Lab1.DataProcessing.DataSource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmpiricMethods_Lab1.Forms.Forms
{
    public partial class CorrelationFieldForm : Form
    {
        public VariationalSeries XSource { get; private set; }
        public VariationalSeries YSource { get; private set; }
        public CorrelationFieldForm()
        {
            InitializeComponent();
        }

        private void CorrelationFieldForm_Load(object sender, EventArgs e)
        {
            
        }

        public void UploadSources(VariationalSeries xSource, VariationalSeries ySource)
        {
            ClearCharts();

            XSource = xSource;
            YSource = ySource;

            var regressionComputing = new OneDimensionalLinearRegressionComputing(XSource, YSource);
            var regressionIntervals = regressionComputing.RegressionIntervals();
            var forecastIntervals = regressionComputing.ForecastIntervals();
            var n = regressionComputing.N;

            var sortedXSource = XSource.Series.OrderBy(i => i).ToList();

            for (int i = 0; i < Math.Min(XSource.Series.Count, n); i++)
            {
                CorrelationFieldChart.Series["Correlation Field"].Points.AddXY(XSource.Series[i], YSource.Series[i]);
            }

            for (int i = 0; i < Math.Min(sortedXSource.Count, n); i++)
            {
                var a0 = regressionComputing.FirstLinearValue();
                var a1 = regressionComputing.SecondLinearValue();
                CorrelationFieldChart.Series["Regression Line"].Points.AddXY(sortedXSource[i], a0 + a1 * sortedXSource[i]);
            }

            for (int i = 0; i < Math.Min(sortedXSource.Count, regressionIntervals.Count); i++)
            {
                CorrelationFieldChart.Series["Regression Interval Infs"].Points.AddXY(sortedXSource[i], regressionIntervals[i].Item1);
                CorrelationFieldChart.Series["Regression Interval Sups"].Points.AddXY(sortedXSource[i], regressionIntervals[i].Item2);
            }

            for (int i = 0; i < Math.Min(sortedXSource.Count, forecastIntervals.Count); i++)
            {
                CorrelationFieldChart.Series["Forecast Interval Infs"].Points.AddXY(sortedXSource[i], forecastIntervals[i].Item1);
                CorrelationFieldChart.Series["Forecast Interval Sups"].Points.AddXY(sortedXSource[i], forecastIntervals[i].Item2);
            }
        }

        public void ClearCharts()
        {
            CorrelationFieldChart.Series["Correlation Field"].Points.Clear();
            CorrelationFieldChart.Series["Regression Interval Infs"].Points.Clear();
            CorrelationFieldChart.Series["Regression Interval Sups"].Points.Clear();
            CorrelationFieldChart.Series["Forecast Interval Infs"].Points.Clear();
            CorrelationFieldChart.Series["Forecast Interval Sups"].Points.Clear();
            CorrelationFieldChart.Series["Regression Line"].Points.Clear();
        }
    }
}
