namespace EmpiricMethods_Lab1.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.CorrelationField = new System.Windows.Forms.TabPage();
            this.StatCharacteristics = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.CorrelationField);
            this.tabControl1.Controls.Add(this.StatCharacteristics);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(976, 473);
            this.tabControl1.TabIndex = 0;
            // 
            // CorrelationField
            // 
            this.CorrelationField.Location = new System.Drawing.Point(4, 25);
            this.CorrelationField.Name = "CorrelationField";
            this.CorrelationField.Padding = new System.Windows.Forms.Padding(3);
            this.CorrelationField.Size = new System.Drawing.Size(968, 444);
            this.CorrelationField.TabIndex = 0;
            this.CorrelationField.Text = "Correlation Field";
            this.CorrelationField.UseVisualStyleBackColor = true;
            // 
            // StatCharacteristics
            // 
            this.StatCharacteristics.Location = new System.Drawing.Point(4, 25);
            this.StatCharacteristics.Name = "StatCharacteristics";
            this.StatCharacteristics.Padding = new System.Windows.Forms.Padding(3);
            this.StatCharacteristics.Size = new System.Drawing.Size(968, 444);
            this.StatCharacteristics.TabIndex = 1;
            this.StatCharacteristics.Text = "Stat Characteristics";
            this.StatCharacteristics.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button1.Location = new System.Drawing.Point(12, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(288, 85);
            this.button1.TabIndex = 1;
            this.button1.Text = "Browse Files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 576);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage CorrelationField;
        private System.Windows.Forms.TabPage StatCharacteristics;
        private System.Windows.Forms.Button button1;
    }
}
