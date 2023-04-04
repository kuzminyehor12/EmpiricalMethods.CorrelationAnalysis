using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace EmpiricMethods_Lab1.Forms.Extensions
{
    public static class ChartZoomer
    {
        public static void AllowZooming(this Chart chart)
        {
            ChartArea chartArea = chart.ChartAreas[0];
            chartArea.AxisX.ScaleView.Zoomable = true;
            chartArea.CursorX.AutoScroll = true;
            chartArea.CursorX.IsUserSelectionEnabled = true;
            chartArea.CursorX.Interval = 0.01;

            chartArea.AxisY.ScaleView.Zoomable = true;
            chartArea.CursorY.AutoScroll = true;
            chartArea.CursorY.IsUserSelectionEnabled = true;
        }
    }
}
