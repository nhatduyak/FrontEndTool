using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;
using TOOLChuyenDuLieu.ControlEntity;
using TPMessageBox;
using System.Text;

namespace SGC_Tool.MyControls
{
    public partial class RichTextEdit : UserControl
    {

        public enum Ext
        {
            Excel,
            Word,
            Text,
            Exe,
            Pdf,
            Config,
            Setting,
            Other
        }

        public RichTextEdit()
        {
            InitializeComponent();
            lstFullFileName = new List<string>();
            lstFileName = new List<string>();
        }

        private RichTextBox attachmentText;
        public RichTextBox AttachmentText
        {
            get { return txtAtt.RichText; }
            set { txtAtt.RichText = value; }
        }

        public string AutoEditor
        {
            get { return Editor.RtfText; }
        }

        private string autoEditor;

       
        public RichTextEdit(HtmlDocument document)
        {
            InitializeComponent();
            doc = document;
            lstFullFileName = new List<string>();
            lstFileName = new List<string>();
        }

        private List<string> lstFileName;
        private List<string> lstFullFileName;

        

        public void ViewDocument(StringBuilder richtext,string version,string att,string att_title,string reference,string id)
        {
            Editor.CreateNewDocument();
            Editor.Document.RtfText = richtext.ToString();
            txtReference.Text = reference;
            txtVersion.Text = version;
            txtAtt.RichText.Text = att;
            Att_Title = att_title;
            isNew = false;
            ID = id;
            btnManualSave.Enabled = true;
            _isload = true;
        }

        public void CreateDocument()
        {
            
            Editor.CreateNewDocument();
            txtAtt.RichText.Text = "";
            txtReference.Text = "";
            txtVersion.Text = "";
            isNew = true;
            btnManualSave.Enabled = true;
            _isload = true;
        }

        public void CloseDocument()
        {
            Editor.CloseImeWindow(ImeCloseStatus.ImeCompositionCancel);
        }
        

        void ViewDoc_Attachment(string att)
        {
            string[] lstAtt = att.Split(';');
            foreach(string at in lstAtt)
            {
                if(at.Length >0)
                {
                    CheckExtension(at);
                }
            }
        }

        private List<DocAttachment> attFromDB;
        public void GetListAttachment(List<DocAttachment> source)
        {
            attFromDB = source;
        }

        private HtmlDocument doc;
        public string AppName;
        public string Item;
        public string Event;
        public string IDNhanVien;
        public string ID;
        public bool isNew = true;
        public bool isComment = false;
        public string Att_Title;

        #region Feedback

        public string _IDIsuee;
        public string _IDCreate;

        public bool _isfinish = false;
        #endregion

        public string AutoSave(string applicationName, string item, string eventIssue, string idNhanVien, string content, string version, string reference)
        {
            CTLXuLyAddNewApplication_Master control = new CTLXuLyAddNewApplication_Master();
            try
            {

                ID = control.AddNewEvent(applicationName, item, eventIssue, idNhanVien, content, version,
                                            reference, lstFullFileName, lstFileName);
            }
            catch (Exception ex)
            {
                //FrmMessage frm = new FrmMessage("Thêm mới không thành công. Vui lòng kiểm tra lại thông tin");
                //frm.ShowDialog();
                InfoMessage.HienThi("Thêm mới không thành công. Vui lòng kiểm tra lại thông tin", "Thông báo",
                                    "Thông báo", HinhAnhThongBao.LOI, NutThongBao.DONGY);
                return null;
            }
            //FrmMessage frm2 = new FrmMessage("Thêm mới thành công");
            //frm2.Show();
            InfoMessage.HienThi("Thêm mới thành công", "Thông báo",
                                   "Thông báo", HinhAnhThongBao.THANHCONG, NutThongBao.DONGY);
            btnManualSave.Enabled = true;
            return ID;


        }

       
        public delegate void GanIDNode(String id, String MyString2);
        // khai báo 1 kiểu hàm delegate
        public GanIDNode Ganidnode;      

