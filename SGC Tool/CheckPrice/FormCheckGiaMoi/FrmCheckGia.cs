using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CheckPrice;
using DevExpress.LookAndFeel;
using DevExpress.XtraGrid.Views.Grid;
using TOOLChuyenDuLieu.ControlEntity;
using TOOLChuyenDuLieu.HelpFile;
using TOOLChuyenDuLieu.MyForm.FrmmainCheckPrice;
using SGC_Tool.MyControls;
using DevExpress.XtraEditors;

namespace TOOLChuyenDuLieu.MyForm.CheckPrice
{
    public partial class FrmCheckGia : DevExpress.XtraEditors.XtraForm
    {
        #region Skin
        //public DefaultLookAndFeel Skin=new DefaultLookAndFeel();

        #endregion
        private string _pathFileDM=@"INVMST.TPS";
        private string _pathFileGia = @"INVEVT.TPS";
        private string _pathFileUPC = @"INVUPC.TPS";
        private string PhatSinhUPC = "0000000000";
        DataTable tbM2=new DataTable();
        DataTable tbM20 = new DataTable();
        DataTable tbM21 = new DataTable();
        DataTable tbM22 = new DataTable();
        DataTable tbM25=new DataTable();
        private long _Const_datetime = 36161;
        private string _sku = "";
        List<LabelControl> _ListLabel=new List<LabelControl>();
        public FrmCheckGia()
        {
            InitializeComponent();
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
            //panel1.Visible = false;
            //panel2.Visible = false;
            
        }
        #endregion
        private void FrmCheckGia_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F5||e.KeyCode==Keys.Enter)
            {
                if(txtsku.Text!=string.Empty)
                {
                    string masku = txtsku.Text;
                    if (txtsku.Text.Length <= 7)
                        masku = "00" + txtsku.Text;
                    else if(txtsku.Text.Length>7)
                    {
                        if(txtsku.Text.Length<=14)
                            masku = GetSKU(PhatSinhUPC.Substring(0,18-txtsku.Text.Length)+txtsku.Text);
                        else
                            masku = GetSKU(txtsku.Text);
                    }
                    TPSDataAccess access=new TPSDataAccess(Path.Combine(Config._pathfileWinDSS,this._pathFileDM));
                    DataTable dt = access.GetDataTable("Select SKU,Description,Price,Vendor,Buy_Unit,Sell_Unit from INVMST where 1=1" + ((txtsku.Text == string.Empty) ? "" : " and SKU='" + masku + "'"));
                    if (dt.Rows.Count > 0)
                    {
                        labgiapos.Text = "Không có khuyến mãi tại POS";
                        //labslKMTL.Text = "0";
                        labGiaKMTL.Text = "Không có khuyến mãi theo lượng";
                        _sku = dt.Rows[0]["SKU"].ToString();
                        labten.Text = dt.Rows[0]["Description"].ToString();
                        labgia.Text =Convert.ToDecimal(dt.Rows[0]["PRICE"]).ToString("N2");
                        labelVendor.Text = dt.Rows[0]["Vendor"].ToString();
                        labelBuyUnit.Text = dt.Rows[0]["Buy_Unit"].ToString();
                        labelSelunit.Text = dt.Rows[0]["Sell_Unit"].ToString();
                        LoadPromo(_sku);
                        txtsku.Clear();
                        return;
                    }
                    else
                    {
                        _sku = "";
                        labten.Text = "_ _";
                        labgia.Text = "_ _";
                        labelSelunit.Text = "_ _";
                        labelBuyUnit.Text = "_ _";
                        labelVendor.Text = "_ _";
                        //labslpos.Text = "0";
                        labgiapos.Text = "Không có khuyến mãi tại POS";
                        //labslKMTL.Text = "0";
                        labGiaKMTL.Text = "Không có khuyến mãi theo lượng";
                        //panel2.Visible = false;
                        //panel1.Visible = false;
                        gridControl1.DataSource = null;
                        if (_ListLabel.Count > 0)
                        {
                            foreach (LabelControl labelControl in _ListLabel)
                            {
                                labelControl.Dispose();
                            }
                        }
                        _ListLabel.Clear();
                    }
                    //if (txtsku.Text.Length == 7 || txtsku.Text.Length == 13)
                    //{
                    //    string ma13 = "";
                    //    SQLHelper helper = new SQLHelper();
                    //    DataTable dtcustommer = helper.InfoCustommer(txtsku.Text);
                    //    if (dtcustommer != null)
                    //        if (dtcustommer.Rows.Count > 0)
                    //        {
                    //            ConvertBarCode cv = new ConvertBarCode();
                    //            if (Convert.ToInt64(txtsku.Text) > 25000)
                    //                ma13 = cv.CreaBarCode(txtsku.Text);
                    //            else if (txtsku.Text.Length != 13)
                    //                ma13 = cv.CreaBarCodeTV(txtsku.Text);
                    //            if (txtsku.Text.Length == 13)
                    //                ma13 = txtsku.Text;
                    //            Frmkiot frmkiot = new Frmkiot(this, dtcustommer, ma13);
                    //            frmkiot.rtbarcode += new Frmkiot.ReturnBarcode(retunbarcode);
                    //            this.OpenDialog(frmkiot);
                    //            //txtsku.Clear();
                    //        }

                    //}
                    if (txtsku.Text.Length > 13)
                        txtsku.Clear();
                }
                else
                {
                    labten.Text = "_ _";
                    labgia.Text = "_ _";
                    labelSelunit.Text = "_ _";
                    labelBuyUnit.Text = "_ _";
                    labelVendor.Text = "_ _";
                    labgiapos.Text = "Không có khuyến mãi tại POS";
                    //labslKMTL.Text = "0";
                    labGiaKMTL.Text = "Không có khuyến mãi theo lượng";
                    gridControl1.DataSource = null;
                    if (_ListLabel.Count > 0)
                    {
                        foreach (LabelControl labelControl in _ListLabel)
                        {
                            labelControl.Dispose();
                        }
                    }
                    _ListLabel.Clear();
                    //panel2.Visible = false;
                    //panel1.Visible = false;
                    txtsku.Clear();
                    return;
                }
                txtsku.Clear();
            }
          
        }
        private void retunbarcode(string mabarcode)
        {
            txtsku.Text = mabarcode;
        }
        public void OpenDialog(Form frmChild)
        {
            new FrmCheHet(frmChild).ShowDialog(this);
        }
        private void txtsku_EditValueChanged(object sender, EventArgs e)
        {
            //if(txtsku.Text==string.Empty)
            //{
            //    labten.Text = "_ _";
            //    labgia.Text = "_ _";
            //    //labslpos.Text = "0";
            //    labgiapos.Text = "_ _";
            //    //labslKMTL.Text = "0";
            //    labGiaKMTL.Text = "_ _";
            //    //panel2.Visible = false;
            //    //panel1.Visible = false;
            //    gridControl1.DataSource = null;
            //    return;
            //}
            //if(txtsku.Text!=string.Empty)
            //{
            //    string masku = txtsku.Text;
            //    if (txtsku.Text.Length <= 7)
            //        masku = "00" + txtsku.Text;
            //    else if (txtsku.Text.Length > 9)
            //    {
            //        if (txtsku.Text.Length <= 14)
            //            masku = GetSKU(PhatSinhUPC.Substring(0, 18 - txtsku.Text.Length) + txtsku.Text);
            //        else
            //            masku = GetSKU(txtsku.Text);
            //    }
            //    TPSDataAccess access = new TPSDataAccess(Path.Combine(Config._pathfileWinDSS,this._pathFileDM));
            //    DataTable dt = access.GetDataTable("Select SKU,Description,Price from INVMST where 1=1" + ((txtsku.Text == string.Empty) ? "" : " and SKU='" + masku + "'"));
            //    if (dt.Rows.Count > 0)
            //    {
            //        labgiapos.Text = "Không có khuyến mãi tại pos";
            //        //labslKMTL.Text = "0";
            //        labGiaKMTL.Text = "Không có khuyến mãi theo lượng";
            //        _sku = dt.Rows[0]["SKU"].ToString();
            //        labten.Text = dt.Rows[0]["Description"].ToString();
            //        labgia.Text = Convert.ToDecimal(dt.Rows[0]["PRICE"]).ToString("N2");
            //        LoadPromo(_sku);
            //        return;
            //    }
            //    else
            //    {
            //        labten.Text = "_ _";
            //        labgia.Text = "_ _";
            //        //labgiapos.Text = "Không có khuyến mãi tại pos";
            //        //labslKMTL.Text = "0";
            //        //labGiaKMTL.Text = "Không có khuyến mãi theo lượng";
            //        labGiaKMTL.Text = "_ _";
            //        //panel2.Visible = false;
            //        //panel1.Visible = false;
            //        gridControl1.DataSource = null;
            //        //return;
            //    }
            //    //if (txtsku.Text.Length == 7 || txtsku.Text.Length == 13)
            //    //{
            //    //    string ma13 = "";
            //    //    SQLHelper helper = new SQLHelper();
            //    //    DataTable dtcustommer = helper.InfoCustommer(txtsku.Text);
            //    //    if (dtcustommer != null)
            //    //        if (dtcustommer.Rows.Count > 0)
            //    //        {
            //    //            ConvertBarCode cv = new ConvertBarCode();
            //    //            if (Convert.ToInt64(txtsku.Text) > 25000)
            //    //                ma13 = cv.CreaBarCode(txtsku.Text);
            //    //            else if (txtsku.Text.Length != 13)
            //    //                ma13 = cv.CreaBarCodeTV(txtsku.Text);
            //    //            if (txtsku.Text.Length == 13)
            //    //                ma13 = txtsku.Text;
            //    //            Frmkiot frmkiot = new Frmkiot(this, dtcustommer, ma13);
            //    //            frmkiot.rtbarcode += new Frmkiot.ReturnBarcode(retunbarcode);
            //    //            this.OpenDialog(frmkiot);
            //    //            //txtsku.Clear();
            //    //        }

            //    //}
            //    if (txtsku.Text.Length > 13)
            //        txtsku.Clear();
            //}
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
            DataTable dt = access.GetDataTable_gia((@"Select SKU,MeThod,Start,Stop,Qty1,DiscPrice,Code,Prc_Key ,Price,Pricetype 
                                                        from INVEVT 
                                                        where 1=1 
                                                        and Method in (2,25,20,21,22) 
                                                        and " + ((Int64)DateTime.Now.ToOADate() + _Const_datetime) + @" >= Start 
                                                        and " + ((Int64)DateTime.Now.ToOADate()+_Const_datetime) + " <= stop "
                                                              + ((txtsku.Text == string.Empty) ? "" : " and SKU='" + masku + "'"))
                                                              );
            //DataTable dt = access.GetDataTable_gia(("Select SKU,MeThod,START,Stop,Qty1,DiscPrice from INVEVT where 1=1 and Method in (2,25) " + ((txtsku.Text == string.Empty) ? "" : " and SKU='" + txtsku.Text + "'")), dETuNgay.DateTime, dEDenNgay.DateTime);
            if (dt.Rows.Count > 0)
            {
                tbM2.Rows.Clear();
                tbM25.Rows.Clear();
                tbM20.Rows.Clear();
                tbM21.Rows.Clear();
                tbM22.Rows.Clear(); 
                dt=Fixtable(dt);
                gridControl1.DataSource = dt;
                gridView1.ExpandAllGroups();
                innitgrid();
                if (tbM2.Select("MeThod=2").Length >= 1)
                {
                    DataRow row;
                    if (tbM2.Select("MeThod=2 and Prc_Key=Min(Prc_Key)").Length==1)
                        row = tbM2.Select("MeThod=2 and Prc_Key=Min(Prc_Key)")[0];
                    else
                    {
                        Int32 prc_key = Convert.ToInt32(tbM2.Select("MeThod=2 and Prc_Key=Min(Prc_Key)")[0]["Prc_key"]);
                        row = tbM2.Select("MeThod=2 and Prc_Key="+prc_key+" and Code=max(Code)")[0];
                    }
                    //panel2.Visible = true;
                    labGiaKMTL.Text = "Khi mua với SL      " + Convert.ToInt32(row["Qty1"]).ToString("N0") + "     giá tiền là      " + Convert.ToDecimal(row["DiscPrice"]).ToString("N2"); //+ " Từ: " + Convert.ToDateTime(row["Start"]).ToString("dd/MM/yyyy") + " Đến:" + Convert.ToDateTime(row["Stop"]).ToString("dd/MM/yyyy");
                    //labslKMTL.Text = Convert.ToInt32(row["Qty1"]).ToString("N0");
                }
                else
                {
                    labGiaKMTL.Text = "Không có giảm giá theo lượng";
                    //panel2.Visible = false;
                    //labslKMTL.Text = "0";

                }
                if (tbM25.Select("MeThod=25").Length >= 1)
                {
                    DataRow row;
                    if(tbM25.Select("MeThod=25 and Prc_Key=Min(Prc_Key)").Length==1)
                         row= tbM25.Select("MeThod=25 and Prc_Key=Min(Prc_Key)")[0];
                    else
                    {
                        Int32 prc_key = Convert.ToInt32(tbM25.Select("MeThod=25 and Prc_Key=Min(Prc_Key)")[0]["Prc_key"]);
                        row = tbM25.Select("MeThod=25 and Prc_Key="+prc_key+" and Code=max(Code)")[0];
                    }
                    //panel1.Visible = true;
                    labgiapos.Text = "     "+Convert.ToDecimal(row["Price"]).ToString("N2");// +" Từ: " + Convert.ToDateTime(row["Start"]).ToString("dd/MM/yyyy") + " Đến:" + Convert.ToDateTime(row["Stop"]).ToString("dd/MM/yyyy");
                    //labslpos.Text = "1";
                }
                else
                {
                    labgiapos.Text = "Không có khuyến mãi tại POS";
                    //panel1.Visible = false;
                    //labslpos.Text = "0";
                }

                #region khuyen mai theo so gia
                if (_ListLabel.Count > 0)
                {
                    foreach (LabelControl labelControl in _ListLabel)
                    {
                        labelControl.Dispose();
                    }
                }
                _ListLabel.Clear();
                int count = 0;
                bool daApDungSoGia = false;
                if (tbM20.Select("MeThod=20").Length >= 1)
                {
                     List<DataTable> list = GetTaleByPricetype(tbM20);
                    
                    foreach (DataTable dataTable in list)
                    {
                        DataRow row;
                        if (dataTable.Select("MeThod=20 and Prc_Key=Min(Prc_Key)").Length == 1)
                            row = dataTable.Select("MeThod=20 and Prc_Key=Min(Prc_Key)")[0];
                        else
                        {
                            Int32 prc_key =
                                Convert.ToInt32(dataTable.Select("MeThod=20 and Prc_Key=Min(Prc_Key)")[0]["Prc_key"]);
                            row = dataTable.Select("MeThod=20 and Prc_Key=" + prc_key + " and Code=max(Code)")[0];
                        }
                        ////panel2.Visible = true;
                        //LableValueGiam.Text = "Sổ giá giảm theo %(MeThod 20):  " + row["Pricetype"].ToString() +
                        //                      "_Giảm giá:  " + Convert.ToDecimal(row["DiscPrice"]).ToString("N2") +
                        //                      " % So với giá bán ";
                        ////labslKMTL.Text = Convert.ToInt32(row["Qty1"]).ToString("N0");
                        //daApDungSoGia = true;
                        LabelControl lable = new LabelControl();
                        lable.ForeColor = LableSoGiaGiamTemp.ForeColor;
                        lable.Font = LableSoGiaGiamTemp.Font;
                        LabelControl lablePtype = new LabelControl();
                        lablePtype.ForeColor = labelControlPtype.ForeColor;
                        lablePtype.Font = labelControlPtype.Font;
                        lablePtype.Text = row["Pricetype"].ToString();// +" Giá giảm:  " + Convert.ToDecimal(row["DiscPrice"]).ToString("N2") + " So với giá bán ";
                        lablePtype.Location = new Point(262, 278 + count);
                        this.Controls.Add(lablePtype);
                        LabelControl lableValue = new LabelControl();
                        lable.Text = "Sổ giá giảm theo %(Method 20):";
                        lable.Location = new Point(34, 278 + count);
                        this.Controls.Add(lable);
                        lableValue.ForeColor = LableValueGiam.ForeColor;
                        lableValue.Font = LableValueGiam.Font;
                        lableValue.Text = " Giá giảm:    " + Convert.ToDecimal(row["DiscPrice"]).ToString("N2") + " %   so với giá bán ";
                        lableValue.Location = new Point(311, 278 + count);
                        this.Controls.Add(lableValue);
                        count += 21;
                        _ListLabel.Add(lable);
                        _ListLabel.Add(lableValue);
                        _ListLabel.Add(lablePtype);
                        //labslKMTL.Text = Convert.ToInt32(row["Qty1"]).ToString("N0");
                        daApDungSoGia = true;
                    }
                }
                else if (!daApDungSoGia)
                {
                    //LableValueGiam.Text = "Không giảm giá theo sổ giá";
                    //panel2.Visible = false;
                    //labslKMTL.Text = "0";

                }
                if (tbM21.Select("MeThod=21").Length >= 1)
                {
                     List<DataTable> list = GetTaleByPricetype(tbM21);
                    
                    foreach (DataTable dataTable in list)
                    {
                        DataRow row;
                        if (dataTable.Select("MeThod=21 and Prc_Key=Min(Prc_Key)").Length == 1)
                            row = dataTable.Select("MeThod=21 and Prc_Key=Min(Prc_Key)")[0];
                        else
                        {
                            Int32 prc_key =
                                Convert.ToInt32(dataTable.Select("MeThod=21 and Prc_Key=Min(Prc_Key)")[0]["Prc_key"]);
                            row = dataTable.Select("MeThod=21 and Prc_Key=" + prc_key + " and Code=max(Code)")[0];
                        }
                        ////panel2.Visible = true;
                        //LableValueGiam.Text = "Sổ giá giảm theo %(Method 21): " + row["Pricetype"].ToString() +
                        //                      "_Giá khuyến mãi tại POS:  " +
                        //                      Convert.ToDecimal(row["DiscPrice"]).ToString("N0") + "  ";
                        ////labslKMTL.Text = Convert.ToInt32(row["Qty1"]).ToString("N0");
                        //daApDungSoGia = true;
                        LabelControl lable = new LabelControl();
                        lable.ForeColor = LableSoGiaGiamTemp.ForeColor;
                        lable.Font = LableSoGiaGiamTemp.Font;
                        LabelControl lablePtype = new LabelControl();
                        lablePtype.ForeColor = labelControlPtype.ForeColor;
                        lablePtype.Font = labelControlPtype.Font;
                        lablePtype.Text = row["Pricetype"].ToString();// +" Giá giảm:  " + Convert.ToDecimal(row["DiscPrice"]).ToString("N2") + " So với giá bán ";
                        lablePtype.Location = new Point(262, 278 + count);
                        this.Controls.Add(lablePtype);
                        LabelControl lableValue = new LabelControl();
                        lable.Text = "Sổ giá giảm theo %(Method 21):";
                        lable.Location = new Point(34, 278 + count);
                        this.Controls.Add(lable);
                        lableValue.ForeColor = LableValueGiam.ForeColor;
                        lableValue.Font = LableValueGiam.Font;
                        lableValue.Text = " Giá khuyến mãi tại POS:    " + Convert.ToDecimal(row["DiscPrice"]).ToString("N2");
                        lableValue.Anchor = LableValueGiam.Anchor;
                        lableValue.Location = new Point(311, 278 + count);
                        this.Controls.Add(lableValue);
                        count += 21;
                        _ListLabel.Add(lable);
                        _ListLabel.Add(lableValue);
                        _ListLabel.Add(lablePtype);
                        lable.Visible = true;
                        lableValue.Visible = true;
                    }
                }
                else if (!daApDungSoGia)
                {
                    //LableValueGiam.Text = "Không giảm giá theo sổ giá";
                    //panel2.Visible = false;
                    //labslKMTL.Text = "0";

                }
                if (tbM22.Select("MeThod=22").Length >= 1)
                {
                    List<DataTable> list = GetTaleByPricetype(tbM22);
                    foreach (DataTable dataTable in list)
                    {
                        DataRow row;
                        if (dataTable.Select("MeThod=22 and Prc_Key=Min(Prc_Key)").Length == 1)
                            row = dataTable.Select("MeThod=22 and Prc_Key=Min(Prc_Key)")[0];
                        else
                        {
                            //if(row["Pricetype"])
                            //{
                                
                            //}
                            Int32 prc_key = Convert.ToInt32(dataTable.Select("MeThod=22 and Prc_Key=Min(Prc_Key)")[0]["Prc_key"]);
                            row = dataTable.Select("MeThod=22 and Prc_Key=" + prc_key + " and Code=max(Code)")[0];
                        }
                        //panel2.Visible = true;
                        LabelControl lable=new LabelControl();
                        lable.ForeColor = LableSoGiaGiamTemp.ForeColor;
                        lable.Font = LableSoGiaGiamTemp.Font;
                        LabelControl lablePtype = new LabelControl();
                        lablePtype.ForeColor = labelControlPtype.ForeColor;
                        lablePtype.Font = labelControlPtype.Font;
                        lablePtype.Text = row["Pricetype"].ToString();// +" Giá giảm:  " + Convert.ToDecimal(row["DiscPrice"]).ToString("N2") + " So với giá bán ";
                        lablePtype.Location = new Point(262, 278 + count);
                        this.Controls.Add(lablePtype);
                        LabelControl lableValue = new LabelControl();
                        lable.Text = "Sổ giá giảm theo %(Method 22):";
                        lable.Location = new Point(34 , 278+ count);
                        this.Controls.Add(lable);
                        lableValue.ForeColor = LableValueGiam.ForeColor;
                        lableValue.Font = LableValueGiam.Font;
                        lableValue.Text = " Giá giảm:    " + Convert.ToDecimal(row["DiscPrice"]).ToString("N2") + "    so với giá bán ";
                        lableValue.Location = new Point(311, 278 + count);
                        this.Controls.Add(lableValue);
                        count += 21;
                        _ListLabel.Add(lable);
                        _ListLabel.Add(lableValue);
                        _ListLabel.Add(lablePtype);
                        //labslKMTL.Text = Convert.ToInt32(row["Qty1"]).ToString("N0");
                        daApDungSoGia = true;
                    }
                    
                }
                else if (!daApDungSoGia)
                {
                    //LableValueGiam.Text = "Không giảm giá theo sổ giá";
                    ////panel2.Visible = false;
                    ////labslKMTL.Text = "0";
                    //if(_ListLabel.Count>0)
                    //{
                    //    foreach (LabelControl labelControl in _ListLabel)
                    //    {
                    //        labelControl.Dispose();
                    //    }
                    //}
                    //_ListLabel.Clear();
                }

                #endregion
            }
            else
            {
                gridControl1.DataSource = null;
                if (_ListLabel.Count > 0)
                {
                    foreach (LabelControl labelControl in _ListLabel)
                    {
                        labelControl.Dispose();
                    }
                }
                _ListLabel.Clear();
                //panel2.Visible = false;
                //panel1.Visible = false;
                //innitgrid();
            }
        }
        public DataTable Fixtable(DataTable dt)
        {
            DataTable dataTable=new DataTable();
            dataTable.Columns.AddRange(new DataColumn[]{new DataColumn("STT", typeof(System.Int32)) 
                                                   , new DataColumn("SKU", typeof(System.String))
                                                   ,new DataColumn("Vendor", typeof(System.String)) 
                                                   ,new DataColumn("MeThod", typeof(System.String))
                                                    ,new DataColumn("Start", typeof(System.DateTime))
                                                     ,new DataColumn("Stop", typeof(System.DateTime))
                                                         ,new DataColumn("Qty1", typeof(System.Int32))
                                                         ,new DataColumn("DiscPrice", typeof(System.Decimal))
                                                          ,new DataColumn("DiscPriceKMTL", typeof(System.Decimal))
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
            if (tbM20.Columns.Count == 0)
                tbM20.Columns.AddRange(new DataColumn[]{new DataColumn("STT", typeof(System.Int32)) 
                                                       , new DataColumn("SKU", typeof(System.String)) 
                                                       ,new DataColumn("MeThod", typeof(System.String))
                                                        ,new DataColumn("Start", typeof(System.DateTime))
                                                         ,new DataColumn("Stop", typeof(System.DateTime))
                                                             ,new DataColumn("Qty1", typeof(System.Int32))
                                                             ,new DataColumn("Pricetype", typeof(System.String))
                                                             ,new DataColumn("DiscPrice", typeof(System.Decimal))
                                                             ,new DataColumn("Code", typeof(System.Decimal))
                                                                 ,new DataColumn("Prc_Key", typeof(System.Int32))
                                             ,new DataColumn("Price", typeof(System.Decimal))});
            if (tbM21.Columns.Count == 0)
                tbM21.Columns.AddRange(new DataColumn[]{new DataColumn("STT", typeof(System.Int32)) 
                                                       , new DataColumn("SKU", typeof(System.String)) 
                                                       ,new DataColumn("MeThod", typeof(System.String))
                                                        ,new DataColumn("Start", typeof(System.DateTime))
                                                         ,new DataColumn("Stop", typeof(System.DateTime))
                                                             ,new DataColumn("Qty1", typeof(System.Int32))
                                                             ,new DataColumn("Pricetype", typeof(System.String))
                                                             ,new DataColumn("DiscPrice", typeof(System.Decimal))
                                                             ,new DataColumn("Code", typeof(System.Decimal))
                                                                 ,new DataColumn("Prc_Key", typeof(System.Int32))
                                             ,new DataColumn("Price", typeof(System.Decimal))});
            if (tbM22.Columns.Count == 0)
                tbM22.Columns.AddRange(new DataColumn[]{new DataColumn("STT", typeof(System.Int32)) 
                                                       , new DataColumn("SKU", typeof(System.String)) 
                                                       ,new DataColumn("MeThod", typeof(System.String))
                                                        ,new DataColumn("Start", typeof(System.DateTime))
                                                         ,new DataColumn("Stop", typeof(System.DateTime))
                                                             ,new DataColumn("Qty1", typeof(System.Int32))
                                                             ,new DataColumn("Pricetype", typeof(System.String))
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
                    row["MeThod"] = "Giảm giá tại POS";
                else if(dataRow["MeThod"].ToString().Trim()=="2")
                    row["MeThod"] = "Giảm giá theo lượng";
                else
                    row["MeThod"] = "khuyến mãi theo sổ giá";
                if (dataRow["Code"].ToString() != string.Empty)
                    row["Code"] = Convert.ToDecimal(dataRow["Code"]).ToString("N0");
                else
                    row["Code"] = 0;
                string sokhong = "00000";
                TPSDataAccess access = new TPSDataAccess(Path.Combine(Config._pathfileWinDSS,"INVHPR.TPS"));
                DataTable tbtemp = access.GetDataTable_gia(string.Format(@"Select Description 
                                                        from INVHPR
                                                        where Code='{0}'",sokhong.Substring(0,6-row["Code"].ToString().Trim().Length)+ row["Code"]));
                if (tbtemp.Rows.Count > 0)
                {
                    row["Vendor"] = tbtemp.Rows[0][0];
                }
                row["Start"] = DateTime.FromOADate(Convert.ToDouble(dataRow["Start"]) - _Const_datetime);
                row["Stop"] = DateTime.FromOADate(Convert.ToDouble(dataRow["Stop"]) - _Const_datetime);
                row["Qty1"] =Convert.ToInt32(dataRow["Qty1"]).ToString("N0");
                row["DiscPrice"] =Convert.ToDecimal(dataRow["DiscPrice"]).ToString("N2");
                if (dataRow["MeThod"].ToString().Trim() == "2")
                {
                    row["DiscPriceKMTL"] = Convert.ToDecimal(dataRow["DiscPrice"]).ToString("N2");
                }
                else
                {
                    row["DiscPriceKMTL"] = 0;
                }
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
                else if (dataRow["MeThod"].ToString().Trim() == "20")
                {
                    DataRow row20 = tbM20.NewRow();
                    row20["STT"] = i;
                    row20["SKU"] = dataRow["SKU"];
                    row20["MeThod"] = dataRow["MeThod"];
                    row20["Pricetype"] = dataRow["Pricetype"];
                    row20["Start"] = DateTime.FromOADate(Convert.ToDouble(dataRow["Start"]) - _Const_datetime);
                    row20["Stop"] = DateTime.FromOADate(Convert.ToDouble(dataRow["Stop"]) - _Const_datetime);
                    row20["Qty1"] = Convert.ToInt32(dataRow["Qty1"]).ToString("N0");
                    row20["DiscPrice"] = Convert.ToDecimal(dataRow["DiscPrice"]).ToString("N2");
                    if (dataRow["Code"].ToString() != string.Empty)
                        row20["Code"] = Convert.ToDecimal(dataRow["Code"]).ToString("N0");
                    else
                        row20["Code"] = 0;
                    if (dataRow["Prc_Key"].ToString() != string.Empty)
                        row20["Prc_Key"] = Convert.ToInt32(dataRow["Prc_Key"]).ToString("N0");
                    else
                        row20["Prc_Key"] = 0;
                    row20["Price"] = Convert.ToDecimal(dataRow["Price"]).ToString("N2");
                    tbM20.Rows.Add(row20);
                }
                else if (dataRow["MeThod"].ToString().Trim() == "21")
                {
                    DataRow row21 = tbM21.NewRow();
                    row21["STT"] = i;
                    row21["SKU"] = dataRow["SKU"];
                    row21["MeThod"] = dataRow["MeThod"];
                    row21["Pricetype"] = dataRow["Pricetype"];
                    row21["Start"] = DateTime.FromOADate(Convert.ToDouble(dataRow["Start"]) - _Const_datetime);
                    row21["Stop"] = DateTime.FromOADate(Convert.ToDouble(dataRow["Stop"]) - _Const_datetime);
                    row21["Qty1"] = Convert.ToInt32(dataRow["Qty1"]).ToString("N0");
                    row21["DiscPrice"] = Convert.ToDecimal(dataRow["DiscPrice"]).ToString("N2");
                    if (dataRow["Code"].ToString() != string.Empty)
                        row21["Code"] = Convert.ToDecimal(dataRow["Code"]).ToString("N0");
                    else
                        row21["Code"] = 0;
                    if (dataRow["Prc_Key"].ToString() != string.Empty)
                        row21["Prc_Key"] = Convert.ToInt32(dataRow["Prc_Key"]).ToString("N0");
                    else
                        row21["Prc_Key"] = 0;
                    row21["Price"] = Convert.ToDecimal(dataRow["Price"]).ToString("N2");
                    tbM21.Rows.Add(row21);
                }
                else if (dataRow["MeThod"].ToString().Trim() == "22")
                {
                    DataRow row22 = tbM22.NewRow();
                    row22["STT"] = i;
                    row22["SKU"] = dataRow["SKU"];
                    row22["MeThod"] = dataRow["MeThod"];
                    row22["Pricetype"] = dataRow["Pricetype"];
                    row22["Start"] = DateTime.FromOADate(Convert.ToDouble(dataRow["Start"]) - _Const_datetime);
                    row22["Stop"] = DateTime.FromOADate(Convert.ToDouble(dataRow["Stop"]) - _Const_datetime);
                    row22["Qty1"] = Convert.ToInt32(dataRow["Qty1"]).ToString("N0");
                    row22["DiscPrice"] = Convert.ToDecimal(dataRow["DiscPrice"]).ToString("N2");
                    if (dataRow["Code"].ToString() != string.Empty)
                        row22["Code"] = Convert.ToDecimal(dataRow["Code"]).ToString("N0");
                    else
                        row22["Code"] = 0;
                    if (dataRow["Prc_Key"].ToString() != string.Empty)
                        row22["Prc_Key"] = Convert.ToInt32(dataRow["Prc_Key"]).ToString("N0");
                    else
                        row22["Prc_Key"] = 0;
                    row22["Price"] = Convert.ToDecimal(dataRow["Price"]).ToString("N2");
                    tbM22.Rows.Add(row22);
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
            gridView1.ClearSorting();
            gridView1.Columns["Prc_Key"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            gridView1.Columns["Code"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
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

        private void FrmCheckGia_FormClosing(object sender, FormClosingEventArgs e)
        {
            CTLQuanLyForm.formName.Remove(this.Name);
        }

       public List<DataTable> GetTaleByPricetype(DataTable dt)
       {
           List<DataTable> list=new List<DataTable>();
           DataTable tabletemp = dt.Copy();
           tabletemp.Rows.Clear();
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               DataTable table = tabletemp.Copy();
               if(dt.Rows[i]["Pricetype"].ToString().Trim()==string.Empty)
                   continue;
               else
               {
                   DataRow row = table.NewRow();
                   row["STT"] = dt.Rows[i]["STT"];
                   row["SKU"] = dt.Rows[i]["SKU"];
                   row["MeThod"] = dt.Rows[i]["MeThod"];
                   row["Pricetype"] = dt.Rows[i]["Pricetype"];
                   row["Start"] = dt.Rows[i]["Start"];
                   row["Stop"] = dt.Rows[i]["Stop"];
                   row["Qty1"] = dt.Rows[i]["Qty1"];
                   row["DiscPrice"] = dt.Rows[i]["DiscPrice"];
                   row["Code"] = dt.Rows[i]["Code"];
                   row["Prc_Key"] = dt.Rows[i]["Prc_Key"];
                   row["Price"] = dt.Rows[i]["Price"];
                   table.Rows.Add(row);
               }
               for (int j = i+1; j < dt.Rows.Count; j++)
               {
                   if (dt.Rows[i]["Pricetype"].ToString().Trim() == dt.Rows[j]["Pricetype"].ToString().Trim() && dt.Rows[j]["Pricetype"].ToString().Trim()!=string.Empty)
                   {
                       DataRow row = table.NewRow();
                       row["STT"] = dt.Rows[i]["STT"];
                       row["SKU"] = dt.Rows[i]["SKU"];
                       row["MeThod"] = dt.Rows[i]["MeThod"];
                       row["Pricetype"] = dt.Rows[i]["Pricetype"];
                       row["Start"] = dt.Rows[i]["Start"];
                       row["Stop"] = dt.Rows[i]["Stop"];
                       row["Qty1"] = dt.Rows[i]["Qty1"];
                       row["DiscPrice"] = dt.Rows[i]["DiscPrice"];
                       row["Code"] = dt.Rows[i]["Code"];
                       row["Prc_Key"] = dt.Rows[i]["Prc_Key"];
                       row["Price"] = dt.Rows[i]["Price"];
                       table.Rows.Add(row);
                       dt.Rows[j]["Pricetype"] = "";
                   }
                   
               }
               list.Add(table);
           }

           return list;
       }
    }
}