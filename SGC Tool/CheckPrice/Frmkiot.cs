using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraGrid.Views.Grid;
using SGC_Tool.HelpFile;
using SGC_Tool.MyControls;
using TOOLChuyenDuLieu.ControlEntity;
using TOOLChuyenDuLieu.HelpFile;
using TOOLChuyenDuLieu.MyForm.CheckPrice;

namespace TOOLChuyenDuLieu.MyForm.FrmmainCheckPrice
{
    public partial class Frmkiot : DevExpress.XtraEditors.XtraForm
    {
        #region Skin
        //public DefaultLookAndFeel Skin = new DefaultLookAndFeel();

        #endregion

        #region

        public delegate void ReturnBarcode(string mabarcode);

        public ReturnBarcode rtbarcode;

        #endregion

        private Form frmmain;
        private int _sogiay=60;
        public Frmkiot()
        {
            InitializeComponent();
            //BonusSkins.Register();
            //OfficeSkins.Register();
            //SkinManager.EnableFormSkins();
            //this.Skin.LookAndFeel.SetSkinStyle("Xmas 2008 Blue");
            textBox1.Focus();
            //xtraTabPage1.Visible = false;

        }
        public Frmkiot(CheckGiaFull main,DataTable dtcustommer,string makh)
        {
            InitializeComponent();
            textBox1.BackColor = Color.FromArgb(192, 220, 255);
            textBox1.ForeColor = Color.FromArgb(192, 220, 255);
            //if(Config._timemer!=string.Empty)
            //    _sogiay =Convert.ToInt32(Config._timemer) * 60;
            //BonusSkins.Register();
            //OfficeSkins.Register();
            //SkinManager.EnableFormSkins();
            //this.Skin.LookAndFeel.SetSkinStyle("Xmas 2008 Blue");
            frmmain = main;
            SQLHelper helper=new SQLHelper();
            if(dtcustommer.Rows.Count<=0)
                return;
            //tabpage1
            //labhoten.Text = dtcustommer.Rows[0]["HoLot"].ToString() + " " + dtcustommer.Rows[0]["Ten"].ToString();
            //labsodt.Text = (dtcustommer.Rows[0]["DTDD"].ToString() == string.Empty) ? dtcustommer.Rows[0]["DTBan"].ToString() : dtcustommer.Rows[0]["DTDD"].ToString();
            //labmathe.Text = dtcustommer.Rows[0]["MaThe13"].ToString();
            DataTable dt= helper.GetInfoCustommer(makh);
            loadThongTin(dt);
            //xtraTabPage1.Visible = false;
        }
        public Frmkiot(FrmCheckGia main, DataTable dtcustommer, string makh)
        {
            InitializeComponent();
            textBox1.BackColor = Color.FromArgb(192, 220, 255);
            textBox1.ForeColor = Color.FromArgb(192, 220, 255);
            //if (Config._timemer != string.Empty)
            //    _sogiay = Convert.ToInt32(Config._timemer) * 60;
            //BonusSkins.Register();
            //OfficeSkins.Register();
            //SkinManager.EnableFormSkins();
            //this.Skin.LookAndFeel.SetSkinStyle("Xmas 2008 Blue");
            frmmain = main;
            SQLHelper helper = new SQLHelper();
            if (dtcustommer.Rows.Count <= 0)
                return;
            //labhoten.Text = dtcustommer.Rows[0]["HoLot"].ToString() + " " + dtcustommer.Rows[0]["Ten"].ToString();
            //labsodt.Text = (dtcustommer.Rows[0]["DTDD"].ToString() == string.Empty) ? dtcustommer.Rows[0]["DTBan"].ToString() : dtcustommer.Rows[0]["DTDD"].ToString();
            //labmathe.Text = dtcustommer.Rows[0]["MaThe13"].ToString();
            DataTable dt = helper.GetInfoCustommer(makh);
            loadThongTin(dt);
            
        }
        private void btthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loadThongTin(DataTable dt)
        {
            if(dt==null)
                return;
            try
            {
                if(dt.Rows.Count==1)
                {
                    DataRow row = dt.Rows[0];
                    //labdiemmuahangChinhthuc.Text = row["DiemMuaHangDauNgay"].ToString();
                    //labdiemthuongChinhthuc.Text = row["DiemThuongDauNgay"].ToString();
                    //labdiemdasudungChinhThuc.Text = row["DiemDaSuDungDauNgay"].ToString();
                    //labdiemconlaiChinhthuc.Text = row["DiemConLaiDauNgay"].ToString();
                    //labdiemmuahangGhinhan.Text = row["DiemMuaHangTrongNgay"].ToString();
                    //labDiemThuongGhiNhan.Text = row["DiemThuongTrongNgay"].ToString();
                    //labDiemDaSuDungGhiNhan.Text = row["DiemDaSuDungTrongNgay"].ToString();
                    //labDiemConLaiGiNhan.Text = row["DiemConLaiTrongNgay"].ToString();
                    //labSoPhieuQuaTang.Text = (row["SoPhieuQTDaNhan"].ToString() == string.Empty)
                    //                             ? "0"
                    //                             : row["SoPhieuQTDaNhan"].ToString();
                    //labNgayIn.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    //labDiemConLaiNamTruoc.Text = row["DiemNamTruoc"].ToString();
                    //labdiemmuahangchinhthucdenhet.Text =Convert.ToDateTime(row["Ngay"]).ToString("dd/MM/yyyy");
                }

            }
            catch (Exception ex)
            {
                CTLError.WriteError("FrmKiot LoadThongTin", ex.Message);
                return ;
                throw;
            }
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if(_sogiay--<=0)
            //    this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (textBox1.Text.Length == 7 || textBox1.Text.Length == 13)
            //{
            //    string ma13 = "";
            //    SQLHelper helper = new SQLHelper();
            //    DataTable dtcustommer = helper.InfoCustommer(textBox1.Text);
            //    if (dtcustommer != null)
            //    {
            //        if (dtcustommer.Rows.Count > 0)
            //        {
            //            _sogiay = 60;
            //            if (Config._timemer!=null)
            //                _sogiay =Convert.ToInt32(Config._timemer)*60;
            //            ConvertBarCode cv = new ConvertBarCode();
            //            if (Convert.ToInt64(textBox1.Text) > 25000)
            //                ma13 = cv.CreaBarCode(textBox1.Text);
            //            else if (textBox1.Text.Length != 13)
            //                ma13 = cv.CreaBarCodeTV(textBox1.Text);
            //            if (textBox1.Text.Length == 13)
            //                ma13 = textBox1.Text;
            //            //Frmkiot frmkiot = new Frmkiot(this, dtcustommer, ma13);
            //            //this.OpenDialog(frmkiot);
            //            if (dtcustommer.Rows.Count <= 0)
            //                return;
            //            labhoten.Text = dtcustommer.Rows[0]["HoLot"].ToString() + " " + dtcustommer.Rows[0]["Ten"].ToString();
            //            labsodt.Text = (dtcustommer.Rows[0]["DTDD"].ToString() == string.Empty) ? dtcustommer.Rows[0]["DTBan"].ToString() : dtcustommer.Rows[0]["DTDD"].ToString();
            //            labmathe.Text = dtcustommer.Rows[0]["MaThe13"].ToString();
            //            DataTable dt = helper.GetInfoCustommer(ma13);
            //            if(dt==null)
            //            {
            //                labdiemmuahangChinhthuc.Text = "_ _";
            //                labdiemthuongChinhthuc.Text = "_ _";
            //                labdiemdasudungChinhThuc.Text = "_ _";
            //                labdiemconlaiChinhthuc.Text = "_ _";
            //                labdiemmuahangGhinhan.Text = "_ _";
            //                labDiemThuongGhiNhan.Text = "_ _";
            //                labDiemDaSuDungGhiNhan.Text = "_ _";
            //                labDiemConLaiGiNhan.Text = "_ _";
            //                labSoPhieuQuaTang.Text = "_ _";
            //                labNgayIn.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //                labDiemConLaiNamTruoc.Text = "_ _";
            //                        labdiemmuahangchinhthucdenhet.Text = "_ _";
            //            }
            //            else
            //            {
            //                loadThongTin(dt);
            //            }
                            
            //            textBox1.Clear();
            //        }
            //        else if(textBox1.Text.Length==13)
            //        {
            //            if (rtbarcode != null)
            //            {
            //                rtbarcode(textBox1.Text);
            //                this.Close();
            //            }
            //        }
            //    }
            //    else if (textBox1.Text.Length == 13)
            //    {
            //        if (rtbarcode != null)
            //        {
            //            rtbarcode(textBox1.Text);
            //            this.Close();
            //        }
                        
            //    }
            //}
            //if(textBox1.Text.Length>13)
            //    textBox1.Clear();
        }

