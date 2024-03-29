﻿namespace EmpiricMethods_Lab1.Forms.Forms
{
    partial class CorrelationCoefficientForm
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
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coefficient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Interval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Criteria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Statistics = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSignificant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactExists = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Title,
            this.Coefficient,
            this.Interval,
            this.Criteria,
            this.Statistics,
            this.IsSignificant,
            this.ContactExists});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(975, 451);
            this.dataGridView1.TabIndex = 0;
            // 
            // Title
            // 
            this.Title.HeaderText = "Name";
            this.Title.MinimumWidth = 6;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Coefficient
            // 
            this.Coefficient.HeaderText = "Coefficient";
            this.Coefficient.MinimumWidth = 6;
            this.Coefficient.Name = "Coefficient";
            this.Coefficient.ReadOnly = true;
            // 
            // Interval
            // 
            this.Interval.HeaderText = "Interval";
            this.Interval.MinimumWidth = 6;
            this.Interval.Name = "Interval";
            this.Interval.ReadOnly = true;
            // 
            // Criteria
            // 
            this.Criteria.HeaderText = "Criteria";
            this.Criteria.MinimumWidth = 6;
            this.Criteria.Name = "Criteria";
            this.Criteria.ReadOnly = true;
            // 
            // Statistics
            // 
            this.Statistics.HeaderText = "Statistics";
            this.Statistics.MinimumWidth = 6;
            this.Statistics.Name = "Statistics";
            this.Statistics.ReadOnly = true;
            // 
            // IsSignificant
            // 
            this.IsSignificant.HeaderText = "Significant/Insignificant";
            this.IsSignificant.MinimumWidth = 6;
            this.IsSignificant.Name = "IsSignificant";
            this.IsSignificant.ReadOnly = true;
            // 
            // ContactExists
            // 
            this.ContactExists.HeaderText = "Contact Exists";
            this.ContactExists.MinimumWidth = 6;
            this.ContactExists.Name = "ContactExists";
            this.ContactExists.ReadOnly = true;
            // 
            // CorrelationCoefficientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CorrelationCoefficientForm";
            this.Text = "CorrelationCoefficient";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coefficient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Interval;
        private System.Windows.Forms.DataGridViewTextBoxColumn Criteria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Statistics;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsSignificant;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactExists;
    }
}