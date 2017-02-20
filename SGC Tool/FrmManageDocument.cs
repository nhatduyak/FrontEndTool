using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SGC_Tool.MyControls;
using TPMessageBox;

namespace SGC_Tool
{
    public partial class FrmManageDocument : Form
    {
        public FrmManageDocument(string idNhanVien)
        {
            InitializeComponent();
            _control = new CTLXuLyAddNewApplication_Master();
            LoadTree();
            LoadContextMenu();
            IdNhanVien = idNhanVien;
            rte.Visible = false;
            panelControl2.Controls.Add(rte);
            rte.Dock = DockStyle.Fill;
            tvDocument.LabelEdit = false;
        }
        //bien luu gia tri = true khi text thay doi
       

        public string IdNhanVien;
        private CTLXuLyAddNewApplication_Master _control;
        private string currentID;
        public string EventName="";
        public string AppName="";
        public string Item="";
        private bool isEdit=false;

        void LoadTree()
        {
            DataTable lstApp = _control.LoadAllApplication();
            TreeNode root = new TreeNode("Quản lý document");
            root.Name = "-1";
            tvDocument.Nodes.Add(root);
            foreach(DataRow row in lstApp.Rows)
            {
                TreeNode nodeApp = new TreeNode(Convert.ToString(row[0]));
                nodeApp.ImageIndex = 0;
                nodeApp.SelectedImageIndex = 0;
                DataTable lstItem = _control.LoadItemForApp(nodeApp.Text);
                root.Nodes.Add(nodeApp);
                foreach(DataRow rowItem in lstItem.Rows)
                {
                    TreeNode nodeItem = new TreeNode(Convert.ToString(rowItem["Item"]), 1, 1);
                    nodeApp.Nodes.Add(nodeItem);
                    DataTable issue = _control.LoadEventList(nodeApp.Text, nodeItem.Text);
                    foreach(DataRow rowIssue in issue.Rows)
                    {
                        TreeNode nodeIssue = new TreeNode(Convert.ToString(rowIssue["Event"]),2,2);
                        nodeIssue.Name = Convert.ToString(rowIssue["ID"]);
                        nodeItem.Nodes.Add(nodeIssue);
                    }
                }
            }
            root.Expand();
        }

        void LoadContextMenu()
        {
            context.Items.Add("Thêm application");
            context.Items.Add("Thêm item");
            context.Items.Add("Soạn event");
            context.Items[0].Width = 80;
            context.Items[1].Width = 50;
        }

        private void tvDocument_MouseClick(object sender, MouseEventArgs e)
        {
            tvDocument.SelectedNode.EndEdit(false);
            if(e.Button == MouseButtons.Right)
            {
                if(tvDocument.SelectedNode.Level == 0)
                {
                    // Thêm app
                    context.Visible = true;
                    context.Items[1].Visible = false;
                    context.Items[2].Visible = false;
                    context.Items[0].Visible = true;
                    context.Show((Control) sender, e.X, e.Y);
                    return;
                }
                if(tvDocument.SelectedNode.Level == 1)
                {
                    // Thêm detail
                    context.Visible = true;
                    context.Items[0].Visible = false;
                    context.Items[1].Visible = true;
                    context.Items[2].Visible = false;
                    context.Show((Control)sender, e.X, e.Y);
                    return;
                }
                if(tvDocument.SelectedNode.Level == 2)
                {
                    // Thêm event
                    context.Visible = true;
                    context.Items[0].Visible = false;
                    context.Items[1].Visible = false;
                    context.Items[2].Visible = true;
                    context.Show((Control)sender, e.X, e.Y);
                    return;
                }
                else
                {
                    context.Items[0].Visible = false;
                    context.Items[1].Visible = false;
                    context.Items[2].Visible = false;
                    return;
                }
                
            }
        }

        
        private void context_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            tvDocument.LabelEdit = true;
            if(e.ClickedItem == context.Items[0])
            {
                // Thêm app
                TreeNode node = new TreeNode("New application",0,0);
                tvDocument.SelectedNode.Nodes.Add(node);
                tvDocument.SelectedNode.Expand();
                isEdit = false;
                AppName = "";
                node.BeginEdit();

            }
            if (e.ClickedItem == context.Items[1])
            {
                // Thêm item
                TreeNode node = new TreeNode("New item",1,1);
                tvDocument.SelectedNode.Nodes.Add(node);
                tvDocument.SelectedNode.Expand();
                isEdit = false;
                Item = "";
                node.BeginEdit();

            }
            if (e.ClickedItem == context.Items[2])
            {
                // Thêm item
                TreeNode node = new TreeNode("New event", 2, 2);
                tvDocument.SelectedNode.Nodes.Add(node);
                tvDocument.SelectedNode.Expand();
                isEdit = false;
                EventName = "";
                node.BeginEdit();
                rte.Visible = true;
                rte.AppName = tvDocument.SelectedNode.Parent.Text;
                rte.Item = tvDocument.SelectedNode.Text;
                rte.Event = EventName;
                rte.IDNhanVien = IdNhanVien;
                rte.CreateDocument();
            }
            //tvDocument.LabelEdit = false;
        }