        private void btnManualSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isComment)
            {
                CTLSearchBug searchBug=new CTLSearchBug();
                string ten = Config._tennv + "-" + Config._tenst;
                if (searchBug.InsertFeedBack(_IDIsuee, Editor.Document.RtfText, (ten.Length > 36) ? ten.Substring(0, 36) : ten.Substring(0, ten.Length), ""))
                {
                    _isfinish = true;
                }
                return;
            }
            _isload = true;
            _isModify = false;
            //if (isNew)
            //{
            //    // Khi lưu phải lưu những phần DocumentIssue, DocumentDetail,Attachment
            //    string applicationName = AppName;
            //    string item = Item;
            //    string eventIssue = Event;
            //    string idNhanVien = IDNhanVien;
            //    string content = Editor.Document.RtfText;
            //    string version = txtVersion.Text;
            //    string reference = txtReference.Text;

            //    CTLXuLyAddNewApplication_Master control = new CTLXuLyAddNewApplication_Master();
            //    try
            //    {
            //        control.AddNewEvent(applicationName, item, eventIssue, idNhanVien, content, version,
            //                                    reference, lstFullFileName, lstFileName);
            //    }
            //    catch (Exception ex)
            //    {
            //        FrmMessage frm = new FrmMessage("Thêm mới không thành công. Vui lòng kiểm tra lại thông tin");
            //        frm.Show();
            //        return;
            //    }
            //    FrmMessage frm2 = new FrmMessage("Thêm mới thành công");
            //    frm2.Show();
            //    btnManualSave.Enabled = true;
            //    return;
            //}
            //else
            //{
                // Cập nhật detail:
                string applicationName = AppName;
                string item = Item;
                string eventIssue = Event;
                string idNhanVien = IDNhanVien;
                StringBuilder content =new StringBuilder();
                content.Append(Editor.Document.RtfText);
            
                string version = txtVersion.Text;
                string reference = txtReference.Text;
                
                try
                {
                    //int a = control.UpdateDocument_Detail(ID, content,version,reference,Att_Title,lstFileName);
                    if(CompareAttachment(content.ToString(),version,reference,Att_Title))
                    {
                        //FrmMessage frm1 = new FrmMessage("Cập nhật thành công");
                        //frm1.ShowDialog();
                        InfoMessage.HienThi("Cập nhật thành công", "Update", "Thông báo", HinhAnhThongBao.THANHCONG,
                                            NutThongBao.DONGY);
                        lstFileName.Clear();
                        lstFullFileName.Clear();
                        return;
                    }
                    else
                    {
                        //FrmMessage frm = new FrmMessage("Cập nhật không thành công. Vui lòng kiểm tra lại thông tin");
                        //frm.ShowDialog();
                        InfoMessage.HienThi("Cập nhật không thành công", "Update", "Thông báo", HinhAnhThongBao.LOI,
                                            NutThongBao.DONGY);
                        lstFileName.Clear();
                        lstFullFileName.Clear();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    //FrmMessage frm = new FrmMessage("Cập nhật không thành công. Vui lòng kiểm tra lại thông tin");
                    //frm.ShowDialog();
                    InfoMessage.HienThi("Cập nhật không thành công. Vui lòng kiểm tra lại thông tin", "Update", "Thông báo", HinhAnhThongBao.LOI,
                                            NutThongBao.DONGY);
                    lstFileName.Clear();
                    lstFullFileName.Clear();
                    return;
                }

            //}

        }

