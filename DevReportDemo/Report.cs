using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DevReportDemo
{
    public partial class Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Report()
        {
            InitializeComponent();
        }

        private void xrLabel6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
