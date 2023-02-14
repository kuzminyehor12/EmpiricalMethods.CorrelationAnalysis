using EmpiricMethods_Lab1.DataProcessing.DataSource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            CorrelationFieldChart.Series["Correlation Field"].Points.Clear();

            XSource = xSource;
            YSource = ySource;

            for (int i = 0; i < XSource.Series.Count; i++)
            {
                CorrelationFieldChart.Series["Correlation Field"].Points.AddXY(XSource.Series[i], YSource.Series[i]);
            }
        }
    }
}
