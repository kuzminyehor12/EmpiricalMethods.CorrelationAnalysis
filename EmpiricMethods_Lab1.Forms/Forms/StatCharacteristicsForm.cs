using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAnalysis1.Computing;
using DataAnalysis1.Computing.Computing;
using EmpiricMethods_Lab1.DataProcessing.DataSource;
using EmpiricMethods_Lab1.Forms.Extensions;

namespace EmpiricMethods_Lab1.Forms.Forms
{
    public partial class StatCharacteristicsForm : Form
    {
        private const int HEADER_CELL_WIDTH = 100;
        private const string Format = "F5";
        public StatCharacteristicsForm()
        {
            InitializeComponent();
        }

        public void SetupCharacteristics(VariationalSeries xSource, VariationalSeries ySource)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.RowHeadersWidth = HEADER_CELL_WIDTH;

            ComputeCharacteristics(xSource, ySource);

            dataGridView1.Rows[0].HeaderCell.Value = "Mean";
            dataGridView1.Rows[1].HeaderCell.Value = "Median";
            dataGridView1.Rows[2].HeaderCell.Value = "Standard Deviation";
            dataGridView1.Rows[3].HeaderCell.Value = "Skewness";
            dataGridView1.Rows[4].HeaderCell.Value = "Kurtosis";
        }

        public void ComputeCharacteristics(VariationalSeries xSource, VariationalSeries ySource)
        {
            var pointEstimationComputingForXSource = new PointEstimationCharacteristicsComputing(xSource);
            var pointEstimationComputingForYSource = new PointEstimationCharacteristicsComputing(ySource);

            var intervalEstimationComputingForXSource = new IntervalEstimationCharacteristicsComputing(xSource);
            var intervalEstimationComputingForYSource = new IntervalEstimationCharacteristicsComputing(ySource);

            dataGridView1.Rows.Add(pointEstimationComputingForXSource.ComputeAverage().ToString(Format), 
                                   pointEstimationComputingForYSource.ComputeAverage().ToString(Format),
                                   intervalEstimationComputingForXSource.ComputeIntervalForAverage().ToStringFormatted(Format),
                                   intervalEstimationComputingForYSource.ComputeIntervalForAverage().ToStringFormatted(Format));

            dataGridView1.Rows.Add(pointEstimationComputingForXSource.ComputeMedian().ToString(Format), 
                                   pointEstimationComputingForYSource.ComputeMedian().ToString(Format),
                                   intervalEstimationComputingForXSource.ComputeIntervalForMedian().ToStringFormatted(Format),
                                   intervalEstimationComputingForYSource.ComputeIntervalForMedian().ToStringFormatted(Format));

            dataGridView1.Rows.Add(pointEstimationComputingForXSource.ComputeStandartDeviation().ToString(Format), 
                                   pointEstimationComputingForYSource.ComputeStandartDeviation().ToString(Format),
                                   intervalEstimationComputingForXSource.ComputeIntervalForStandartDeviation().ToStringFormatted(Format), 
                                   intervalEstimationComputingForYSource.ComputeIntervalForStandartDeviation().ToStringFormatted(Format));

            dataGridView1.Rows.Add(pointEstimationComputingForXSource.ComputeSkewnessCoefficient().ToString(Format), 
                                   pointEstimationComputingForYSource.ComputeSkewnessCoefficient().ToString(Format),
                                   intervalEstimationComputingForXSource.ComputeIntervalForSkewness().ToStringFormatted(Format),
                                   intervalEstimationComputingForYSource.ComputeIntervalForSkewness().ToStringFormatted(Format));

            dataGridView1.Rows.Add(pointEstimationComputingForXSource.ComputeKurtosisCoefficient().ToString(Format),
                                   pointEstimationComputingForYSource.ComputeKurtosisCoefficient().ToString(Format),
                                   intervalEstimationComputingForXSource.ComputeIntervalForKurtosis().ToStringFormatted(Format), 
                                   intervalEstimationComputingForYSource.ComputeIntervalForKurtosis().ToStringFormatted(Format));
        }
    }
}
