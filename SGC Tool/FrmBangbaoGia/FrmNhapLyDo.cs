using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TOOLChuyenDuLieu.ControlEntity;
using TPMessageBox;

namespace SGC_Tool.FrmBangbaoGia
{
    public partial class FrmNhapLyDo : DevExpress.XtraEditors.XtraForm
    {
        public FrmNhapLyDo()
        {
            InitializeComponent();
        }

        public bool _isdongy=false;
        #region xu ly su kien
        private void button1_Click(object sender, EventArgs e)
        {
            if(txtlydo.Text==string.Empty)
            {
                InfoMessage.HienThi("Vui lòng nhập lý do xuất file", "Xuất file excel", "Thong bao",
                                    HinhAnhThongBao.LOCK, NutThongBao.DONGY);
                return;
            }
            checkPath();
            WriteLogfile("ExpL", "", txtlydo.Text);
            _isdongy = true;
            this.Close();
        }

        #endregion

        #region các hàm hỗ trợ

        public static bool WriteLogfile(string file_name, string Title,string lydo)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(Path.Combine(Path.Combine(Path.Combine(Application.StartupPath, "ExpCust"),DateTime.Now.ToString("MMyyyy")), file_name));
                if (!fileInfo.Exists)
                    fileInfo.Create();
                FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.Append);
                StreamWriter writer = new StreamWriter(fileStream);
                writer.WriteLine("");
                writer.WriteLine("");
                writer.WriteLine("");
                writer.WriteLine("");
                writer.WriteLine("-------------------------" + DateTime.Now + "---------------------------------");
                writer.WriteLine(Title);
                string ip = GetIP();
                writer.WriteLine(Config._MaNV+"-"+ip);
                writer.WriteLine(lydo);
                writer.Dispose();
                writer.Close();
                fileStream.Dispose();
                fileStream.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        public void checkPath()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Application.StartupPath , "ExpCust"));
            if(!directoryInfo.Exists)
                directoryInfo.Create();
            DirectoryInfo folMonth=new DirectoryInfo(Path.Combine(directoryInfo.FullName,DateTime.Now.ToString("MMyyyy")));
            if(!folMonth.Exists)
                folMonth.Create();
        }
        public static string GetIP()
        {
            try
            {
                IPHostEntry host;
                string localIP = "";
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();
                    }
                }
                return localIP;

            }
            catch (Exception exception)
            {
                CTLError.WriteError("getIP", exception.Message);
                return "";
                throw;
            }
        }
        #endregion

        private void FrmNhapLyDo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                button1_Click(null, null);
            }
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }
    }
}