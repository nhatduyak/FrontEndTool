using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using SGC_Tool.MyControls;
using TOOLChuyenDuLieu;
using TOOLChuyenDuLieu.ControlEntity;
using TOOLChuyenDuLieu.HelpFile;
using System.Data;
using TPMessageBox;

namespace SGC_Tool.CheckSKU_CKTM
{
    public partial class FrmCheckSKU_CKTM : DevExpress.XtraEditors.XtraForm
    {
        public FrmCheckSKU_CKTM()
        {
            InitializeComponent();
        }
        private string _PathFileINVMST;
        private int _filepuge = 100;
        private void BTLoadDS_Click(object sender, EventArgs e)
        {
            WaitingMsg waitingMsg = new WaitingMsg("Chương trình đang load dữ liệu!", "Please Waiting .......");
            try
            {
                if(CopyFileINVMST())
                {
                    if(_PathFileINVMST==string.Empty)
                    {
                        InfoMessage.HienThi("Thong bao",
                                            "Không lấy đữ liệu được ! Vui lòng kiểm tra lại H:\\ hoặc Server 21",
                                            "Lay du lieu khong thanh cong", HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                        return;
                    }
                //_PathFileINVMST = @"C:\WINDOWS\Temp\INVMST.tps";
                    TPSDataAccess access = new TPSDataAccess(_PathFileINVMST);
                    string strsql = string.Format(@"Select SKU,Description,Disc_Flag,0 as Check from INVMST where Disc_Flag='N'");
                    DataTable dt=new DataTable();
                    dt = access.GetDataTable(strsql);
                    GrDSPriceSKU.DataSource = null;
                    if(dt!=null&&dt.Rows.Count>0)
                    {
                        GrDSPriceSKU.DataSource = dt;
                        repositoryItemCheckEdit2.ValueChecked = 1;
                        repositoryItemCheckEdit2.ValueUnchecked = 0;
                    }
                }
                else
                {
                    InfoMessage.HienThi("Thong bao",
                                           "Không lấy đữ liệu được ! Vui lòng kiểm tra lại H:\\ hoặc Server 21",
                                           "Lay du lieu khong thanh cong", HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                    return;
                }
                    waitingMsg.Finish();
                
            }
            catch (Exception exception)
            {

                CTLError.WriteError("btLoadData ", exception.Message);
                waitingMsg.Finish();
                return;
            }
        }
        public bool CopyFileINVMST()
        {
            try
            {
                FileInfo fileInfo = new FileInfo(Path.Combine(Config._pathfileWinDSS, "INVMST.tps"));
                DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\WINDOWS\Temp");
                if (!directoryInfo.Exists)
                    directoryInfo.Create();
                fileInfo.CopyTo(@"C:\WINDOWS\Temp\INVMST.tps", true);
                _PathFileINVMST = @"C:\WINDOWS\Temp\INVMST.tps";
                return true;
            }
            catch (Exception exception)
            {
                CTLError.WriteError(" Loi CopyFileINVMST ", exception.Message);
                return false;
                throw;
            }
        }

        private void BTthoat_Click(object sender, EventArgs e)
        {
            CTLQuanLyForm.formName.Remove(this.Name);
            this.Dispose();
            this.Close();
        }

        private void btexportExcell_Click(object sender, EventArgs e)
        {
            try
            {


                if (gridView1.DataRowCount <= 0)
                {
                    InfoMessage.HienThi("Không có dữ liệu xuất file ", "Vui lòng load dữ liệu", "Thông báo",
                                            HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                    return;
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "*.xls|*.xls";
                saveFileDialog.FileName = "CheckSKU_CKTM" + DateTime.Now.ToString("ddMMyyyy") + ".xls";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GrDSPriceSKU.ExportToXls(saveFileDialog.FileName);
                    InfoMessage.HienThi("Xuất file " + saveFileDialog.FileName + " thành công!!! ", "Export Excell", "Thanh Cong",
                                            HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);
                }

            }
            catch (Exception exception)
            {
                CTLError.WriteError("Export excell file ", exception.Message);
                throw;
            }
        }

        private void BTXuatfile_Click(object sender, EventArgs e)
        {
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "PRCUPD.*|PRCUPD.*";
            //saveFileDialog.FileName = "PRCUPD.001";
            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            try
            {
                if (gridView1.DataRowCount <= 0)
                {
                    InfoMessage.HienThi("Không có dữ liệu export!!!!!", "Vui lòng kiểm tra lại", "Thông báo",
                                        HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                    return;
                }
                gridView1.FocusedRowHandle = -1;
                bool isdata = false;
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    DataRow row = gridView1.GetDataRow(i);
                    if (Convert.ToBoolean(row["Check"]))
                    {
                        isdata = true;
                    }
                }
                if (!isdata)
                {
                    InfoMessage.HienThi("vui lòng chọn dữ liệu export!!!!!", "Vui lòng kiểm tra lại", "Thông báo",
                                        HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                    return;
                }
                CTLSearchBug ctlSearchBug = new CTLSearchBug();
                int iTo = 0;
                int maxP = GetMaxFilePRCUPD();
                if (_filepuge < maxP)
                {
                    _filepuge = maxP + 1;
                }
                if (_filepuge < 999)
                    _filepuge += 1;
                //for (int i = 0; i < gridView1.DataRowCount;)
                //{
                //int numTemp = gridView1.DataRowCount - i;
                //iTo =  numTemp> 100 ? iTo + 100 : iTo + (numTemp);
                DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Path.Combine(Application.StartupPath, "ExportBackup"), DateTime.Now.ToString("yyyyMMddhhmm")));
                if (!directoryInfo.Exists)
                    directoryInfo.Create();
                if (!ExportFile(@"H:\Pollfile"))
                {
                    InfoMessage.HienThi("Conect server không thành công!!!!!", "Vui lòng kiểm tra lại", "Thông báo",
                                    HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                    return;
                }
                ExportFile(directoryInfo.FullName);

                //}
                // Ghi log file khi export
                ctlSearchBug.InsertTraceLog(Config._MaNV, DateTime.Now, GetIP(), "FrmSynPrice", 1, "FrontEnd Utility", "Export PRCUPD file");
                InfoMessage.HienThi("Export file " + " thành công  !!!!!", "Export file", "Thanh cong",
                                        HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);

                return;
            }
            catch (Exception exception)
            {
                CTLError.WriteError("Export file from DSSKU ", exception.Message);
                //ctlSearchBug.InsertTraceLog(Config._MaNV, DateTime.Now, GetIP(), "FrmSynPrice", 0);
                return;
                throw;
            }
        }
        public int GetMaxFilePRCUPD()
        {
            try
            {
                int kq = 0;
                DirectoryInfo directoryInfo = new DirectoryInfo(@"H:\Pollfile");
                foreach (FileInfo f in directoryInfo.GetFiles("PRCUPD.*"))
                {
                    string ex = f.Extension.Replace(".", "");
                    kq = kq > Convert.ToInt32(ex) ? kq : Convert.ToInt32(ex);
                }
                return kq;

            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
        public bool ExportFile(string pathFileExport)
        {
            try
            {
                bool _iscreate = false;
                int dem = 0;

                int fromIndex = 0;
                while (fromIndex < gridView1.DataRowCount)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(@"<ROOT>
<TABLE filename=" + '"' + "INVMST" + '"' + " extension=" + '"' + '"' + @">
<ROWS>
");
                    dem = 0;

                    for (int i = fromIndex; i < gridView1.DataRowCount; i++)
                    {
                        //builder.Append(listbox.Items[i].ToString());
                        DataRow row = gridView1.GetDataRow(i);
                        fromIndex = i;
                        if (!Convert.ToBoolean(row["Check"]))
                            continue;
                        dem++;

                        string item = @"<ROW SKU=" + '"' +
                                        row["SKU"] + '"' +
                                      @">
<COLS>";

                        item += @"
<COL Disc_Flag=" +'"'+
                                'Y'+'"'+ @" />";
                        item +=
        @"
</COLS>
</ROW>
";
                        builder.Append(item);
                        if (dem >= 100)
                            break;
                    }
                    builder.Append(@"</ROWS></TABLE>
</ROOT>");
                    if (dem > 0)
                    {
                        StreamWriter writer = new StreamWriter(Path.Combine(pathFileExport, "PRCUPD." + _filepuge.ToString()), false);
                        writer.Write(builder.ToString());
                        writer.Dispose();
                        writer.Close();
                        _filepuge++;

                    }
                    fromIndex++;
                    //return true;
                }
                return true;

            }
            catch (Exception exception)
            {
                CTLError.WriteError("Export file ", exception.Message);
                return false;
                throw;
            }

        }
        #region getIPlocal

        public string GetIP()
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

        private void FrmCheckSKU_CKTM_FormClosing(object sender, FormClosingEventArgs e)
        {
            CTLQuanLyForm.formName.Remove(this.Name);
        }
    }
}