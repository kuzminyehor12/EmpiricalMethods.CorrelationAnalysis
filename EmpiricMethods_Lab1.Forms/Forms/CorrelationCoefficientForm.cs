using DataAnalysis1.Computing.Computing;
using EmpiricMethods_Lab1.Computing.Computing;
using EmpiricMethods_Lab1.Computing.Models;
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
            dataGridView1.Rows.Clear();

            var correlationCoefficientComputing = new CorrelationCoefficientComputing(xSource, ySource);

            var pearsonResult = correlationCoefficientComputing.Pearson();
            var spearmanResult = correlationCoefficientComputing.Spearman();
            var kendallResult = correlationCoefficientComputing.Kendall();
            var ratioResult = correlationCoefficientComputing.CorrelationRatio() as RatioResult;

            dataGridView1.Rows.Add(nameof(correlationCoefficientComputing.Pearson), pearsonResult.Value.ToString(Format), 
              pearsonResult.Interval.ToStringFormatted(Format), pearsonResult.Criteria.ToString(Format), ((double)pearsonResult.Statistics).ToString(Format),
              pearsonResult.Summary, pearsonResult.ContactExists.ToString());

            dataGridView1.Rows.Add(nameof(correlationCoefficientComputing.Spearman), spearmanResult.Value.ToString(Format),
              spearmanResult.Interval.ToStringFormatted(Format), spearmanResult.Criteria.ToString(Format), ((double)spearmanResult.Statistics).ToString(Format),
              spearmanResult.Summary, spearmanResult.ContactExists.ToString());

            dataGridView1.Rows.Add(nameof(correlationCoefficientComputing.Kendall), kendallResult.Value.ToString(Format),
              kendallResult.Interval.ToStringFormatted(Format), kendallResult.Criteria.ToString(Format), ((double)kendallResult.Statistics).ToString(Format),
              kendallResult.Summary, kendallResult.ContactExists.ToString());

            dataGridView1.Rows.Add(nameof(correlationCoefficientComputing.CorrelationRatio), ratioResult.Value.ToString(Format),
              ratioResult.Interval.ToStringFormatted(Format), ratioResult.Criteria.ToString(Format), ((double)ratioResult.Statistics).ToString(Format),
              ratioResult.Summary, ratioResult.ContactExists.ToString());
        }
    }
}
