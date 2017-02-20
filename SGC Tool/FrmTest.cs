using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TOOLChuyenDuLieu;
using System.IO;

namespace SGC_Tool
{
    public partial class FrmTest : DevExpress.XtraEditors.XtraForm
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TPSDataAccess acces = new TPSDataAccess(@"D:\WinDSS\Data\INVEVT.tps");
            DataTable dt=new DataTable();
            dt = acces.GetDataTable("Select * from INVEVT where Method=25 and Stop>=108847 and Stop<=109211");
            GridDSMa.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            gridView1.ExportToXlsx(Path.Combine(Application.StartupPath,"DS Stop 2099.xlsx"));
        }
    }
}