        RichTextEdit rte = new RichTextEdit();
        public List<DocAttachment> lstAtt;

        private void tvDocument_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!isEdit)
            {
                
                    if (e.Node.Level == 1) // Application
                    {
                        TreeNode root = tvDocument.Nodes.Find("-1", true)[0];
                        TreeNode des = FindNameInTreeView(root, e.Label==null?e.Node.Text:e.Label);
                        if (!(des != null && des.Level == 1))
                        {
                            if (e.Label != null)
                            {
                                _control.AddNewApp(e.Label, "");
                                AppName = e.Label;
                            }
                            else
                            {
                                _control.AddNewApp(e.Node.Text, "");
                                AppName = e.Node.Text;
                            }
                            
                        }
                        else
                        {
                            //FrmMessage frm = new FrmMessage("Đã có application " + e.Label + ". Vui lòng dùng tên khác.");
                            //frm.ShowDialog();
                            InfoMessage.HienThi("Đã có application " + e.Label + ". Vui lòng dùng tên khác.","Thông báo","Thông báo",HinhAnhThongBao.THONGTIN,NutThongBao.DONGY);
                            e.Node.Remove();
                            AppName = "";
                            return;
                        }

                    }
                    if (e.Node.Level == 2) // Add item
                    {
                        TreeNode root = tvDocument.Nodes.Find("-1", true)[0];
                        TreeNode des = FindNameInTreeView(root, e.Label==null?e.Node.Text:e.Label);
                        if (!(des != null && des.Level == 2))
                        {
                            if (_control.CheckEmptyApp(e.Node.Parent.Text))
                            {
                                if(e.Label!=null)
                                    _control.UpdateApp(e.Node.Parent.Text, e.Label);
                                else
                                {
                                    _control.UpdateApp(e.Node.Parent.Text, e.Node.Text);
                                }
                            }
                            else
                            {
                                _control.AddNewApp(e.Node.Parent.Text, e.Label==null?e.Node.Text:e.Label);
                            }
                            if(e.Label!=null)
                                Item = e.Label;
                            else
                            {
                                Item = e.Node.Text;
                            }
                        }
                        else
                        {
                            //FrmMessage frm = new FrmMessage("Đã có item " + e.Label + ". Vui lòng dùng tên khác.");
                            //frm.ShowDialog();
                            InfoMessage.HienThi("Đã có item " + e.Label + ". Vui lòng dùng tên khác.", "Thông báo", "Thông báo", HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                            e.Node.Remove();
                            Item = "";
                            return;
                        }
                    }
                    if (e.Node.Level == 3) // Add issue
                    {
                        TreeNode root = tvDocument.Nodes.Find("-1", true)[0];
                        TreeNode des = FindNameInTreeView(root, e.Label==null?e.Node.Text:e.Label);
                        if (!(des != null && des.Level == 3))
                        {
                            rte.CreateDocument();
                            rte._isModify = false;
                            if (e.Label != null)
                                e.Node.Name = rte.AutoSave(e.Node.Parent.Parent.Text, e.Node.Parent.Text, e.Label, IdNhanVien,
                                         rte.AutoEditor, "", "");
                            else
                            {
                                e.Node.Name = rte.AutoSave(e.Node.Parent.Parent.Text, e.Node.Parent.Text, e.Node.Text, IdNhanVien,
                                         rte.AutoEditor, "", "");
                            }
                        }
                        else
                        {
                            //FrmMessage frm = new FrmMessage("Đã có Event " + e.Label + ". Vui lòng dùng tên khác.");
                            //frm.ShowDialog();
                            InfoMessage.HienThi("Đã có Event " + e.Label + ". Vui lòng dùng tên khác.", "Thông báo", "Thông báo", HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                            e.Node.Remove();
                            rte.Hide();
                            rte._isModify = false;
                            return;
                        }
                        if(e.Label!=null)
                        {
                            EventName = e.Label;
                            rte.Event = e.Label;
                        }
                        else
                        {
                            EventName = e.Node.Text;
                            rte.Event = e.Node.Text;
                        }
                       
                    }
                
            }
            else
            {
                // rename
                if (e.Node.Level == 1)
                {
                    TreeNode root = tvDocument.Nodes.Find("-1", true)[0];
                    TreeNode des = FindNameInTreeView(root, e.Label==null?e.Node.Text:e.Label);
                    if (!(des != null && des.Level == 1))
                    {
                        if (e.Label != null /*|| e.Label.Length > 0*/)
                            _control.UpdateAppName(AppName, e.Label==null?e.Node.Text:e.Label);
                    }
                    else
                    {
                        //FrmMessage frm = new FrmMessage("Đã có Application " + e.Label + ". Vui lòng dùng tên khác.");
                        //frm.ShowDialog();
                        InfoMessage.HienThi("Đã có Application " + e.Label + ". Vui lòng dùng tên khác.", "Thông báo", "Thông báo", HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                        return;
                    }
                }
                if (e.Node.Level == 2)
                {
                    TreeNode root = tvDocument.Nodes.Find("-1", true)[0]; 
                   
                    TreeNode des = FindNameInTreeView(root, e.Label==null?e.Node.Text:e.Label);
                  
                    if (!(des != null && des.Level == 1))
                    {
                        if (e.Label!=null /*|| e.Label.Length > 0*/)
                            _control.UpdateItemName(Item, e.Label==null?e.Node.Text:e.Label, ((TreeNode) e.Node.Parent).Text);
                    }
                    else
                    {
                        //FrmMessage frm = new FrmMessage("Đã có item " + e.Label + ". Vui lòng dùng tên khác.");
                        //frm.ShowDialog();
                        InfoMessage.HienThi("Đã có item " + e.Label + ". Vui lòng dùng tên khác.", "Thông báo", "Thông báo", HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                        return;
                    }
                }
                if (e.Node.Level == 3)
                {
                    TreeNode root = tvDocument.Nodes.Find("-1", true)[0];
                    TreeNode des = FindNameInTreeView(root, e.Label==null?e.Node.Text:e.Label);
                    if (!(des != null && des.Level == 1))
                    {
                        if (e.Label != null /*|| e.Label.Length > 0*/)
                            _control.UpdateEventName(EventName, e.Label == null ? e.Node.Text : e.Label,((TreeNode) e.Node.Parent.Parent).Text, ((TreeNode) e.Node.Parent).Text);
                    }
                    else
                    {
                        //FrmMessage frm = new FrmMessage("Đã có item " + e.Label + ". Vui lòng dùng tên khác.");
                        //frm.ShowDialog();
                        InfoMessage.HienThi("Đã có item " + e.Label + ". Vui lòng dùng tên khác.", "Thông báo", "Thông báo", HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                        return;
                    }
                }
            }
            tvDocument.LabelEdit = false;
        }

        #region gan ID cho node 

        

        #endregion


        private void tvDocument_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            lstAtt = new List<DocAttachment>();  
           
            if(e.Node.Level == 3 && e.Button == MouseButtons.Left)
            {
                if (rte._isModify)
                {
                    if (InfoMessage.HienThi("Bạn muốn đóng Văn bản đang soạn thảo??", "Thông báo", "Close Document",
                                        HinhAnhThongBao.HOI, NutThongBao.CO_KHONG) == KetQuaThongBao.KHONG)
                    {
                        return;
                    }
                    else
                    {
                        rte._isModify = false;
                    }
                }
                
                EventName = e.Node.Text;
                DataTable kq = _control.LoadEventContent(e.Node.Text, e.Node.Parent.Parent.Text, e.Node.Parent.Text);
                rte._isload = true;
                rte._isModify = false;
                if (kq.Rows.Count > 0)
                {
                    StringBuilder richText=new StringBuilder();
                    richText.Append( Convert.ToString(kq.Rows[0]["IssueContent"]));
                    string reference = Convert.ToString(kq.Rows[0]["Reference"]);
                    string version = Convert.ToString(kq.Rows[0]["Version"]);
                    string att = Convert.ToString(kq.Rows[0]["Title"]);
                    currentID = e.Node.Name;
                    if (att.Length > 0)
                        att = att.Substring(0, att.Length - 1);
                    
                    //region xu ly viewdoc
                    string[] lstatt = att.Split(';');
                    att = " ";
                    foreach (string s in lstatt)
                    {
                        if (s.Length > 0)
                        {
                            int index = s.IndexOf('-') + 1;
                            int length = s.Length - index;
                            att += s.Substring(index, length) + "; ";
                            DocAttachment item = new DocAttachment();
                            item.Id = s.Substring(0, s.IndexOf('-'));
                            item.Name = s.Substring(index, length);
                            item.Filepath = "";
                            item.DocId = currentID;
                            lstAtt.Add(item);
                        }
                    }
                    if (att.Length > 0)
                        att = att.Substring(0, att.Length - 1);
                    //endregion 
                    rte.Visible = true;
                    rte.ViewDocument(richText,version,att,Convert.ToString(kq.Rows[0]["Title"]),reference,currentID);
                    rte.GetListAttachment(lstAtt);
                    rte._isModify = false;
                }
                else
                {
                    
                }
            }
            if (e.Node.Level == 1)
                AppName = e.Node.Text;
            if (e.Node.Level == 2)
                Item = e.Node.Text;
            if (e.Node.Level == 3)
            {
                AppName = e.Node.Parent.Parent.Text;
                Item = e.Node.Parent.Text;
            }
                
        }

        TreeNode FindNameInTreeView(TreeNode node, String nametxt)
        {
            // check if we have a node
            if (node == null)
                return null;
            if (nametxt == null)
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
            return null;
        }

        private void FrmManageDocument_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                if (this.rte.AttachmentText.Focused)
                    this.rte.ribbonControl1_KeyDown(rte.AttachmentText, e);
        }

        private void tvDocument_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (tvDocument.SelectedNode.Level == 1) // delete app
                {
                    //FrmConfirm askApp =
                    //    new FrmConfirm("Bạn có chắc muốn xóa application " + tvDocument.SelectedNode.Text);
                    //askApp.ShowDialog();
                    if (InfoMessage.HienThi("Bạn có chắc muốn xóa application " + tvDocument.SelectedNode.Text,"Delete Application","Thông báo",HinhAnhThongBao.HOI,NutThongBao.CO_KHONG)==KetQuaThongBao.CO)
                    {
                        string name = tvDocument.SelectedNode.Text;
                        if (_control.DeleteApplication(name))
                        {
                            tvDocument.Nodes.Remove(tvDocument.SelectedNode);
                            //FrmMessage frm = new FrmMessage("Đã xóa application " + name);
                            //frm.ShowDialog();
                            InfoMessage.HienThi("Đã xóa application " + name, "Thông báo", "Thông báo", HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                            return;
                        }
                        else
                        {
                            //FrmMessage frm = new FrmMessage("Không xóa được application " + name);
                            //frm.ShowDialog();
                            InfoMessage.HienThi("Không xóa được application " + name, "Thông báo", "Thông báo", HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                            return;
                        }
                    }
                }
                if (tvDocument.SelectedNode.Level == 2) // delete item
                {
                    //FrmConfirm askItem = new FrmConfirm("Bạn có chắc muốn xóa item " + tvDocument.SelectedNode.Text);
                    //askItem.ShowDialog();
                    if (/*askItem.buttonRes == FrmConfirm.ButtonResult.OK*/
                        InfoMessage.HienThi("Bạn có chắc muốn xóa item " + tvDocument.SelectedNode.Text, "Thông báo", "Thông báo", HinhAnhThongBao.HOI, NutThongBao.CO_KHONG)==KetQuaThongBao.CO)
                    {
                        string itemName = tvDocument.SelectedNode.Text;
                        string appName = tvDocument.SelectedNode.Parent.Text;
                        if (_control.DeleteItem(appName, itemName))
                        {
                            tvDocument.Nodes.Remove(tvDocument.SelectedNode);
                            //FrmMessage frm = new FrmMessage("Đã xóa item " + itemName);
                            //frm.ShowDialog();
                            InfoMessage.HienThi("Đã xóa item " + itemName, "Thông báo", "Thông báo", HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);
                            return;
                        }
                        else
                        {
                            //FrmMessage frm = new FrmMessage("Không xóa được item " + itemName);
                            //frm.ShowDialog();
                            InfoMessage.HienThi("Không xóa được item " + itemName, "Thông báo", "Thông báo", HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);
                            return;
                        }
                    }

                }
                if (tvDocument.SelectedNode.Level == 3) // delete item
                {
                    //FrmConfirm askItem = new FrmConfirm("Bạn có chắc muốn xóa item " + tvDocument.SelectedNode.Text);
                    //askItem.ShowDialog();

                    if (InfoMessage.HienThi("Bạn có chắc muốn xóa item " + tvDocument.SelectedNode.Text,"Delete Item","Thông báo",HinhAnhThongBao.HOI,NutThongBao.CO_KHONG)==KetQuaThongBao.CO)
                    {
                        string itemName = tvDocument.SelectedNode.Parent.Text;
                        string appName = tvDocument.SelectedNode.Parent.Parent.Text;
                        string eventName = tvDocument.SelectedNode.Text;
                        if (_control.DeleteEvent(appName, itemName,eventName))
                        {
                            TreeNode next = tvDocument.SelectedNode.NextNode;
                            tvDocument.Nodes.Remove(tvDocument.SelectedNode);
                            rte.Visible = false;
                            rte._isModify = false;
                            tvDocument.SelectedNode = next;
                            //FrmMessage frm = new FrmMessage("Đã xóa event " + eventName);
                            //frm.ShowDialog();
                            InfoMessage.HienThi("Đã xóa event " + eventName, "Thông báo", "Thông báo", HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);
                            return;
                        }
                        else
                        {
                            //FrmMessage frm = new FrmMessage("Không xóa được event " + eventName);
                            //frm.ShowDialog();
                            InfoMessage.HienThi("Không xóa được event " + eventName, "Thông báo", "Thông báo", HinhAnhThongBao.THONGTIN, NutThongBao.DONGY);
                            return;
                        }
                    }
                }
            }
            if(e.KeyCode == Keys.F2)
            {
                tvDocument.LabelEdit = true;
                tvDocument.SelectedNode.BeginEdit();
            }
                

        }

        private void tvDocument_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.Level == 1 && AppName.Length > 0)
                isEdit = true;
            if (e.Node.Level == 2 && Item.Length > 0)
                isEdit = true;
            if (e.Node.Level == 3 && EventName.Length > 0)
                isEdit = true;
        }

        private void FrmManageDocument_FormClosing(object sender, FormClosingEventArgs e)
        {
            CTLQuanLyForm.formName.Remove(this.Name);
        }

      

    }
}
