using DataAnalysis1.Computing.Computing;
using EmpiricMethods_Lab1.Computing.Computing;
using EmpiricMethods_Lab1.Computing.Models;
using EmpiricMethods_Lab1.DataProcessing.DataSource;
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
    public partial class LinearExistenceCheckForm : Form
    {
        private const string Format = "F5";
        public LinearExistenceCheckForm()
        {
            InitializeComponent();
        }

        public void UploadEstimation(VariationalSeries xSource, VariationalSeries ySource)
        {
            dataGridView1.Rows.Clear();

            var correlationCoefficientComputing = new CorrelationCoefficientComputing(xSource, ySource);

            var linearResult = correlationCoefficientComputing.PearsonToRatio();

            dataGridView1.Rows.Add(linearResult.PearsonValue.ToString(Format), linearResult.RatioValue.ToString(Format), 
                linearResult.Statistics.ToString(Format), linearResult.Criteria.ToString(Format), 
                linearResult.Summary, linearResult.IsLinear);
        }
    }
}
