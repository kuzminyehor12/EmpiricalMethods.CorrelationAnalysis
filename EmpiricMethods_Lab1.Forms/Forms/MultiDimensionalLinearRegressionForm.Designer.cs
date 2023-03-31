namespace EmpiricMethods_Lab1.Forms.Forms
{
    partial class MultiDimensionalLinearRegressionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StandardDeviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Interval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Statistics = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Parameter,
            this.Value,
            this.StandardDeviation,
            this.Interval,
            this.Statistics,
            this.Quantile,
            this.Summary});
            this.dataGridView1.Location = new System.Drawing.Point(0, -1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(993, 326);
            this.dataGridView1.TabIndex = 1;
            // 
            // Parameter
            // 
            this.Parameter.HeaderText = "Parameter";
            this.Parameter.MinimumWidth = 6;
            this.Parameter.Name = "Parameter";
            this.Parameter.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.MinimumWidth = 6;
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // StandardDeviation
            // 
            this.StandardDeviation.HeaderText = "Standard Deviation";
            this.StandardDeviation.MinimumWidth = 6;
            this.StandardDeviation.Name = "StandardDeviation";
            this.StandardDeviation.ReadOnly = true;
            // 
            // Interval
            // 
            this.Interval.HeaderText = "Interval";
            this.Interval.MinimumWidth = 6;
            this.Interval.Name = "Interval";
            this.Interval.ReadOnly = true;
            // 
            // Statistics
            // 
            this.Statistics.HeaderText = "Statistics";
            this.Statistics.MinimumWidth = 6;
            this.Statistics.Name = "Statistics";
            this.Statistics.ReadOnly = true;
            // 
            // Quantile
            // 
            this.Quantile.HeaderText = "Quantile";
            this.Quantile.MinimumWidth = 6;
            this.Quantile.Name = "Quantile";
            this.Quantile.ReadOnly = true;
            // 
            // Summary
            // 
            this.Summary.HeaderText = "Summary";
            this.Summary.MinimumWidth = 6;
            this.Summary.Name = "Summary";
            this.Summary.ReadOnly = true;
            // 
            // MultiDimensionalLinearRegressionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 454);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MultiDimensionalLinearRegressionForm";
            this.Text = "MultiDimensionalLinearRegressionForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn StandardDeviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Interval;
        private System.Windows.Forms.DataGridViewTextBoxColumn Statistics;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary;
    }
}