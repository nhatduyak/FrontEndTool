using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SGC_Tool.FrmScaleAdappterTool
{
    public partial class FrmThongBaoExport : Form
    {
        public bool _isfilter=false;
        public bool _isclose = false;
        public bool _isThoat = false;
        public FrmThongBaoExport()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _isThoat = true;

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _isfilter = true;
            this.Close();
        }
        public delegate void isxuattoanbods();
        public isxuattoanbods bt_xuattoanDS;
        private void button1_Click(object sender, EventArgs e)
        {
            _isfilter = false;
            if(bt_xuattoanDS!=null)
            {
                bt_xuattoanDS();
                this.Close();
            }
        }
    }
}
