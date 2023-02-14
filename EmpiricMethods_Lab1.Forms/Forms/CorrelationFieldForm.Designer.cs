namespace EmpiricMethods_Lab1.Forms.Forms
{
    partial class CorrelationFieldForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.CorrelationFieldChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.CorrelationFieldChart)).BeginInit();
            this.SuspendLayout();
            // 
            // CorrelationFieldChart
            // 
            chartArea1.Name = "ChartArea1";
            this.CorrelationFieldChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.CorrelationFieldChart.Legends.Add(legend1);
            this.CorrelationFieldChart.Location = new System.Drawing.Point(0, 0);
            this.CorrelationFieldChart.Name = "CorrelationFieldChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Correlation Field";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.CorrelationFieldChart.Series.Add(series1);
            this.CorrelationFieldChart.Size = new System.Drawing.Size(973, 451);
            this.CorrelationFieldChart.TabIndex = 0;
            this.CorrelationFieldChart.Text = "chart1";
            // 
            // CorrelationFieldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 450);
            this.Controls.Add(this.CorrelationFieldChart);
            this.Name = "CorrelationFieldForm";
            this.Text = "CorrelationFieldForm";
            this.Load += new System.EventHandler(this.CorrelationFieldForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CorrelationFieldChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart CorrelationFieldChart;
    }
}