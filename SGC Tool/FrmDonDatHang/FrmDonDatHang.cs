using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Net;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using Microsoft.Office.Interop.Excel;
using SGC_Tool.FrmBangbaoGia;
using SGC_Tool.MyControls;
using TOOLChuyenDuLieu;
using TOOLChuyenDuLieu.ControlEntity;
using TOOLChuyenDuLieu.HelpFile;
using TPMessageBox;
using Application = System.Windows.Forms.Application;
using CTLImportExcel = TOOLChuyenDuLieu.ControlEntity.CTLImportExcel;
using DataTable = System.Data.DataTable;

namespace SGC_Tool.FrmDonDatHang
{
    public partial class FrmDonDatHang : DevExpress.XtraEditors.XtraForm
    {
        public FrmDonDatHang(MainForm f)
        {
            InitializeComponent();
            _frmmain = f;
            CTLDonDatHang ddh=new CTLDonDatHang();
            ddh.CreateTableDonDatHang();
            ddh.CreateTableCTDonDatHang();
            InitiTable();
        }
        #region khoi tao bien

        private MainForm _frmmain;

        private string _sokhong = "000000000000000";
        private DataTable _dsSKU = null;
        string _PathFileINVMST = Path.Combine(Config._pathfileWinDSS,"INVMST.TPS");
        string _PathFileINVEVT = Path.Combine(Config._pathfileWinDSS, "INVEVT.TPS");
        private long _Const_datetime = 36161;
        public void InitiTable()
        {
            _dsSKU=new DataTable();
            DataColumn colsku=new DataColumn("SKU");
            DataColumn colupc = new DataColumn("UPC");
            DataColumn coldes = new DataColumn("Description");
            DataColumn colsl=new DataColumn("SoLuong",typeof(System.Decimal));
            DataColumn colGiaGoc=new DataColumn("GiaGoc",typeof(System.Decimal));
            DataColumn colGiaKM=new DataColumn("GiaKM",typeof(System.Decimal));
            DataColumn coltt = new DataColumn("ThanhTien", typeof(System.Decimal));
            DataColumn colMethod=new DataColumn("Method");
            DataColumn colDISCPRICE = new DataColumn("DISCPRICE");
            DataColumn colQTY1 = new DataColumn("QTY1");
            DataColumn colghichu = new DataColumn("GhiChu");
            _dsSKU.Columns.AddRange(new DataColumn[]{colsku,colupc,coldes,colsl,colGiaGoc,colGiaKM,coltt,colghichu,colMethod,colQTY1,colDISCPRICE});
        }

        #endregion 

        #region xu ly su kien

