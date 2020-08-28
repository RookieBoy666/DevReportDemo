using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
namespace DevReportDemo
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // 创建报表
            Report report = new Report();
            //显示预览
            ReportPrintTool tool = new ReportPrintTool(report);
            tool.ShowPreview();
        }

        private void print_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            ReportPrintTool tl = new ReportPrintTool(report);
            //打印
            tl.Print();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            ReportDesignTool tool = new ReportDesignTool(report);
            //设计报表
            tool.ShowDesignerDialog();

        }
    }
}
