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
    public partial class OneDimensionalLinearRegressionForm : Form
    {
        private const string Format = "F5";
        public OneDimensionalLinearRegressionForm()
        {
            InitializeComponent();
        }

        public void ComputeRegression(VariationalSeries xSource, VariationalSeries ySource)
        {
            dataGridView1.Rows.Clear();

            var oneDimLinearRegresComputing = new OneDimensionalLinearRegressionComputing(xSource, ySource);

            var a0 = oneDimLinearRegresComputing.FirstLinearParameter();
            var a1 = oneDimLinearRegresComputing.SecondLinearParameter();

            dataGridView1.Rows.Add(nameof(a0), a0.Value.ToString(Format), a0.Std.ToString(Format), a0.Interval.ToStringFormatted(Format),
                a0.Statistics.ToString(Format), a0.Criteria.ToString(Format), a0.Summary);

            dataGridView1.Rows.Add(nameof(a1), a1.Value.ToString(Format), a1.Std.ToString(Format), a1.Interval.ToStringFormatted(Format),
                a1.Statistics.ToString(Format), a1.Criteria.ToString(Format), a1.Summary);

            var residualVariance = oneDimLinearRegresComputing.ResidualVariance();
            var fTestResult = oneDimLinearRegresComputing.FTest();
            var coefficientOfDetermination = oneDimLinearRegresComputing.CoefficientOfDetermination();
            var normality = oneDimLinearRegresComputing.Normality();

            textBox1.Text = residualVariance.ToString(Format);
            textBox3.Text = fTestResult.Value.ToString(Format);
            textBox5.Text = fTestResult.Criteria.ToString(Format);
            textBox6.Text = fTestResult.Summary;
            textBox2.Text = coefficientOfDetermination.ToString(Format);
            textBox4.Text = normality.ToString();
        }
    }
}
