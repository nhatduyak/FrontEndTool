using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SGC_Tool.MyControls
{
    public partial class ControlAtt : UserControl
    {
        public LinkLabel getlink
        {
            get { return link; }
            set { link = value; }
        }
        public PictureBox getpicturebox
        {
            get { return pictureBox1; }
            set { pictureBox1 = value; }
        }
        public ControlAtt()
        {
            InitializeComponent();
            pictureBox1.Image = imageList1.Images[0];
        }
    }
}
