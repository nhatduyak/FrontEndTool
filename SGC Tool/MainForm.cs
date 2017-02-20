using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraNavBar;
using SGC_Tool.CheckFileT;
using SGC_Tool.FrmBangbaoGia;
using SGC_Tool.FrmDonDatHang;
using SGC_Tool.FrmScaleAdappterTool;
using SGC_Tool.MyControls;
using SGC_Tool.SyncPrice;
using TOOLChuyenDuLieu;
using TOOLChuyenDuLieu.HelpFile;
using TOOLChuyenDuLieu.MyForm.CheckPrice;
using TOOLChuyenDuLieu.MyForm.FrmmainCheckPrice;
using TPMisc.PublicUtility;
using TOOLChuyenDuLieu.ControlEntity;
using SGC_Tool.CheckSKU_CKTM;


namespace SGC_Tool
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
            //this.defaultLookAndFeel1.LookAndFeel.SkinName = "O";
            //LookAndFeel.SkinName = "Money Twins";
            //LookAndFeel.UseDefaultLookAndFeel = false;

            //this.LookAndFeel.ParentLookAndFeel = defaultLookAndFeel1.LookAndFeel;
            
            SplashScreen.SetTitleString("Chương trình đang nạp dữ liệu !!!");
            SplashScreen.SetCommentaryString("Kiểm tra version.......");
            FirstRun();
            InitForm();
            byte[] bytes = imageToByteArray(pictureBox1.Image);
            barEditItem1.EditValue = bytes;
            barEditItem1.Width = 100;
            this.Text += " - " + Config._version;

        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        #region Declare Forms
        public FrmManageDocument frmManageDocument;
        public FrmSearchBug frmSearchBug;
        public FrmScaleAddTool frmscale;
        public FrmCheckGia frmCheckgia;
        public Frmkiot frmkiot;
        public FrmSyncPrice frmSyncPrice;
        public FrmbangBaoGia frmbangbaogia;
        public FrmDonDatHang.FrmDonDatHang frmDonDatHang;
        private FrmImage frm;
        public FrmQuanlyDDH quanlyDdh;
        public FrmCheckSKU_CKTM frmCheckCKTM;
        public FrmCheckFileT frmKiemTrafileT;
        public FrmCheckCurrentcy frmCheckCurency;
        #endregion

       public void addformImag()
       {
           //frmLogIn._isfirt = false;
           xtraTabbedMdiManager.MdiParent = this;
           
           //CTLQuanLyForm.formName.Add(frm.Name);
           frm.Text = "FrontEnd Utility";
           //frm.LookAndFeel.SkinName = defaultLookAndFeel1.LookAndFeel.SkinName;
           //frm.LookAndFeel.UseDefaultLookAndFeel = true;
           frm.MdiParent = this;
           frm.Show();
           xtraTabbedMdiManager.Pages[frm].ShowCloseButton=DevExpress.Utils.DefaultBoolean.False;
          
       }


        private void barControl_HotTrackedLinkChanged(object sender, NavBarLinkEventArgs e)
        {
            NavBarControl control = (NavBarControl) sender;
            if (control.HotTrackedLink != null)
            {
                if (control.HotTrackedLink.ItemName == "btnInsertDataWinDSS")
                {
                    //barIntro.Visible = true;
                    barIntro.OptionsNavPane.NavPaneState = NavPaneState.Expanded;
                    barIntro.Groups[0].Expanded = true;
                    barIntro.Dock = DockStyle.Fill;
                    // Các group khách expand = false
                }
                if (control.HotTrackedLink.ItemName == "btnScaleAdapterTool")
                {
                    //barIntro.Visible = true;
                    barIntro.Groups[1].Expanded = true;
                    barIntro.Dock = DockStyle.Fill;
                    barIntro.OptionsNavPane.NavPaneState = NavPaneState.Expanded;
                }
                if (control.HotTrackedLink.ItemName == "btnKiemTraSieuThi")
                {
                    //barIntro.Visible = true;
                    barIntro.Groups[2].Expanded = true;
                    barIntro.Dock = DockStyle.Fill;
                    barIntro.OptionsNavPane.NavPaneState = NavPaneState.Expanded;
                }
                if (control.HotTrackedLink.ItemName == "btnCheckPrice")
                {
                    //barIntro.Visible = true;
                    barIntro.Groups[3].Expanded = true;
                    barIntro.Dock = DockStyle.Fill;
                    barIntro.OptionsNavPane.NavPaneState = NavPaneState.Expanded;
                }
                if (control.HotTrackedLink.ItemName == "btnCheckPrice")
                {
                    //barIntro.Visible = false;
                }
            }

        }

        string str123 = "ThinhPhat@JSC@123";
        private DataSet _dsKetNoi = new DataSet();
        private string IDNhanVien;
        public void InitForm()
        {
            frmManageDocument = new FrmManageDocument(IDNhanVien);
            btnMasterControl.Enabled = false;
            frmSearchBug = new FrmSearchBug();
            btnUseDocument.Enabled = false;
            frmscale=new FrmScaleAddTool();
            btnScaleAdapterTool.Enabled = false;
            frmCheckgia=new FrmCheckGia();
            btnCheckPrice.Enabled = false;
            frmkiot=new Frmkiot();
            frmSyncPrice=new FrmSyncPrice();
            frmbangbaogia=new FrmbangBaoGia();
            frmDonDatHang=new FrmDonDatHang.FrmDonDatHang(this);
            quanlyDdh=new FrmQuanlyDDH();
            frmCheckCKTM=new FrmCheckSKU_CKTM();
            frmKiemTrafileT=new FrmCheckFileT();
            frmCheckCurency=new FrmCheckCurrentcy();
            //btcheckcurrentcy.Enabled = false;
            btbangbaogia.Enabled = false;
            btSyncPrice.Enabled = false;
            btbangbaogia.Enabled = false;
            btnKHTVCheck.Enabled = false;
            btCheckCKTM.Enabled = false;
            
            frm = new FrmImage();
            
        }

        public void LayCauHinh()
        {
            byte[] key = Blowfish.GetBytes(this.str123).Clone() as byte[];
            Blowfish blowfish = new Blowfish(key);
            StringReader reader = new StringReader(blowfish.ReadFromFile(Application.StartupPath + @"\Config.tps"));
            this._dsKetNoi = new DataSet();
            this._dsKetNoi.ReadXml(reader);
            if (this._dsKetNoi.Tables[0].Rows.Count < 1)
            {
                throw new Exception("File cấu hình không có kết nối nào");
            }
            ReadXML xml = new ReadXML();
            xml.db_name = Convert.ToString(_dsKetNoi.Tables["KetNoi"].Rows[0]["DBName"]);
            xml.db_server = Convert.ToString(_dsKetNoi.Tables["KetNoi"].Rows[0]["ServerName"]);
            xml.db_username = Convert.ToString(_dsKetNoi.Tables["KetNoi"].Rows[0]["UserName"]);
            xml.db_password = Convert.ToString(_dsKetNoi.Tables["KetNoi"].Rows[0]["Password"]);
            ConnectDb.Connect(xml.db_server, xml.db_name, xml.db_username, xml.db_password);
            txtDBname.Caption += xml.db_server + " - " + xml.db_name;
            try
            {
                reader.Close();
            }
            catch
            {
            }
        }

        void FirstRun()
        {
            try
            {
                LayCauHinh();
            }
            catch (Exception ex)
            {
                FrmMessage frm = new FrmMessage("Không có file cấu hình. \n Vui lòng chép file config.tps trong thư mục của chương trình GOLDMEM vào ");
                frm.ShowDialog();
                Environment.Exit(0);
            }
        }

        private void btnMasterControl_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (!CTLQuanLyForm.formName.Contains(frmManageDocument.Name))
            {
                if (frmManageDocument != null)
                {
                    frmManageDocument = new FrmManageDocument(frmLogIn.ID);
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmManageDocument.Name);
                    frmManageDocument.Text = "Quản lý hướng dẫn sử dụng các phần mềm";
                    frmManageDocument.MdiParent = this;
                    frmManageDocument.Show();
                }
                else
                {
                    frmManageDocument = new FrmManageDocument(frmLogIn.ID);
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmManageDocument.Name);
                    frmManageDocument.Text = "Quản lý hướng dẫn sử dụng các phần mềm";
                    frmManageDocument.MdiParent = this;
                    frmManageDocument.Show();
                }
            }
            else
            {
                if (frmManageDocument == null)
                {
                    frmManageDocument = new FrmManageDocument(frmLogIn.ID);
                    frmManageDocument.MdiParent = this;
                    frmManageDocument.Activate();
                    frmManageDocument.BringToFront();
                }
                else
                {
                    frmManageDocument.MdiParent = this;
                    frmManageDocument.Activate();
                    frmManageDocument.BringToFront();
                }
            }
        }

        FrmLogIn frmLogIn = new FrmLogIn();
        private void MainForm_Load(object sender, EventArgs e)
        {
            SplashScreen.SetCommentaryString("Kiểm tra phân quyền .......");
            xtraTabbedMdiManager.MdiParent = this;
            frmLogIn.Text = "Đăng nhập hệ thống SGC Tool";
            frmLogIn.MdiParent = this;
            SplashScreen.EndDisplay();
            frmLogIn.Show();
            frmLogIn.Loadf += new FrmLogIn.LoadFormImg(addformImag);
            IDNhanVien = frmLogIn.ID;
            txtDate.Caption = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            if (frmLogIn.Visible)
            {
                barControl.Hide();
                barControl.Enabled = false;
            }
            if (!frmLogIn.Visible)
            {
                barControl.Enabled = true;
                barControl.Show();
                txtLogIn.Caption = "Xin chào " + frmLogIn.MaNV + " - " + frmLogIn.MaST;
                Config._idcreate = frmLogIn.ID;
                Config._tennv = frmLogIn.TenNV;
                Config._tenst = frmLogIn.MaST;
                Config._MaNV = frmLogIn.ID;
                TPSDataAccess access = new TPSDataAccess(Path.Combine(Config._pathfileWinDSS, "SYSMST"));
                string MaST = "0";
                MaST = access.getMaSieuthi();
                storename.Caption =" WinDSS Store number: "+ MaST;
                //XetQuyenNhanVien(frmLogIn.ID, frmLogIn.TenNV);
                XetQuyenNhanVien(frmLogIn.ID);
              
                   
            }
        }
        public void XetQuyenNhanVien(string id)
        {
            CTLSearchBug sb = new CTLSearchBug();
            DataTable dt = sb.GetQuyenNhanVien(id);
            foreach (DataRow dataRow in dt.Rows)
            {
                switch (dataRow["TenForm"].ToString())
                {
                    case "FrmManageDocument":
                        btnMasterControl.Enabled = true;
                        break;
                    case "FrmSearchBug":
                        btnUseDocument.Enabled = true;
                        break;
                    case "FrmScaleAddTool":
                        btnScaleAdapterTool.Enabled = true;
                        break;
                    case "FrmCheckGia":
                        btnCheckPrice.Enabled = true; break;

                    case "FrmBackupDataWinDss":
                        //btbangbaogia.Enabled = true;
                        break;
                    case "FrmKiot":
                        btnKHTVCheck.Enabled = true;
                        break;
                    case "FrmSynPrice":
                        btSyncPrice.Enabled = true;
                        break;
                    case "FrmbangBaoGia":
                        btbangbaogia.Enabled = true;
                        break;
                    case "FrmDonDatHang":
                        btGhiNhanDonHang.Enabled = true;
                        break;
                    case "FrmCheckSKU_CKTM":
                        btCheckCKTM.Enabled = true;
                        break;
                    case "FrmCheckCurrentcy":
                        frmCheckCurency.Enabled = true;
                        break;

                }
            }
        }
        private void btnUseDocument_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (!CTLQuanLyForm.formName.Contains(frmSearchBug.Name))
            {
                if (frmSearchBug != null)
                {
                    frmSearchBug = new FrmSearchBug();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmSearchBug.Name);
                    frmSearchBug.Text = "Cẩm nang hướng dẫn sử dụng các phần mềm";
                    frmSearchBug.MdiParent = this;
                    frmSearchBug.Show();
                }
                else
                {
                    frmSearchBug = new FrmSearchBug();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmSearchBug.Name);
                    frmSearchBug.Text = "Cẩm nang hướng dẫn sử dụng các phần mềm";
                    frmSearchBug.MdiParent = this;
                    frmSearchBug.Show();
                }
            }
            else
            {
                if (frmSearchBug == null)
                {
                    frmSearchBug = new FrmSearchBug();
                    frmSearchBug.MdiParent = this;
                    frmSearchBug.Activate();
                    frmSearchBug.BringToFront();
                }
                else
                {
                    frmSearchBug.MdiParent = this;
                    frmSearchBug.Activate();
                    frmSearchBug.BringToFront();
                }
            }
        }

        private void btnScaleAdapterTool_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (!CTLQuanLyForm.formName.Contains(frmscale.Name))
            {
                if (frmscale != null)
                {
                    frmscale = new FrmScaleAddTool();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmscale.Name);
                    frmscale.Text = "Tool Cân";
                    frmscale.MdiParent = this;
                    frmscale.Show();
                }
                else
                {
                    frmscale = new FrmScaleAddTool();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmscale.Name);
                    frmscale.Text = "Tool Cân";
                    frmscale.MdiParent = this;
                    frmscale.Show();
                }
            }
            else
            {
                if (frmscale == null)
                {
                    frmscale = new FrmScaleAddTool();
                    frmscale.MdiParent = this;
                    frmscale.Activate();
                    frmscale.BringToFront();
                }
                else
                {
                    frmscale.MdiParent = this;
                    frmscale.Activate();
                    frmscale.BringToFront();
                }
            }
        }

        private void btnCheckPrice_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (!CTLQuanLyForm.formName.Contains(frmCheckgia.Name))
            {
                if (frmCheckgia != null)
                {
                    frmCheckgia = new FrmCheckGia();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmCheckgia.Name);
                    frmCheckgia.Text = "SKU Price, promotion check Tool";
                    frmCheckgia.MdiParent = this;
                    frmCheckgia.Show();
                }
                else
                {
                    frmCheckgia = new FrmCheckGia();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmCheckgia.Name);
                    frmCheckgia.Text = "SKU Price, promotion check Tool";
                    frmCheckgia.MdiParent = this;
                    frmCheckgia.Show();
                }
            }
            else
            {
                if (frmCheckgia == null)
                {
                    frmCheckgia = new FrmCheckGia();
                    frmCheckgia.MdiParent = this;
                    frmCheckgia.Activate();
                    frmCheckgia.BringToFront();
                }
                else
                {
                    frmCheckgia.MdiParent = this;
                    frmCheckgia.Activate();
                    frmCheckgia.BringToFront();
                }
            }
        }

        private void btnKHTVCheck_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (!CTLQuanLyForm.formName.Contains(frmkiot.Name))
            {
                if (frmkiot != null)
                {
                    frmkiot = new Frmkiot();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmkiot.Name);
                    frmkiot.Text = "Kiểm Tra Sổ Giá KH";
                    frmkiot.MdiParent = this;
                    frmkiot.Show();
                }
                else
                {
                    frmkiot = new Frmkiot();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmkiot.Name);
                    frmkiot.Text = "Kiểm Tra Sổ Giá KH";
                    frmkiot.MdiParent = this;
                    frmkiot.Show();
                }
            }
            else
            {
                if (frmkiot == null)
                {
                    frmkiot = new Frmkiot();
                    frmkiot.MdiParent = this;
                    frmkiot.Activate();
                    frmkiot.BringToFront();
                }
                else
                {
                    frmkiot.MdiParent = this;
                    frmkiot.Activate();
                    frmkiot.BringToFront();
                }
            }
        }

        private void SyncPrice_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (!CTLQuanLyForm.formName.Contains(frmSyncPrice.Name))
            {
                if (frmSyncPrice != null)
                {
                    frmSyncPrice = new FrmSyncPrice();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmSyncPrice.Name);
                    frmSyncPrice.Text = "Kiểm Tra Đồng Bộ Giá";
                    frmSyncPrice.MdiParent = this;
                    frmSyncPrice.Show();
                }
                else
                {
                    frmSyncPrice = new FrmSyncPrice();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmSyncPrice.Name);
                    frmSyncPrice.Text = "Kiểm Tra Đồng Bộ Giá";
                    frmSyncPrice.MdiParent = this;
                    frmSyncPrice.Show();
                }
            }
            else
            {
                if (frmSyncPrice == null)
                {
                    frmSyncPrice = new FrmSyncPrice();
                    frmSyncPrice.MdiParent = this;
                    frmSyncPrice.Activate();
                    frmSyncPrice.BringToFront();
                }
                else
                {
                    frmSyncPrice.MdiParent = this;
                    frmSyncPrice.Activate();
                    frmSyncPrice.BringToFront();
                }
            }
        }

        private void btbangbaogia_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (!CTLQuanLyForm.formName.Contains(frmbangbaogia.Name))
            {
                if (frmbangbaogia != null)
                {
                    frmbangbaogia = new FrmbangBaoGia();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmbangbaogia.Name);
                    frmbangbaogia.Text = "Bảng Báo Giá";
                    frmbangbaogia.MdiParent = this;
                    //if (Config._tableDMSKU == null)
                    //{
                    //    WaitingMsg waitingMsg = new WaitingMsg("Đang load dữ liệu......", "Vui lòng chờ trong giây lát");
                    //    Config.LoadDanhMucSKU();
                    //    waitingMsg.Finish();
                    //}
                    frmbangbaogia.Show();
                }
                else
                {
                    frmbangbaogia = new FrmbangBaoGia();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmbangbaogia.Name);
                    frmbangbaogia.Text = "Bảng Báo Giá";
                    frmbangbaogia.MdiParent = this;
                    //if (Config._tableDMSKU == null)
                    //{
                    //    WaitingMsg waitingMsg = new WaitingMsg("Đang load dữ liệu......", "Vui lòng chờ trong giây lát");
                    //    Config.LoadDanhMucSKU();
                    //    waitingMsg.Finish();
                    //}
                    frmbangbaogia.Show();
                }
            }
            else
            {
                if (frmbangbaogia == null)
                {
                    frmbangbaogia = new FrmbangBaoGia();
                    frmbangbaogia.MdiParent = this;
                    frmbangbaogia.Activate();
                    frmbangbaogia.BringToFront();
                }
                else
                {
                    frmbangbaogia.MdiParent = this;
                    frmbangbaogia.Activate();
                    frmbangbaogia.BringToFront();
                }
            }
        }

        private void btGhiNhanDonHang_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (!CTLQuanLyForm.formName.Contains(frmDonDatHang.Name))
            {
                if (frmDonDatHang != null)
                {
                    frmDonDatHang = new FrmDonDatHang.FrmDonDatHang(this);
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmDonDatHang.Name);
                    frmDonDatHang.Text = "Ghi nhận đơn đặt hàng";
                    frmDonDatHang.MdiParent = this;
                    if (Config._tableDMSKU == null)
                    {
                        WaitingMsg waitingMsg = new WaitingMsg("Đang load dữ liệu......", "Vui lòng chờ trong giây lát");
                        Config.LoadDanhMucSKU();
                        waitingMsg.Finish();
                    }
                    frmDonDatHang.Show();
                }
                else
                {
                    frmDonDatHang = new FrmDonDatHang.FrmDonDatHang(this);
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmDonDatHang.Name);
                    frmDonDatHang.Text = "Ghi nhận đơn đặt hàng";
                    frmDonDatHang.MdiParent = this;
                    if (Config._tableDMSKU == null)
                    {
                        WaitingMsg waitingMsg = new WaitingMsg("Đang load dữ liệu......", "Vui lòng chờ trong giây lát");
                        Config.LoadDanhMucSKU();
                        waitingMsg.Finish();
                    }
                    frmDonDatHang.Show();
                }
            }
            else
            {
                if (frmDonDatHang == null)
                {
                    frmDonDatHang = new FrmDonDatHang.FrmDonDatHang(this);
                    frmDonDatHang.MdiParent = this;
                    frmDonDatHang.Activate();
                    frmDonDatHang.BringToFront();
                }
                else
                {
                    frmDonDatHang.MdiParent = this;
                    frmDonDatHang.Activate();
                    frmDonDatHang.BringToFront();
                }
            }
        }

        private void btCheckCKTM_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (!CTLQuanLyForm.formName.Contains(frmCheckCKTM.Name))
            {
                if (frmCheckCKTM != null)
                {
                    frmCheckCKTM = new FrmCheckSKU_CKTM();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmCheckCKTM.Name);
                    frmCheckCKTM.Text = "Kiểm tra SKU không CKTM";
                    frmCheckCKTM.MdiParent = this;
                    frmCheckCKTM.Show();
                }
                else
                {
                    frmCheckCKTM = new FrmCheckSKU_CKTM();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmCheckCKTM.Name);
                    frmCheckCKTM.Text = "Kiểm tra SKU không CKTM";
                    frmCheckCKTM.MdiParent = this;
                    frmCheckCKTM.Show();
                }
            }
            else
            {
                if (frmCheckCKTM == null)
                {
                    frmCheckCKTM = new FrmCheckSKU_CKTM();
                    frmCheckCKTM.MdiParent = this;
                    frmCheckCKTM.Activate();
                    frmCheckCKTM.BringToFront();
                }
                else
                {
                    frmCheckCKTM.MdiParent = this;
                    frmCheckCKTM.Activate();
                    frmCheckCKTM.BringToFront();
                }
            }
        }

        private void btKiemTraFileT_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (!CTLQuanLyForm.formName.Contains(frmKiemTrafileT.Name))
            {
                if (frmKiemTrafileT != null)
                {
                    frmKiemTrafileT = new FrmCheckFileT();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmKiemTrafileT.Name);
                    frmKiemTrafileT.Text = "K/tra MMS có file T WinDSS";
                    frmKiemTrafileT.MdiParent = this;
                    frmKiemTrafileT.Show();
                }
                else
                {
                    frmKiemTrafileT = new FrmCheckFileT();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmKiemTrafileT.Name);
                    frmKiemTrafileT.Text = "K/tra MMS có file T WinDSS";
                    frmKiemTrafileT.MdiParent = this;
                    frmKiemTrafileT.Show();
                }
            }
            else
            {
                if (frmKiemTrafileT == null)
                {
                    frmKiemTrafileT = new FrmCheckFileT();
                    frmKiemTrafileT.MdiParent = this;
                    frmKiemTrafileT.Activate();
                    frmKiemTrafileT.BringToFront();
                }
                else
                {
                    frmKiemTrafileT.MdiParent = this;
                    frmKiemTrafileT.Activate();
                    frmKiemTrafileT.BringToFront();
                }
            }
        }

        private void btcheckcurrentcy_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (!CTLQuanLyForm.formName.Contains(frmCheckCurency.Name))
            {
                if (frmCheckCurency != null)
                {
                    frmCheckCurency = new FrmCheckCurrentcy();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmCheckCurency.Name);
                    frmCheckCurency.Text = "Kiểm tra Lỗi T1 CKTM";
                    frmCheckCurency.MdiParent = this;
                    frmCheckCurency.Show();
                }
                else
                {
                    frmCheckCurency = new FrmCheckCurrentcy();
                    xtraTabbedMdiManager.MdiParent = this;
                    CTLQuanLyForm.formName.Add(frmCheckCurency.Name);
                    frmCheckCurency.Text = "Kiểm tra Lỗi T1 CKTM";
                    frmCheckCurency.MdiParent = this;
                    frmCheckCurency.Show();
                }
            }
            else
            {
                if (frmCheckCurency == null)
                {
                    frmCheckCurency = new FrmCheckCurrentcy();
                    frmCheckCurency.MdiParent = this;
                    frmCheckCurency.Activate();
                    frmCheckCurency.BringToFront();
                }
                else
                {
                    frmCheckCurency.MdiParent = this;
                    frmCheckCurency.Activate();
                    frmCheckCurency.BringToFront();
                }
            }
        }

        private void barIntro_Click(object sender, EventArgs e)
        {

        }

     
       
      

       

    }
}