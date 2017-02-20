using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraGrid.Views.Grid;
using SGC_Tool.MyControls;
using TOOLChuyenDuLieu;
using TOOLChuyenDuLieu.ControlEntity;
using TOOLChuyenDuLieu.HelpFile;
using TPMessageBox;
using SGC_Tool.HelpFile;

namespace SGC_Tool.FrmScaleAdappterTool
{
    public partial class FrmScaleAddTool : DevExpress.XtraEditors.XtraForm
    {
        #region Skin
        //public DefaultLookAndFeel Skin = new DefaultLookAndFeel();
        #endregion
        public string _PathFileINVMST ="";
        DataTable _tableDSSku=new DataTable();
        System.Data.Odbc.OdbcDataAdapter obj_oledb_da;
        private string[] _list_SKU;
        
        #region ham khoi tao

        public FrmScaleAddTool()
        {
            InitializeComponent();
            //BonusSkins.Register();
            //OfficeSkins.Register();
            //SkinManager.EnableFormSkins();
            //this.Skin.LookAndFeel.SetSkinStyle("Money Twins");
            //buttonEdit1.Text = _PathFileINVMST;
            Config.GetConfiguration();
            if (Config._pathfileWinDSS!=null)
                _PathFileINVMST = Path.Combine(Config._pathfileWinDSS,"INVMST.TPS");
            CheckMa.ValueChecked = 1;
            CheckMa.ValueUnchecked = 0;
            FileInfo file = new FileInfo(Path.Combine(Application.StartupPath, "DSLoaiBo.csv"));
            if (file.Exists)
            {
                writeSchema();
                _tableDSSku=ConnectCSV("DSLoaiBo.csv");	
            }
            if(Config._loaican=="0")
            {
                labhandung.Text = "Định nghĩa hạn sử dụng cho cân Bizerba";
                labhd1.Text = "Không in hạn sử dụng --> 0";
                labHD2.Text = "Hạn sử dụng trong ngày --> 900";
                labHD3.Text = "Hạn sử dụng N ngày --> N-1 (vd: 3 ngày-->2 )";
            }
            else if(Config._loaican=="2")
            {
                labhandung.Text = "Định nghĩa hạn sử dụng cho cân Mettle toltdo";
                labhd1.Text = "Không in hạn sử dụng --> 0";
                labHD2.Text = "Hạn sử dụng trong ngày --> 1";
                labHD3.Text = "Hạn sử dụng N ngày --> N (vd: 3 ngày-->3 )";
            }
            else if (Config._loaican == "1")
            {
                labhandung.Text = "Định nghĩa hạn sử dụng cho cân Bizerba hard lock";
                labhd1.Text = "Không in hạn sử dụng --> 0";
                labHD2.Text = "Hạn sử dụng trong ngày --> 900";
                labHD3.Text = "Hạn sử dụng N ngày --> N-1 (vd: 3 ngày-->2 )";
            }
            
        }
        #endregion

        #region xu ly xu kien tren form

        private void BTthoat_Click(object sender, EventArgs e)
        {
            CTLQuanLyForm.formName.Remove(this.Name);
            this.Dispose();
            this.Close();
        }
        public void copyfile(string path)
        {
            if (path.Contains(@"D:\") || path.Contains(@"d:\"))
                _PathFileINVMST= Path.Combine(path,"INVMST.tps");
            try
            {
                FileInfo fileInfo = new FileInfo(Path.Combine(Config._pathfileWinDSS, "INVMST.tps"));
                DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\WINDOWS\Temp");
                if (!directoryInfo.Exists)
                    directoryInfo.Create();
                fileInfo.CopyTo(@"C:\WINDOWS\Temp\INVMST.tps", true);
                _PathFileINVMST= @"C:\WINDOWS\Temp\INVMST.tps";
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi copy", ex.Message);
                _PathFileINVMST= Path.Combine(path, "INVMST.tps");
                throw;
            }
            
        }
        private void BTHienthi_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            WaitingMsg waitingMsg = new WaitingMsg("Chương trình đang load dữ liệu!", "Waiting .......");
            try
            {
                copyfile(Config._pathfileWinDSS);
                TPSDataAccess dataAccess = new TPSDataAccess(_PathFileINVMST);
                //TPSDataAccess dataAccess = new TPSDataAccess(_PathFileINVMST);
                dataTable = dataAccess.GetTableDM(0);
                CreateTableHanDung();
               
                 if(!LoadhanDung(ref dataTable))
                {
                    InfoMessage.HienThi("Không lấy được hạn dùng Từ Server KHTT", "Vui lòng liên hệ với quản trị", "Thong Bao", HinhAnhThongBao.LOI, NutThongBao.DONGY);
                    return;
                }
                if(_list_SKU!=null)
                    if(_list_SKU.Length>0)
                    {
                        string sql = "SKU in (";
                        foreach (string ma in _list_SKU)
                        {
                            sql += "'" + ma + "',";
                        }
                        DataRow[] arow = null;
                        if (sql != "SKU in (")
                        {
                            sql = sql.Remove(sql.Length - 1, 1) + ")";
                            arow = dataTable.Select(sql);
                        }

                        if (arow != null)
                        {
                            foreach (DataRow dataRow in arow)
                            {
                                dataRow["Check"] = 1;
                                dataRow.AcceptChanges();
                            }
                        }
                    }
                GridDSMa.DataSource = dataTable;
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    gridView1.GetDataRow(i).AcceptChanges();
                }
                locPLU.Visible = true;
                LuuPLU.Visible = true;
                waitingMsg.Finish();
            }
            catch (Exception exception)
            {
                CTLError.WriteError("FrmMain HienthiClick", exception.Message);
                waitingMsg.Finish();
                return;
                throw new Exception(exception.Message);
            }
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog=new OpenFileDialog();
            openFileDialog.Title = "Chọn file dữ liệu";
            openFileDialog.Filter = "file TPS|*.TPS";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _PathFileINVMST = openFileDialog.FileName;
                //buttonEdit1.Text = openFileDialog.FileName;
            }
        }

