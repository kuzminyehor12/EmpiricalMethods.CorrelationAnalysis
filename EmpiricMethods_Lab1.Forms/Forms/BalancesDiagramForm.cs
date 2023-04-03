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
    public partial class BalancesDiagramForm : Form
    {
        public BalancesDiagramForm()
        {
            InitializeComponent();
        }

        public void UploadBalancesDiagram(VariationalSeries dependentSource, params VariationalSeries[] independentSources)
        {
            var multiDimensionalComputing = new MultiDimensionalLinearRegressionComputing(dependentSource, independentSources);
            var balances = multiDimensionalComputing.Balances;
            var arguments = multiDimensionalComputing.Arguments;

            for (int i = 0; i < balances.Series.Count; i++)
            {
                chart1.Series[0].Points.AddXY(balances.Series[i], arguments.Series[i]);
            }
        }
    }
}
