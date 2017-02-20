using System.Windows.Forms;

namespace SGC_Tool
{
    public partial class FrmMessage : Form
    {
        public FrmMessage(string Message)
        {
            InitializeComponent();
            lblThongBao.Text = Message;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        

    }
}
