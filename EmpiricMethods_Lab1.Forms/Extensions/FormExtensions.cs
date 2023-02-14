using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmpiricMethods_Lab1.Forms.Extensions
{
    public static class FormExtensions
    {
        public static void AddToTabPage(this Form form, TabControl tabControl, int pageIndex)
        {
            form.TopLevel = false;
            form.Visible = true;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            tabControl.TabPages[pageIndex].Controls.Add(form);
        }
    }
}
