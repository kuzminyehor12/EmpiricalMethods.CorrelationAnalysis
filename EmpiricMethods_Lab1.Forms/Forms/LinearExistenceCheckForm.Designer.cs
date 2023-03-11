namespace EmpiricMethods_Lab1.Forms.Forms
{
    partial class LinearExistenceCheckForm
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
            this.Pearson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrelationRatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Statistics = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Criteria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.IsLinear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pearson,
            this.CorrelationRatio,
            this.Statistics,
            this.Criteria,
            this.Summary,
            this.IsLinear});
            this.dataGridView1.Location = new System.Drawing.Point(2, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(938, 451);
            this.dataGridView1.TabIndex = 0;
            // 
            // Pearson
            // 
            this.Pearson.HeaderText = "Pearson";
            this.Pearson.MinimumWidth = 6;
            this.Pearson.Name = "Pearson";
            this.Pearson.ReadOnly = true;
            // 
            // CorrelationRatio
            // 
            this.CorrelationRatio.HeaderText = "Correlation Ratio";
            this.CorrelationRatio.MinimumWidth = 6;
            this.CorrelationRatio.Name = "CorrelationRatio";
            this.CorrelationRatio.ReadOnly = true;
            // 
            // Statistics
            // 
            this.Statistics.HeaderText = "Statistics";
            this.Statistics.MinimumWidth = 6;
            this.Statistics.Name = "Statistics";
            this.Statistics.ReadOnly = true;
            // 
            // Criteria
            // 
            this.Criteria.HeaderText = "Criteria";
            this.Criteria.MinimumWidth = 6;
            this.Criteria.Name = "Criteria";
            this.Criteria.ReadOnly = true;
            // 
            // Summary
            // 
            this.Summary.HeaderText = "Summary";
            this.Summary.MinimumWidth = 6;
            this.Summary.Name = "Summary";
            this.Summary.ReadOnly = true;
            // 
            // IsLinear
            // 
            this.IsLinear.HeaderText = "Is Linear";
            this.IsLinear.MinimumWidth = 6;
            this.IsLinear.Name = "IsLinear";
            this.IsLinear.ReadOnly = true;
            // 
            // LinearExistenceCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 451);
            this.Controls.Add(this.dataGridView1);
            this.Name = "LinearExistenceCheckForm";
            this.Text = "LinearExistenceCheckForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pearson;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrelationRatio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Statistics;
        private System.Windows.Forms.DataGridViewTextBoxColumn Criteria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsLinear;
    }
}