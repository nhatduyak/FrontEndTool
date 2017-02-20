using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SGC_Tool.FrmDonDatHang
{
    public partial class FrmCTDonDatHang : DevExpress.XtraEditors.XtraForm
    {
        public FrmCTDonDatHang()
        {
            InitializeComponent();
        }
        public FrmCTDonDatHang(EntityDonDatHang ddh)
        {
            InitializeComponent();
            DataTable dt= CTLDonDatHang.SearchCTDDH(ddh.ID);
            GrDSSKU.DataSource = dt;
            loadData(ddh);
        }
        public void loadData(EntityDonDatHang ddh)
        {
            labHoTen.Text = ddh.HoTen;
            labngayTao.Text = ddh.NgayTao.ToString("dd/MM/yyyy");
            labDienThoai.Text = ddh.DT;
            labDiaChi.Text = ddh.DiaChi;
            labreco.Text = gridView1.DataRowCount.ToString();
            labtongsoluong.Text = ddh.SoLuong.ToString("N0");
            labtongthanhtien.Text = ddh.ThanTien.ToString("N2");

        }
    }
}