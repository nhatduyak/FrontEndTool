using System.Windows.Forms;

namespace SGC_Tool.MyControls
{
    public partial class Attachment : UserControl
    {
        public Attachment()
        {
            InitializeComponent();
            RichText = new RichTextBox();
            RichText = txtAtt;
        }

        public RichTextBox RichText;

    }
}
