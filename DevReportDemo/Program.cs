using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
 
namespace DevReportDemo 
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            BonusSkins.Register();
            SkinManager.EnableFormSkins();



       //     UserLookAndFeel.Default.SetSkinStyle("DevExpress Dark Style");
            //UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");//皮肤主题

            //     | DevExpress Style | Caramel | Money Twins | DevExpress Dark Style| iMaginary

            //| Lilian | Black | Blue | Office 2010 Blue | Office 2010 Black | Office 2010 Silver

            //           | Office 2007 Blue | Office 2007 Black | Officmetre 2007 Silver | Office 2007 Green

            //                  | Office 2007 Pink | Seven | Seven Classic | Darkroom | McSkin | Sharp | Sharp Plus

            //                               | Foggy | Dark Side | Xmas(Blue) | Springtime | Summer | Pumpkin | Valentine | Stardust

            //                                  | Coffee | Glass Oceans | High Contrast | Liquid Sky | London Liquid Sky| The Asphalt World| Blueprint |



            Application.Run(new MainForm());
        }
    }
}
