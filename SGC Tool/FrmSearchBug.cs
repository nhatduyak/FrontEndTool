using System;
using System.Data;
using System.Drawing;
using System.Text;
using DevExpress.XtraRichEdit.API.Native;
using SGC_Tool.MyControls;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using TOOLChuyenDuLieu.ControlEntity;
using Application = System.Windows.Forms.Application;
using TPMessageBox;
using DevExpress.XtraRichEdit;
using System.Drawing.Printing;

namespace SGC_Tool
{
    public partial class FrmSearchBug : DevExpress.XtraEditors.XtraForm
    {
        public bool _isPrintClick = false;


        private CTLSearchBug _control;
        private DataTable _Tablemanin;
        private DataTable _TableAttfile;
        private DataTable _dataFeedBack;
        private bool _istextchange = false;
        private int i = -1;//count listnode search
        List<TreeNode> list = new List<TreeNode>();
        private string _IDDocument="";
        public FrmSearchBug()
        {
            InitializeComponent();
            _control = new CTLSearchBug();
            LoadTree();
        }

        //private void simpleButton1_Click(object sender, EventArgs e)
        //{
        //    LinkLabel lin=new LinkLabel();
        //    lin.Text = dem.ToString() + "ậh dhfdjh sdjfsdjh";
        //    flowLayoutPanel1.Controls.Add(lin);
        //}
   
        void LoadTree()
        {
            DataTable lstApp = _control.LoadAllApplication();
            TreeNode root = new TreeNode("Quản lý document");
            root.Name = "-1";
            tvDocument.Nodes.Add(root);
            CTLSearchBug ctlSearchBug=new CTLSearchBug();
            foreach (DataRow row in lstApp.Rows)
            {
                TreeNode nodeApp = new TreeNode(Convert.ToString(row[0])+"   ( "+ctlSearchBug.GetMaxdatemodify(Convert.ToString(row[0]).Trim())+" )");
                nodeApp.ImageIndex = 0;
                nodeApp.SelectedImageIndex = 0;
                DataTable lstItem = _control.LoadDetailForApp(Convert.ToString(row[0]));
                root.Nodes.Add(nodeApp);
                foreach (DataRow rowItem in lstItem.Rows)
                {
                    TreeNode nodeItem = new TreeNode(Convert.ToString(rowItem["Item"]) + "   ( " + ctlSearchBug.GetMaxdatemodify(Convert.ToString(row[0]).Trim(), Convert.ToString(rowItem["Item"]).Trim())+" )", 1, 1);
                    nodeApp.Nodes.Add(nodeItem);
                    DataTable dtevent=new DataTable();
                    dtevent = _control.LoadEventForApp(Convert.ToString(row[0]), Convert.ToString(rowItem["Item"]));
                    foreach (DataRow rowevent in dtevent.Rows)
                    {
                        object datemodify = rowevent["DateModify"];
                        TreeNode nodeEvent = new TreeNode(Convert.ToString(rowevent["Event"]) + "   ( " + (datemodify.ToString() == string.Empty ? Convert.ToDateTime(rowevent["DateCreated"]).ToString("dd-MM-yy HH:mm:ss") : Convert.ToDateTime(datemodify).ToString("dd-MM-yy HH:mm:ss")) + " )", 2, 2);
                        //nodeEvent.Text = Convert.ToString(rowevent["Event"]);
                        nodeEvent.Name = Convert.ToString(rowevent["ID"]);
                        nodeItem.Nodes.Add(nodeEvent);
                    }
                }
            }
            root.Expand();
        }

        private void txtserch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if(txtserch.Text==string.Empty)
                {
                    return;
                }
                    