        private void Frmkiot_FormClosing(object sender, FormClosingEventArgs e)
        {
            CTLQuanLyForm.formName.Remove(this.Name);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                //if (textBox1.Text.Length==13)
                //{
                //    textBox1.Text = textBox1.Text.Substring(2, 10);
                //}
                if (textBox1.Text.Length !=10)
                {
                    labthongbao.Visible = true;
                    labthongbao.Text = "Vui long nhap Ma 10 cua KH";
                    return;
                }
                //if (textBox1.Text.Length == 10 &&radKHTT.Checked)
                //{
                //    string ma13 = "";
                //    SQLHelper helper = new SQLHelper();
                //    DataTable dtcustommer = helper.InfoCustommer(textBox1.Text.Substring(3,7));
                //    if (dtcustommer != null)
                //    {
                //        if (dtcustommer.Rows.Count > 0)
                //        {
                //            //_sogiay = 60;
                //            //if (Config._timemer != null)
                //            //    _sogiay = Convert.ToInt32(Config._timemer) * 60;
                //            ConvertBarCode cv = new ConvertBarCode();
                //            //if (Convert.ToInt64(textBox1.Text) > 25000)
                //            ma13 = cv.CreaBarCode(textBox1.Text.Substring(3, 7));
                //            //else if (textBox1.Text.Length != 13)
                //            //    ma13 = cv.CreaBarCodeTV(textBox1.Text);
                //            //if (textBox1.Text.Length == 13)
                //            //    ma13 = textBox1.Text;
                //            //Frmkiot frmkiot = new Frmkiot(this, dtcustommer, ma13);
                //            //this.OpenDialog(frmkiot);
                //            if (dtcustommer.Rows.Count <= 0)
                //                return;
                //            labhoten.Text = dtcustommer.Rows[0]["HoLot"].ToString() + " " + dtcustommer.Rows[0]["Ten"].ToString();
                //            labsodt.Text = (dtcustommer.Rows[0]["DTDD"].ToString() == string.Empty) ? dtcustommer.Rows[0]["DTBan"].ToString() : dtcustommer.Rows[0]["DTDD"].ToString();
                //            labmathe.Text = dtcustommer.Rows[0]["MaThe13"].ToString();
                //            DataTable dt = helper.GetInfoCustommer(ma13);
                //            if (dt == null)
                //            {
                //                labdiemmuahangChinhthuc.Text = "_ _";
                //                labdiemthuongChinhthuc.Text = "_ _";
                //                labdiemdasudungChinhThuc.Text = "_ _";
                //                labdiemconlaiChinhthuc.Text = "_ _";
                //                labdiemmuahangGhinhan.Text = "_ _";
                //                labDiemThuongGhiNhan.Text = "_ _";
                //                labDiemDaSuDungGhiNhan.Text = "_ _";
                //                labDiemConLaiGiNhan.Text = "_ _";
                //                labSoPhieuQuaTang.Text = "_ _";
                //                labNgayIn.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //                labDiemConLaiNamTruoc.Text = "_ _";
                //                labdiemmuahangchinhthucdenhet.Text = "_ _";
                //            }
                //            else
                //            {
                //                loadThongTin(dt);
                //            }

                //            textBox1.Clear();
                //        }
                //        else if (textBox1.Text.Length == 13)
                //        {
                //            if (rtbarcode != null)
                //            {
                //                rtbarcode(textBox1.Text);
                //                this.Close();
                //            }
                //        }
                //    }
                //    else if (textBox1.Text.Length == 13)
                //    {
                //        if (rtbarcode != null)
                //        {
                //            rtbarcode(textBox1.Text);
                //            this.Close();
                //        }

                //    }
                //}
                labthongbao.Visible = false;
                if(textBox1.Text.Length==10&&radWDSS.Checked)
                {
                    //code get infomation cust Windss
                    TPSDataAccess access = new TPSDataAccess("H:\\Data\\CUST.tps");
                    DataTable source = access.GetTableDM(@"Select Mcreatedate,Xlastmoddate,Pricecategory,Pclienttype,Allowchrg,Mfname,Mlname,Mcustnum,Jcuststatus from CUST where Mcustnum=" + textBox1.Text);
                    if(source!=null&&source.Rows.Count>0)
                    {
                        labWMa.Text = source.Rows[0]["Mcustnum"].ToString();
                        //labWten.Text = source.Rows[0]["Mlname"].ToString() + " " + source.Rows[0]["Mfname"].ToString();
                        labWngaytao.Text = source.Rows[0]["Mcreatedate"] != null ? ((DateTime)source.Rows[0]["Mcreatedate"]).ToString("dd/MM/yyyy") : "";
                        labWngaychinhsua.Text = source.Rows[0]["Jcuststatus"].ToString();
                        labWSogia.Text = source.Rows[0]["Pricecategory"].ToString();
                        labWLoaiKH.Text = source.Rows[0]["Pclienttype"].ToString();
                        labWmuano.Text = source.Rows[0]["Allowchrg"].ToString();
                    }
                    else
                    {
                        labthongbao.Visible = true;
                        labthongbao.Text = "Vui lòng kiểm tra mã KH khác";
                        
                        labWMa.Text = "_ _";
                        //labWten.Text = "_ _";
                        labWngaytao.Text = "_ _";
                        labWngaychinhsua.Text = "_ _";
                        labWSogia.Text = "_ _";
                        labWLoaiKH.Text = "_ _";
                        labWmuano.Text = "_ _";
                    }

                }
                if (textBox1.Text.Length > 13)
                    textBox1.Clear();
            }
        }

