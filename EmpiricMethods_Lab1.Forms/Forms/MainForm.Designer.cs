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
            this.CorrelationCoefficients = new System.Windows.Forms.TabPage();
            this.LinearCorrelationExistence = new System.Windows.Forms.TabPage();
            this.OneDimensionalLinearRegression = new System.Windows.Forms.TabPage();
            this.MultiDimensionalRegression = new System.Windows.Forms.TabPage();
            this.BalancesDiagram = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.CorrelationField);
            this.tabControl1.Controls.Add(this.StatCharacteristics);
            this.tabControl1.Controls.Add(this.CorrelationCoefficients);
            this.tabControl1.Controls.Add(this.LinearCorrelationExistence);
            this.tabControl1.Controls.Add(this.OneDimensionalLinearRegression);
            this.tabControl1.Controls.Add(this.MultiDimensionalRegression);
            this.tabControl1.Controls.Add(this.BalancesDiagram);
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
            // CorrelationCoefficients
            // 
            this.CorrelationCoefficients.Location = new System.Drawing.Point(4, 25);
            this.CorrelationCoefficients.Name = "CorrelationCoefficients";
            this.CorrelationCoefficients.Padding = new System.Windows.Forms.Padding(3);
            this.CorrelationCoefficients.Size = new System.Drawing.Size(968, 444);
            this.CorrelationCoefficients.TabIndex = 2;
            this.CorrelationCoefficients.Text = "Correlation Coefficients";
            this.CorrelationCoefficients.UseVisualStyleBackColor = true;
            // 
            // LinearCorrelationExistence
            // 
            this.LinearCorrelationExistence.Location = new System.Drawing.Point(4, 25);
            this.LinearCorrelationExistence.Name = "LinearCorrelationExistence";
            this.LinearCorrelationExistence.Size = new System.Drawing.Size(968, 444);
            this.LinearCorrelationExistence.TabIndex = 3;
            this.LinearCorrelationExistence.Text = "Linear Correlation Existence";
            this.LinearCorrelationExistence.UseVisualStyleBackColor = true;
            // 
            // OneDimensionalLinearRegression
            // 
            this.OneDimensionalLinearRegression.Location = new System.Drawing.Point(4, 25);
            this.OneDimensionalLinearRegression.Name = "OneDimensionalLinearRegression";
            this.OneDimensionalLinearRegression.Size = new System.Drawing.Size(968, 444);
            this.OneDimensionalLinearRegression.TabIndex = 4;
            this.OneDimensionalLinearRegression.Text = "One Dimensional Linear Regression";
            this.OneDimensionalLinearRegression.UseVisualStyleBackColor = true;
            // 
            // MultiDimensionalRegression
            // 
            this.MultiDimensionalRegression.Location = new System.Drawing.Point(4, 25);
            this.MultiDimensionalRegression.Name = "MultiDimensionalRegression";
            this.MultiDimensionalRegression.Padding = new System.Windows.Forms.Padding(3);
            this.MultiDimensionalRegression.Size = new System.Drawing.Size(968, 444);
            this.MultiDimensionalRegression.TabIndex = 5;
            this.MultiDimensionalRegression.Text = "Multi Dimensional Regression";
            this.MultiDimensionalRegression.UseVisualStyleBackColor = true;
            // 
            // BalancesDiagram
            // 
            this.BalancesDiagram.Location = new System.Drawing.Point(4, 25);
            this.BalancesDiagram.Name = "BalancesDiagram";
            this.BalancesDiagram.Padding = new System.Windows.Forms.Padding(3);
            this.BalancesDiagram.Size = new System.Drawing.Size(968, 444);
            this.BalancesDiagram.TabIndex = 6;
            this.BalancesDiagram.Text = "Balances Diagram";
            this.BalancesDiagram.UseVisualStyleBackColor = true;
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
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button2.Location = new System.Drawing.Point(678, 479);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(288, 85);
            this.button2.TabIndex = 2;
            this.button2.Text = "Load Autompg";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numericUpDown1.Location = new System.Drawing.Point(581, 479);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(91, 30);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(327, 481);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dependent Source Index:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 576);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage CorrelationField;
        private System.Windows.Forms.TabPage StatCharacteristics;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage CorrelationCoefficients;
        private System.Windows.Forms.TabPage LinearCorrelationExistence;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage OneDimensionalLinearRegression;
        private System.Windows.Forms.TabPage MultiDimensionalRegression;
        private System.Windows.Forms.TabPage BalancesDiagram;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}
