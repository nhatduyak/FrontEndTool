using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CheckPrice;
using DevExpress.LookAndFeel;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using TOOLChuyenDuLieu.ControlEntity;
using TOOLChuyenDuLieu.HelpFile;
using TOOLChuyenDuLieu.MyForm.FrmmainCheckPrice;
using SGC_Tool.HelpFile;

namespace TOOLChuyenDuLieu.MyForm.CheckPrice
{
    public partial class CheckGiaFull : DevExpress.XtraEditors.XtraForm
    {
        #region Skin
        public DefaultLookAndFeel Skin=new DefaultLookAndFeel();

        #endregion

        private long _sogiay=60;
        private bool flag = false;
        private string _pathFileDM=@"INVMST.TPS";
        private string _pathFileGia = @"INVEVT.TPS";
        private string _pathFileUPC = @"INVUPC.TPS";
        private string PhatSinhUPC = "0000000000";
        DataTable tbM2=new DataTable();
        DataTable tbM25=new DataTable();
        private long _Const_datetime = 36161;
        private string _sku = "";
        public CheckGiaFull()
        {
            InitializeComponent();
            Config.GetConfiguration();
            //BonusSkins.Register();
            //OfficeSkins.Register();
            //SkinManager.EnableFormSkins();
            //this.Skin.LookAndFeel.SetSkinStyle("Xmas 2008 Blue");
            IntControl();
            //innitgrid();
        }
        #region InitControl
        private void IntControl()
        {
            //dETuNgay.EditValue = DateTime.Today.AddDays(-7);
            //dEDenNgay.EditValue = DateTime.Now;
        }
        #endregion
        private void FrmCheckGia_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F5)
            {
                if(txtsku.Text!=string.Empty)
                {
                    string masku = txtsku.Text;
                    if (txtsku.Text.Length <= 7)
                        masku = "00" + txtsku.Text;
                    else if(txtsku.Text.Length>9)
                    {
                        if(txtsku.Text.Length<=14)
                            masku = GetSKU(PhatSinhUPC.Substring(0,18-txtsku.Text.Length)+txtsku.Text);
                        else
                            masku = GetSKU(txtsku.Text);
                    }
                    TPSDataAccess access=new TPSDataAccess(Path.Combine(Config._pathfileWinDSS,this._pathFileDM));
                    DataTable dt = access.GetDataTable("Select SKU,Description,Price from INVMST where 1=1" + ((txtsku.Text == string.Empty) ? "" : " and SKU='" + masku + "'"));
                    if (dt.Rows.Count > 0)
                    {
                        _sku = dt.Rows[0]["SKU"].ToString();
                        labten.Text = dt.Rows[0]["Description"].ToString();
                        labgia.Text =Convert.ToDecimal(dt.Rows[0]["PRICE"]).ToString("N2")+" VND";
                        LoadPromo(_sku);
                    }
                    else
                    {
                        _sku = "";
                        //labten.Text = "_ _";
                        //labgia.Text = "_ _";
                        //labslpos.Text = "0";
                        //labgiapos.Text = "_ _";
                        //labslKMTL.Text = "0";
                        //labGiaKMTL.Text = "_ _";
                        //gridControl1.DataSource = null;
                    }
                }
                else
                {
                    labten.Text = "_ _";
                    labgia.Text = "_ _";
                    labslpos.Text = "0";
                    labgiapos.Text = "_ _";
                    labslKMTL.Text = "0";
                    labGiaKMTL.Text = "_ _";
                   // gridControl1.DataSource = null;
                    return;
                }
            }
        }

        private void txtsku_EditValueChanged(object sender, EventArgs e)
        {
        }
        public void LoadPromo(string sku)
        {
            if (_sku == string.Empty)
            {
                return;
            }
            string masku = txtsku.Text;
            if (txtsku.Text.Length <= 7)
                masku = "00" + txtsku.Text;
            else if (txtsku.Text.Length > 9)
            {
                if (txtsku.Text.Length <= 14)
                    masku = GetSKU(PhatSinhUPC.Substring(0, 18 - txtsku.Text.Length) + txtsku.Text);
                else
                    masku = GetSKU(txtsku.Text);
            }
            TPSDataAccess access = new TPSDataAccess(Path.Combine(Config._pathfileWinDSS,this._pathFileGia));
            DataTable dt = access.GetDataTable_gia((@"Select SKU,MeThod,Start,Stop,Qty1,DiscPrice,Code,Prc_Key ,Price
                                                        from INVEVT 
                                                        where 1=1 
                                                        and Method in (2,25) 
                                                        and " + (Math.Round(DateTime.Now.ToOADate()) + _Const_datetime) + @" >= Start 
                                                        and " + (Math.Round(DateTime.Now.ToOADate())+_Const_datetime) + " <= stop "
                                                              + ((txtsku.Text == string.Empty) ? "" : " and SKU='" + masku + "'"))
                                                              );
            //DataTable dt = access.GetDataTable_gia(("Select SKU,MeThod,START,Stop,Qty1,DiscPrice from INVEVT where 1=1 and Method in (2,25) " + ((txtsku.Text == string.Empty) ? "" : " and SKU='" + txtsku.Text + "'")), dETuNgay.DateTime, dEDenNgay.DateTime);
            if (dt.Rows.Count > 0)
            {
                tbM2.Rows.Clear();
                tbM25.Rows.Clear();
                dt=Fixtable(dt);
                //gridControl1.DataSource = dt;
                //gridView1.ExpandAllGroups();
                innitgrid();
                if (tbM2.Select("MeThod=2").Length >= 1)
                {
                    DataRow row;
                    if (tbM2.Select("MeThod=2 and Prc_Key=Min(Prc_Key)").Length==1)
                    {
                        row = tbM2.Select("MeThod=2 and Prc_Key=Min(Prc_Key)")[0];
                        labGiaMH.Text = "Thời gian : " + Convert.ToDateTime(row["Start"]).ToString("dd/MM/yyyy") + "  ==> " +
                                        Convert.ToDateTime(row["Stop"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        Int32 prc_key = Convert.ToInt32(tbM2.Select("MeThod=2 and Prc_Key=Min(Prc_Key)")[0]["Prc_key"]);
                        row = tbM2.Select("MeThod=2 and Prc_Key="+prc_key+" and Code=max(Code)")[0];
                        labGiaMH.Text = "Thời gian : " +Convert.ToDateTime(row["Start"]).ToString("dd/MM/yyyy") + "  ==> " +
                                        Convert.ToDateTime(row["Stop"]).ToString("dd/MM/yyyy");
                    }
                        
                    labGiaKMTL.Text = Convert.ToDecimal(row["DiscPrice"]).ToString("N2");
                    labslKMTL.Text = Convert.ToInt32(row["Qty1"]).ToString("N0");
                    labGiaKMTL.Visible = true;
                    labslKMTL.Visible = true;
                    labelControl10.Visible = true;
                }
                else
                {
                    labGiaKMTL.Text = "0";
                    labslKMTL.Text = "0";
                    labGiaKMTL.Visible = false;
                    labslKMTL.Visible = false;
                    labelControl10.Visible = false;
                    
                }
                if (tbM25.Select("MeThod=25").Length >= 1)
                {
                    DataRow row;
                    if(tbM25.Select("MeThod=25 and Prc_Key=Min(Prc_Key)").Length==1)
                    {
                        row= tbM25.Select("MeThod=25 and Prc_Key=Min(Prc_Key)")[0];
                        labGiaMH.Text = "Thời gian : " + Convert.ToDateTime(row["Start"]).ToString("dd/MM/yyyy") + " ==> " +
                                          Convert.ToDateTime(row["Stop"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        Int32 prc_key = Convert.ToInt32(tbM2.Select("MeThod=25 and Prc_Key=Min(Prc_Key)")[0]["Prc_key"]);
                        row = tbM25.Select("MeThod=25 and Prc_Key="+prc_key+" and Code=max(Code)")[0];
                        labGiaMH.Text = "Thời gian : " + Convert.ToDateTime(row["Start"]).ToString("dd/MM/yyyy") + "  ==> " +
                                        Convert.ToDateTime(row["Stop"]).ToString("dd/MM/yyyy");
                    }
                    labgiapos.Text = Convert.ToDecimal(row["Price"]).ToString("N2");
                    labslpos.Text = "1";
                    labgiapos.Visible = true;
                    labslpos.Visible = true;
                    labelControl4.Visible=true;
                }
                else
                {
                    labgiapos.Text = "_ _";
                    labslpos.Text = "0";
                    labgiapos.Visible = false;
                    labslpos.Visible = false;
                    labelControl4.Visible = false;
                }
            }
            else
            {
                labGiaKMTL.Visible = false;
                labslKMTL.Visible = false;
                labelControl10.Visible = false;
                labgiapos.Visible = false;
                labslpos.Visible = false;
                labelControl4.Visible = false;
                labGiaMH.Visible = false;
                //gridControl1.DataSource = null;
                //innitgrid();
            }
        }
        public DataTable Fixtable(DataTable dt)
        {
            DataTable dataTable=new DataTable();
            dataTable.Columns.AddRange(new DataColumn[]{new DataColumn("STT", typeof(System.Int32)) 
                                                   , new DataColumn("SKU", typeof(System.String)) 
                                                   ,new DataColumn("MeThod", typeof(System.String))
                                                    ,new DataColumn("Start", typeof(System.DateTime))
                                                     ,new DataColumn("Stop", typeof(System.DateTime))
                                                         ,new DataColumn("Qty1", typeof(System.Int32))
                                                         ,new DataColumn("DiscPrice", typeof(System.Decimal))
                                                         ,new DataColumn("Code", typeof(System.Decimal))
                                                             ,new DataColumn("Prc_Key", typeof(System.Int32))
                                                        ,new DataColumn("Price", typeof(System.Decimal))});
            if(tbM2.Columns.Count==0)
                tbM2.Columns.AddRange(new DataColumn[]{new DataColumn("STT", typeof(System.Int32)) 
                                                       , new DataColumn("SKU", typeof(System.String)) 
                                                       ,new DataColumn("MeThod", typeof(System.String))
                                                        ,new DataColumn("Start", typeof(System.DateTime))
                                                         ,new DataColumn("Stop", typeof(System.DateTime))
                                                             ,new DataColumn("Qty1", typeof(System.Int32))
                                                             ,new DataColumn("DiscPrice", typeof(System.Decimal))
                                                             ,new DataColumn("Code", typeof(System.Decimal))
                                                                 ,new DataColumn("Prc_Key", typeof(System.Int32))
                                             ,new DataColumn("Price", typeof(System.Decimal))});
            if (tbM25.Columns.Count == 0)    
                tbM25.Columns.AddRange(new DataColumn[]{new DataColumn("STT", typeof(System.Int32)) 
                                                       , new DataColumn("SKU", typeof(System.String)) 
                                                       ,new DataColumn("MeThod", typeof(System.String))
                                                        ,new DataColumn("Start", typeof(System.DateTime))
                                                         ,new DataColumn("Stop", typeof(System.DateTime))
                                                             ,new DataColumn("Qty1", typeof(System.Int32))
                                                             ,new DataColumn("DiscPrice", typeof(System.Decimal))
                                                             ,new DataColumn("Code", typeof(System.Decimal))
                                                                 ,new DataColumn("Prc_Key", typeof(System.Int32))
                                                            ,new DataColumn("Price", typeof(System.Decimal))});
            int i = 0;
            foreach (DataRow dataRow in dt.Rows)
            {
                i++;
                DataRow row = dataTable.NewRow();
                row["STT"] = i;
                row["SKU"] = dataRow["SKU"];
                if (dataRow["MeThod"].ToString().Trim()=="25")
                    row["MeThod"] = "giảm giá tại POS";
                else if(dataRow["MeThod"].ToString().Trim()=="2")
                    row["MeThod"] = "giảm giá theo lượng";
                row["Start"] = DateTime.FromOADate(Convert.ToDouble(dataRow["Start"]) - _Const_datetime);
                row["Stop"] = DateTime.FromOADate(Convert.ToDouble(dataRow["Stop"]) - _Const_datetime);
                row["Qty1"] =Convert.ToInt32(dataRow["Qty1"]).ToString("N0");
                row["DiscPrice"] =Convert.ToDecimal(dataRow["DiscPrice"]).ToString("N2");
                if (dataRow["Code"].ToString() != string.Empty)
                    row["Code"] = Convert.ToDecimal(dataRow["Code"]).ToString("N0");
                else
                    row["Code"] = 0;
                if (dataRow["Prc_Key"].ToString() != string.Empty)
                    row["Prc_Key"] = Convert.ToInt64(dataRow["Prc_Key"]).ToString("N0");
                else
                    row["Prc_Key"] = 0;
                row["Price"] = Convert.ToDecimal(dataRow["Price"]).ToString("N2");
                dataTable.Rows.Add(row);
                if(dataRow["MeThod"].ToString().Trim()=="2")
                {
                    DataRow row2 = tbM2.NewRow();
                    row2["STT"] = i;
                    row2["SKU"] = dataRow["SKU"];
                    row2["MeThod"] = dataRow["MeThod"];
                    row2["Start"] = DateTime.FromOADate(Convert.ToDouble(dataRow["Start"]) - _Const_datetime);
                    row2["Stop"] = DateTime.FromOADate(Convert.ToDouble(dataRow["Stop"]) - _Const_datetime);
                    row2["Qty1"] = Convert.ToInt32(dataRow["Qty1"]).ToString("N0");
                    row2["DiscPrice"] = Convert.ToDecimal(dataRow["DiscPrice"]).ToString("N2");
                    if (dataRow["Code"].ToString() != string.Empty)
                        row2["Code"] = Convert.ToDecimal(dataRow["Code"]).ToString("N0");
                    else
                        row2["Code"] = 0;
                    if (dataRow["Prc_Key"].ToString() != string.Empty)
                        row2["Prc_Key"] = Convert.ToInt32(dataRow["Prc_Key"]).ToString("N0");
                    else
                        row2["Prc_Key"] = 0;
                    row2["Price"] = Convert.ToDecimal(dataRow["Price"]).ToString("N2");
                    tbM2.Rows.Add(row2);
                }
                else if (dataRow["MeThod"].ToString().Trim() == "25")
                {
                    DataRow row25 = tbM25.NewRow();
                    row25["STT"] = i;
                    row25["SKU"] = dataRow["SKU"];
                    row25["MeThod"] = dataRow["MeThod"];
                    row25["Start"] = DateTime.FromOADate(Convert.ToDouble(dataRow["Start"]) - _Const_datetime);
                    row25["Stop"] = DateTime.FromOADate(Convert.ToDouble(dataRow["Stop"]) - _Const_datetime);
                    row25["Qty1"] = Convert.ToInt32(dataRow["Qty1"]).ToString("N0");
                    row25["DiscPrice"] = Convert.ToDecimal(dataRow["DiscPrice"]).ToString("N2");
                    if (dataRow["Code"].ToString() != string.Empty)
                        row25["Code"] = Convert.ToDecimal(dataRow["Code"]).ToString("N0");
                    else
                        row25["Code"] = 0;
                    if (dataRow["Prc_Key"].ToString() != string.Empty)
                        row25["Prc_Key"] = Convert.ToInt32(dataRow["Prc_Key"]).ToString("N0");
                    else
                        row25["Prc_Key"] = 0;
                    row25["Price"] = Convert.ToDecimal(dataRow["Price"]).ToString("N2");
                    tbM25.Rows.Add(row25);
                }
            }
            return dataTable;
        }
        #region InitGrid
        public void innitgrid()
        {
            //XtraGridSupportExt.TextCenterColumn(sku, "SKU");
            //XtraGridSupportExt.TextCenterColumn(MeThod, "MeThod");
            //XtraGridSupportExt.TextCenterColumn(Start, "Start");            
            //XtraGridSupportExt.TextCenterColumn(Stop, "Stop");
            //XtraGridSupportExt.TextCenterColumn(Qty1, "Qty1");
            //XtraGridSupportExt.TextCenterColumn(DiscPrice, "DiscPrice");
            //DiscPrice.DisplayFormat.FormatString = "N2";
            //Qty1.DisplayFormat.FormatString = "N0";
            //gridView1.ClearSorting();
            //gridView1.Columns["Prc_Key"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            //gridView1.Columns["Code"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
        }
        #endregion

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                //string strSTT = View.GetRowCellDisplayText(e.RowHandle, View.Columns["STT"]);
                if (e.RowHandle % 2 == 0)
                {
                    e.Appearance.BackColor = Color.FromArgb(189, 224, 253);
                    e.Appearance.BackColor2 = Color.FromArgb(189, 224, 253);
                }
            }
        }
        public string GetSKU(string UPC)
        {
            TPSDataAccess access=new TPSDataAccess(Path.Combine(Config._pathfileWinDSS,_pathFileUPC));
            return access.GetSkuToUPC(UPC);
        }

        private void txtsku_TextChanged_1(object sender, EventArgs e)
        {
            if (txtsku.Text == string.Empty)
            {
                //labten.Text = "_ _";
                //labgia.Text = "_ _";
                //labslpos.Text = "0";
                //labgiapos.Text = "_ _";
                //labslKMTL.Text = "0";
                //labGiaKMTL.Text = "_ _";
                //gridControl1.DataSource = null;

                return;
            }
            if (txtsku.Text != string.Empty)
            {
                string masku = txtsku.Text;
                if (txtsku.Text.Length <= 7)
                    masku = "00" + txtsku.Text;
                else if (txtsku.Text.Length > 9)
                {
                    if (txtsku.Text.Length <= 14)
                        masku = GetSKU(PhatSinhUPC.Substring(0, 18 - txtsku.Text.Length) + txtsku.Text);
                    else
                        masku = GetSKU(txtsku.Text);
                }
                try
                {
                    Image myimg = Code128Rendering.MakeBarcodeImage(masku, 3, true);
                    pictureBox2.Image = myimg;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                }
                TPSDataAccess access = new TPSDataAccess(Path.Combine(Config._pathfileWinDSS, this._pathFileDM));
                DataTable dt = access.GetDataTable("Select SKU,Description,Price from INVMST where 1=1" + ((txtsku.Text == string.Empty) ? "" : " and SKU='" + masku + "'"));
                if (dt.Rows.Count > 0)
                {
                    _sogiay = 60;
                    if (Config._timemer != string.Empty)
                        _sogiay = Convert.ToInt64(Config._timemer) * 60;
                    flag = true;
                    labelControl3.Visible = true;
                    labelControl5.Visible = true;
                    labten.Visible = true;
                    labgia.Visible = true;
                    pictureBox2.Visible = true;
                    pictBarcode.Visible = true;
                    labGiaKMTL.Visible = true;
                    labslKMTL.Visible = true;
                    labelControl10.Visible = true;
                    labgiapos.Visible = true;
                    labslpos.Visible = true;
                    labelControl4.Visible = true;
                    labnameItem.Visible = true;
                    labelMa13.Visible = true;
                    labGiaMH.Visible = true;
                    _sku = dt.Rows[0]["SKU"].ToString();
                    labten.Text = dt.Rows[0]["Description"].ToString();
                    labgia.Text = Convert.ToDecimal(dt.Rows[0]["PRICE"]).ToString("N2") + " VND";
                    labnameItem.Text = dt.Rows[0]["Description"].ToString();
                    //labGiaMH.Text ="Giá Gốc: "+ Convert.ToDecimal(dt.Rows[0]["PRICE"]).ToString("N2");
                    labelMa13.Text = _sku;
                    LoadPromo(_sku);
                    //txtsku.Clear();
                }
                else
                {
                    labten.Text = "_ _";
                    labgia.Text = "_ _";
                    labslpos.Text = "0";
                    labgiapos.Text = "_ _";
                    labslKMTL.Text = "0";
                    labGiaKMTL.Text = "_ _";
                    labelControl3.Visible = false;
                    labelControl5.Visible = false;
                    labten.Visible = false;
                    labgia.Visible = false;
                    pictureBox2.Visible = false;
                    pictBarcode.Visible = false;
                    labGiaKMTL.Visible = false;
                    labslKMTL.Visible = false;
                    labelControl10.Visible = false;
                    labgiapos.Visible = false;
                    labslpos.Visible = false;
                    labelControl4.Visible = false;
                    labnameItem.Visible = false;
                    labelMa13.Visible = false;
                    labGiaMH.Visible = false;
                    //gridControl1.DataSource = null;
                    //return;
                }
                if (txtsku.Text.Length == 7 || txtsku.Text.Length == 13)
                {
                    string ma13 = "";
                    SQLHelper helper = new SQLHelper();
                    DataTable dtcustommer = helper.InfoCustommer(txtsku.Text);
                    if (dtcustommer != null)
                        if (dtcustommer.Rows.Count > 0)
                        {
                            ConvertBarCode cv = new ConvertBarCode();
                            if (Convert.ToInt64(txtsku.Text) > 25000)
                                ma13 = cv.CreaBarCode(txtsku.Text);
                            else if (txtsku.Text.Length != 13)
                                ma13 = cv.CreaBarCodeTV(txtsku.Text);
                            if (txtsku.Text.Length == 13)
                                ma13 = txtsku.Text;
                            Frmkiot frmkiot = new Frmkiot(this, dtcustommer, ma13);
                            frmkiot.rtbarcode+=new Frmkiot.ReturnBarcode(retunbarcode);
                            this.OpenDialog(frmkiot);
                            txtsku.Clear();
                        }

                }
                if(txtsku.Text.Length>13)   
                    txtsku.Clear();
            }
        }
        private void retunbarcode(string mabarcode)
        {
            txtsku.Text = mabarcode;
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if(txtsku.Text.Length==7||txtsku.Text.Length==13)
        //    {
        //        string ma13="";
        //        SQLHelper helper=new SQLHelper();
        //        DataTable dtcustommer= helper.InfoCustommer(txtsku.Text);
        //        if(dtcustommer!=null)
        //            if(dtcustommer.Rows.Count>0)
        //            {
        //                ConvertBarCode cv=new ConvertBarCode();
        //                if (Convert.ToInt64(txtsku.Text) > 25000)
        //                    ma13= cv.CreaBarCode(txtsku.Text);
        //                else if(txtsku.Text.Length!=13)
        //                    ma13 = cv.CreaBarCodeTV(txtsku.Text);
        //                if (txtsku.Text.Length == 13)
        //                    ma13 = txtsku.Text;
        //                Frmkiot frmkiot=new Frmkiot(this,dtcustommer,ma13);
        //                this.OpenDialog(frmkiot);
        //            }
           
        //    }
            
        //}
        public void OpenDialog(Form frmChild)
        {
            new FrmCheHet(frmChild).ShowDialog(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if(_sogiay--<=0&&flag)
            //{
            //    labelControl3.Visible = false;
            //    labelControl5.Visible = false;
            //    labten.Visible = false;
            //    labgia.Visible = false;
            //    pictureBox2.Visible = false;
            //    pictBarcode.Visible = false;
            //    labGiaKMTL.Visible = false;
            //    labslKMTL.Visible = false;
            //    labelControl10.Visible = false;
            //    labgiapos.Visible = false;
            //    labslpos.Visible = false;
            //    labelControl4.Visible = false;
            //    labnameItem.Visible = false;
            //    labelMa13.Visible = false;
            //    labGiaMH.Visible = false;
            //    flag = false;
            //}
        }
    }
}