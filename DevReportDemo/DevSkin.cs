﻿using System;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;

namespace DevReportDemo
{
    public partial class barSubItem1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public barSubItem1()
        {
            InitializeComponent();
        }

        private void DevSkin_Load(object sender, EventArgs e)
        {
            //设置本地化的类
            BarLocalizer.Active = new CastorBarLocalizer();
            SkinHelper.InitSkinGallery(ribbonGalleryBarItem1, true);
            barSubItem2.Caption = "点我选皮肤";
            SkinHelper.InitSkinPopupMenu(barSubItem2);

        }
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
    }
}