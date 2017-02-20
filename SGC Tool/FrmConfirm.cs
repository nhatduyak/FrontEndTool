using System.Windows.Forms;

namespace SGC_Tool
{
    public partial class FrmConfirm : Form
    {
        public enum ButtonResult
        {
            OK,
            Cancel
        }

        public FrmConfirm(string Message)
        {
            InitializeComponent();
            lblThongBao.Text = Message;
        }

        public ButtonResult buttonRes;
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            buttonRes = ButtonResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            buttonRes = ButtonResult.Cancel;
            this.Close();
        }

        

    }
}
