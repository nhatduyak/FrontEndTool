using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SGC_Tool
{
    public partial class FrmAddComment : DevExpress.XtraEditors.XtraForm
    {
        public FrmAddComment()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(richTextEdit1._isfinish)
            {
                this.Dispose();
                this.Close();
            }
        }
    }
}