        private void FrmbangBaoGia_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F6)
            {
                btexportExcell_Click(null,null);
            }
            if (e.KeyCode == Keys.F7)
            {
                btSave_Click(null, null);
            }
            if (e.KeyCode == Keys.F8)
            {
                toolStripButton1_Click(null, null);
            }
            if(e.KeyCode==Keys.F2)
            {
                txtSKU.Focus();
            }
            else if(e.KeyCode==Keys.F3)
            {
                //txtsoluong.Focus();
                simpleButton1_Click(null,null);
            }
            else if (e.KeyCode == Keys.F4)
            {
                FrmSearchBBGia bbGia = new FrmSearchBBGia();
                bbGia.MyGetData += new FrmSearchBBGia.GetStringSKU(InserchNewSKu);
                bbGia.ShowDialog();
            }
            else if(e.KeyCode==Keys.F5)
            {
                btclear_Click(null,null);
            }
        }

        private void BTthoat_Click(object sender, EventArgs e)
        {
            CTLQuanLyForm.formName.Remove(this.Name);
            this.Dispose();
            this.Close();
        }

        #endregion

        private void txtSKU_KeyDown(object sender, KeyEventArgs e)
        {
            //Math.Round(DateTime.Now.ToOADate()) + _Const_datetime
            if(e.KeyCode==Keys.Enter)
            {
                txtsoluong.Focus();
            }
            
        }

        #region ham xu ly

        public void clearData()
        {
            txtSKU.Text = string.Empty;
            txtsoluong.Value = 1;
        }
        public bool validate(string sku)
        {
            bool flag = true;
            
            if (_dsSKUAdd.Contains(sku))
            {
                return false;
            }
            //if()
            return flag;
        }
        Hashtable _dsSKUAdd = new Hashtable();
        private int _indexadd = 0;

        #endregion

        private void FrmbangBaoGia_FormClosed(object sender, FormClosedEventArgs e)
        {
            CTLQuanLyForm.formName.Remove(this.Name);
        }

        private void grbtxoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]);
            if(_dsSKUAdd.Contains(row["SKU"]))
                _dsSKUAdd.Remove(row["SKU"]);
            else
            {
                _dsSKUAdd.Remove(row["UPC"]);
            }
            _dsSKU.Rows.Remove(row);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.Name=="CSoLuong")
            {
                DataRow row = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]);
                if (row["GiaKM"].ToString().Trim()!=string.Empty&&row["Method"].ToString()=="25")
                        row["ThanhTien"] = Convert.ToDecimal(row["SoLuong"])*Convert.ToDecimal(row["GiaKM"]);
                else if (row["Method"].ToString()=="2")
                {
                    row["ThanhTien"] = (int)(int.Parse(row["SoLuong"].ToString()) / Int32.Parse(Convert.ToDecimal(row["QTY1"]).ToString("N0"))) *
                                      Convert.ToDecimal(row["DISCPRICE"].ToString())
                                     +
                                     (int)(int.Parse(row["SoLuong"].ToString()) % Int32.Parse(Convert.ToDecimal(row["QTY1"]).ToString("N0"))) *
                                     Convert.ToDecimal(row["GiaGoc"]);
                    row["GhiChu"] = "Mua SL " + row["QTY1"].ToString() + " co gia " +
                                  Convert.ToDecimal(row["DISCPRICE"]).ToString("N0");
                }
                else
                {
                    row["ThanhTien"] = Convert.ToDecimal(row["SoLuong"])*Convert.ToDecimal(row["GiaGoc"]);
                }
                
            }
        }

        private void btexportExcell_Click(object sender, EventArgs e)
        {
            //FrmNhapLyDo nhapLyDo=new FrmNhapLyDo();
            //nhapLyDo.ShowDialog();
            //if(nhapLyDo._isdongy)
            //{
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "*.xls|*.xls|*.pdf|*.pdf";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    
                    ExcelHelper.exportDataToExcel("Đơn Đặt Hàng",(DataTable)GrDSSKU.DataSource,save.FileName,txthotenKH.Text,txtDienThoai.Text,txtDiaChi.Text);
                    //CXoa.Visible = false;
                    //GrDSSKU.ExportToXls(save.FileName);
                    
                    if (txtghichu.Text != string.Empty)
                    {
                        CTLImportExcel excel = new CTLImportExcel();
                        excel.WireGhiChuExcel(save.FileName, txtghichu.Text, gridView1.DataRowCount + 7);
                    }
                    //excel.WireInfomationCIM(save.FileName, gridView1.DataRowCount + 5, "Họ Tên KH: " + txthotenKH.Text, "Số Điện Thoại: " + txtDienThoai.Text, "Địa Chỉ: " + txtDiaChi.Text);
                    

                    //File.Copy(save.FileName, Path.Combine(Path.Combine(Path.Combine(Application.StartupPath, "ExpCust"), DateTime.Now.ToString("MMyyyy")), DateTime.Now.ToString("ddMMyyhhmmss")));
                    ////GrDSSKU.ExportToXls(save.);
                    ////GrDSSKU.ExportToXls(save.FileName);
                    //CXoa.Visible = true;
                    //CTLSearchBug ctlSearchBug = new CTLSearchBug();
                    //ctlSearchBug.InsertTraceLog(Config._MaNV, DateTime.Now, GetIP(), "FrmXuatBangGia", 1, "FrontEnd Utility", "Export Export Excel");
                    InfoMessage.HienThi("Xuất file " + save.FileName + " Thành công!!", "Xuất file Excel", "Thông báo",
                                        HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);
                }
            //}
            
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

        private void btclear_Click(object sender, EventArgs e)
        {
            txtSKU.Text = "";
            txthotenKH.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
            txtsoluong.Value = 1;
            if(_dsSKU!=null)
                _dsSKU.Clear();
            _dsSKUAdd.Clear();

        }

        private void txtsoluong_KeyDown(object sender, KeyEventArgs e)
        {
            string upc = "";
            string sku = "";
            if (e.KeyCode == Keys.F5)
            {
                btclear_Click(null, null);
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (gridView1.RowCount >= 30)
                {
                    InfoMessage.HienThi("Số lượng SKU cho phép xuất bảng giá là 30 !", "Vui lòng kiểm tra lại",
                                        "Thong bao", HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                    return;
                }
                if (txtSKU.Text == string.Empty || txtSKU.Text.Length > 18)
                    return;

                string where = "";
                if (txtSKU.Text.Length <= 9)
                {
                    sku = _sokhong.Substring(0, 9 - txtSKU.Text.Length) + txtSKU.Text;
                    where = " and SKU='" + sku + "'";
                }
                else
                {
                    upc = _sokhong.Substring(0, 18 - txtSKU.Text.Length) + txtSKU.Text;
                    where = " and UPC='" + upc + "'";
                }
                if (!validate((sku != string.Empty) ? sku : upc))
                {
                    InfoMessage.HienThi("SKU đã có trong danh sách!", "Vui lòng thay đổi số lượng trong lưới", "Thong Bao",
                                        HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                    return;
                }
                TPSDataAccess dataAccess = new TPSDataAccess(_PathFileINVMST);
                TPSDataAccess dataAccessKM = new TPSDataAccess(_PathFileINVEVT);
                DataTable dt = new DataTable();
                dt = dataAccess.GetTableDM("Select SKU,UPC,Description,Price From INVMST where 1=1 " + where);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    InfoMessage.HienThi("SKU không có trong danh mục!", "Vui lòng kiểm tra lại", "Thong Bao",
                                        HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                    return;

                }
                DataTable dtKM = new DataTable();
                dtKM =
                    dataAccessKM.GetTableDM("select SKU,QTY1,DISCPRICE,Method From INVEVT where SKU='" +
                                            dt.Rows[0]["SKU"].ToString() + "' and " + (Math.Round(DateTime.Now.ToOADate()) + _Const_datetime) + @" >= Start 
                                                        and " + (Math.Round(DateTime.Now.ToOADate()) + _Const_datetime) + " <= stop ");
                DataRow r = _dsSKU.NewRow();
                r["SKU"] = dt.Rows[0]["SKU"].ToString();
                r["UPC"] = dt.Rows[0]["UPC"].ToString();
                r["Description"] = dt.Rows[0]["Description"].ToString();
                r["SoLuong"] = txtsoluong.Value;
                r["GiaGoc"] = dt.Rows[0]["Price"].ToString();
                r["ThanhTien"] = r["GiaGoc"];
                if (dtKM.Rows.Count > 0)
                {
                    r["Method"] = dtKM.Rows[0]["Method"].ToString();
                    r["DISCPRICE"] = dtKM.Rows[0]["DISCPRICE"].ToString();
                    r["QTY1"] = dtKM.Rows[0]["QTY1"].ToString();
                    if (dtKM.Rows[0]["Method"].ToString() == "25")
                    {
                        r["GiaKM"] = dtKM.Rows[0]["DISCPRICE"].ToString();
                        r["ThanhTien"] = txtsoluong.Value * Convert.ToDecimal(r["GiaKM"]);
                    }
                    else if (dtKM.Rows[0]["Method"].ToString() == "2")
                    {
                        r["ThanhTien"] = (int)(txtsoluong.Value / Int32.Parse(Convert.ToDecimal(dtKM.Rows[0]["QTY1"]).ToString("N0"))) *
                                      Convert.ToDecimal(dtKM.Rows[0]["DISCPRICE"].ToString())
                                     +
                                     (int)(txtsoluong.Value % Int32.Parse(Convert.ToDecimal(dtKM.Rows[0]["QTY1"]).ToString("N0"))) *
                                     Convert.ToDecimal(r["GiaGoc"]);
                        r["GhiChu"] = "Mua SL " + dtKM.Rows[0]["QTY1"].ToString() + " co gia " +
                                      Convert.ToDecimal(dtKM.Rows[0]["DISCPRICE"]).ToString("N0");
                    }
                }
                else
                {
                    r["GiaKM"] = r["GiaGoc"];
                    r["ThanhTien"] = Convert.ToDecimal(r["GiaGoc"]) * txtsoluong.Value;
                }
                _dsSKU.Rows.Add(r);
                _dsSKUAdd.Add((sku != string.Empty) ? sku : upc, _indexadd++);
                clearData();
                txtSKU.Focus();
            }
            GrDSSKU.DataSource = _dsSKU;
            
            //_dsSKUAdd.Add((sku != string.Empty) ? sku : upc, _indexadd++);
            //clearData();
        }

        private void btsearch_Click(object sender, EventArgs e)
        {
            FrmSearchBBGia bbGia=new FrmSearchBBGia();
            bbGia.MyGetData += new FrmSearchBBGia.GetStringSKU(InserchNewSKu);
            bbGia.ShowDialog();
        }
        public void InserchNewSKu(string sku,string sl)
        {
            txtSKU.Text = sku;
            if(sl==string.Empty)
                txtsoluong.Value = 1;
            else
            {
                int soluong = Convert.ToInt32(sl);
                if(soluong<=1)
                    txtsoluong.Value = 1;
                else
                {
                    txtsoluong.Value = soluong;
                }
            }
            txtsoluong_KeyDown(null,new KeyEventArgs(Keys.Enter));
        }

        private void FrmbangBaoGia_Shown(object sender, EventArgs e)
        {
            
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                try
                {
                    EntityDonDatHang dh = new EntityDonDatHang();
                    dh.ID = Guid.NewGuid().ToString();
                    dh.HoTen = txthotenKH.Text;
                    dh.DT = txtDienThoai.Text;
                    dh.DiaChi = txtDiaChi.Text;
                    dh.GhiChu = txtghichu.Text;
                    dh.NgayTao = DateTime.Now;
                    decimal soluong = 0;
                    decimal tongtien = 0;
                    for (int i = 0; i < gridView1.DataRowCount;i++)
                    {
                        DataRow row = gridView1.GetDataRow(i);
                        soluong += Convert.ToDecimal(row["SoLuong"]);
                        tongtien += Convert.ToDecimal(row["ThanhTien"]);
                    }
                    dh.SoLuong = soluong;
                    dh.ThanTien = tongtien;
                    CTLDonDatHang.InsertDonDatHang(dh, (DataTable)GrDSSKU.DataSource);
                }
                catch (Exception ex)
                {
                    CTLError.WriteError("btSave_Click ", ex.Message);
                    return;
                    throw;
                }
                
               
            }
        }
        public bool validate()
        {
            if (gridView1.DataRowCount <= 0)
            {
                InfoMessage.HienThi("Vui lòng nhập Sản phẩm cho đơn hàng", "Thông báo", "Thong Bao",
                                    HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                return false;
            }
                
            return true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //FrmQuanlyDDH quanlyDdh = new FrmQuanlyDDH();
            if (!CTLQuanLyForm.formName.Contains(_frmmain.quanlyDdh.Name))
            {
                if (_frmmain.quanlyDdh != null)
                {
                    _frmmain.quanlyDdh = new FrmQuanlyDDH();
                    _frmmain.xtraTabbedMdiManager.MdiParent = _frmmain;
                    CTLQuanLyForm.formName.Add(_frmmain.quanlyDdh.Name);
                    _frmmain.quanlyDdh.Text = "Quản lý đơn đặt hàng";
                    _frmmain.quanlyDdh.MdiParent = _frmmain;
                    _frmmain.quanlyDdh.Show();
                }
                else
                {
                    _frmmain.quanlyDdh = new FrmQuanlyDDH();
                    _frmmain.xtraTabbedMdiManager.MdiParent = _frmmain;
                    CTLQuanLyForm.formName.Add(_frmmain.quanlyDdh.Name);
                    _frmmain.quanlyDdh.Text = "Quản lý đơn đặt hàng";
                    _frmmain.quanlyDdh.MdiParent = _frmmain;

                    _frmmain.quanlyDdh.Show();
                }
            }
            else
            {
                if (_frmmain.quanlyDdh == null)
                {
                    _frmmain.quanlyDdh = new FrmQuanlyDDH();
                    _frmmain.quanlyDdh.MdiParent = _frmmain;
                    _frmmain.quanlyDdh.Activate();
                    _frmmain.quanlyDdh.BringToFront();
                }
                else
                {
                    _frmmain.quanlyDdh.MdiParent = _frmmain;
                    _frmmain.quanlyDdh.Activate();
                    _frmmain.quanlyDdh.BringToFront();
                }
            }
            
        }

        private void FrmDonDatHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            CTLQuanLyForm.formName.Remove(this.Name);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string upc = "";
            string sku = "";
            if (gridView1.RowCount >= 30)
                {
                    InfoMessage.HienThi("Số lượng SKU cho phép xuất bảng giá là 30 !", "Vui lòng kiểm tra lại",
                                        "Thong bao", HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                    return;
                }
                if (txtSKU.Text == string.Empty || txtSKU.Text.Length > 18)
                    return;

                string where = "";
                if (txtSKU.Text.Length <= 9)
                {
                    sku = _sokhong.Substring(0, 9 - txtSKU.Text.Length) + txtSKU.Text;
                    where = " and SKU='" + sku + "'";
                }
                else
                {
                    upc = _sokhong.Substring(0, 18 - txtSKU.Text.Length) + txtSKU.Text;
                    where = " and UPC='" + upc + "'";
                }
                if (!validate((sku != string.Empty) ? sku : upc))
                {
                    InfoMessage.HienThi("SKU đã có trong danh sách!", "Vui lòng thay đổi số lượng trong lưới", "Thong Bao",
                                        HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                    return;
                }
                TPSDataAccess dataAccess = new TPSDataAccess(_PathFileINVMST);
                TPSDataAccess dataAccessKM = new TPSDataAccess(_PathFileINVEVT);
                DataTable dt = new DataTable();
                dt = dataAccess.GetTableDM("Select SKU,UPC,Description,Price From INVMST where 1=1 " + where);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    InfoMessage.HienThi("SKU không có trong danh mục!", "Vui lòng kiểm tra lại", "Thong Bao",
                                        HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                    return;

                }
                DataTable dtKM = new DataTable();
                dtKM =
                    dataAccessKM.GetTableDM("select SKU,QTY1,DISCPRICE,Method From INVEVT where SKU='" +
                                            dt.Rows[0]["SKU"].ToString() + "' and " + (Math.Round(DateTime.Now.ToOADate()) + _Const_datetime) + @" >= Start 
                                                        and " + (Math.Round(DateTime.Now.ToOADate()) + _Const_datetime) + " <= stop ");
                DataRow r = _dsSKU.NewRow();
                r["SKU"] = dt.Rows[0]["SKU"].ToString();
                r["UPC"] = dt.Rows[0]["UPC"].ToString();
                r["Description"] = dt.Rows[0]["Description"].ToString();
                r["SoLuong"] = txtsoluong.Value;
                r["GiaGoc"] = dt.Rows[0]["Price"].ToString();
                r["ThanhTien"] = r["GiaGoc"];
                if (dtKM.Rows.Count > 0)
                {
                    r["Method"] = dtKM.Rows[0]["Method"].ToString();
                    r["DISCPRICE"] = dtKM.Rows[0]["DISCPRICE"].ToString();
                    r["QTY1"] = dtKM.Rows[0]["QTY1"].ToString();
                    if (dtKM.Rows[0]["Method"].ToString() == "25")
                    {
                        r["GiaKM"] = dtKM.Rows[0]["DISCPRICE"].ToString();
                        r["ThanhTien"] = txtsoluong.Value * Convert.ToDecimal(r["GiaKM"]);
                    }
                    else if (dtKM.Rows[0]["Method"].ToString() == "2")
                    {
                        r["ThanhTien"] = (int)(txtsoluong.Value / Int32.Parse(Convert.ToDecimal(dtKM.Rows[0]["QTY1"]).ToString("N0"))) *
                                      Convert.ToDecimal(dtKM.Rows[0]["DISCPRICE"].ToString())
                                     +
                                     (int)(txtsoluong.Value % Int32.Parse(Convert.ToDecimal(dtKM.Rows[0]["QTY1"]).ToString("N0"))) *
                                     Convert.ToDecimal(r["GiaGoc"]);
                        r["GhiChu"] = "Mua SL " + dtKM.Rows[0]["QTY1"].ToString() + " co gia " +
                                      Convert.ToDecimal(dtKM.Rows[0]["DISCPRICE"]).ToString("N0");
                    }
                }
                else
                {
                    r["GiaKM"] = r["GiaGoc"];
                    r["ThanhTien"] = Convert.ToDecimal(r["GiaGoc"]) * txtsoluong.Value;
                }
                _dsSKU.Rows.Add(r);
                _dsSKUAdd.Add((sku != string.Empty) ? sku : upc, _indexadd++);
                clearData();
                txtSKU.Focus();
            
            GrDSSKU.DataSource = _dsSKU;
    
            
        }

        private void txtsoluong_Enter(object sender, EventArgs e)
        {
            txtsoluong.Select(0,txtsoluong.Value.ToString().Length);
        }
        
    }
}