using EmpiricMethods_Lab1.Computing.Computing;
using EmpiricMethods_Lab1.DataProcessing.DataSource;
using EmpiricMethods_Lab1.Forms.Extensions;
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
            CorrelationFieldChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            CorrelationFieldChart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            CorrelationFieldChart.ChartAreas[0].AxisY.Title = "Y";
            CorrelationFieldChart.ChartAreas[0].AxisX.Title = "X";
            CorrelationFieldChart.AllowZooming();
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

            var sortedXSource = XSource.Series.OrderBy(i => i);

            CorrelationFieldChart.Invoke(new MethodInvoker(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    CorrelationFieldChart.Series["Correlation Field"].Points.AddXY(XSource.Series[i], YSource.Series[i]);
                }

                for (int i = 0; i < n; i++)
                {
                    var a0 = regressionComputing.FirstLinearValue;
                    var a1 = regressionComputing.SecondLinearValue;
                    CorrelationFieldChart.Series["Regression Line"].Points.AddXY(sortedXSource.ElementAt(i), a0 + a1 * sortedXSource.ElementAt(i));
                }

                for (int i = 0; i < regressionIntervals.Count; i++)
                {
                    CorrelationFieldChart.Series["Regression Interval Infs"].Points.AddXY(sortedXSource.ElementAt(i), regressionIntervals[i].Item1);
                    CorrelationFieldChart.Series["Regression Interval Sups"].Points.AddXY(sortedXSource.ElementAt(i), regressionIntervals[i].Item2);
                }

                for (int i = 0; i < forecastIntervals.Count; i++)
                {
                    CorrelationFieldChart.Series["Forecast Interval Infs"].Points.AddXY(sortedXSource.ElementAt(i), forecastIntervals[i].Item1);
                    CorrelationFieldChart.Series["Forecast Interval Sups"].Points.AddXY(sortedXSource.ElementAt(i), forecastIntervals[i].Item2);
                }
            }));
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
