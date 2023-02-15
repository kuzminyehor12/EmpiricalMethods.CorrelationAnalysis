namespace EmpiricMethods_Lab1.Forms.Forms
{
    partial class StatCharacteristicsForm
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
            this.XSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XSourceInterval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YSourceInterval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.XSource,
            this.YSource,
            this.XSourceInterval,
            this.YSourceInterval});
            this.dataGridView1.Location = new System.Drawing.Point(1, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(939, 452);
            this.dataGridView1.TabIndex = 0;
            // 
            // XSource
            // 
            this.XSource.HeaderText = "XSource";
            this.XSource.MinimumWidth = 6;
            this.XSource.Name = "XSource";
            this.XSource.ReadOnly = true;
            // 
            // YSource
            // 
            this.YSource.HeaderText = "YSource";
            this.YSource.MinimumWidth = 6;
            this.YSource.Name = "YSource";
            this.YSource.ReadOnly = true;
            // 
            // XSourceInterval
            // 
            this.XSourceInterval.HeaderText = "XSource Interval";
            this.XSourceInterval.MinimumWidth = 6;
            this.XSourceInterval.Name = "XSourceInterval";
            this.XSourceInterval.ReadOnly = true;
            // 
            // YSourceInterval
            // 
            this.YSourceInterval.HeaderText = "YSource Interval";
            this.YSourceInterval.MinimumWidth = 6;
            this.YSourceInterval.Name = "YSourceInterval";
            this.YSourceInterval.ReadOnly = true;
            // 
            // StatCharacteristicsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 455);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StatCharacteristicsForm";
            this.Text = "StatCharacteristicsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn XSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn YSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn XSourceInterval;
        private System.Windows.Forms.DataGridViewTextBoxColumn YSourceInterval;
    }
}