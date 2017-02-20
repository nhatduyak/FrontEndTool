using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SGC_Tool.MyControls;

namespace SGC_Tool.FrmDonDatHang
{
    public partial class FrmQuanlyDDH : DevExpress.XtraEditors.XtraForm
    {
        public FrmQuanlyDDH()
        {
            InitializeComponent();
        }
        #region xu ly su kien tren form

        private void checkNgayTao_CheckedChanged(object sender, EventArgs e)
        {
            if(checkNgayTao.Checked)
            {
                TuNgay.Enabled = true;
                DenNgay.Enabled = true;
            }
            else
            {
                TuNgay.Enabled = false;
                TuNgay.Enabled = false;
            }
        }
        private void BTthoat_Click(object sender, EventArgs e)
        {
            CTLQuanLyForm.formName.Remove(this.Name);
            this.Dispose();
            this.Close();

        }
        private void btclear_Click(object sender, EventArgs e)
        {
            checkNgayTao.Checked = false;
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            if (GrDSSKU.DataSource!=null)
                ((DataTable)GrDSSKU.DataSource).Clear();
        }

        private void btsearch_Click(object sender, EventArgs e)
        {
            DataTable dt = CTLDonDatHang.GetDonDatHang(txtHoTen.Text, txtSoDienThoai.Text, txtDiaChi.Text,
                                                       checkNgayTao.Checked, TuNgay.Value, DenNgay.Value);
            GrDSSKU.DataSource = dt;
        }

        #endregion

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if(gridView1.FocusedRowHandle<0)
                return;
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(row==null)
                return;
            EntityDonDatHang ddh=new EntityDonDatHang();
            ddh.ID = row["ID"].ToString();
            ddh.HoTen = row["HoTen"].ToString();
            ddh.DT = row["DienThoai"].ToString();
            ddh.DiaChi = row["DiaChi"].ToString();
            ddh.NgayTao = Convert.ToDateTime(row["NgayTao"]);
            ddh.GhiChu = row["GhiChu"].ToString();
            ddh.SoLuong = Convert.ToDecimal(row["SoLuong"]);
            ddh.ThanTien = Convert.ToDecimal(row["ThanhTien"]);
            FrmCTDonDatHang ct=new FrmCTDonDatHang(ddh);
            ct.ShowDialog();
        }

        private void FrmQuanlyDDH_FormClosing(object sender, FormClosingEventArgs e)
        {
            CTLQuanLyForm.formName.Remove(this.Name);
        }

        private void FrmQuanlyDDH_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F2)
            {
                txtHoTen.Focus();
            }
            else if(e.KeyCode==Keys.F3)
            {
                txtSoDienThoai.Focus();
            }
            else if(e.KeyCode==Keys.F4)
            {
                btsearch_Click(null,null);
            }
            else if(e.KeyCode==Keys.F5)
            {
                btclear_Click(null,null);
            }
        }

        

        

        
    }
}