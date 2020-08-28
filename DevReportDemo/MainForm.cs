using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraBars.Helpers;

namespace DevReportDemo
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            SkinHelper.InitSkinPopupMenu(MenuSkin);
        }
    }
}