        private void BTDSSKULoaiBo_Click(object sender, EventArgs e)
        {
            FrmImportfile dssku = new FrmImportfile(_tableDSSku);
            dssku.Dongy+=new FrmImportfile.DSSKU(LayDSLoaiBoSKU);
            dssku.ShowDialog();
        }

        private void BTXuatfile_Click(object sender, EventArgs e)
        {
            //if(GridDSMa.DataSource==null)
            //{
            //    InfoMessage.HienThi("Không có dữ liệu xuất ra cân!Vui lòng kiểm tra lại", "Thông báo",
            //                        "Xuất dữ liệu ra cân", HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
            //    return;
            //}
            //if(((DataTable)GridDSMa.DataSource).Rows.Count<=0)
            //{
            //    InfoMessage.HienThi("Không có dữ liệu xuất ra cân!Vui lòng kiểm tra lại", "Thông báo",
            //                       "Xuất dữ liệu ra cân", HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
            //    return;
            //}
            //CTLSearchBug ctlSearchBug=new CTLSearchBug();
            if (_isLocTheoDMGoc)
            {
                FrmThongBaoExport thongBaoExport=new FrmThongBaoExport();
                thongBaoExport.bt_xuattoanDS=new FrmThongBaoExport.isxuattoanbods(ClearCheckList);
                thongBaoExport.ShowDialog();
                if(thongBaoExport._isThoat)
                {
                    return;
                }
            }
            gridView1.FocusedRowHandle = -1;
            try
            {
                

                SaveFileDialog saveFileDialogCSV = new SaveFileDialog();
                saveFileDialogCSV.InitialDirectory = Application.ExecutablePath.ToString();

                saveFileDialogCSV.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialogCSV.FilterIndex = 1;
                saveFileDialogCSV.RestoreDirectory = true;
                saveFileDialogCSV.FileName = "SaigonCoopPLU";
                if (saveFileDialogCSV.ShowDialog() == DialogResult.OK)
                {
                    if (GridDSMa.DataSource != null)
                    // Runs the export operation if the given filenam is valid.
                    {
                        if (Config._loaican.Trim() == "2")
                        {
                            if (Export_Mettler(saveFileDialogCSV.FileName))
                            {
                                SavehanDung();
                                InfoMessage.HienThi("Tạo file cân mettler tolodo thành công", "Xuất file Cân mettler",
                                                    "Thông báo",
                                                    HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);
                            }
                                
                            else
                            {
                                InfoMessage.HienThi("Tạo file cân mettler tolodo Thất bại", "Xuất file Cân mettler",
                                                    "Thông báo",
                                                    HinhAnhThongBao.LOI, NutThongBao.DONGY);
                            }
                        }
                        else if (Config._loaican.Trim() == "0")
                        {
                            if (Export_Bizerba(saveFileDialogCSV.FileName))
                            {
                                SavehanDung();
                                InfoMessage.HienThi("Tạo file cân Bizerba thành công", "Xuất file Cân Bizerba",
                                                    "Thông báo",
                                                    HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);
                            }
                                
                            else
                            {
                                InfoMessage.HienThi("Tạo file cân Bizerba tolodo Thất bại", "Xuất file Cân Bizerba",
                                                    "Thông báo",
                                                    HinhAnhThongBao.LOI, NutThongBao.DONGY);
                            }
                        }
                        else
                        {
                            if (Export_Bizerba_HardLock(saveFileDialogCSV.FileName))
                            {
                                SavehanDung();
                                InfoMessage.HienThi("Tạo file cân Bizeba Hard lock thành công",
                                                    "Xuất file Cân Bizeba Hard lock", "Thông báo",
                                                    HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);
                            }
                                
                            else
                            {
                                InfoMessage.HienThi("Tạo file cân Bizeba Hard lock Thất bại",
                                                    "Xuất file Cân Bizeba Hard lock", "Thông báo",
                                                    HinhAnhThongBao.LOI, NutThongBao.DONGY);
                            }
                        }
                    }
                    //else
                    //{
                    //    TPSDataAccess access=new TPSDataAccess(_PathFileINVMST);
                    //    DataTable dt = access.GetTableDM();
                    //    if (Config._loaican.Trim() == "2")
                    //    {
                    //        if (Export_Mettler(saveFileDialogCSV.FileName,dt))
                    //            InfoMessage.HienThi("Tạo file cân mettler tolodo thành công", "Xuất file Cân mettler",
                    //                                "Thông báo",
                    //                                HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);
                    //        else
                    //        {
                    //            InfoMessage.HienThi("Tạo file cân mettler tolodo Thất bại", "Xuất file Cân mettler",
                    //                                "Thông báo",
                    //                                HinhAnhThongBao.LOI, NutThongBao.DONGY);
                    //        }
                    //    }
                    //    else if (Config._loaican.Trim() == "0")
                    //    {
                    //        if (Export_Bizerba(saveFileDialogCSV.FileName,dt))
                    //            InfoMessage.HienThi("Tạo file cân Bizerba thành công", "Xuất file Cân Bizerba",
                    //                                "Thông báo",
                    //                                HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);
                    //        else
                    //        {
                    //            InfoMessage.HienThi("Tạo file cân Bizerba tolodo Thất bại", "Xuất file Cân Bizerba",
                    //                                "Thông báo",
                    //                                HinhAnhThongBao.LOI, NutThongBao.DONGY);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (Export_Bizerba_HardLock(saveFileDialogCSV.FileName,dt))
                    //            InfoMessage.HienThi("Tạo file cân Bizeba Hard lock thành công",
                    //                                "Xuất file Cân Bizeba Hard lock", "Thông báo",
                    //                                HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);
                    //        else
                    //        {
                    //            InfoMessage.HienThi("Tạo file cân Bizeba Hard lock Thất bại",
                    //                                "Xuất file Cân Bizeba Hard lock", "Thông báo",
                    //                                HinhAnhThongBao.LOI, NutThongBao.DONGY);
                    //        }
                    //    }
                    //}
                    if(_isLocTheoDMGoc)
                    {
                        toolStripButton1_Click(null,null);
                        _isLocTheoDMGoc = false;
                    }
                        
                }
                //ctlSearchBug.InsertTraceLog(Config._MaNV, DateTime.Now, GetIP(), "FrmScaleAddapterTool", 1);

            }
            catch (Exception exception)
            {
                //ctlSearchBug.InsertTraceLog(Config._MaNV, DateTime.Now, GetIP(), "FrmScaleAddapterTool", 0);
                CTLError.WriteError("FrmMain Xuatfile", exception.Message);
                return;
                throw;
            }


        }

