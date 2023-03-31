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
    public partial class MultiDimensionalLinearRegressionForm : Form
    {
        public const string Format = "F5";
        public MultiDimensionalLinearRegressionForm()
        {
            InitializeComponent();
        }

        public void UploadMultiDimensionalData(VariationalSeries depSource, params VariationalSeries[] indepSources)
        {
            var multiDimensionalComputing = new MultiDimensionalLinearRegressionComputing(depSource, indepSources);
            var parameters = multiDimensionalComputing.Parameters();
            var variances = multiDimensionalComputing.Variances();
            var intervals = multiDimensionalComputing.Intervals();
            var statistics = multiDimensionalComputing.Statistics();

            for (int i = 0; i < parameters.Rows; i++)
            {
                dataGridView1.Rows.Add($"a{i}", parameters[i, 0].ToString(Format), Math.Sqrt(variances[i]).ToString(Format), intervals[i].ToStringFormatted(Format),
                    statistics[i].Item1.ToString(Format), multiDimensionalComputing.Criteria, statistics[i].Item2);
            }
        }
    }
}
