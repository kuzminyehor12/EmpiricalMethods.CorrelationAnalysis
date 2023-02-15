using DataAnalysis1.Computing.Computing;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpiricMethods_Lab1.Forms.Forms
{
    public partial class CorrelationCoefficientForm : Form
    {
        private const string Format = "F5";
        public CorrelationCoefficientForm()
        {
            InitializeComponent();
        }

        public void UploadCoefficients(VariationalSeries xSource, VariationalSeries ySource)
        {
            var correlationCoefficientComputing = new CorrelationCoefficientComputing();
            var quantileComputing = new SeriesQuantileComputing();
            var pearsonResult = correlationCoefficientComputing.Pearson(xSource, ySource);
            var criteria = quantileComputing.ComputeStudentQuantile(1 - correlationCoefficientComputing.Alpha / 2, xSource.Series.Count);

            dataGridView1.Rows.Add(nameof(correlationCoefficientComputing.Pearson), pearsonResult.Value.ToString(Format), 
                pearsonResult.Interval.ToStringFormatted(Format), criteria, pearsonResult.Statistics, pearsonResult.Summary);
        }
    }
}