                TreeNode node= tvDocument.SelectedNode;
                _Tablemanin = null;
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.Controls.Add(labThongTinlienQuang);
                Webdetail.RtfText = "";
                flowAtt.Visible = false;
                btviewCm.Enabled = false;
                _isshowdocumet = true;
                btviewCm.Text = "View comment";
                _document = "";
                //if(node.Parent==null)
                //{
                    _Tablemanin = _control.SearchBytitle(txtserch.Text);
                    loaddata(_Tablemanin);
                //}
                //else if (node.Level==1)
                //{
                //    _Tablemanin = _control.SearchBySelectedDC(node.Text,txtserch.Text);
                //    loaddata(_Tablemanin);
                //}
                //else if(node.Level==2)
                //{
                //    _Tablemanin = _control.SearchBySelectedItem(node.Parent.Text, txtserch.Text,node.Text);
                //    loaddata(_Tablemanin);
                //}
            }
        }
        public void loaddata(DataTable dataTable)
        {
            if(dataTable==null)
                return;
            if (dataTable.Rows.Count<=0)
            {
                return;
            }
            _isPrintClick = false;
            //Webdetail.Document.
            CTLSearchBug searchBug=new CTLSearchBug();
            using (DataTable createdocument = searchBug.GetCreateDocument(dataTable.Rows[0]["ID"].ToString()))
            {
                if (createdocument != null)
                {
                    if (createdocument.Rows.Count > 0)
                    {
                        string create = createdocument.Rows[0]["Creator"].ToString();
                        string date = createdocument.Rows[0]["DateCreated"].ToString();
                        if (createdocument.Rows[0]["UpDateBy"].ToString().Trim() != "NULL" && createdocument.Rows[0]["UpDateBy"].ToString().Trim() != "null")
                            create = createdocument.Rows[0]["UpDateBy"].ToString();
                        DataTable tbTenNV = searchBug.GetNameCreateDoc(create);
                        //Webdetail.Document.
                        Webdetail.CreateNewDocument();
                        if (createdocument.Rows[0]["DateModify"].ToString() != string.Empty)
                            date = createdocument.Rows[0]["DateModify"].ToString();
                        if (tbTenNV != null)
                            if (tbTenNV.Rows.Count > 0)
                            {
                                create = tbTenNV.Rows[0]["TenNV"] + " - " + tbTenNV.Rows[0]["MaST"] + " - " + tbTenNV.Rows[0]["TenSieuThi"];
                            }

                        string s = @"<!DOCTYPE html PUBLIC " + '"' + "-//W3C//DTD XHTML 1.0 Transitional//EN" + '"' + " " + '"' + "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" + '"' + @">
                        <html>
	                        <head>
		                        <meta HTTP-EQUIV=" + '"' + "Content-Type" + '"' + " CONTENT=" + '"' + "text/html; charset=utf-8" + '"' + @" /><title>

		                        </title><style type=" + '"' + "text/css" + '"' + @">
			                        .cs742CAEF8{text-align:center;text-indent:36pt;padding:0pt 0pt 0pt 0pt;margin:0pt 0pt 0pt 36pt}
			                        .cs5EFED22F{color:#000000;background-color:#FFFFC0;font-family:Times New Roman; font-size:11pt; font-weight:normal; font-style:italic; }
			                        .cs676C7CC9{text-align:left;text-indent:0pt;padding:0pt 0pt 0pt 0pt;margin:0pt 0pt 0pt 0pt}
			                        .csC0D2101E{color:#0000FF;background-color:#FFFFC0;font-family:Times New Roman; font-size:11pt; font-weight:normal; font-style:italic; }
                                    .cs6EF5D217{color:#0000FF;background-color:#FFFFC0;font-family:Times New Roman; font-size:11pt; font-weight:normal; font-style:italic; }
                                    .cs3D49C0F4{text-align:center;text-indent:36pt;padding:0pt 0pt 0pt 0pt;margin:0pt 0pt 0pt 36pt}
                                    
		                        </style>
	                        </head><body>
		                        <span><p class=" + '"' + @"cs742CAEF8" + '"' + @"><span class=" + '"' + @"csC0D2101E" + '"' + @">" + date + "    --  Tài liệu mật - lưu hành nội bộ  " + @"</span><span class=" + '"' + "csC0D2101E" + '"' + @">			</span><span class=" + '"' + @"csC0D2101E" + '"' + @"> " + "" + @"</span></p></span><p class=" + '"' + "cs3D49C0F4" + '"' + "><span class=" + '"' + "cs6EF5D217" + '"' + @"></span></p><p class=" + '"' + @"cs742CAEF8" + '"' + @"><span class=" + '"' + @"cs5EFED22F" + '"' + @">-------------------------------------------------------</span></p>
	                        </body>
                        </html>"
                            ;


                        //bk cu date --ten -- data tao
                        /*
                         <span><p class=" + '"' + @"cs742CAEF8" + '"' + @"><span class=" + '"' + @"csC0D2101E" + '"' + @">" + date + "    --    " + @"</span><span class=" + '"' + "csC0D2101E" + '"' + @">			</span><span class=" + '"' + @"csC0D2101E" + '"' + @"> " + create + @"</span></p></span><p class=" + '"' + "cs3D49C0F4" + '"' + "><span class=" + '"' + "cs6EF5D217" + '"' + @">Tài liệu mật - lưu hành nội bộ</span></p><p class=" + '"' + @"cs742CAEF8" + '"' + @"><span class=" + '"' + @"cs5EFED22F" + '"' + @">-------------------------------------------------------</span></p>
                         */

                        RichEditControl richEditControl = new RichEditControl();
                        richEditControl.HtmlText = s;
                        richEditControl.Refresh();
                        Webdetail.Document.InsertRtfText(Webdetail.Document.CaretPosition, richEditControl.RtfText);
                        richEditControl.Dispose();
                    }
                }

                //Webdetail.RtfText = dataTable.Rows[0]["IssueContent"].ToString();
                RichEditControl noidungftf = new RichEditControl();
                noidungftf.RtfText = dataTable.Rows[0]["IssueContent"].ToString();
                Webdetail.Document.InsertRtfText(Webdetail.Document.CaretPosition, noidungftf.RtfText);
                noidungftf.Dispose();
                _TableAttfile = null;
                _TableAttfile = _control.GetAttachment(dataTable.Rows[0]["ID"].ToString());

                //loadAttachmentFile(_TableAttfile);
                _IDDocument = dataTable.Rows[0]["ID"].ToString();
                if (CheckFeedback(_IDDocument))
                {
                    //Webdetail.Height -= 30;
                    btviewCm.Enabled = true;
                }
                else
                {
                    btviewCm.Enabled = false;
                }
                if (_TableAttfile != null)
                {
                    loadAttachmentFile(_TableAttfile);
                }
                for (int i = 1; i < dataTable.Rows.Count; i++)
                {
                    ControlAtt controlAtt = new ControlAtt();
                    //LinkLabel linkLabel=new LinkLabel();
                    //linkLabel.Text = dataTable.Rows[i]["Event"].ToString();
                    //linkLabel.Name = i.ToString();
                    //linkLabel.LinkClicked+=new LinkLabelLinkClickedEventHandler(linkLabel_LinkClick);
                    //flowLayoutPanel1.Controls.Add(linkLabel);
                    controlAtt.getlink.Text = dataTable.Rows[i]["Event"].ToString();
                    controlAtt.getlink.Name = i.ToString();
                    controlAtt.getlink.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel_LinkClick);
                    controlAtt.getpicturebox.Image = imageList2.Images[0];
                    flowLayoutPanel1.Controls.Add(controlAtt);
                }
            } ;
            
        }
        protected void linkLabel_LinkClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel) sender;
            Webdetail.CreateNewDocument();
            CTLSearchBug searchBug = new CTLSearchBug();
            DataTable createdocument = searchBug.GetCreateDocument(_Tablemanin.Rows[Convert.ToInt32(link.Name)]["ID"].ToString());
            if (createdocument != null)
            {
                if (createdocument.Rows.Count > 0)
                {
                    _isPrintClick = false;
                    string create = createdocument.Rows[0]["Creator"].ToString();
                    string date = createdocument.Rows[0]["DateCreated"].ToString();
                    if (createdocument.Rows[0]["UpDateBy"].ToString().Trim() != "NULL" && createdocument.Rows[0]["UpDateBy"].ToString().Trim() == "null")
                        create = createdocument.Rows[0]["UpDateBy"].ToString();
                    DataTable tbTenNV = searchBug.GetNameCreateDoc(create);
                    Webdetail.CreateNewDocument();
                    if (createdocument.Rows[0]["DateModify"].ToString() != string.Empty)
                        date = createdocument.Rows[0]["DateModify"].ToString();
                    if (tbTenNV != null)
                        if (tbTenNV.Rows.Count > 0)
                        {
                            create = tbTenNV.Rows[0]["TenNV"] + " - " + tbTenNV.Rows[0]["MaST"] + " - " + tbTenNV.Rows[0]["TenSieuThi"];
                        }

                    string s = @"<!DOCTYPE html PUBLIC " + '"' + "-//W3C//DTD XHTML 1.0 Transitional//EN" + '"' + " " + '"' + "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" + '"' + @">
                        <html>
	                        <head>
		                        <meta HTTP-EQUIV=" + '"' + "Content-Type" + '"' + " CONTENT=" + '"' + "text/html; charset=utf-8" + '"' + @" /><title>

		                        </title><style type=" + '"' + "text/css" + '"' + @">
			                        .cs742CAEF8{text-align:center;text-indent:36pt;padding:0pt 0pt 0pt 0pt;margin:0pt 0pt 0pt 36pt}
			                        .cs5EFED22F{color:#000000;background-color:#FFFFC0;font-family:Times New Roman; font-size:11pt; font-weight:normal; font-style:italic; }
			                        .cs676C7CC9{text-align:left;text-indent:0pt;padding:0pt 0pt 0pt 0pt;margin:0pt 0pt 0pt 0pt}
			                        .csC0D2101E{color:#0000FF;background-color:#FFFFC0;font-family:Times New Roman; font-size:11pt; font-weight:normal; font-style:italic; }
                                    .cs6EF5D217{color:#0000FF;background-color:#FFFFC0;font-family:Times New Roman; font-size:11pt; font-weight:normal; font-style:italic; }
                                    .cs3D49C0F4{text-align:center;text-indent:36pt;padding:0pt 0pt 0pt 0pt;margin:0pt 0pt 0pt 36pt}

		                        </style>
	                        </head><body>
		                        <span><p class=" + '"' + @"cs742CAEF8" + '"' + @"><span class=" + '"' + @"csC0D2101E" + '"' + @">" + date + "    --    " + @"</span><span class=" + '"' + "csC0D2101E" + '"' + @">			</span><span class=" + '"' + @"csC0D2101E" + '"' + @"> " + create + @"</span></p></span><p class=" + '"' + "cs3D49C0F4" + '"' + "><span class=" + '"' + "cs6EF5D217" + '"' + @">Tài liệu mật - lưu hành nội bộ</span></p><p class=" + '"' + @"cs742CAEF8" + '"' + @"><span class=" + '"' + @"cs5EFED22F" + '"' + @">-------------------------------------------------------</span></p>
	                        </body>
                        </html>"
                        ;
                    RichEditControl richEditControl = new RichEditControl();
                    richEditControl.HtmlText = s;
                    richEditControl.Refresh();
                    Webdetail.Document.InsertRtfText(Webdetail.Document.CaretPosition, richEditControl.RtfText);
                    richEditControl.Dispose();
                }
            }

            //Webdetail.RtfText = dataTable.Rows[0]["IssueContent"].ToString();
            RichEditControl noidungftf = new RichEditControl();
            noidungftf.RtfText = _Tablemanin.Rows[Convert.ToInt32(link.Name)]["IssueContent"].ToString();
            Webdetail.Document.InsertRtfText(Webdetail.Document.CaretPosition, noidungftf.RtfText);
            noidungftf.Dispose();
            //Webdetail.RtfText = _Tablemanin.Rows[Convert.ToInt32(link.Name)]["IssueContent"].ToString();
            _IDDocument = _Tablemanin.Rows[Convert.ToInt32(link.Name)]["ID"].ToString();
            if (CheckFeedback(_IDDocument))
            {
                //Webdetail.Height -= 30;
                btviewCm.Enabled = true;
            }
            else
            {
                btviewCm.Enabled = false;
            }
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(labThongTinlienQuang);
            for (int i = 0; i < _Tablemanin.Rows.Count; i++)
            {
                if(i.ToString()==link.Name)
                    continue;
                ControlAtt controlAtt = new ControlAtt();
                //LinkLabel linkLabel = new LinkLabel();
                //linkLabel.Text = _Tablemanin.Rows[i]["Title"].ToString();
                //linkLabel.Name = i.ToString();
                //linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel_LinkClick);
                //flowLayoutPanel1.Controls.Add(linkLabel);
                controlAtt.getlink.Text = _Tablemanin.Rows[i]["Event"].ToString();
                controlAtt.getlink.Name = i.ToString();
                controlAtt.getlink.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel_LinkClick);
                controlAtt.getpicturebox.Image = imageList2.Images[0];
                flowLayoutPanel1.Controls.Add(controlAtt);
            }
            _TableAttfile = null;
            _TableAttfile = _control.GetAttachment(_Tablemanin.Rows[Convert.ToInt32(link.Name)]["ID"].ToString());
            loadAttachmentFile(_TableAttfile);
            createdocument.Dispose();
            _TableAttfile = null;

        }
        public void LoadDataLinkClick(LinkLabel linkLabel)
        {
            
        }
        public void loadAttachmentFile(DataTable dt)
        {
            if(dt==null)
            {
                flowAtt.Visible = false;
                return;
            }
            if(dt.Rows.Count<=0)
            {
                flowAtt.Visible = false;
                return;
            }
            flowAtt.Visible = true;
            string filename = "file att";
            flowAtt.Controls.Clear();
            foreach (DataRow dataRow in dt.Rows)
            {
                LinkLabel linkLabelatt=new LinkLabel();
                //linkLabelatt.Text = dataRow["Name"].ToString();
                ControlAtt att=new ControlAtt();
                string[] listname = dataRow["Title"].ToString().Split(';');
                foreach (string s in listname)
                {
                    if (s.Substring(0,dataRow["ID"].ToString().Trim().Length+1).Equals(dataRow["ID"].ToString().Trim() + "-"))
                    {
                        filename = s;
                        int index = filename.IndexOf('-') + 1;
                        int length = s.Length - index;
                        filename = filename.Substring(index, length);
                        break;
                    }
                }
                //linkLabelatt.Name = dataRow["ID"].ToString();
                //linkLabelatt.Text = filename;
                //linkLabelatt.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabelAttment_LinkClick);
                att.getlink.Name = dataRow["ID"].ToString();
                att.getlink.Text = filename;
                att.getlink.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabelAttment_LinkClick);
                //flowAtt.Controls.Add(linkLabelatt);
                flowAtt.Controls.Add(att);
            }
        }
        protected void linkLabelAttment_LinkClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog save=new SaveFileDialog();
            LinkLabel link = (LinkLabel) sender;
            save.InitialDirectory = Application.ExecutablePath.ToString();
            save.Filter = "All files (*.*)|*.*";
            save.FilterIndex = 1;
            save.RestoreDirectory = true;
            string filename = "";
            DataRow[] rowatt = _TableAttfile.Select(string.Format("ID='{0}'", link.Name));
         

            if(rowatt.Length==1)
            {  
                string Strnameatt = _TableAttfile.Select(string.Format("ID='{0}'", link.Name))[0]["Title"].ToString();
                string[] listname = Strnameatt.Split(';');
                foreach (string s in listname)
                {
                    if (s.Substring(0, rowatt[0]["ID"].ToString().Trim().Length + 1).Equals(rowatt[0]["ID"].ToString().Trim() + "-"))
                    {
                        filename = s;
                        break;
                    }
                }
                save.FileName = filename;
                if(save.ShowDialog()==DialogResult.OK)
                {
                        File.WriteAllBytes(save.FileName, (byte[]) rowatt[0]["Attachment"]);
                }
            }
        }
        private void flowAtt_VisibleChanged(object sender, EventArgs e)
        {
            if (flowAtt.Visible == false)
            {
                if (flowAtt.Location == Webdetail.Location)
                    return;
                Webdetail.Location = new Point(flowAtt.Location.X, flowAtt.Location.Y);
                Webdetail.Height += 44;
            }
            else
            {
                Webdetail.Location = new Point(Webdetail.Location.X, Webdetail.Location.Y + 44);
                Webdetail.Height = Webdetail.Height - 44;
            }
        }

        private void btprint_Click(object sender, EventArgs e)
        {
//            Webdetail.HtmlText =
//                Webdetail.HtmlText.Replace(@"<p class=" + '"' + "cs3D49C0F4" + '"' + @"><span class=" + '"' + "cs80072B89" + '"' + @">-------------------------------------------------------</span></p>",
//                                           @"<p class=" + '"' + "cs3D49C0F4" + '"' + "><span class=" + '"' + "cs6EF5D217" + '"' + @">Tài liệu mật - lưu hành nội bộ</span></p>
//<p class=" + '"' + "cs3D49C0F4" + '"' + @"><span >-------------------------------------------------------</span>");
            //Webdetail.Document.;
            using (RichEditControl richEditControl=new RichEditControl())
            {
                string Chuoilogo = @"{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}}{\colortbl\red0\green0\blue0 ;\red0\green0\blue255 ;}{\*\listoverridetable}{\stylesheet {\ql\cf0 Normal;}{\*\cs1\cf0 Default Paragraph Font;}{\*\cs2\sbasedon1\cf0 Line Number;}{\*\cs3\ul\cf1\ulc1 Hyperlink;}}\sectd\pard\plain\ql{\*\shppict{\pict\pngblip\picw1845\pich448\picwgoal1046\pichgoal254\picscalex100\picscaley100 89504e470d0a1a0a0000000d4948445200000046000000110802000000efc74d9c000000017352474200aece1ce90000000467414d
410000b18f0bfc6105000000206348524d00007a26000080840000fa00000080e8000075300000ea6000003a98000017709cba513c000000097048597300000ec400000ec401952b0e1b0000076249444154484bdd56694cdb571227bb55b5adb6abaa1f
56ea4a51aa6db29bedc768ab54ab3649a3842c4d4838024dca1d969640126e02e63e93721adc848623402017105282d7e1363ec1189ff8c4d80673d8061bdf36f6df363b16c8b028d26a2bb45af5e97d781acdfbcdfcdecc9b99039b9b9b3ebfb005947e
61cbe78d7c8c5664416d850d87ff7fc2669b53b16a73bbb73ddd4b49bc64aee9957e5bc78da864c38eab9ba9ee9589972c7b88698c0e4cdf7cc9136951e7dcbd57728b75e3673397abacddc4658bcd01084285e9ee7369e913e91632a64f6eb2d8fe2372
dd4ff2cbc5b46595764b73871204648cad89aa645da9e026b448331ec9d21fc9129b25576a0551681e81a3d90d8d9b5a3d9531e19745bc80225c2b1bd2e90d4e97dbbc81986d08e2dc56449c6eadd10172efc50d87cbee70e92d8865635bc9e5767fdf25
fd329dcc112d815a6daffc8b34ea85ecf14bb9840ba8f198d221edba0ee4169b132eae9b1cde506c61c2cb6a0cf6780c2fb4605ca3d5ff1b2550ad7d290bab60c661f895cd745c76f5486ad1487ae9606a09ee46416b2a3ab692c15b30799d6bc429cede
a63cc531e717554683c1e57257764b636bb957ee729ab142509b96186e3508038a98194d8279a51924eb4647ea03c1750c3fa494195bc3a1f2d7dc6e77ed4bf9c5c269bfbce944f4b4566fca6c1105e45348748174413537af34180c707194a589a9e6c6
a167828a19851d228dc113379dc971e799f452112bbc827db190918621230e4f9c77a2c49cd3879631a2ab39c54f24e4e49c59bf33e2f8f8d9e80871649824e2eaf33b1d51b533459db35b4f0efc4b1e4bfcf3a723ab38b71a04738beb669bebca1dd6d9
4cf23fca87c88c59c9b239b8841998337abb61c2173595f79003976822dd39d4545831bebc7dda1745cfb83fe572226dafe7cee7d1bf2e2235744da8b5a6c84a8e7f3e3dae8e178f117e57cf9fe0a9c01ca4e29719d4cc1fc693efb34e67505e53a520ac
7e213b9d4e4aaf1fbf8e66fae5d2eb9e313737b723bf9d780f700b5f9733539a442d9d53bc4bfe02541e3fa7801f19c98f8e6664e4fdd0274b69144657b315ab568033599133d9b44f1347c34ac6122a46640aa540613e933d75fb1ed162f6e409e4cfd9
db640a9dbfe946a22ab951e544b7cbd137a13e9745edc7cfaceaac40b8a865129c90ad98028b19df3f823332a7b48694b1c2cbc8b76a89376b4837aac7681c29bce1cdfb829082719341d331b274329d44a04b56b4f61319930955f84db7b97374f150c4
601b96ebcda06d4a654f2531e899ac0ed94b749720c05f545cc60b0a5c7cfc748e2d19a7ca9a0614a856514c0d674aecf1183ef1fb21c367527106831e71780a43dbf0e26ffcb1f55df0549e05c970307c98c25deea1ac1e8c184baa1903efb35bc54763
4766c40b030ced916b63986e8f723749793866b4a90fc2b8f982ac3c7c0d9f82a130c52a9a402d9cf77c77e5fac6d1386260ceb0c3818455b0ff70152757ac4c8af4ef060c7c534691a9ace772e9ef5eec1f9910efa594d6c80fafe1e53d968ee65609ce
ff9d1712c2bb705e147a598cbe3fc65e6b1954e4b58b834ba6095c8f995e8ad2e72c36194df0a2a435097d4ef76089822d4943bff4805fff7bc1c3bff2c31e09eb620be490b1c753a81f04f4e875ebf91d129f13dd3d2333a099da28f439d98325782ea2
5a853ea7fadef67ffddba0a17702860e860f2896d728029d8f2f36b11a6fdbb07f7c8df0a7885e8bd5b26eb41f4bc01ff8eaf5fbc1033ebefd1f86f42d2c7a52746b6d4729b551f0fbd889cbf914cae5b09930cfe6e714727b872844710f555dfe4c72b1
90fec7e831c9b2a79a4b968c29f544067fde8b82a32d41aeebf4c62d09e2449afa053177f0390d04a1640124503fea5ff0eb9e52e138c250a6d5e3355a1dc8ff39b97391ca5327d5916ed6126fd410ae5711ca1e92cd66f3d29a2d094d9ce2cae0039776
b0dafae880001759b3ab0935a494baf182165aed63aa13d9e99fdb94a842ddafc3278f04bf20bffd16f9afc7e91f1da49f3c45cd2c1a4e44e557137c73e91f840ec267831a0570161ba2335aedc84e75f672d39b77a08d26b3dbf5df766ac0048fb7b677
79cf7b2c82fc0d3eecf4a5a436f9d1c881acbf04de3b15defcb7a08e4f4e741e39de7ef4f3abf1cf3f8cc07f1435ca936f076184b9165ace843c86f16298b9e670ba57f5761c7dd566771674889b07154ea77b8ca3c96c1142d5415cee51d61ad4406847
58daaac182a874762827732b16e84e3f4da8f8bb7ac32e1a3fffb84369c3ee1c6669fe7c63f27721c31fc7538ea5d08ea54c1efe8ef45ed0c027df8e4317f61aa10ad62b7a3c95f4ea5de61719542096d326c2bc9243638dc7ccc097836c49fe9177b76b
2ef9017f657d23a292b5a4b1953f97f817d0f11c4debd0625415ab8bb832cad68024eba1a78fede3da3b10c9d53654bbf8b354eaa168fca1183c1c72dbc5e0f46e936ca9615ae269d510847bfdf30ec405c50a6a06cc1faf26d5589a1a3a3db80e941812
3d34f841c61a28bf9a54016da30521f1b465cf246add06cc3b493ff2006d1ff9ec94873da050a0a0d9c300b27b9cd95fc38026555a6068da77d8374fe2fb6ee67f09f82f140d129bd36f6db50000000049454e44ae426082}}{\nonshppict{\pict\wmetafile8\picw1845\pich448\picwgoal1046\pichgoal254\picscalex100\picscaley100 
0100090000035007000000002b07000000000400000003010800050000000b0200000000050000000c0212004700030000001e0004000000070104002b070000410b2000cc00110046000000000011004600000000002800000046000000110000000100
180000000000140e000000000000000000000000000000000000ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff0000fffffffffffffffffffffffffffffffffffffffffffffffffffff7fff7f7ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff7efdeffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff0000ffffffffffffffffffffffffffffffffefe7dea57bce7339c66321c66321c67339dea584f7efe7ffffffffffffffffffffff
fff7e7d6f7deceffffffe7b59ce7bd9cffffffefceb5efc6adfffff7efceb5efcebdfffffff7d6c6dead8cf7ded6fff7eff7d6bdffffffefceb5e7b594fffff7efd6c6dead8cfff7efe7b59cd69c6bf7e7d6ffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff0000fffffffffffffffffffffffff7d6c6ce6b29c65a10c66b21d67b39ce7331ce6b29bd5208c66b
31efd6c6fffffffffffffffffff7decee7b594ffffffd68c63ce7b42ffefe7dea57be7bd9cfff7f7de9c6bce8452fff7efd69c73e7b58cd69c73fff7efd68c63fff7efdead8cd68452efd6c6efc6a5d68c63efceb5efd6c6d68452dea57bffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff0000ffffffffffffffffffe7a573bd5a2952297b5a42945239a53929
a53929ad3929a5ad6b5abd5a18c66321f7e7d6ffffffffffffefd6c6ce8452ffefe7f7efe7efd6bdfffffffff7efefceb5ffffffdea584e7bda5fffffff7d6c6de9c73e7bd9cffffffefd6c6f7e7defffff7efceb5fffff7fff7efffe7def7e7deffffff
efceb5ffe7deffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff0000fffffffffffff7decece5a00b55a
290008c63939ce2121ce4242d6847bce8473c6c69484d6844abd5a10d68c5afffffffffffffffff7fffff7fffffffffffffffffffffffffffffffffffffffffffffff7ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff0000ffff
ffffffffd69c73ce6318c67b52635ace5a5ad65a5ad6847bd6bdb5d6dec6c6efceb5dead84d68452bd6321ffefdefffffff7efe7c69473e7ded6ffffffffffffffffffefcebdc69473f7f7f7ffffffffffffffffffdebda5bd8463c69c7be7dedeffffff
ffffffdeb594c6ad94ffffffe7cebdc69473f7efefffffffe7ceb5c69c7bf7f7f7ffffffefd6c6c69473c6946bc69473c68c6bcea58cf7f7f7fff7efc6946be7d6ceffffffd6ad8cceb5a5ffffffffffffefded6c68c6bc69473ce9c84cead94ffffffff
ffffffffffffffff0000ffffffffffffdea57bd6945ae7ad848c7bc64a52de5252d65252de525ade9c94deefd6c6efc6a5dea584d68c5aefd6c6ffffffefceb5bd4a00c69473ffffffffffffffffffde9c73b54a00dec6b5ffffffffffffe7bd9cb54a00
c65a10b54a00b56329e7ded6ffffffce7339b55218f7f7f7e7ad84ad4200dec6b5ffffffdea57bad4200decebdffffffdea584b54200bd5208bd5208c65208bd5a18f7efeff7decebd4a00c68c6bffffffc66321b56329f7fff7fffff7c66b31bd5200bd
5210bd4a00b55a18efefe7ffffffffffffffffff0000ffffffffffffdead84de9463dea57bad94b54a52d68c84de5252d6adade7ded6dee7cec6e7bd9cdea57bd68c63f7decefffffff7e7debd5210bd734af7f7f7ffffffffffffefc6a5b54a08d6ad94
ffffffffffffd68c5abd6321e7d6c6efceb5bd5a18c69473ffffffdea57bbd6329e7ded6efcebdc66329cead94ffffffefc6adc66329d6b59cffffffefc6adc66329c69473efded6efd6cef7e7defffffffff7efc66329c68452ffffffd68c5ab55a18ef
e7e7f7decebd5208c6845affefe7ce7b42b55208decebdffffffffffffffffff0000ffffffffffffefbda5d68c5adea573cea59c5252de847bde8484de6363d66363de847bd6e7b59cde9c73d69463ffefe7fffffffffff7d6844ac66b39c68c63bd8c6b
efefe7f7e7ded67b4ac6947bf7ffffffffffe7b594c67b42ded6ceffffffde9463c68c63ffffffefceb5ce7b4ad6c6b5fff7f7d68452cea584ffffffffefe7d68452cead8cffffffffefe7d68c5ace8c63c69473ce9473c6946be7d6ceffffffde9c73c6
845af7f7ffe7bda5ce7b42decec6fff7efce7342c69473f7ffffefc6adbd5a21debda5ffffffffffffffffff0000fffffffffffff7deced68c5ad68c63e7ad847b73c64a4ade6b6bde6363de5a5ade5a63dea58cadde9463dea584ffffffffffffffffff
dea584d68452d68c5ade9c73efe7deffffffd68c5ace7b4abd8463ded6cef7e7ded68c5abd7b52ce9c7bce7b42d6a584fffffff7decece7b4ac68463cea584ce7b4ace9473ffffffdeb5a5ce844ac6845acead9cf7efefd68c63ce7b4ade946bd6946bde
946befd6ceffffffdead8cce7b42c69473d69c73c67342e7cebdffffffe7b594c67342c6947bce946bd6844acead94ffffffffffffffffff0000ffffffffffffffffffe7b594d69463de946bd6a5948c7bbd8c7bc68473bd8c7bbd846bbd947ba5d68c63
ffe7deffffffffffffffffffefbda5c67b42d6bdadefe7e7f7f7ffffffffe7b594d69463d68c5adeb59cfffffff7decede9c73d68452dea57bf7efe7fffffffff7f7dea57bde946bd68c5ad69463f7deceffffffe7b594ce8452d68452ce946bfff7f7de
9c7bce8452decec6efe7e7efe7defffffffffffff7d6c6d68c63de946bd68452dead84fff7effffffffff7f7e7ad8cd68452d69463d68452ce9c7bffffffffffffffffff0000fffffffffffffffffffffff7efd6bdd68c63d68c5ae7a56bdea573e7a57b
de9c6bde945ad6945af7d6c6ffffffffffffffffffffffffefceb5ce7b42c67b4ac67b52bd8463f7f7f7fffffffffffffffff7fffffffffffffffffffffffffff7f7fffffffffffffffffffffffffffffffffffffff7f7ffffffffffffffffffffffffe7
ad8cc67342efded6ffffffe7b594c67339c67b52c67b52c67b52bd8463f7f7f7fffffffffffffffffffff7f7fffffffffffffffffffffffffffffffff7f7fff7efde946bc68452f7f7f7ffffffffffff0000fffffffffffffffffffffffffffffff7e7de
e7b594d6946bd69463d68c5ade9c6be7b594ffefdefffffffffffffffffffffffffffffffffff7e7b594e7ad8cdea584e7bd9cffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffefe7efceb5fffff7fffffff7e7dee7ad8cdead84e7ad8cdea584e7b59cfff7f7ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffe7b594d68c5af7efefffffffffffff0000ffffffffffff
fffffffffffffffffffffffffffffffffff7f7efe7ffefe7fff7f7ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff7efe7ffffffffff
ffffffff0000ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffff0000ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffff0000040000002701ffff030000000000}}\par\pard\plain\ql\par}";
                if (!_isPrintClick)
                {
                    richEditControl.RtfText = Chuoilogo;
                    Webdetail.Document.InsertRtfText(Webdetail.Document.CreatePosition(0), richEditControl.RtfText);
                    _isPrintClick = true;
                }
                
                Webdetail.ShowPrintDialog();
            } 
            
        }

        private void tvDocument_DoubleClick(object sender, EventArgs e)
        {
            TreeNode nodeselect = tvDocument.SelectedNode;
            _Tablemanin = null;
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(labThongTinlienQuang);
            _isshowdocumet = true;
            _document = "";
            btviewCm.Text = "View comment";
            if(nodeselect.Level==3)
            {
                _Tablemanin = _control.SearchByID(nodeselect.Name);
                loaddata(_Tablemanin);
                if (CheckFeedback(nodeselect.Name))
                {
                    //Webdetail.Height -= 30;
                    btviewCm.Enabled = true;
                }
                else
                {
                    btviewCm.Enabled = false;
                }
            }
        }
        #region search tree node
        private void txttree_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                TreeNode root = tvDocument.Nodes.Find("-1", true)[0];
                if(_istextchange)
                { 
                    i=0;
                    list.Clear();
                     foreach (TreeNode treeNode in root.Nodes)
                    {
                        TreeNode n = FindNameInTreeView(treeNode, txttree.Text);
                        if(n!=null)
                            list.Add(n);
                    }
                    if(list.Count>0)
                    {
                        TreeNode node = list[i];
                        list[i].Expand();
                        tvDocument.SelectedNode = node;
                        
                    }
                    _istextchange = false;
                }
                else
                {
                    if(i<list.Count-1)
                        i++;
                    else
                    {
                        i = 0;
                    }
                    if (list.Count==0)
                    {
                        tvDocument.SelectedNode = root;
                        return;
                    }
                    list[i].Expand();
                    tvDocument.SelectedNode = list[i];
                }
            }
        }
       
        TreeNode FindNameInTreeView(TreeNode node, String nametxt)
        {
            // check if we have a node
            if (node == null)
                return null;

            // check if the name of this node matches the one we're looking for
            if (node.Text.ToLower().Contains(nametxt.ToLower()))
                return node;

            // iterate through the childs of this node
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                // call this same function to each child node
                TreeNode foundNode = FindNameInTreeView(node.Nodes[i], nametxt);
                // if we found the node, return it
                if (foundNode != null)
                    return foundNode;
            }

            // no node found
            return null;
        }

        private void txttree_EditValueChanged(object sender, EventArgs e)
        {
            _istextchange = true;
        }
        public byte[] ConvertFileToByte(FileInfo fi)
        {
            try
            {
                FileStream fs = fi.OpenRead();
                //Read all bytes into an array from the specified file.
                int nBytes = (int) fs.Length;
                byte[] ByteArray = new byte[nBytes];
                int nBytesRead = fs.Read(ByteArray, 0, nBytes);
                fs.Close();
                return ByteArray;
            }
            catch (Exception exception)
            {
                //CTLError.WriteError("FrmMain ConvertFileToByte", exception.Message);
                return null;
                throw;
            }
        }

        #endregion

        private void FrmSearchBug_FormClosing(object sender, FormClosingEventArgs e)
        {
            CTLQuanLyForm.formName.Remove(this.Name);
        }

        public bool CheckFeedback(string iddocument)
        {
            //bool flag = false;
            try
            {
                    //_Tablemanin = _control.SearchByID(nodeselect.Name);
                    //loaddata(_Tablemanin);
                    _dataFeedBack = _control.GetDataFeedback(iddocument);
                if(_dataFeedBack!=null)
                    if(_dataFeedBack.Rows.Count>0)
                        return true;
            }
            catch (Exception ex)
            {
                CTLError.WriteError("check feedback", ex.Message);
                return false;
            }
            return false;
        }

        private void btAddCm_Click(object sender, EventArgs e)
        {
            if(_IDDocument==string.Empty)
            {
                InfoMessage.HienThi("Vui lòng chọn Event để comment !!!", "Thông báo", "Add Comment", HinhAnhThongBao.THANHCONG,
                                    NutThongBao.DONGY);
                return;
            }
            FrmAddComment addComment=new FrmAddComment();
            addComment.richTextEdit1.isComment = true;
            addComment.richTextEdit1._IDIsuee = _IDDocument;
            addComment.richTextEdit1._IDCreate = Config._idcreate;
            addComment.richTextEdit1.labelControl1.Visible = false;
            addComment.richTextEdit1.labelControl2.Visible = false;
            addComment.richTextEdit1.labelControl3.Visible = false;
            addComment.richTextEdit1.txtVersion.Visible = false;
            addComment.richTextEdit1.txtAtt.Visible = false;
            addComment.richTextEdit1.txtReference.Visible = false;
            addComment.richTextEdit1.btnBrowse.Visible = false;
            addComment.ShowDialog();
            if(addComment.richTextEdit1._isfinish)
            {
                InfoMessage.HienThi("Add new comment thành công!", "Thông báo", "Add Comment", HinhAnhThongBao.THANHCONG,
                                    NutThongBao.DONGY);
            }
        }

        private string _document = "";
        private bool _isshowdocumet = true;
        private void btviewCm_Click(object sender, EventArgs e)
        {
            if(_isshowdocumet)
            {
                btviewCm.Text = "View Document";
                _isshowdocumet = false;
                _document = Webdetail.RtfText;
                string de = "";
                int i = 0;
                Webdetail.CreateNewDocument();

                string addtitle = "";
                TreeNode[] node = tvDocument.Nodes.Find(_IDDocument, true);
                if(node.Length>0)
                {
                    if (addtitle == string.Empty)
                        addtitle = node[0].Text;
                    while (node[0].Parent!=null)
                    {
                        addtitle = node[0].Parent.Text + "->" + addtitle;
                        node[0] = node[0].Parent;
                    }
                    
                        
                    
                }

                string Title = @"<!DOCTYPE html PUBLIC " + '"' + "-//W3C//DTD XHTML 1.0 Transitional//EN" + '"' + " " + '"' + "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" + '"' + @">
<html>
	<head>
		<meta HTTP-EQUIV=" + '"' + "Content-Type" + '"' + " CONTENT=" + '"' + "text/html; charset=utf-8" + '"' + @" /><title>

		</title><style type=" + '"' + "text/css" + '"' + @">
			.cs7CED571B{text-align:left;text-indent:0pt;padding:0pt 0pt 0pt 0pt;margin:0pt 0pt 0pt 0pt}
			.csF4FE13F3{color:#000000;background-color:#C0FFC0;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:italic; }

		</style>
	</head><body>
		<span><p class=" + '"'+@"cs7CED571B"+'"'+@"><span class="+'"'+@"csF4FE13F3"+'"'+@"> </span><span class="+'"'+@"csF4FE13F3"+'"'+@"> "+addtitle+@"</span></p></span>
	</body>
</html>";
                RichEditControl richEditControl=new RichEditControl();
                richEditControl.HtmlText = Title;
                richEditControl.Refresh();
                Webdetail.Document.InsertRtfText(Webdetail.Document.CaretPosition, richEditControl.RtfText);
                richEditControl.CreateNewDocument();
                foreach (DataRow dataRow in _dataFeedBack.Rows)
                {
                    string s = @"<!DOCTYPE html PUBLIC " + '"' + "-//W3C//DTD XHTML 1.0 Transitional//EN" + '"' + " " + '"' + "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" + '"' + @">
<html>
	<head>
		<meta HTTP-EQUIV=" + '"' + "Content-Type" + '"' + " CONTENT=" + '"' + "text/html; charset=utf-8" + '"' + @" /><title>

		</title><style type=" + '"' + "text/css" + '"' + @">
			.cs742CAEF8{text-align:left;text-indent:36pt;padding:0pt 0pt 0pt 0pt;margin:0pt 0pt 0pt 36pt}
			.cs5EFED22F{color:#000000;background-color:FFFFC0;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:italic; }
			.cs676C7CC9{text-align:left;text-indent:0pt;padding:12pt 0pt 0pt 0pt;margin:0pt 0pt 11pt 0pt}
			.csC0D2101E{color:#0000FF;background-color:FFFFC0;font-family:Times New Roman; font-size:11pt; font-weight:normal; font-style:italic; }

		</style>
	</head><body>
		<span><p class=" + '"' + @"cs742CAEF8" + '"' + @"><span class=" + '"' + @"cs5EFED22F" + '"' + @">-------------------------------------------------------</span></p><p class=" + '"' + @"cs676C7CC9" + '"' + @"><span class=" + '"' + @"csC0D2101E" + '"' + @">" + dataRow["DateCreated"].ToString() + @"</span><span class=" + '"' + "csC0D2101E" + '"' + @">			</span><span class=" + '"' + @"csC0D2101E" + '"' + @"> " + dataRow["Creator"].ToString() + @"</span></p></span>
	</body>
</html>"
;
                    richEditControl.HtmlText = s;
                    richEditControl.Refresh();
                    de = dataRow["Detail"].ToString();
                    Webdetail.Document.InsertRtfText(Webdetail.Document.CaretPosition,richEditControl.RtfText);
                    Webdetail.Document.InsertRtfText(Webdetail.Document.CaretPosition, de);
                    i = de.Length;
                }
                richEditControl.Dispose();
                
            }
            else
            {
                btviewCm.Text = "View comment";
                _isshowdocumet = true;
                Webdetail.RtfText = _document;
                _document = "";
            }
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtserch.Text == string.Empty)
            {
                return;
            }

            TreeNode node = tvDocument.SelectedNode;
            _Tablemanin = null;
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(labThongTinlienQuang);
            Webdetail.RtfText = "";
            flowAtt.Visible = false;
            btviewCm.Enabled = false;
            _isshowdocumet = true;
            btviewCm.Text = "View comment";
            _document = "";
            //if(node.Parent==null)
            //{
            _Tablemanin = _control.SearchBytitle(txtserch.Text);
            loaddata(_Tablemanin);

            #region test search theo noi dung
            
            //RichEditControl r=new RichEditControl();
            //r.Text = txtserch.Text;
            //string detail = r.RtfText;
            ////detail= r.ToString();
            ////r.Document.Text
            //detail = GetRtfUnicodeEscapedString("Công cụ");
            //detail = ConvertToRtf("Công cụ");
            #endregion

            //}
            //else if (node.Level==1)
            //{
            //    _Tablemanin = _control.SearchBySelectedDC(node.Text,txtserch.Text);
            //    loaddata(_Tablemanin);
            //}
            //else if(node.Level==2)
            //{
            //    _Tablemanin = _control.SearchBySelectedItem(node.Parent.Text, txtserch.Text,node.Text);
            //    loaddata(_Tablemanin);
            //}
        }
        string GetRtfUnicodeEscapedString(string s)
        {
            var sb = new StringBuilder();
            foreach (var c in s)
            {
                if (c <= 0x7f)
                    sb.Append(c);
                else
                    sb.Append("\\u" + Convert.ToUInt32(c) + "?");
            }
            return sb.ToString();
        }
             public  string ConvertToRtf(string value)
             {
                 RichEditControl richTextBox = new RichEditControl();
                 richTextBox.Text = value;
                 int offset = richTextBox.RtfText.IndexOf(@"{\cf0") + 6;
                 // offset = 118;
                 int len = richTextBox.RtfText.LastIndexOf(@"}\par}") - offset;
                 string result = richTextBox.RtfText.Substring(offset, len).Trim(); 
                 return result;
             } 
    }
}