        private void BTLuu_Click(object sender, EventArgs e)
        {
            if (GridDSMa.DataSource == null)
            {
                InfoMessage.HienThi("Không có dữ liệu vui lòng kiểm tra lại!", "Thông báo", "Thông báo",
                                    HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                return;
            }
            if (Save_FileDaTa())
            {
                InfoMessage.HienThi("Lưu danh sách mã loại bỏ thành công!", "Thông báo", "Insert Data",
                                    HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool check = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, view.Columns["Check"]));
                if (check)
                {
                     e.Appearance.BackColor = Color.FromArgb(252, 218, 216);
                    //gridView1.GetDataRow(e.RowHandle).AcceptChanges();
                }
                   
            }


        }

        #endregion

        #region cac ham ho tro

        private void LayDSLoaiBoSKU(DataTable dataTable, string[] str)
        {
            try
            {
                _tableDSSku = dataTable;
                _list_SKU = str;
                if (GridDSMa.DataSource != null && dataTable != null)
                {
                    DataTable dt = (DataTable)GridDSMa.DataSource;
                    string sql = "SKU in (";
                    foreach (string ma in str)
                    {
                        sql+= "'" + ma + "',";
                    }
                    DataRow[] arow=null;
                    if (sql != "SKU in (")
                    {
                        sql=sql.Remove(sql.Length-1,1)+")";
                        arow= dt.Select(sql);
                    }
                       
                    if(arow!=null)
                    {
                        foreach (DataRow dataRow in arow)
                        {
                            //dt.Rows.Remove(dataRow);
                            dataRow["Check"] = 1;
                        }
                    }
                    GridDSMa.DataSource = dt;
                }
            }
            catch (Exception exception)
            {
                CTLError.WriteError("FrmMain LayDSLoaiBoSKU", exception.Message);
                return;
                throw;
            }


        }

        public DataTable ConnectCSV(string filetable)
        {
            DataTable dt = new DataTable();
            try
            {
                // You can get connected to driver either by using DSN or connection string

                // Create a connection string as below, if you want to use DSN less connection. The DBQ attribute sets the path of directory which contains CSV files
                string strConnString = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + Application.StartupPath.Trim() + ";Extensions=asc,csv,tab,txt;Persist Security Info=False";
                string sql_select;
                System.Data.Odbc.OdbcConnection conn;

                //Create connection to CSV file
                conn = new System.Data.Odbc.OdbcConnection(strConnString.Trim());

                // For creating a connection using DSN, use following line
                //conn	=	new System.Data.Odbc.OdbcConnection(DSN="MyDSN");

                //Open the connection 
                conn.Open();
                //Fetch records from CSV
                sql_select = "select * from [" + filetable + "]";

                obj_oledb_da = new System.Data.Odbc.OdbcDataAdapter(sql_select, conn);
                //Fill dataset with the records from CSV file
                obj_oledb_da.Fill(dt);
                _list_SKU = new string[dt.Rows.Count];
                int index = 0;
                string SKU = "";
                foreach (DataRow row in dt.Rows)
                {
                    SKU = row["SKU"].ToString();
                    if (SKU.Length <= 7)
                        SKU = "00" + SKU;
                    _list_SKU[index++] = SKU;
                }
                //Set the datagrid properties

                //dGridCSVdata.DataSource = ds;
                //dGridCSVdata.DataMember = "Stocks";
                //Close Connection to CSV file
                conn.Close();
            }
            catch (Exception e) //Error
            {
                InfoMessage.HienThi("File dsLoaiBoMa.csv đang được sử dụng bởi chương trình khác!", "Thông báo", "Lỗi",
                                    HinhAnhThongBao.LOI, NutThongBao.DONGY);
                return dt;
            }
            return dt;
        }

