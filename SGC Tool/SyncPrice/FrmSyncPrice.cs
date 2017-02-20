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
using SGC_Tool.HelpFile;
using SGC_Tool.MyControls;
using TOOLChuyenDuLieu;
using TOOLChuyenDuLieu.ControlEntity;
using TOOLChuyenDuLieu.HelpFile;
using TPMessageBox;

namespace SGC_Tool.SyncPrice
{
    public partial class FrmSyncPrice : DevExpress.XtraEditors.XtraForm
    {
        DataTable _tbDSGia = new DataTable();
        private string _storeName = "";
        public FrmSyncPrice()
        {
            InitializeComponent();
            initTable();
            //_builder = new StringBuilder();
        }

        private int _filepuge = 100;
        public void initTable()
        {
            _tbDSGia.Columns.Add("Check", Type.GetType("System.Boolean"));
            _tbDSGia.Columns.Add("SKU", Type.GetType("System.String"));
            _tbDSGia.Columns.Add("Description", Type.GetType("System.String"));
            _tbDSGia.Columns.Add("Price", Type.GetType("System.Decimal"));
            _tbDSGia.Columns.Add("PriceMMS", Type.GetType("System.Decimal"));
        }
        private void BTthoat_Click(object sender, EventArgs e)
        {
            CTLQuanLyForm.formName.Remove(this.Name);
            this.Dispose();
            this.Close();
        }
        public string _PathFileINVMST = @"D:\WinDSS\Data\INVMST.tps";
        private void BTHienthi_Click(object sender, EventArgs e)
        {
            WaitingMsg waitingMsg = new WaitingMsg("Chương trình đang load dữ liệu!", "Please Waiting .......");
            try
            {
                _tbDSGia.Clear();
                copyfile(Config._pathfileWinDSS);
                //TPSDataAccess access = new TPSDataAccess(Path.Combine(CTLConfig._pathfileWinDSS, "INVMST"));
                TPSDataAccess access = new TPSDataAccess(_PathFileINVMST);
                TPSDataAccess accessPathWSS = new TPSDataAccess(Path.Combine(Config._pathfileWinDSS,"SYSMST"));
                SQLHelper helper = new SQLHelper(true);
                string MaST = "0";
                MaST = accessPathWSS.getMaSieuthi();
                _storeName = MaST;
                helper.AddParameterToSQLCommand("@STR", SqlDbType.NVarChar, 8);
                helper.SetSQLCommandParameterValue("@STR", MaST);
                if(MaST=="0")
                {
                    InfoMessage.HienThi("Khong lay duoc StoreNumber " + MaST + " ", "Vui long lien he voi quan tri",
                                        "Loi Get StoreNumber", HinhAnhThongBao.LOI, NutThongBao.DONGY);
                    return;
                }
                string strconf = "";
                string strsale = "";
                string strupc = "";
                if (!radConfirAll.Checked)
                {
                    strconf = " and CONF_PRICE=" + (radconfirYes.Checked ? "'Y'" : "'N'");
                    helper.AddParameterToSQLCommand("@ISTYPE", SqlDbType.NVarChar, 8);
                    helper.SetSQLCommandParameterValue("@ISTYPE", (radconfirNo.Checked) ? "01" : "CS");
                }
                if (!radsaleAll.Checked)
                {
                    strsale = " and SELL_UNIT=" + (radsaleEA.Checked ? "'EA'" : "'KG'");
                    helper.AddParameterToSQLCommand("@ISLUM", SqlDbType.NVarChar, 8);
                    helper.SetSQLCommandParameterValue("@ISLUM", (radsaleKG.Checked) ? radsaleKG.Text : radsaleEA.Text);
                }
                if (!radUPCALL.Checked)
                {
                    strupc = " and UPC<>''";
                    helper.AddParameterToSQLCommand("@ISUPC", SqlDbType.NVarChar, 8);
                    helper.SetSQLCommandParameterValue("@ISUPC", 1);
                }
                DataTable dt = helper.GetDatatableBySP("PRLN_spGetPricebyStore");
                string sql = string.Format("Select SKU,Price,Description from INVMST where 1=1 {0}{1}{2} order by SKU", strconf, strsale, strupc);
                DataTable tbg = access.GetDataTable(sql);
                int dem = 0;
                foreach (DataRow dataRow in dt.Rows)
                {
                    decimal p = Convert.ToDecimal(dataRow["PLNITM"].ToString());
                    for (int i = dem; i < tbg.Rows.Count; i++)
                    {

                        decimal pMMS = Convert.ToDecimal(tbg.Rows[i]["SKU"].ToString());
                        if (p == pMMS)
                        {
                            if (Convert.ToDecimal(tbg.Rows[i]["Price"]) != Convert.ToDecimal(dataRow["PLNAMT"].ToString()))
                            {
                                DataRow r = _tbDSGia.NewRow();
                                r["SKU"] = "00" + dataRow["PLNITM"].ToString();
                                r["Check"] = false;
                                r["Description"] = tbg.Rows[i]["Description"].ToString();
                                r["Price"] = Convert.ToDecimal(dataRow["PLNAMT"].ToString());
                                r["PriceMMS"] = Convert.ToDecimal(tbg.Rows[i]["Price"]);
                                _tbDSGia.Rows.Add(r);
                            }
                            dem = i + 1;
                            break;
                        }
                        else if (pMMS > p)
                        {
                            dem = i;
                            break;
                        }
                    }



                }
                GrDSPriceSKU.DataSource = _tbDSGia;
                waitingMsg.Finish();


            }
            catch (Exception exception)
            {
                CTLError.WriteError("btLoadData ", exception.Message);
                waitingMsg.Finish();
                return;
                throw;
            }
        }
        public void copyfile(string path)
        {
            if (path.Contains(@"D:\") || path.Contains(@"d:\"))
            {
                _PathFileINVMST = Path.Combine(path, "INVMST.tps");
                return;
            }

            try
            {
                //FileInfo fINV = new FileInfo(@"C:\WINDOWS\Temp\INVMST.tps");
                //if (fINV.Exists && fINV.LastWriteTime.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"))
                //{
                //    _PathFileINVMST = @"C:\WINDOWS\Temp\INVMST.tps";
                //    return;
                //}
                FileInfo fileInfo = new FileInfo(Path.Combine(Config._pathfileWinDSS, "INVMST.tps"));
                DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\WINDOWS\Temp");
                if (!directoryInfo.Exists)
                    directoryInfo.Create();
                fileInfo.CopyTo(@"C:\WINDOWS\Temp\INVMST.tps", true);
                _PathFileINVMST = @"C:\WINDOWS\Temp\INVMST.tps";
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi copy", ex.Message);
                _PathFileINVMST = Path.Combine(path, "INVMST.tps");
                throw;
            }

        }

        private void FrmSyncPrice_FormClosing(object sender, FormClosingEventArgs e)
        {
            CTLQuanLyForm.formName.Remove(this.Name);
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
                    bool isdata = false;
                    for (int i = 0; i < gridView1.DataRowCount; i++)
                    {
                        DataRow row = gridView1.GetDataRow(i);
                        if(Convert.ToBoolean(row["Check"]))
                        {
                            isdata = true;
                        }
                    }
                    if(!isdata)
                    {
                        InfoMessage.HienThi("vui lòng chọn dữ liệu export!!!!!", "Vui lòng kiểm tra lại", "Thông báo",
                                            HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                        return;
                    }
                    CTLSearchBug ctlSearchBug = new CTLSearchBug();
                    int iTo = 0;
                    int maxP = GetMaxFilePRCUPD();
                    if(_filepuge<maxP)
                    {
                        _filepuge = maxP + 1;
                    }
                    if (_filepuge < 999)
                        _filepuge += 1;
                    //for (int i = 0; i < gridView1.DataRowCount;)
                    //{
                        //int numTemp = gridView1.DataRowCount - i;
                        //iTo =  numTemp> 100 ? iTo + 100 : iTo + (numTemp);
                        DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Path.Combine(Application.StartupPath, "ExportBackup"),DateTime.Now.ToString("yyyyMMddhhmm")));
                        if (!directoryInfo.Exists)
                            directoryInfo.Create();
                        if(!ExportFile(@"H:\Pollfile"))
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

            //}
        }
        public bool ExportFile(string pathFileExport)
        {
            try
            {
                bool _iscreate = false;
                int dem = 0;
                
                int fromIndex = 0;
                while (fromIndex<gridView1.DataRowCount)
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
<COL PRICE=" +
                                '"' + Convert.ToInt64(row["Price"]) + '"' + @" />";
                        item += @"
<COL CURRENCYCODE=" +
                                    '"' + "VND" + '"' + @" />";
                        item += @"
<COL PRICEBOOK=" +
                                    '"' + "RET" + '"' + @" />";

                        item +=
        @"
</COLS>
</ROW>
";
                        builder.Append(item);
                        if(dem>=100)
                            break;
                    }
                    builder.Append(@"</ROWS></TABLE>
</ROOT>");
                    if(dem>0)
                    {
                        StreamWriter writer = new StreamWriter(Path.Combine(pathFileExport,"PRCUPD."+_filepuge.ToString()), false);
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
        public int GetMaxFilePRCUPD()
        {
            try
            {   
                int kq = 0;
                DirectoryInfo directoryInfo = new DirectoryInfo(@"H:\Pollfile");
                foreach (FileInfo f in directoryInfo.GetFiles("PRCUPD.*"))
                {
                    string ex=f.Extension.Replace(".","");
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

        private void btexportExcell_Click(object sender, EventArgs e)
        {
            try
            {
                

                if(gridView1.DataRowCount<=0)
                {
                    InfoMessage.HienThi("Không có dữ liệu xuất file ", "Vui lòng load dữ liệu","Thông báo",
                                            HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                    return;
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "*.xls|*.xls";
                saveFileDialog.FileName = "SynPrice" + _storeName + DateTime.Now.ToString("ddMMyyyy") + ".xls";
                if(saveFileDialog.ShowDialog()==DialogResult.OK)
                {
                    GrDSPriceSKU.ExportToXls(saveFileDialog.FileName);
                    InfoMessage.HienThi("Xuất file "+saveFileDialog.FileName+" thành công!!! ","Export Excell", "Thanh Cong",
                                            HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);
                }
                
            }
            catch (Exception exception)
            {
                CTLError.WriteError("Export excell file ", exception.Message);
                throw;
            }
            
        }
    }
}