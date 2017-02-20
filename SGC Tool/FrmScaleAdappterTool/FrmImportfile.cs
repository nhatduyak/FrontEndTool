using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using TOOLChuyenDuLieu;
using TOOLChuyenDuLieu.ControlEntity;

namespace SGC_Tool.FrmScaleAdappterTool
{
    public partial class FrmImportfile : DevExpress.XtraEditors.XtraForm
    {
        public string _PathFileINVMST =Path.Combine(Config._pathfileWinDSS,"INVMST.TPs");
        public delegate void DSSKU(DataTable dt, string[] MsSKU);
        public DSSKU Dongy;
        public FrmImportfile()
        {
            InitializeComponent();
        }
        public FrmImportfile(DataTable dataTable)
        {
            InitializeComponent();
            if (dataTable.Rows.Count >= 0)
                GridDSMa.DataSource = dataTable;
        }
        private void BTDongY_Click(object sender, EventArgs e)
        {
            if(Dongy!=null)
            {
                try
                {
                    if(gridView1.DataSource!=null)
                    {
                        DataTable dt = (DataTable) GridDSMa.DataSource;
                        Dongy(dt, GetListSKU(dt));
                        this.Close();
                    }

                }
                catch (Exception exception)
                {
                    CTLError.WriteError("FrmImportfile BTDongYClick", exception.Message);
                    return;
                    throw;
                }
               
            }
        }
        public string[] GetListSKU(DataTable dt)
        {
            string[] str=new string[dt.Rows.Count];
            try
            {
                int i = 0;
                foreach (DataRow dataRow in dt.Rows)
                {
                    str[i] = dataRow["SKU"].ToString();
                    i++;
                }
            }
            catch (Exception ex)
            {
                CTLError.WriteError("FrmImportfile GetLiskSKU", ex.Message);
                return null;
                throw new Exception(ex.Message);
            }
            return str;
        }
        public void ImPort_Excel()
        {
            DataTable dt=new DataTable();
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "*.xls|*.xls|*.xlsx|*.xlsx";
                CTLImportExcel excel = new CTLImportExcel();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file=new FileInfo(dialog.FileName);
                    if(file.Extension.ToString().Trim().ToUpper()==".XLS")
                        dt= excel.getDataFromXLS(dialog.FileName);
                    else if (file.Extension.ToString().Trim().ToUpper() == ".XLSX")
                    {
                        dt = excel.getDataFromXLS2007(dialog.FileName);
                    }
                    int dem = 0;
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName.ToUpper() == "SKU")
                        {
                            dem++;
                        }
                    }
                    if(dem==0)
                        return;
                    string listma=LayDKMaSKUsql(dt);
                    if (listma.Trim() == "and SKU in )")
                        return;
                    if(dt.Rows.Count>=1)
                    {//code cu
                        TPSDataAccess access = new TPSDataAccess(_PathFileINVMST);
//                        DataTable source = access.GetTableDM(@"Select SKU,UPC,Description,Price,CurrencyCode,Sell_Unit from INVMST 
//                                                                where 1=1 "+listma);
//                        if (source.Rows.Count >= 1)
//                            GridDSMa.DataSource = source;

                        //sua lai
                        DataTable dttemp=new DataTable();
                        dttemp.Columns.Add("SKU");
                        dttemp.Columns.Add("UPC");
                        dttemp.Columns.Add("Description");
                        dttemp.Columns.Add("Price");
                        dttemp.Columns.Add("CurrencyCode");
                        dttemp.Columns.Add("Sell_Unit");
                        foreach (DataRow r in dt.Rows)
                        {
                            if(r["SKU"].ToString()!=string.Empty)
                            {
                                DataTable source = access.GetTableDM(string.Format(@"Select SKU,UPC,Description,Price,CurrencyCode,Sell_Unit from INVMST 
                                                                                                where 1=1 and sku='{0}'",r["SKU"].ToString()));
                                if(source.Rows.Count>0)
                                {
                                    DataRow nrow = dttemp.NewRow();
                                    nrow["SKU"] = source.Rows[0]["SKU"];
                                    nrow["UPC"] = source.Rows[0]["UPC"];
                                    nrow["Description"] = source.Rows[0]["Description"];
                                    nrow["Price"] = source.Rows[0]["Price"];
                                    nrow["CurrencyCode"] = source.Rows[0]["CurrencyCode"];
                                    nrow["Sell_Unit"] = source.Rows[0]["Sell_Unit"];
                                    dttemp.Rows.Add(nrow);
                                }
                            }
                        }
                        if(dttemp.Rows.Count>0)
                            GridDSMa.DataSource = dttemp;
                    }
                    
                }

            }
            catch (Exception ex)
            {
                CTLError.WriteError("FrmImportfile ImportExcel", ex.Message);
                return;
                throw new Exception(ex.Message);
            }
             
        }
        public string LayDKMaSKUsql(DataTable dt)
        {
            string sql = " and SKU in (";
            try
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    sql += "'" + dataRow["SKU"].ToString() + "',";
                }
                sql=sql.Remove(sql.Length - 1);
                sql += ")";
            }
            catch (Exception ex)
            {
                CTLError.WriteError("FrmImportfile layDKMaSKU", ex.Message);
                return "";
                throw new Exception(ex.Message);
            }
            return sql;
        }

        private void BTthoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ImPort_Excel();
        }
    }
}