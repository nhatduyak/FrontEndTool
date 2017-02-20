using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32.SafeHandles;
using SGC_Tool.MyControls;
using TOOLChuyenDuLieu;
using TOOLChuyenDuLieu.ControlEntity;
using TPMessageBox;

namespace SGC_Tool.CheckFileT
{
    public partial class FrmCheckFileT : DevExpress.XtraEditors.XtraForm
    {
        public string _Store = "";
        public FrmCheckFileT()
        {
            InitializeComponent();
            Ngay.Value = DateTime.Now.AddDays(-1);
            string ip = LocalIPAddress();
            //if(ip.Substring(ip.Length-3,3)==".21"&&ip.Substring(0,3)=="10.")
            //{
            //    BTcheckFileT.Enabled = true;
            //}
            //else
            //{
            //    labthongbao.Visible = true;
            //}
            BTcheckFileT.Enabled = true;
        }
        public string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CTLQuanLyForm.formName.Remove(this.Name);
            this.Dispose();
            this.Close();
        }

        private void BTcheckFileT_Click(object sender, EventArgs e)
        {
            if(validateForm())
            {
                try
                {
                    panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = false;
                    TPSDataAccess accessPathWSS = new TPSDataAccess(Path.Combine(Config._pathfileWinDSS,"SYSMST"));
                    string MaST = "0";
                    MaST = accessPathWSS.getMaSieuthi();
                    if(MaST=="0")
                    {
                        InfoMessage.HienThi("Khong lay Duoc Store ...,Vui long lien he voi Admin", "Loi ", "Thong bao",
                                            HinhAnhThongBao.LOI, NutThongBao.DONGY);
                        return;
                    }
                    NetworkShareAccesser.Access("10.10.1.23", "synback", "synsgcoop");
                    string strStore = "000" + MaST;
                    strStore = strStore.Substring(strStore.Length - 5, 5);
                    _Store = strStore;
                    FileInfo f = new FileInfo(@"\\10.10.1.23\QDLS\MM770FLR\"+"A"+strStore+@"\T1"+Ngay.Value.ToString("dd")+".001");
                    FileInfo fthumuc0 = new FileInfo(@"\\10.10.1.23\QDLS\MM770FLR\"+strStore+@"\T1"+Ngay.Value.ToString("yyMMdd")+".001");
                    DateTime datemodify = f.LastWriteTime;
                    if(f.Exists && datemodify.Month==Ngay.Value.Month)
                    {
                        panel2.Visible = true;
                    }
                    else if(fthumuc0.Exists)
                    {
                        panel1.Visible = true;
                    }
                    else
                    {
                        panel3.Visible = true;
                    }

                }
                catch (Exception)
                {
                    
                    throw;
                }
                
            }
        }
        public bool validateForm()
        {
            try
            {
                errorProvider1.Clear();
                if(Ngay.Value>=DateTime.Now&&Ngay.Value<=DateTime.Now.AddDays(-8))
                {
                    errorProvider1.SetError(Ngay,"Ngày hợp lệ "+DateTime.Now.AddDays(-8).ToString("dd/MM/yyyy")+" --> "+DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy"));
                    return false;
                }
                return true;
            }
            catch (Exception exception)
            {
                CTLError.WriteError(" Loi validate form CheckFileT ", exception.Message);
                return false;
                throw;
            }
        }
        public bool validateFileT(string fileName)
        {
            try
            {
                errorProvider1.Clear();
                if (fileName.Substring(2, 6) != Ngay.Value.ToString("yyMMdd"))
                {
                    errorProvider1.SetError(textBox1,"File Khong hop le vui long kiem tra lai ngay upload !");
                    return false;
                }
                    
                return true;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi ValidateFile T ", ex.Message);
                return false;
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog=new OpenFileDialog();
            openFileDialog.Filter = "*.001|*.001";
            if(openFileDialog.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo f = new FileInfo(textBox1.Text);
                if (f.Exists && validateFileT(f.Name))
                {
                    if (_Store != "")
                    {
                        FileInfo fthumuc0 = new FileInfo(@"\\10.10.1.23\QDLS\MM770FLR\" + _Store + @"\T1" + Ngay.Value.ToString("yyMMdd") + ".001");
                        if (!fthumuc0.Exists)
                        {
                            f.CopyTo(fthumuc0.FullName);
                            if(GoiEmailNhomWinDSS(f.Name))
                                InfoMessage.HienThi("Upload File Thanh Cong !!!", "Upload file....", "Thanh Cong",
                                                HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);
                        }
                        else
                        {
                            InfoMessage.HienThi("File "+fthumuc0.Name+" Da Ton tai,Vui long kiem tra lai !!!", "Upload file....", "Thong Bao",
                                                HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi Khi Upload File T ", ex.Message);
                InfoMessage.HienThi("Vui long lien he voi admin ", "Loi Khi upload file...", "Loi", HinhAnhThongBao.LOI,
                                    NutThongBao.DONGY);
                return;
                throw;
            }
            
        }
        public bool GoiEmailNhomWinDSS(string filenaem)
        {
            try
            {
                try
                {
                    SmtpClient emailClient1 = new SmtpClient("10.10.15.61", 25);
                    System.Net.NetworkCredential SMTPUserInfo1 = new System.Net.NetworkCredential("duy-npn@saigonco-op.com.vn", "@Nhnhatduy25");
                    emailClient1.UseDefaultCredentials = false;
                    MailAddress FromMail1 = new MailAddress("duy-npn@saigonco-op.com.vn", "Bao Cao Upload File T");
                    //emailClient.EnableSsl = true;
                    emailClient1.Credentials = SMTPUserInfo1;
                    //MailAddress FromMail1 = new MailAddress(CTLConfig._UserEmail, "IT SGC WinDSS");
                    MailMessage message1 = new MailMessage(FromMail1, new MailAddress("duy-npn@saigonco-op.com.vn"));
                    message1.Subject = "Thông báo V/v upload File T strore " + _Store + " ngay " + Ngay.Value.ToString("dd-MM-yyyy");
                    message1.To.Add("Hieu-tt@saigonco-op.com.vn");
                    message1.To.Add("trung-nq@saigonco-op.com.vn");
                    message1.To.Add("phong-hv@saigonco-op.com.vn");

                    message1.Body = "Thông báo V/v upload File T strore " + _Store + " ngay " + Ngay.Value.ToString("dd-MM-yyyy hh:mm:ss")+" file "+filenaem;
                    //System.Net.Mail.Attachment attachment;
                    //attachment = new System.Net.Mail.Attachment(Path.Combine(Application.StartupPath, DateTime.Now.AddDays(-1).ToString("dd-MM-yyyy") + "_BaoCao.csv"));
                    //message1.Attachments.Add(attachment);
                    emailClient1.Send(message1);
                    return true;
                }
                catch (Exception)
                {
                    SmtpClient emailClient1 = new SmtpClient("10.10.15.61", 25);
                    System.Net.NetworkCredential SMTPUserInfo1 = new System.Net.NetworkCredential("duy-npn@saigonco-op.com.vn", "@Nhnhatduy1");
                    emailClient1.UseDefaultCredentials = false;
                    MailAddress FromMail1 = new MailAddress("duy-npn@saigonco-op.com.vn", "Bao Cao Upload File T");
                    //emailClient.EnableSsl = true;
                    emailClient1.Credentials = SMTPUserInfo1;
                    //MailAddress FromMail1 = new MailAddress(CTLConfig._UserEmail, "IT SGC WinDSS");
                    MailMessage message1 = new MailMessage(FromMail1, new MailAddress("duy-npn@saigonco-op.com.vn"));
                    message1.Subject = "Thông báo V/v upload File T strore " + _Store + " ngay " + Ngay.Value.ToString("dd-MM-yyyy hh:mm:ss") + " file " + filenaem;
                    message1.To.Add("Hieu-tt@saigonco-op.com.vn");
                    message1.To.Add("trung-nq@saigonco-op.com.vn");
                    message1.To.Add("phong-hv@saigonco-op.com.vn");

                    message1.Body = "Thông báo V/v upload File T strore " + _Store + " ngay " + Ngay.Value.ToString("dd-MM-yyyy");
                    //System.Net.Mail.Attachment attachment;
                    //attachment = new System.Net.Mail.Attachment(Path.Combine(Application.StartupPath, DateTime.Now.AddDays(-1).ToString("dd-MM-yyyy") + "_BaoCao.csv"));
                    //message1.Attachments.Add(attachment);
                    emailClient1.Send(message1);
                    return true;
                    
                }
               
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi Khi Goi Email nhom WinDSS ", ex.Message);
                InfoMessage.HienThi("Vui long lien he voi voi Nhom WinDSS (Ex : 1081) ",
                                    "Loi Khi Goi Email nhom WDSS...", "Loi", HinhAnhThongBao.LOI, NutThongBao.DONGY);
                return false;
                throw;
            }
        }
        
    }
}