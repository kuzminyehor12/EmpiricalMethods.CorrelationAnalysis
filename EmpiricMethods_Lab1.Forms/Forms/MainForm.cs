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
        private LinearExistenceCheckForm _linearExistenceForm;
        private OneDimensionalLinearRegressionForm _oneDimensionalLinearRegressionForm;
        private MultiDimensionalLinearRegressionForm _multiDimensionalRegressionForm;
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
            _linearExistenceForm = new LinearExistenceCheckForm();
            _oneDimensionalLinearRegressionForm = new OneDimensionalLinearRegressionForm();
            _multiDimensionalRegressionForm = new MultiDimensionalLinearRegressionForm();
        }

        public void SetTabPages()
        {
            _correlationFieldForm.AddToTabPage(tabControl1, 0);
            _characteristicsForm.AddToTabPage(tabControl1, 1);
            _correlationCoefficientForm.AddToTabPage(tabControl1, 2);
            _linearExistenceForm.AddToTabPage(tabControl1, 3);
            _oneDimensionalLinearRegressionForm.AddToTabPage(tabControl1, 4);
            _multiDimensionalRegressionForm.AddToTabPage(tabControl1, 5);
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
                YSource = new VariationalSeries(path, false);
                XSource = new VariationalSeries(path, true);
                UploadData();
            }
        }
        
        public void UploadData()
        {
            _correlationFieldForm.UploadSources(XSource, YSource);
            _characteristicsForm.SetupCharacteristics(XSource, YSource);
            _correlationCoefficientForm.UploadCoefficients(XSource, YSource);
            _linearExistenceForm.UploadEstimation(XSource, YSource);
            _oneDimensionalLinearRegressionForm.ComputeRegression(XSource, YSource);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = @"E:\Универ\Курс 3\Емпіричні методи\data_lab1,2_real\auto-mpg-v2.dat";
            var independentSources = new VariationalSeries[VariationalSeries.AUTOMPG_COLUMNS_COUNT - 1];

            var dependentSource = new VariationalSeries();
            dependentSource.InitSeries(path, 1);

            for (int i = 2; i <= VariationalSeries.AUTOMPG_COLUMNS_COUNT; i++)
            {
                var source = new VariationalSeries();
                source.InitSeries(path, i);
                independentSources[i - 2] = source;
            }

            _multiDimensionalRegressionForm.UploadMultiDimensionalData(dependentSource, independentSources);
        }
    }
}