        private void writeSchema()
        {
            try
            {
                FileStream fsOutput = new FileStream(Path.Combine(Application.StartupPath, "schema.ini"), FileMode.Create, FileAccess.Write);
                StreamWriter srOutput = new StreamWriter(fsOutput);
                string s1, s2, s3, s4, s5;
                s1 = "[" + "CSVDelimited" + "]";
                s2 = "ColNameHeader=" + "true";
                s3 = "Format=" + "CSVDelimited";
                s4 = "MaxScanRows=25";
                s5 = "CharacterSet=OEM";
                srOutput.WriteLine(s1.ToString() + '\n' + s2.ToString() + '\n' + s3.ToString() + '\n' + s4.ToString() + '\n' + s5.ToString());
                srOutput.Close();
                fsOutput.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { }
        }

        #endregion

        #region xu ly export

        public bool Export_Mettler(string path)
        {
            try
            {
                string stLine;
                DataTable dt = (DataTable)GridDSMa.DataSource;
                string ma_Upc = "";
                using (StreamWriter MyFile = new StreamWriter(path))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((int)dt.Rows[i]["Check"]==1)
                            continue;
                       ma_Upc= Convert.ToDecimal(dt.Rows[i]["UPC"]).ToString().Remove(0, 2);
                        stLine = "";
                        for (int j = 0; j < 6; j++)
                        {
                            switch (j)
                            {
                                case 0: stLine = stLine + ma_Upc  + ",";
                                    break;
                                case 1: stLine = stLine + dt.Rows[i]["Description"] + ",";
                                    break;
                                case 2: stLine = stLine +Convert.ToInt64(dt.Rows[i]["Price"]).ToString() + ",";
                                    break;
                                case 3: stLine = stLine + ma_Upc + ",";
                                    break;
                                case 4: stLine = stLine + "By Weight" + ",";
                                    break;
                                case 5:
                                    if (dt.Rows[i]["HanDung"].ToString().Trim()!="0")
                                    {
                                        stLine = stLine + dt.Rows[i]["HanDung"].ToString().Trim();
                                    }
                                    else
                                    {
                                        stLine = stLine + "0";
                                    }                                        
                                    break;
                            }
                          
                        }
                        MyFile.WriteLine(stLine);
                    }
                    //MessageBox.Show("Information of all the files are successfully saved in the following location: \n" + Application.StartupPath + "\\output.csv", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("FrmMain XuatMettle", ex.Message);
                return false;
                throw new Exception(ex.Message);
            }
        }
        public bool Export_Bizerba(string path)
        {
            try
            {
                string stLine;
                DataTable dt = (DataTable)GridDSMa.DataSource;
                string ma_Upc = "";
                using (StreamWriter MyFile = new StreamWriter(path))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((int)dt.Rows[i]["Check"]==1)
                            continue;
                        ma_Upc = Convert.ToDecimal(dt.Rows[i]["UPC"]).ToString().Remove(0, 2);
                        stLine = "";
                        for (int j = 0; j < 7; j++)
                        {
                            switch (j)
                            {
                                case 0: stLine = stLine + "0" + ",";
                                    break;
                                case 1: stLine = stLine + ma_Upc   + ",";
                                    break;
                                case 2: stLine = stLine +ma_Upc     + ",";
                                    break;
                                case 3: stLine = stLine + dt.Rows[i]["Description"] + ",";
                                    break;
                                case 4:
                                    stLine = stLine +Convert.ToInt64(dt.Rows[i]["Price"]).ToString() + ",";
                                    break;
                                case 5: stLine = stLine +dt.Rows[i]["Sell_Unit"] + ",";
                                    break;
                                case 6:
                                    if (dt.Rows[i]["HanDung"].ToString().Trim() != "0")
                                    {
                                        stLine = stLine + dt.Rows[i]["HanDung"].ToString().Trim();
                                    }
                                    else
                                    {
                                        stLine = stLine + "0";
                                    }
                                    break;
                            }

                        }
                        MyFile.WriteLine(stLine);
                    }
                    //MessageBox.Show("Information of all the files are successfully saved in the following location: \n" + Application.StartupPath + "\\output.csv", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("FrmMain xuatbizerba", ex.Message);
                return false;
                throw new Exception(ex.Message);
            }
        }
        public bool Export_Bizerba_HardLock(string path)
        {
            try
            {
                string stLine = "STT,PLU,UPC,FLAGPLU,TENVT,SKU,DVT,DGBVN";
                DataTable dt = (DataTable)GridDSMa.DataSource;
                string ma_Upc = "";
                using (StreamWriter MyFile = new StreamWriter(path))
                {
                    MyFile.WriteLine(stLine);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ma_Upc = Convert.ToDecimal(dt.Rows[i]["UPC"]).ToString();
                        stLine = "";
                        for (int j = 0; j < 9; j++)
                        {
                            switch (j)
                            {
                                case 0: stLine = stLine + (i + 3065655).ToString() + ",";
                                    break;
                                case 1: stLine = stLine + ma_Upc.Remove(0,2) + ",";
                                    break;
                                case 2: stLine = stLine + ma_Upc + ",";
                                    break;
                                case 3: stLine = stLine + ma_Upc.Substring(0,2) + ",";
                                    break;
                                case 5: stLine = stLine + dt.Rows[i]["Description"] + ",";
                                    break;
                                case 6: stLine = stLine +Convert.ToDecimal(dt.Rows[i]["SKU"]).ToString() + ",";
                                    break;
                                case 7: stLine = stLine + dt.Rows[i]["Sell_Unit"] + ",";
                                    break;
                                case 8: stLine =stLine + Convert.ToInt64(dt.Rows[i]["price"]).ToString("");
                                    break;
                            }
                        }
                        MyFile.WriteLine(stLine);
                    }
                    //MessageBox.Show("Information of all the files are successfully saved in the following location: \n" + Application.StartupPath + "\\output.csv", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("FrmMain XuatBizerbaHardLock", ex.Message);
                return false;
                throw new Exception(ex.Message);
            }
        }

        public bool Export_Mettler(string path,DataTable dataTable)
        {
            try
            {
                string stLine;
                string ma_Upc = "";
                using (StreamWriter MyFile = new StreamWriter(path))
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        ma_Upc = Convert.ToDecimal(dataTable.Rows[i]["UPC"]).ToString().Remove(0, 2);
                        stLine = "";
                        for (int j = 0; j < 6; j++)
                        {
                            switch (j)
                            {
                                case 0: stLine = stLine + ma_Upc + ",";
                                    break;
                                case 1: stLine = stLine + dataTable.Rows[i]["Description"] + ",";
                                    break;
                                case 2:
                                    if (dataTable.Rows[i]["price"]==null)
                                        stLine = stLine + "0" + ",";
                                    else
                                        stLine = stLine + Convert.ToInt64(dataTable.Rows[i]["price"]).ToString("") + ",";
                                    break;
                                case 3: stLine = stLine + ma_Upc + ",";
                                    break;
                                case 4: stLine = stLine + "By Weight" + ",";
                                    break;
                                case 5: stLine = stLine + "0";
                                    break;
                            }

                        }
                        MyFile.WriteLine(stLine);
                    }
                    //MessageBox.Show("Information of all the files are successfully saved in the following location: \n" + Application.StartupPath + "\\output.csv", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("FrmMain XuatMettle", ex.Message);
                return false;
                throw new Exception(ex.Message);
            }
        }
        public bool Export_Bizerba(string path,DataTable dataTable)
        {
            try
            {
                string stLine;
                string ma_Upc = "";
                using (StreamWriter MyFile = new StreamWriter(path))
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        ma_Upc = Convert.ToDecimal(dataTable.Rows[i]["UPC"]).ToString().Remove(0, 2);
                        stLine = "";
                        for (int j = 0; j < 7; j++)
                        {
                            switch (j)
                            {
                                case 0: stLine = stLine + "0" + ",";
                                    break;
                                case 1: stLine = stLine + ma_Upc + ",";
                                    break;
                                case 2: stLine = stLine + ma_Upc + ",";
                                    break;
                                case 3: stLine = stLine + dataTable.Rows[i]["Description"] + ",";
                                    break;
                                case 4:
                                    if (dataTable.Rows[i]["price"]==null)
                                        stLine = stLine + "0" + ",";
                                    else
                                    {
                                        stLine = stLine +Convert.ToInt64(dataTable.Rows[i]["price"]).ToString("")+ ",";
                                    }
                                    
                                    break;
                                case 5: stLine = stLine + dataTable.Rows[i]["Sell_Unit"].ToString() + ",";
                                    break;
                                case 6: stLine = stLine + "0";
                                    break;
                            }

                        }
                        MyFile.WriteLine(stLine);
                    }
                    //MessageBox.Show("Information of all the files are successfully saved in the following location: \n" + Application.StartupPath + "\\output.csv", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("FrmMain xuatbizerba", ex.Message);
                return false;
                throw new Exception(ex.Message);
            }
        }
        public bool Export_Bizerba_HardLock(string path,DataTable dataTable)
        {
            try
            {
                string stLine = "STT,PLU,UPC,FLAGPLU,TENVT,SKU,DVT,DGBVN";
                
                string ma_Upc = "";
                using (StreamWriter MyFile = new StreamWriter(path))
                {
                    MyFile.WriteLine(stLine);
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        ma_Upc = Convert.ToDecimal(dataTable.Rows[i]["UPC"]).ToString();
                        stLine = "";
                        for (int j = 0; j < 9; j++)
                        {
                            switch (j)
                            {
                                case 0: stLine = stLine + (i + 3065655).ToString() + ",";
                                    break;
                                case 1: stLine = stLine + ma_Upc.Remove(0, 2) + ",";
                                    break;
                                case 2: stLine = stLine + ma_Upc + ",";
                                    break;
                                case 3: stLine = stLine + ma_Upc.Substring(0, 2) + ",";
                                    break;
                                case 5: stLine = stLine + dataTable.Rows[i]["Description"] + ",";
                                    break;
                                case 6: 
                                    stLine = stLine + Convert.ToDecimal(dataTable.Rows[i]["SKU"]).ToString() + ",";
                                    break;
                                case 7: stLine = stLine + dataTable.Rows[i]["Sell_Unit"] + ",";
                                    break;
                                case 8:
                                    if (dataTable.Rows[i]["price"]==null)
                                        stLine += "0";
                                    else
                                        stLine += stLine +Convert.ToInt64(dataTable.Rows[i]["price"]).ToString("");
                                    break;
                            }

                        }
                        MyFile.WriteLine(stLine);
                    }
                    //MessageBox.Show("Information of all the files are successfully saved in the following location: \n" + Application.StartupPath + "\\output.csv", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("FrmMain XuatBizerbaHardLock", ex.Message);
                return false;
                throw new Exception(ex.Message);
            }
        }

        public bool Save_FileDaTa()
        {
            try
            {
                string stLine = "Check,SKU,UPC,Description,Price,CurrencyCode,Sell_Unit";
                DataTable dt = (DataTable)GridDSMa.DataSource;
                string ma_Upc = "";
                using (StreamWriter MyFile = new StreamWriter(Path.Combine(Application.StartupPath,"DSLoaiBo.csv")))
                {
                    MyFile.WriteLine(stLine);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        stLine = "";
                        if (dt.Rows[i]["Check"].ToString().Trim() == "1")
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        stLine = stLine + "1" + ",";
                                        break;
                                    case 1:
                                        stLine = stLine + dt.Rows[i]["SKU"].ToString() + ",";
                                        break;
                                    case 2:
                                        stLine = stLine + dt.Rows[i]["UPC"].ToString() + ",";
                                        break;
                                    case 3:
                                        stLine = stLine + dt.Rows[i]["Description"].ToString() + ",";
                                        break;
                                    case 5:
                                        stLine = stLine +Convert.ToDecimal(dt.Rows[i]["Price"]).ToString("N0") + ",";
                                        break;
                                    case 6:
                                        stLine = stLine + dt.Rows[i]["CurrencyCode"].ToString() + ",";
                                        break;
                                    case 7:
                                        stLine = stLine + dt.Rows[i]["Sell_Unit"];
                                        break;
                                   
                                }

                            }
                            MyFile.WriteLine(stLine);
                        }
                    }
                    //MessageBox.Show("Information of all the files are successfully saved in the following location: \n" + Application.StartupPath + "\\output.csv", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("FrmMain XuatBizerbaHardLock", ex.Message);
                return false;
                throw new Exception(ex.Message);
            }
        }
        #endregion

        private void BTselectPriceupd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PRCUPD.*|PRCUPD.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> skufromfile = new List<string>();
                XmlDocument document = new XmlDocument();
                try
                {
                    int i;
                    document.Load(openFileDialog.FileName);
                    XmlNodeList elm = document.GetElementsByTagName("ROWS");
                    for (i = 0; i < elm.Count; i++)
                    {
                        XmlNodeList node = elm[i].ChildNodes;
                        //string[] strsku = elm[i].InnerXml.Split(new char[] { '"' });
                        //if (strsku[0].ToUpper().Contains("SKU"))
                        //{
                        //    skufromfile.Add(strsku[1]);
                        //}
                        //int x=elm[i].InnerXml.IndexOf("SKU=");
                        //XmlNodeList node1= node.Item(0).ChildNodes;
                        //foreach (XmlNode xmlNode in node)
                        //{
                        //    string[] spl = xmlNode.LastChild.InnerXml.Split(new char[] { '"' });
                        //    skufromfile.Add(spl[1]);
                        //    skufromfile.Add(spl[3]);
                        //}
                        
                        for (int j = 0; j < node.Count; j++)
                        {
                            string sku = node.Item(j).OuterXml;
                            string strsku = sku.Substring(sku.IndexOf("SKU=\"") + 5, 9);
                            skufromfile.Add(strsku.Replace(@"\",""));
                        }
                    }
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("SKU");
                    dataTable.Columns.Add("UPC");
                    dataTable.Columns.Add("Description");
                    dataTable.Columns.Add("Price", typeof(System.Int64));
                    dataTable.Columns.Add("CurrencyCode");
                    dataTable.Columns.Add("Sell_Unit");
                    dataTable.Columns.Add("Check",typeof(System.Int32));
                    dataTable.Columns.Add("HanDung");
                    TPSDataAccess dataAccess = new TPSDataAccess(Path.Combine(Config._pathfileWinDSS, "INVMST.TPS"));
                    if ((skufromfile != null) && (skufromfile.Count > 0))
                    {
                        string sql = "SKU in (";
                        for (i = 0; i < skufromfile.Count; i++)
                        {
                            sql = sql + "'" + skufromfile[i] + "',";
                        }
                        if (sql != "SKU in (")
                        {
                            //dataTable = dataAccess.GetTableDM("Select SKU,UPC,Description,Price,CurrencyCode,Sell_Unit,0 as Check,0 as HanDung from INVMST where 1<>1 ");
                            for (int j = 0; j < skufromfile.Count; j++)
                            {
                                DataTable dtskutemp = dataAccess.GetTableDM("Select SKU,UPC,Description,Price,CurrencyCode,Sell_Unit,0 as Check,0 as HanDung from INVMST where 1=1 and UPC like '%0000000000029%' and SKU='"+skufromfile[j]+"'");
                                if(dtskutemp!=null&&dtskutemp.Rows.Count>0)
                                {
                                    DataRow r = dataTable.NewRow();
                                    r["SKU"] = dtskutemp.Rows[0]["SKU"];
                                    r["UPC"] = dtskutemp.Rows[0]["UPC"];
                                    r["Description"] = dtskutemp.Rows[0]["Description"];
                                    r["Price"] =dtskutemp.Rows[0]["Price"];
                                    r["CurrencyCode"] = dtskutemp.Rows[0]["CurrencyCode"];
                                    r["Sell_Unit"] = dtskutemp.Rows[0]["Sell_Unit"];
                                    r["Check"] = 0;
                                    r["HanDung"] = dtskutemp.Rows[0]["HanDung"];
                                    dataTable.Rows.Add(r);
                                }
                            }
                            
                            if(!LoadhanDung(ref dataTable))
                            {
                                InfoMessage.HienThi("Không lấy được hạn dùng Từ Server KHTT", "Vui lòng liên hệ với quản trị", "Thong Bao", HinhAnhThongBao.LOI, NutThongBao.DONGY);
                                return;
                            }
                        }
                    }
                    //if (dataTable != null)
                    //{
                    //    i = 0;
                    //    bool flag = true;
                    //    foreach (DataRow dataRow in dataTable.Rows)
                    //    {
                    //        while (flag)
                    //        {
                    //            if (dataRow["SKU"].ToString().Trim().Equals(skufromfile[i].Trim()))
                    //            {
                    //                i++;
                    //                dataRow["Price"] = skufromfile[i++];
                    //                dataRow["CurrencyCode"] = skufromfile[i++];
                    //                i = 0;
                    //                break;
                    //            }
                    //            i++;
                    //        }
                    //    }
                    //}
                    this.GridDSMa.DataSource = dataTable;
                    locPLU.Visible = false;
                    LuuPLU.Visible = false;
                }
                catch (Exception exception)
                {
                    CTLError.WriteError("CTLConfig getconfig", exception.Message);
                }
            }
        }

        private void FrmScaleAddTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            CTLQuanLyForm.formName.Remove(this.Name);
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



        #region them chuc nang han dung cho can

        public void CreateTableHanDung()
        {
            try
            {
                SQLHelper sqlHelper=new SQLHelper();
                string sql = string.Format(@"IF (Not EXISTS (SELECT * FROM [" + Config._DBNameFrontEnd + @"].INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{0}'))
                                                        BEGIN                    
                                                        CREATE TABLE [" + Config._DBNameFrontEnd + @"].dbo.ScaleAdHanDung (                                                          
                                                          SKU  nvarchar(10) NOT NULL,
                                                          HanDung   int NOT NULL,
                                                          Node        nvarchar(100)
                                                        ); END", "ScaleAdHanDung");
                int resl= sqlHelper.GetExecuteNonQueryByCommand(sql);
                return ;
            }
            catch (Exception exception)
            {
                CTLError.WriteError("frmScaleAddTool CreateTableHanDung ", exception.Message);
                return ;
                throw;
            }
        }

        public bool LoadhanDung(ref DataTable dataTable)
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                string sql = string.Format(@"select * from [" + Config._DBNameFrontEnd + @"].dbo.ScaleAdHanDung");
                DataTable dt = sqlHelper.GetDatasetByCommand(sql).Tables[0];
                if (dt == null)
                    return false;
                foreach (DataRow r in dataTable.Rows)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (r["SKU"].ToString().Trim() == row["SKU"].ToString().Trim())
                            r["HanDung"] = row["HanDung"];
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                CTLError.WriteError("frmScaleAddTool LoadhanDung ", exception.Message);
                return false;
                throw;
            }
            

        }
        #endregion

        private void SavehanDung()
        {
            try
            {
                DataTable tableTemp = CTLScaleHanDung.SearchHDScaleAll();
                Hashtable hashtable = new Hashtable();
                foreach (DataRow r in tableTemp.Rows)
                {
                    try
                    {
                        hashtable.Add(r["SKU"].ToString().Trim(), r["HanDung"]);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    
                }
                for (int i = 0; i < ((DataTable)(GridDSMa.DataSource)).Rows.Count; i++)
                {
                    //DataRow row = gridView1.GetDataRow(i);
                    DataRow row = ((DataTable) GridDSMa.DataSource).Rows[i];
                    if (DataRowState.Modified == row.RowState || DataRowState.Added == row.RowState)
                    {
                        //DataTable dt = CTLScaleHanDung.SearchHDScale(row["SKU"].ToString().Trim());
                        if (!hashtable.ContainsKey(row["SKU"]))
                        {
                            EntityScaleAdHanDung hd = new EntityScaleAdHanDung();
                            hd.SKU = row["SKU"].ToString();
                            hd.HanDung = Convert.ToInt32(row["HanDung"]);
                            hd.Node = DateTime.Now.ToString("dd-MM-yy hhmmss");
                            CTLScaleHanDung.InsertScaleAdHanDung(hd);
                        }
                        else
                        {
                            CTLScaleHanDung.UpdateHanDung(row["SKU"].ToString(), Convert.ToInt32(row["HanDung"]));
                        }
                    }
                    row.AcceptChanges();
                }
            }
            catch (Exception exception)
            {
                CTLError.WriteError("frmScaleAddTool SavehanDung ", exception.Message);
                return;
                throw;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban muon luu lai Danh Muc nay lam Danh Muc Goc ?", "Thong bao", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;
            WaitingMsg waitingMsg = new WaitingMsg("Chương trình đang lưu dữ liệu!", "Waiting .......");
            try
            {
                
                
                CreateTable_DMGoc();
                //test tren may 112
                //SQLHelper helper = new SQLHelper("10.10.11.112", "PLUTEST", "test", "123456");

                //su dung data server 31
                
                if (gridView1.DataRowCount > 0)
                {
                    SQLHelper helper = new SQLHelper();
                    helper.GetExecuteNonQueryByCommand("Delete from [" + Config._DBNameFrontEnd + @"].dbo.DanhMucGoc");
                    DataTable dt = (DataTable) GridDSMa.DataSource;
                    int countrow = 0;
                    foreach (DataRow r in dt.Rows)
                    {
                        //if (r["Check"].ToString().Trim() == "1")
                        //    continue;
                        //if (r["UPC"].ToString().Trim() == "000000000002958011")
                        //{
                            
                        //}
                        countrow++;
                        string sql =
                            string.Format(
                                @"INSERT INTO ["+ Config._DBNameFrontEnd + @"].dbo.DanhMucGoc
                                                    (
	                                                    PLUNO,
	                                                    [Description],
	                                                    Price,
	                                                    ByWeight,
	                                                    HanDung
                                                    )
                                                    VALUES
                                                    (
	                                                    /* PLUNO	*/'{0}',
	                                                    /* [Description]*/	'{1}',
	                                                    /* Price	*/{2},
	                                                    /* ByWeight	*/'{3}',
	                                                    /* HanDung	*/{4}
                                                    )",
                                r["UPC"],
                                r["Description"].ToString().Replace("'",""),
                                r["Price"],
                                "By Weight",
                                r["HanDung"]);
                        int res= helper.GetExecuteNonQueryByCommand(sql);
                     
                    }
                    waitingMsg.Finish();
                    InfoMessage.HienThi("Luu Du Lieu Thanh Cong !!!!", HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);
                    //MessageBox.Show("Luu Thanh Cong !!!!!!!");
                }
                else
                {
                    InfoMessage.HienThi("Khong Co Du Lieu , Vui Long Kiem Tra Lai !!!!", HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                }
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Loi Luu Danh Muc Goc Ko thanh cong" + ex.Message);
                waitingMsg.Finish();
                InfoMessage.HienThi("Không Luu Duoc Danh Muc Goc", "Vui lòng liên hệ với quản trị", "Thong Bao", HinhAnhThongBao.LOI, NutThongBao.DONGY);
                return;
                throw;
            }
            
            
        }
        Hashtable _tbDMGoc=new Hashtable();
        Hashtable _tbName=new Hashtable();
        Hashtable _tbNgaySD=new Hashtable();
        public void LoadDMGoc()
        {
            //if(gridView1.DataRowCount<=0)
            //    InfoMessage.HienThi("Khong co du lieu !")
            //test tren may 112
            //SQLHelper helper = new SQLHelper("10.10.11.112", "PLUTEST", "test", "123456");
            try
            {
                //chay tren may 31
                SQLHelper helper = new SQLHelper();
                string sql = "SELECT * FROM [" + Config._DBNameFrontEnd + @"].dbo.DanhMucGoc";
                DataTable dt = helper.GetDatasetByCommand(sql).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {


                    _tbDMGoc.Clear();
                    _tbNgaySD.Clear();
                    _tbName.Clear();
                    foreach (DataRow r in dt.Rows)
                    {
                        try
                        {
                            _tbDMGoc.Add(r["PLUNO"].ToString().Trim(), Convert.ToDecimal(r["Price"]));
                            _tbName.Add(r["PLUNO"].ToString().Trim(), r["Description"]);
                            _tbNgaySD.Add(r["PLUNO"].ToString().Trim(), r["HanDung"]);
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                InfoMessage.HienThi("Không lấy dữ liệu được từ Server", "Vui Thử lại sau", "Thong Bao", HinhAnhThongBao.LOI, NutThongBao.DONGY);
                return;
            }
            

        }
        public void CreateTable_DMGoc()
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                string sql = string.Format(@"IF (Not EXISTS (SELECT * FROM [" + Config._DBNameFrontEnd + @"].INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{0}'))
                                                        BEGIN                    
                                                        CREATE TABLE [" + Config._DBNameFrontEnd + @"].dbo.DanhMucGoc (                                                          
                                                          [PLUNO] [nvarchar](50) NULL,
	                                                        [Description] [nvarchar](150) NULL,
	                                                        [Price] [decimal](18, 0) NULL,
	                                                        [ByWeight] [nvarchar](50) NULL,
	                                                        [HanDung] [decimal](18, 0) NULL
                                                        ); END", "DanhMucGoc");
                int resl = sqlHelper.GetExecuteNonQueryByCommand(sql);
                return;
            }
            catch (Exception exception)
            {
                CTLError.WriteError("frmScaleAddTool CreateTableDanhMucGoc ", exception.Message);
                return;
                throw;
            }
        }

        private bool _isLocTheoDMGoc = false;
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(gridView1.DataRowCount<=0)
            {
                InfoMessage.HienThi("Không có dữ liệu để lọc ..", "Vui lòng kiểm tra lại", "Thong bao",
                                    HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                return;
            }
            WaitingMsg waitingMsg = new WaitingMsg("Chương trình đang Load dữ liệu!", "Waiting .......");
            try
            {
                LoadDMGoc();
                DataTable dt = (DataTable) GridDSMa.DataSource;
                if(dt==null)
                    return;
                //foreach (DataRow r in dt.Rows)
                //{
                //    try
                //    {
                //        decimal Currentprice = Convert.ToDecimal(r["Price"]);
                //        decimal DMGocPrice = Convert.ToDecimal(_tbDMGoc[r["UPC"] == null ? "0" : r["UPC"].ToString().Trim()]);
                //        if (Currentprice == DMGocPrice && r["HanDung"].ToString().Trim() == _tbNgaySD[r["UPC"]].ToString().Trim() && r["Description"].ToString().Trim().Replace("'", "") == _tbName[r["UPC"]].ToString().Trim())
                //            r["Check"] = true;
                //        else
                //        {
                //            r["Check"] = false;
                //        }
                //    }
                //    catch (Exception)
                //    {
                //        continue;
                //        //throw;
                //    }
                    
                //}
                for (int i = 0; i < ((DataTable)GridDSMa.DataSource).Rows.Count; i++)
                {
                    DataRow r = ((DataTable)GridDSMa.DataSource).Rows[i];
                    bool rowstate = false;
                    try
                    {
                        
                        decimal Currentprice = Convert.ToDecimal(r["Price"]);
                        decimal DMGocPrice = Convert.ToDecimal(_tbDMGoc[r["UPC"] == null ? "0" : r["UPC"].ToString().Trim()]);
                        
                        if (Currentprice == DMGocPrice && r["HanDung"].ToString().Trim() == _tbNgaySD[r["UPC"]].ToString().Trim() && r["Description"].ToString().Trim().Replace("'", "") == _tbName[r["UPC"]].ToString().Trim())
                        {
                            if (DataRowState.Modified == r.RowState || DataRowState.Added == r.RowState)
                            {
                                rowstate = true;
                            }
                            r["Check"] = true;
                        }
                            
                        else
                        {
                            if (DataRowState.Modified == r.RowState || DataRowState.Added == r.RowState)
                            {
                                rowstate = true;
                            }
                            r["Check"] = false;
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                        //throw;
                    }
                   if(!rowstate)
                   {
                       r.AcceptChanges();
                   }
                }
                GridDSMa.DataSource = dt;
                _isLocTheoDMGoc = true;
                waitingMsg.Finish();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Loi....Vui long lien he voi vi tinh " + ex.Message);
                waitingMsg.Finish();
                return;
                throw;
            }
        }
        public void ClearCheckList()
        {
            DataTable dt = (DataTable) GridDSMa.DataSource;
            foreach (DataRow r in dt.Rows)
            {
                r["Check"] = 0;
            }
            GridDSMa.DataSource = dt;
        }
      
    }

}