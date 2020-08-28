using System;
using DevExpress.XtraReports.UI;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.XtraBars.Localization;

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


            //设置本地化的类
             BarLocalizer.Active = new CastorBarLocalizer();
            SkinHelper.InitSkinGallery(ribbonGalleryBarItem1, true);
            barSubItem2.Caption = "点我选皮肤";
            SkinHelper.InitSkinPopupMenu(barSubItem2);

            //SkinHelper.InitSkinPopupMenu(SkinsLink);
            ////Add skin to combobox
            //foreach (SkinContainer cn in SkinManager.Default.Skins)
            //{
            //    cboSkins.Properties.Items.Add(cn.SkinName);
            //}

        }
        //private void cboSkins_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //Set default look and feel
        //    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(cboSkins.Text);
        //}


        //该类确定本地化的实际工作方式
        public class CastorBarLocalizer : BarLocalizer
        {
            public override string GetLocalizedString(BarString id)
            {
                if (id == BarString.SkinCaptions)
                {
                    string str = base.GetLocalizedString(id);
                    //实现本地化，实际上就是替换字符串
                    return str.Replace("|DevExpress Style|", "|Castor的皮肤|");
                }
                return base.GetLocalizedString(id);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // 创建报表
            ReportTransferPara report = new ReportTransferPara();
            //显示预览
            ReportPrintTool tool = new ReportPrintTool(report);
            tool.ShowPreview();
        }
    }
}
