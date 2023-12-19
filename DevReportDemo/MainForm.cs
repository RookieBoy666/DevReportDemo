using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using DevExpress.XtraNavBar;
using System.Reflection;
using DevExpress.XtraBars.Ribbon;

using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraReports.UI;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraBars.Helpers;
using DevExpress.LookAndFeel;
using DevReportDemo.Helper;

namespace DevReportDemo
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public int menuType = 0;
        public bool restart = false;
        public bool close = false;
        public bool changeuser = false;
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
            UserLookAndFeel.Default.StyleChanged += Default_StyleChanged;
            UserLookAndFeel.Default.SkinName = ConfigHelper.GetConfigVal("ApplicationSkinName");


        }
        private void Default_StyleChanged(object sender, EventArgs e)
        {
            string selectedSkin = UserLookAndFeel.Default.SkinName;
            ConfigHelper.SetConfigVal("ApplicationSkinName", selectedSkin);//保存选择的皮肤
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
        private static bool canCloseFunc(DialogResult parameter)
        {
            return parameter != DialogResult.Cancel;
        }
        private void MainForm_FormClosing(object sender,  FormClosingEventArgs e)
        {
            DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutAction action = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutAction() { Caption = "友情提示", Description = "是否关闭此应用程序?" };
            Predicate<DialogResult> predicate = canCloseFunc;
            DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand command1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand() { Text = "关闭", Result = System.Windows.Forms.DialogResult.Yes };
            DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand command2 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand() { Text = "取消", Result = System.Windows.Forms.DialogResult.No };
            DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand command3 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand() { Text = "重启", Result = System.Windows.Forms.DialogResult.Retry };
            DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand command4 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand() { Text = "切换用户", Result = System.Windows.Forms.DialogResult.Ignore };
            action.Commands.Add(command1);
            action.Commands.Add(command2);
            action.Commands.Add(command3);
            action.Commands.Add(command4);
            FlyoutProperties properties = new FlyoutProperties();
            properties.ButtonSize = new Size(100, 40);
            properties.Style = FlyoutStyle.MessageBox;
            properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            DialogResult result = FlyoutDialog.Show(this, action, properties, predicate);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.close = true;
                e.Cancel = false;
            }
            else if (result == System.Windows.Forms.DialogResult.Retry)
            {
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location, "restart");
                System.Environment.Exit(0);
                //this.restart = true;
                //e.Cancel = false;
            }
            else if (result == System.Windows.Forms.DialogResult.Ignore)
            {
                this.changeuser = true;
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