        private void radKHTT_CheckedChanged(object sender, EventArgs e)
        {
            if(radKHTT.Checked)
            {
                xtraTabControl1.SelectedTabPageIndex = 0;
            }
        }

        private void radWDSS_CheckedChanged(object sender, EventArgs e)
        {
            if(radWDSS.Checked)
            {
                xtraTabControl1.SelectedTabPageIndex = 1;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ImPort_Excel();
        }
        public void ImPort_Excel()
        {
            DataTable dt = new DataTable();
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "*.xls|*.xls|*.xlsx|*.xlsx";
                TOOLChuyenDuLieu.HelpFile.CTLImportExcel excel = new TOOLChuyenDuLieu.HelpFile.CTLImportExcel();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(dialog.FileName);
                    if (file.Extension.ToString().Trim().ToUpper() == ".XLS")
                        dt = excel.getDataFromXLS(dialog.FileName);
                    else if (file.Extension.ToString().Trim().ToUpper() == ".XLSX")
                    {
                        dt = excel.getDataFromXLS2007(dialog.FileName);
                    }
                    int dem = 0;
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName.ToUpper() == "CUSTID")
                        {
                            dem++;
                        }
                    }
                    if (dem == 0)
                        return;
                    DataTable table = KhoitaoDSPriceBook();
                    if (dt.Rows.Count >= 1)
                    {
                        
                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow dataRow = table.NewRow();
                            dataRow["CUSTID"] = row["CUSTID"].ToString();
                            dataRow["PRICEBOOK"] = row["PRICEBOOK"].ToString();
                            dataRow["DATE"] = row["DATE"].ToString();
                            TPSDataAccess access = new TPSDataAccess("H:\\Data\\CUST.pts");
                            DataTable source = access.GetTableDM(@"Select MCUSTNUM,Pricecategory from CUST 
                                                                where 1=1 and MCUSTNUM="+row["CUSTID"].ToString());
                            if(source==null)
                            {
                                dataRow["Check"] = true;
                            }
                            else if(source.Rows.Count==0)
                            {
                                dataRow["Check"] = true;
                            }
                            else
                            {
                                if (source.Rows[0]["Pricecategory"].ToString().Trim() != row["PRICEBOOK"].ToString().Trim())
                                    dataRow["Check"] = true;
                                else
                                {
                                    dataRow["Check"] = false;
                                }
                                dataRow["Pricecategory"] = source.Rows[0]["Pricecategory"].ToString();
                            }
                            table.Rows.Add(dataRow);
                        }
                        
                    }
                    GrDSPriceSKU.DataSource = table;
                }

            }
            catch (Exception ex)
            {
                CTLError.WriteError("FrmImportfile ImportExcel", ex.Message);
                return;
                throw new Exception(ex.Message);
            }

        }
        public DataTable KhoitaoDSPriceBook()
        {
            DataTable dt=new DataTable();
            dt.Columns.Add("Check", Type.GetType("System.Boolean"));
            dt.Columns.Add("CUSTID", Type.GetType("System.String"));
            dt.Columns.Add("PRICEBOOK", Type.GetType("System.String"));
            dt.Columns.Add("DATE", Type.GetType("System.String"));
            dt.Columns.Add("Pricecategory", Type.GetType("System.String"));
            return dt;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool check = Convert.ToBoolean(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Check"]));
                if (check)
                    e.Appearance.BackColor = Color.FromArgb(150, 151, 149);
            }
        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Frmkiot_Load(object sender, EventArgs e)
        {
            //xtraTabPage1.Visible = false;
        }
    }
}