using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TOOLChuyenDuLieu.ControlEntity;

namespace SGC_Tool.Test
{
    public partial class TestFrm : Form
    {
        public TestFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CTLImportExcel ex=new CTLImportExcel();
            OpenFileDialog open=new OpenFileDialog();
            open.Filter = "*.xlsx|*.xlsx";
            if (open.ShowDialog() == DialogResult.OK)
            {
                 DataTable dt= ex.getDataFromXLS2007(open.FileName);
                dataGridView1.DataSource = dt;
            }
            if(dataGridView1.DataSource!=null)
            {
                //DataTable dt =(DataTable) dataGridView1.DataSource;
                //tspdata
                //foreach (DataRow r in dt.Rows)
                //{
                    
                //}
            }
               
        }
    }
}
