using System;
using System.Data;
using System.Windows.Forms;
using TOOLChuyenDuLieu.ControlEntity;
using System.IO;

namespace SGC_Tool.FrmBangbaoGia
{
    public partial class FrmSearchBBGia : DevExpress.XtraEditors.XtraForm
    {
        private long _Const_datetime = 36161;
        public delegate void GetStringSKU(string MyString1,string sl);
        // khai báo 1 kiểu hàm delegate
        public GetStringSKU MyGetData;    
        public FrmSearchBBGia()
        {
            InitializeComponent();
            try
            {

                DataTable dt = Config._tableDMSKU;
                if(!dt.Columns.Contains("GhiChu"))
                    dt.Columns.Add("GhiChu");
                if (!dt.Columns.Contains("SoLuong"))
                    dt.Columns.Add("SoLuong");
               
                GrDSSKU.DataSource = dt;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("FrmSearchBBGia_Load FormTimKiem Bang bao gia", ex.Message);
                return;
            }
           
        }

        private void FrmSearchBBGia_Load(object sender, EventArgs e)
        {
            
        }
        public bool CheckFile()
        {
            try
            {
                FileInfo fileInfo = new FileInfo(@"C:\WINDOWS\Temp\INVMST.tps");
                if(!fileInfo.Exists)
                {
                    File.Copy(Path.Combine(Config._pathfileWinDSS,"INVMST.TPS"),fileInfo.FullName);
                }
                else if(fileInfo.LastWriteTime.ToString("ddMMyyyy")!=DateTime.Now.ToString("ddMMyyyy"))
                {
                    File.Copy(Path.Combine(Config._pathfileWinDSS, "INVMST.TPS"), fileInfo.FullName);
                }
                return true;
            }
            catch (Exception e)
            {
                CTLError.WriteError("CheckFile FormTimKiem Bang bao gia", e.Message);
                return false;
                throw;
            }
        }

        private void grbtxoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(gridView1.FocusedRowHandle<0)
                return;

            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (MyGetData != null)
            {
                MyGetData(row["SKU"].ToString(), row["SoLuong"].ToString());
                this.Close();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if(gridView1.FocusedRowHandle<0)
                return;
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(MyGetData!=null)
            {
                FrmThongTinKMOfSKU frm = new FrmThongTinKMOfSKU(row["SKU"].ToString());
                frm.ShowDialog();
            }
        }

        private void FrmSearchBBGia_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtsku_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                gridView1.ActiveFilterString = "[SKU] Like '%"+txtsku.Text+"'";
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtsku.Text = "";
                gridView1.ActiveFilterString = "[SKU] Like '" + txtsku.Text + "'";
            }
        }

        private void btnangcao_Click(object sender, EventArgs e)
        {
            //FilterControl f=new FilterControl();
            //gridView1.ShowCustomFilterDialog(CTenHangHoa);
            //gridView1.ShowFilterPopup(CTenHangHoa);
            gridView1.ShowFilterEditor(CTenHangHoa);
            //gridView1.ActiveFilterEnabled = true;
            //f.Show();
        }

        private void txtupc_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
              
                gridView1.ActiveFilterString = "[UPC] Like '" + txtupc.Text + "'";
            }
            else if(e.KeyCode==Keys.Escape)
            {
                txtupc.Text = "";
                gridView1.ActiveFilterString = "[UPC] Like '" + txtupc.Text + "'";
            }
        }

        private void txttenhh_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                string[] str = txttenhh.Text.Split(' ');
                string strfilter = "";
                int i = 0;
                foreach (string s in str)
                {
                    //string s1 = s.Replace("&", " and ");
                    //s1 = s1.Replace("|", " or ");
                string dk = "";
                if (i > 0)
                    dk = " and ";
                    if (s.Substring(0, 1) == "&")
                        dk = " and ";
                    else if(s.Substring(0,1)=="|")
                    {
                        dk = " or ";
                    }
                    strfilter += dk+"[DESCRIPTION] like '%" + s.Replace("&","").Replace("|","") + "%' ";
                    i++;
                }
                //gridView1.ActiveFilterString = "[DESCRIPTION] Like '%" + txttenhh.Text + "'";
                gridView1.ActiveFilterString = strfilter;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txttenhh.Text = "";
                gridView1.ActiveFilterString = "[DESCRIPTION] Like '%" + txttenhh.Text + "%'";
            }
        }

        
    }
}