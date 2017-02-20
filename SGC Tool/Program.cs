using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SGC_Tool.CheckSKU_CKTM;
using SGC_Tool.FrmDonDatHang;
using TOOLChuyenDuLieu;
using TOOLChuyenDuLieu.ControlEntity;
using TOOLChuyenDuLieu.MyForm.CheckPrice;
using TPMessageBox;
using TOOLChuyenDuLieu.HelpFile;
using System.Drawing;
using SGC_Tool.FrmBangbaoGia;
namespace SGC_Tool
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
            SplashScreen.SetTitleString("FrontEnd Utility !!!");
            SplashScreen.SetCommentaryString("Khởi tạo chương trình  .......");
            SplashScreen.SetBackgroundImage(Image.FromFile(Path.Combine(Application.StartupPath, "Image.png")));
            SplashScreen.BeginDisplay();
            if(!Config.CheckConfig())
            {
                InfoMessage.HienThi("Vui lòng liên hệ với vi tính để config database!", "Chưa config database",
                                    "Thong bao", HinhAnhThongBao.LOI, NutThongBao.DONGY);
                return;
            }
            SplashScreen.SetCommentaryString("lấy cấu hình.......");
            Config.GetConfiguration();

            Config.LayCauHinh();
            SplashScreen.SetCommentaryString("Kiểm tra version.......");
            Config.CheckVersion();
            SplashScreen.EndDisplay();
            Application.Run(new MainForm());
            SplashScreen.EndDisplay();
            //Application.Run(new FrmTest());
            //SplashScreen.EndDisplay();
            //Application.Run(new FrmScaleAdappterTool.FrmScaleAddTool());
        }
    }
}
