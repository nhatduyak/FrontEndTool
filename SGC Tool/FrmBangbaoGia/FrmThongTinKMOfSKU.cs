using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TOOLChuyenDuLieu.ControlEntity;
using System.IO;
using TOOLChuyenDuLieu;

namespace SGC_Tool.FrmBangbaoGia
{
    public partial class FrmThongTinKMOfSKU : DevExpress.XtraEditors.XtraForm
    {

        #region Khai bao bien
        List<LabelControl> _ListLabel = new List<LabelControl>();
        private long _Const_datetime = 36161;
        private string _SKU = "";
          DataTable tbM2=new DataTable();
        DataTable tbM20 = new DataTable();
        DataTable tbM21 = new DataTable();
        DataTable tbM22 = new DataTable();
        DataTable tbM25=new DataTable();
        #endregion
        
        public FrmThongTinKMOfSKU(string sku)
        {
            InitializeComponent();
           
            LoadForm(sku);
        }
        public bool LoadForm(string sku)
        {
            try
            {
                TPSDataAccess access = new TPSDataAccess(Path.Combine(Config._pathfileWinDSS, @"INVMST.tps"));
                DataTable dtinv = access.GetDataTable(string.Format(@"select SKU,PRICE,Description,UPC from INVMST Where SKU='{0}'",sku));
                if(dtinv!=null&&dtinv.Rows.Count>0)
                {
                    labsku.Text = dtinv.Rows[0]["SKU"].ToString();
                    labUPC.Text = dtinv.Rows[0]["UPC"].ToString();
                    labname.Text = dtinv.Rows[0]["Description"].ToString();
                    labGiagoc.Text =Convert.ToDecimal(dtinv.Rows[0]["Price"]).ToString("N0");
                    LoadPromotion(sku);
                }
                return true;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("FrmThongTinKMOfSKU FrmThongTinKMOfSKU ", ex.Message);
                return false;
            }
        }
        public void LoadPromotion(string sku)
        {
            try
            {
                TPSDataAccess access = new TPSDataAccess(Path.Combine(Config._pathfileWinDSS, @"INVEVT.tps"));
                DataTable dt =access.GetDataTable_gia(
                        (@"Select SKU,MeThod,Start,Stop,Qty1,DiscPrice,Code,Prc_Key ,Price,Pricetype 
                                                        from INVEVT 
                                                        where 1=1 
                                                        and Method in (2,25,20,21,22) 
                                                        and " +
                         (Math.Round(DateTime.Now.ToOADate()) + _Const_datetime) +
                         @" >= Start 
                                                        and " +
                         (Math.Round(DateTime.Now.ToOADate()) + _Const_datetime) + @" <= stop and SKU='" + sku + "'"));
                //DataTable dt = access.GetDataTable_gia(("Select SKU,MeThod,START,Stop,Qty1,DiscPrice from INVEVT where 1=1 and Method in (2,25) " + ((txtsku.Text == string.Empty) ? "" : " and SKU='" + txtsku.Text + "'")), dETuNgay.DateTime, dEDenNgay.DateTime);
                if (dt.Rows.Count > 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                    tbM2.Rows.Clear();
                    tbM25.Rows.Clear();
                    tbM20.Rows.Clear();
                    tbM21.Rows.Clear();
                    tbM22.Rows.Clear();
                    dt = Fixtable(dt);
                    //gridControl1.DataSource = dt;
                    //gridView1.ExpandAllGroups();
                    //innitgrid();
                    if (tbM2.Select("MeThod=2").Length >= 1)
                    {
                        DataRow row;
                        if (tbM2.Select("MeThod=2 and Prc_Key=Min(Prc_Key)").Length == 1)
                            row = tbM2.Select("MeThod=2 and Prc_Key=Min(Prc_Key)")[0];
                        else
                        {
                            Int32 prc_key =
                                Convert.ToInt32(tbM2.Select("MeThod=2 and Prc_Key=Min(Prc_Key)")[0]["Prc_key"]);
                            row = tbM2.Select("MeThod=2 and Prc_Key=" + prc_key + " and Code=max(Code)")[0];
                        }
                        //panel2.Visible = true;
                        string LabMethog2 = "Khi mua với SL      " + Convert.ToInt32(row["Qty1"]).ToString("N0") + "     giá tiền là      " + Convert.ToDecimal(row["DiscPrice"]).ToString("N2") + "       (" + Convert.ToDateTime(row["Start"]).ToString("dd/MM/yyyy") + " -> " + Convert.ToDateTime(row["Stop"]).ToString("dd/MM/yyyy")+")";
                        LabelControl lmt2 = new LabelControl();
                        lmt2.Font = labKM.Font;
                        lmt2.ForeColor = Color.Red;
                        lmt2.Text = LabMethog2;
                        flowLayoutPanel1.Controls.Add(lmt2);
                        //+ " Từ: " + Convert.ToDateTime(row["Start"]).ToString("dd/MM/yyyy") + " Đến:" + Convert.ToDateTime(row["Stop"]).ToString("dd/MM/yyyy");
                        //labslKMTL.Text = Convert.ToInt32(row["Qty1"]).ToString("N0");
                    }
                    if (tbM25.Select("MeThod=25").Length >= 1)
                    {
                        DataRow row;
                        if (tbM25.Select("MeThod=25 and Prc_Key=Min(Prc_Key)").Length == 1)
                            row = tbM25.Select("MeThod=25 and Prc_Key=Min(Prc_Key)")[0];
                        else
                        {
                            Int32 prc_key =
                                Convert.ToInt32(tbM25.Select("MeThod=25 and Prc_Key=Min(Prc_Key)")[0]["Prc_key"]);
                            row = tbM25.Select("MeThod=25 and Prc_Key=" + prc_key + " and Code=max(Code)")[0];
                        }
                        //panel1.Visible = true;
                        string labMethod25 = "Giá khuyến mãi tại POS :     " + Convert.ToDecimal(row["Price"]).ToString("N2") + "      (" + Convert.ToDateTime(row["Start"]).ToString("dd/MM/yyyy") + " -> " + Convert.ToDateTime(row["Stop"]).ToString("dd/MM/yyyy") + ")";
                        LabelControl lmt2 = new LabelControl();
                        lmt2.Font = labKM.Font;
                        lmt2.ForeColor = Color.Red;
                        lmt2.Text = labMethod25;
                        flowLayoutPanel1.Controls.Add(lmt2);
                        // +" Từ: " + Convert.ToDateTime(row["Start"]).ToString("dd/MM/yyyy") + " Đến:" + Convert.ToDateTime(row["Stop"]).ToString("dd/MM/yyyy");
                        //labslpos.Text = "1";
                    }

                    #region khuyen mai theo so gia

                    //if (_ListLabel.Count > 0)
                    //{
                    //    foreach (LabelControl labelControl in _ListLabel)
                    //    {
                    //        labelControl.Dispose();
                    //    }
                    //}
                    //_ListLabel.Clear();
                    bool daApDungSoGia = false;
                    if (tbM20.Select("MeThod=20").Length >= 1)
                    {
                        List<DataTable> list = GetTaleByPricetype(tbM20);
                        int count = 0;
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
                            //lable.ForeColor = LableSoGiaGiamTemp.ForeColor;
                            lable.Font = labKM.Font;
                            //LabelControl lablePtype = new LabelControl();
                            //lablePtype.ForeColor = labelControlPtype.ForeColor;
                            //lablePtype.Font = labelControlPtype.Font;
                            string strMT20 ="Sổ giá " +row["Pricetype"].ToString()+"  ";
                            // +" Giá giảm:  " + Convert.ToDecimal(row["DiscPrice"]).ToString("N2") + " So với giá bán ";
                            //lablePtype.Location = new Point(262, 278 + count);
                            //this.Controls.Add(lablePtype);
                            //LabelControl lableValue = new LabelControl();
                            //lable.Text = "Sổ giá giảm theo %(Method 20):";
                            //lable.Location = new Point(34, 278 + count);
                            //this.Controls.Add(lable);
                            strMT20+= " Giá giảm:    " + Convert.ToDecimal(row["DiscPrice"]).ToString("N2") +
                                              " %   so với giá bán " + "       (" + Convert.ToDateTime(row["Start"]).ToString("dd/MM/yyyy") + " -> " + Convert.ToDateTime(row["Stop"]).ToString("dd/MM/yyyy") + ")"; 
                            lable.Text = strMT20;
                            lable.ForeColor = Color.Red;
                            flowLayoutPanel1.Controls.Add(lable);
                            //labslKMTL.Text = Convert.ToInt32(row["Qty1"]).ToString("N0");
                            daApDungSoGia = true;
                        }
                    }
                    if (tbM21.Select("MeThod=21").Length >= 1)
                    {
                        List<DataTable> list = GetTaleByPricetype(tbM21);
                        int count = 0;
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
                            lable.Font = labKM.Font;
                            lable.ForeColor = Color.Red;
                            string strMT21 = "Sổ giá " + row["Pricetype"].ToString()+"  ";
                            strMT21+= " Giá khuyến mãi tại POS:    " +
                                              Convert.ToDecimal(row["DiscPrice"]).ToString("N2") + "       (" + Convert.ToDateTime(row["Start"]).ToString("dd/MM/yyyy") + " -> " + Convert.ToDateTime(row["Stop"]).ToString("dd/MM/yyyy") + ")"; 
                            lable.Text = strMT21;
                          flowLayoutPanel1.Controls.Add(lable);
                        }
                    }
                    if (tbM22.Select("MeThod=22").Length >= 1)
                    {
                        List<DataTable> list = GetTaleByPricetype(tbM22);
                        int count = 0;
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
                                Int32 prc_key =
                                    Convert.ToInt32(dataTable.Select("MeThod=22 and Prc_Key=Min(Prc_Key)")[0]["Prc_key"]);
                                row = dataTable.Select("MeThod=22 and Prc_Key=" + prc_key + " and Code=max(Code)")[0];
                            }
                            //panel2.Visible = true;
                            LabelControl lable = new LabelControl();
                           string strMT22="Sổ giá " +row["Pricetype"].ToString()+"  ";
                            // +" Giá giảm:  " + Convert.ToDecimal(row["DiscPrice"]).ToString("N2") + " So với giá bán ";
                            strMT22 += " Giá giảm:    " + Convert.ToDecimal(row["DiscPrice"]).ToString("N2") +
                                              "    so với giá bán " + "       (" + Convert.ToDateTime(row["Start"]).ToString("dd/MM/yyyy") + " -> " + Convert.ToDateTime(row["Stop"]).ToString("dd/MM/yyyy") + ")";
                            lable.Font = labKM.Font;
                            lable.Text = strMT22;
                            lable.ForeColor = Color.Red;
                            flowLayoutPanel1.Controls.Add(lable);
                            //labslKMTL.Text = Convert.ToInt32(row["Qty1"]).ToString("N0");
                            daApDungSoGia = true;
                        }

                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {

                CTLError.WriteError("FrmThongTinKMOfSKU LoadPromotion ", ex.Message);
                return;
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
        public List<DataTable> GetTaleByPricetype(DataTable dt)
        {
            List<DataTable> list = new List<DataTable>();
            DataTable tabletemp = dt.Copy();
            tabletemp.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable table = tabletemp.Copy();
                if (dt.Rows[i]["Pricetype"].ToString().Trim() == string.Empty)
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
                for (int j = i + 1; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[i]["Pricetype"].ToString().Trim() == dt.Rows[j]["Pricetype"].ToString().Trim() && dt.Rows[j]["Pricetype"].ToString().Trim() != string.Empty)
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

        private void FrmThongTinKMOfSKU_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }
    }
}