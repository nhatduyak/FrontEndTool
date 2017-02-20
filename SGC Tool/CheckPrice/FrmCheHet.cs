using System;
using System.Windows.Forms;

namespace CheckPrice
{
    public partial class FrmCheHet : Form
    {
        //private IContainer components;
        private Form frm;

        public FrmCheHet()
        {
            InitializeComponent();
        }
        public FrmCheHet(Form frmChild)
        {
            this.InitializeComponent();
            this.frm = frmChild;
        }
        private void FrmCheHet_Load(object sender, EventArgs e)
        {
            base.Location = base.Owner.Location;
            base.Size = base.Owner.Size;
        }

        private void FrmCheHet_Shown(object sender, EventArgs e)
        {
            if (this.frm != null)
            {
                this.frm.ShowDialog(this);
            }
            base.Dispose();
        }
    }
}