        private void txtBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = @"All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string ffn in ofd.FileNames)
                {
                    lstFullFileName.Add(ffn);
                    
                }
                foreach (string fn in ofd.SafeFileNames)
                {
                    if(lstFileName.Contains(fn))
                    {
                        //FrmMessage frm = new FrmMessage("File đã tồn tại");
                        //frm.ShowDialog();
                        InfoMessage.HienThi("File đã tồn tại","Attatch file","Thông báo", HinhAnhThongBao.LOI,NutThongBao.DONGY);
                        return;
                    }
                    lstFileName.Add(fn);
                    if (txtAtt.RichText.Text.Length > 0)
                        txtAtt.RichText.AppendText(" " + fn + ";");
                    else
                        txtAtt.RichText.AppendText(" " + fn + ";");
                }
              
            }


        }
       
        bool UpdateContent(string version,string content,string reference,string ID)
        {
            CTLXuLyAddNewApplication_Master control = new CTLXuLyAddNewApplication_Master();
            return control.UpdateDocument_Detail(ID, content, version, reference);
        }

        void CheckExtension(string fileName)
        {
            if (txtAtt.RichText.Text.Length > 0)
            {
                if (fileName.EndsWith("exe"))
                {
                    Bitmap exe = new Bitmap(imageList.Images[3]);
                    Clipboard.SetDataObject(exe);
                    DataFormats.Format imgFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (txtAtt.RichText.CanPaste(imgFormat))
                    {
                        txtAtt.RichText.AppendText(";");
                        txtAtt.RichText.Paste(imgFormat);
                        txtAtt.RichText.AppendText(fileName);
                    }
                    return;
                }
                if (fileName.EndsWith("doc") || fileName.EndsWith("docx"))
                {
                    Bitmap exe = new Bitmap(imageList.Images[1]);
                    Clipboard.SetDataObject(exe);
                    DataFormats.Format imgFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (txtAtt.RichText.CanPaste(imgFormat))
                    {
                        txtAtt.RichText.AppendText(";");
                        txtAtt.RichText.Paste();
                        txtAtt.RichText.AppendText(fileName);
                    }
                    return;
                }
                if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx"))
                {
                    Bitmap exe = new Bitmap(imageList.Images[0]);
                    Clipboard.SetImage(exe);
                    DataFormats.Format imgFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (txtAtt.RichText.CanPaste(imgFormat))
                    {
                        SendKeys.Send("{End}");
                        txtAtt.RichText.Paste();
                        txtAtt.RichText.AppendText(fileName);
                    }
                    return;
                }
                if (fileName.EndsWith("txt") || fileName.EndsWith("log"))
                {
                    Bitmap exe = new Bitmap(imageList.Images[2]);
                    Clipboard.SetDataObject(exe);
                    DataFormats.Format imgFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (txtAtt.RichText.CanPaste(imgFormat))
                    {
                        txtAtt.RichText.AppendText(";");
                        txtAtt.RichText.Paste(imgFormat);
                        txtAtt.RichText.AppendText(fileName);
                    }
                    return;
                }
                if (fileName.EndsWith("pdf"))
                {
                    Bitmap exe = new Bitmap(imageList.Images[4]);
                    Clipboard.SetDataObject(exe);
                    DataFormats.Format imgFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (txtAtt.RichText.CanPaste(imgFormat))
                    {
                        txtAtt.RichText.AppendText(";");
                        txtAtt.RichText.Paste(imgFormat);
                        txtAtt.RichText.AppendText(fileName);
                    }
                    return;
                }
                if (fileName.EndsWith("config"))
                {
                    Bitmap exe = new Bitmap(imageList.Images[5]);
                    Clipboard.SetDataObject(exe);
                    DataFormats.Format imgFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (txtAtt.RichText.CanPaste(imgFormat))
                    {
                        txtAtt.RichText.AppendText(";");
                        txtAtt.RichText.Paste(imgFormat);
                        txtAtt.RichText.AppendText(fileName);
                    }
                    return;
                }
                else
                {
                    Bitmap exe = new Bitmap(imageList.Images[6]);
                    Clipboard.SetDataObject(exe);
                    DataFormats.Format imgFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (txtAtt.RichText.CanPaste(imgFormat))
                    {
                        txtAtt.RichText.AppendText(";");
                        txtAtt.RichText.Paste(imgFormat);
                        txtAtt.RichText.AppendText(fileName);
                    }
                    return;
                }
            }
            else
            {
                if (fileName.EndsWith("exe"))
                {
                    Bitmap exe = new Bitmap(imageList.Images[3]);
                    
                    Clipboard.SetDataObject(exe);
                    DataFormats.Format imgFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (txtAtt.RichText.CanPaste(imgFormat))
                    {
                        SendKeys.Send("{End}");
                        txtAtt.RichText.Paste();
                        txtAtt.RichText.AppendText(fileName);
                    }
                    return;
                }
                if (fileName.EndsWith("doc") || fileName.EndsWith("docx"))
                {
                    Bitmap exe = new Bitmap(imageList.Images[1]);
                    Clipboard.SetDataObject(exe);
                    DataFormats.Format imgFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (txtAtt.RichText.CanPaste(imgFormat))
                    {
                        SendKeys.Send("{End}");
                        txtAtt.RichText.Paste(imgFormat);
                        txtAtt.RichText.AppendText(fileName);
                    }
                    return;
                }
                if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx"))
                {
                    Bitmap exe = new Bitmap(imageList.Images[0]);
                    Clipboard.SetImage(exe);
                    DataFormats.Format imgFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (txtAtt.RichText.CanPaste(imgFormat))
                    {
                        SendKeys.Send("{End}");
                        txtAtt.RichText.Paste();
                        txtAtt.RichText.AppendText(fileName);
                    }
                    return;
                }
                if (fileName.EndsWith("txt") || fileName.EndsWith("log"))
                {
                    Bitmap exe = new Bitmap(imageList.Images[2]);
                    Clipboard.SetDataObject(exe);
                    DataFormats.Format imgFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (txtAtt.RichText.CanPaste(imgFormat))
                    {
                        SendKeys.Send("{End}");
                        txtAtt.RichText.Paste(imgFormat);
                        txtAtt.RichText.AppendText(fileName);
                    }
                    return;
                }
                if (fileName.EndsWith("pdf"))
                {
                    Bitmap exe = new Bitmap(imageList.Images[4]);
                    Clipboard.SetDataObject(exe);
                    DataFormats.Format imgFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (txtAtt.RichText.CanPaste(imgFormat))
                    {
                        SendKeys.Send("{End}");
                        txtAtt.RichText.Paste(imgFormat);
                        txtAtt.RichText.AppendText(fileName);
                    }
                    return;
                }
                if (fileName.EndsWith("config"))
                {
                    Bitmap exe = new Bitmap(imageList.Images[5]);
                    Clipboard.SetDataObject(exe);
                    DataFormats.Format imgFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (txtAtt.RichText.CanPaste(imgFormat))
                    {
                        SendKeys.Send("{End}");
                        txtAtt.RichText.Paste();
                        txtAtt.RichText.AppendText(fileName);
                    }
                    return;
                }
                else
                {
                    Bitmap exe = new Bitmap(imageList.Images[6]);
                    Clipboard.SetDataObject(exe);
                    DataFormats.Format imgFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (txtAtt.RichText.CanPaste(imgFormat))
                    {
                        SendKeys.Send("{End}");
                        txtAtt.RichText.Paste(imgFormat);
                        txtAtt.RichText.AppendText(fileName);
                    }
                    return;
                }
            }
        }

        bool CompareAttachment(string content,string version,string reference,string title_att)
        {
            bool isExist = false;
            try
            {
                if (title_att!=null)
                    foreach (DocAttachment s in attFromDB)
                    {
                        // có tồn tại trên giao diện mới
                        if (lstFileName.Contains(s.Name))
                        {
                            // Sau khi delete. Add new lại
                            int currentRec = lstFileName.IndexOf(s.Name);
                            DeleteAttachment(s.Id);
                            AddNewAttachment(lstFullFileName[currentRec], s.DocId, content, lstFileName[lstFileName.IndexOf(s.Name)], version, reference,
                                             title_att);
                            isExist = true;
                        }
                    }
                if (!isExist)
                {
                    AddNew(content, version, reference, title_att);
                    UpdateContent(version, content, reference, ID);
                    return true;
                }
                UpdateContent(version, content, reference, ID);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        void AddNew(string content,string version,string reference,string title_att)
        {
            foreach (string filePath in lstFullFileName)
                AddNewAttachment(filePath, ID,content,lstFileName[lstFullFileName.IndexOf(filePath)],version,reference,title_att);
        }

        void DeleteAttachment(string AttID)
        {
            CTLXuLyAddNewApplication_Master control = new CTLXuLyAddNewApplication_Master();
            if(!control.DeleteAtt(AttID))
            {
                //FrmMessage frm = new FrmMessage("Lỗi chỉnh sửa attachment. Vui lòng thao tác lại");
                //frm.ShowDialog();
                InfoMessage.HienThi("Lỗi chỉnh sửa attachment. Vui lòng thao tác lại", "Attatch file", "Thông báo", HinhAnhThongBao.LOI, NutThongBao.DONGY);
                return;
            }
          
        }

        void AddNewAttachment(string filePath, string DocID, string content, string fileNames, string version, string reference, string Title_att)
        {
            CTLXuLyAddNewApplication_Master control = new CTLXuLyAddNewApplication_Master();
            if (!control.AddNewAtt(filePath,DocID,content,fileNames,version,reference,Title_att))
            {
                //FrmMessage frm = new FrmMessage("Lỗi chỉnh sửa attachment. Vui lòng thao tác lại");
                //frm.ShowDialog();
                InfoMessage.HienThi("Lỗi chỉnh sửa attachment. Vui lòng thao tác lại", "Thông báo", "Thông báo",
                                    HinhAnhThongBao.LOI, NutThongBao.DONGY);

                return;
            }
        }

        void DeleteAtt_Text(int pos,List<string> lstFile)
        {
            int start = 0;
            int end = 0;
            string filename = "";
            for(int i=0;i<lstFile.Count;i++)
            {
                end = start + (lstFile[i].Length) +1;
                if (pos >= start && pos <= end)
                {
                    // xử lý delete
                    filename = lstFile[i];
                    if (filename.Trim().Length > 0)
                        if (DeleteinDB(filename.Trim(), ID))
                        {
                            lstFile.Remove(lstFile[i]);
                            txtAtt.RichText.Select(start, end - start + 1);
                            SendKeys.Send("");
                            //txtAtt.RichText.Text.Replace(" ", "");
                            SendKeys.Send("{END}");
                            return;
                        }
                        else
                        {
                            //FrmMessage frm = new FrmMessage("Delete Attachment fail");
                            //frm.ShowDialog();
                            InfoMessage.HienThi("Delete Attachment fail", "Thông báo", "Thông báo",
                                    HinhAnhThongBao.LOI, NutThongBao.DONGY);
                            return;
                        }
                }
                start = end;
            }
            
        }

        public void ribbonControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if(txtAtt.RichText.Focused)
                {
                    string[] a = txtAtt.RichText.Text.Split(';');
                    List<string> lst = new List<string>();
                    foreach (string s in a)
                    {
                        if(s.Length > 0)
                            lst.Add(s);
                    }
                    DeleteAtt_Text(txtAtt.RichText.SelectionStart, lst);
                }
            }
        }

        bool DeleteinDB(string AttName,string DocumentID)
        {
            string sql = string.Format(@"select Title from ["+Config._DBNameFrontEnd+"].dbo.SGC_DocumentDetail where ID = '{0}'", DocumentID);
            object a = ConnectDb.ExcuteScalar(sql);
            if( a == null || a is DBNull)
            {
                return false;
            }
            List<string> lstString = new List<string>();
            List<string> lstSql = new List<string>();
            string[] lst_db = a.ToString().Split(';');
            foreach(string s in lst_db)
            {
                if (s.Length > 0)
                {
                    int index = s.IndexOf('-') + 1;
                    int length = s.Length - index;
                    if (s.Substring(index, length) == AttName)
                    {
                        string id = s.Substring(0, index - 1);
                        string sqlDelete = string.Format(@"delete from [" + Config._DBNameFrontEnd + "].dbo.SGC_Attachment where ID = '{0}'", id);
                        lstSql.Add(sqlDelete);
                    }
                    else
                        lstString.Add(s);
                }
                
            }
            string newTitle = MakeTitle(lstString);
            string sqlUpdate = string.Format(@"update [" + Config._DBNameFrontEnd + "].dbo.SGC_DocumentDetail set Title = N'{0}' where ID='{1}'", newTitle, DocumentID);
            lstSql.Add(sqlUpdate);

            try
            {
                ConnectDb.ExcuteNonQuery_WithTransaction(lstSql);
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;

        }

        string MakeTitle(List<string> lstTitle)
        {
            string a = "";
            foreach(string s in lstTitle)
            {
                if(s.Length > 0)
                {
                    a += s + ";";
                }
            }
            return a;
        }
        //luu giu gia tri khi thay doi khi update
        public bool _isModify = false;
        //luu giu gia tri khi load 1 noi dung #
        public bool _isload = false;
        private void Editor_ModifiedChanged(object sender, EventArgs e)
        {
            if(!_isload)
                _isModify = true;
        }

        private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
            _isload = false;
        }

       
    }
}
