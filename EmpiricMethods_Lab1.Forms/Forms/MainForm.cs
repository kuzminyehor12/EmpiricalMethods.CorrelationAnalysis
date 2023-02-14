using EmpiricMethods_Lab1.Forms.Extensions;
using EmpiricMethods_Lab1.Forms.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpiricMethods_Lab1.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void SetTabPages()
        {
            new CorrelationFieldForm().AddToTabPage(tabControl1, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "All files (*.*)|*.*",
                Multiselect = false
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                /*DataSource = new VariationalSeries(path);
                _abnormalValuesForm = new AbnormalValuesForm(DataSource);
                _probabilitySheetForm = new ProbabilitySheetForm(DataSource);
                await UploadVariationalSeries();*/
            }
        }
    }
}
