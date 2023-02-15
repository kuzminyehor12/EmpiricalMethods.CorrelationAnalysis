using EmpiricMethods_Lab1.DataProcessing.DataSource;
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
        private CorrelationFieldForm _correlationFieldForm;
        private StatCharacteristicsForm _characteristicsForm;
        private CorrelationCoefficientForm _correlationCoefficientForm;
        public VariationalSeries XSource { get; private set; }
        public VariationalSeries YSource { get; private set; }
        public MainForm()
        {
            InitializeComponent();
            SetForms();
            SetTabPages();
        }

        public void SetForms()
        {
            _correlationFieldForm = new CorrelationFieldForm();
            _characteristicsForm = new StatCharacteristicsForm();
            _correlationCoefficientForm = new CorrelationCoefficientForm();
        }

        public void SetTabPages()
        {
            _correlationFieldForm.AddToTabPage(tabControl1, 0);
            _characteristicsForm.AddToTabPage(tabControl1, 1);
            _correlationCoefficientForm.AddToTabPage(tabControl1, 2);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "All files (*.*)|*.*",
                Multiselect = false
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                XSource = new VariationalSeries(path, true);
                YSource = new VariationalSeries(path, false);
                _correlationFieldForm.UploadSources(XSource, YSource);
                _characteristicsForm.SetupCharacteristics(XSource, YSource);
                _correlationCoefficientForm.UploadCoefficients(XSource, YSource);
            }
        }
    }
}
