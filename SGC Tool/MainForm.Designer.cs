namespace SGC_Tool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.txtDBname = new DevExpress.XtraBars.BarStaticItem();
            this.txtLogIn = new DevExpress.XtraBars.BarStaticItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.txtDate = new DevExpress.XtraBars.BarStaticItem();
            this.storename = new DevExpress.XtraBars.BarStaticItem();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.repositoryItemPictureEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.barControl = new DevExpress.XtraNavBar.NavBarControl();
            this.DocumentTool = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnMasterControl = new DevExpress.XtraNavBar.NavBarItem();
            this.btnUseDocument = new DevExpress.XtraNavBar.NavBarItem();
            this.WINDSSTool = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnScaleAdapterTool = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCheckPrice = new DevExpress.XtraNavBar.NavBarItem();
            this.btnInsertDataWinDSS = new DevExpress.XtraNavBar.NavBarItem();
            this.btnKHTVCheck = new DevExpress.XtraNavBar.NavBarItem();
            this.btSyncPrice = new DevExpress.XtraNavBar.NavBarItem();
            this.btbangbaogia = new DevExpress.XtraNavBar.NavBarItem();
            this.btGhiNhanDonHang = new DevExpress.XtraNavBar.NavBarItem();
            this.btCheckCKTM = new DevExpress.XtraNavBar.NavBarItem();
            this.btKiemTraFileT = new DevExpress.XtraNavBar.NavBarItem();
            this.btcheckcurrentcy = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.IntroGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ItemInsertWINDSS = new DevExpress.XtraNavBar.NavBarItem();
            this.ItemScaleAdapterTool = new DevExpress.XtraNavBar.NavBarItem();
            this.ItemKiemTraSieuThi = new DevExpress.XtraNavBar.NavBarItem();
            this.ItemCheckPrice = new DevExpress.XtraNavBar.NavBarItem();
            this.btnInsertDSS_Intro = new DevExpress.XtraNavBar.NavBarItem();
            this.btnGioiThieuWINDSSTool = new DevExpress.XtraNavBar.NavBarItem();
            this.btnIntro_InsertWINDSS = new DevExpress.XtraNavBar.NavBarItem();
            this.barInsertWINDSS = new DevExpress.XtraNavBar.NavBarGroup();
            this.barScaleAdapterTool = new DevExpress.XtraNavBar.NavBarGroup();
            this.barKiemTraSieuThi = new DevExpress.XtraNavBar.NavBarGroup();
            this.barCheckPrice = new DevExpress.XtraNavBar.NavBarGroup();
            this.barIntro = new DevExpress.XtraNavBar.NavBarControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barIntro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.txtDBname);
            this.ribbonStatusBar.ItemLinks.Add(this.txtLogIn);
            this.ribbonStatusBar.ItemLinks.Add(this.barEditItem1);
            this.ribbonStatusBar.ItemLinks.Add(this.txtDate);
            this.ribbonStatusBar.ItemLinks.Add(this.storename);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 474);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(690, 25);
            // 
            // txtDBname
            // 
            this.txtDBname.Caption = "Database: ";
            this.txtDBname.Id = 0;
            this.txtDBname.Name = "txtDBname";
            this.txtDBname.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // txtLogIn
            // 
            this.txtLogIn.Caption = "UserName:";
            this.txtLogIn.Id = 1;
            this.txtLogIn.Name = "txtLogIn";
            this.txtLogIn.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barEditItem1
            // 
            this.barEditItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barEditItem1.Edit = this.repositoryItemPictureEdit2;
            this.barEditItem1.Id = 17;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            // 
            // txtDate
            // 
            this.txtDate.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.txtDate.Caption = "Ngày: ";
            this.txtDate.Id = 2;
            this.txtDate.Name = "txtDate";
            this.txtDate.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // storename
            // 
            this.storename.Caption = "WinDSS Store number:";
            this.storename.Id = 18;
            this.storename.Name = "storename";
            this.storename.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = ((System.Drawing.Bitmap)(resources.GetObject("ribbon.ApplicationIcon")));
            this.ribbon.Images = this.imageList1;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.txtDBname,
            this.txtLogIn,
            this.txtDate,
            this.barEditItem1,
            this.storename});
            this.ribbon.LargeImages = this.imageList1;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 19;
            this.ribbon.Name = "ribbon";
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit6,
            this.repositoryItemPictureEdit1,
            this.repositoryItemPictureEdit2});
            this.ribbon.Size = new System.Drawing.Size(690, 48);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "20100514113247_c__n_excell.png");
            this.imageList1.Images.SetKeyName(1, "logoFE_New01.jpg");
            // 
            // repositoryItemPictureEdit6
            // 
            this.repositoryItemPictureEdit6.Name = "repositoryItemPictureEdit6";
            this.repositoryItemPictureEdit6.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.Image;
            this.repositoryItemPictureEdit6.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.StretchVertical;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // barControl
            // 
            this.barControl.ActiveGroup = this.DocumentTool;
            this.barControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(185)))), ((int)(((byte)(62)))));
            this.barControl.ContentButtonHint = null;
            this.barControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.barControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.WINDSSTool,
            this.DocumentTool});
            this.barControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnInsertDataWinDSS,
            this.btnScaleAdapterTool,
            this.btbangbaogia,
            this.btnCheckPrice,
            this.btnMasterControl,
            this.btnUseDocument,
            this.btnKHTVCheck,
            this.btSyncPrice,
            this.navBarItem1,
            this.btGhiNhanDonHang,
            this.btCheckCKTM,
            this.btKiemTraFileT,
            this.btcheckcurrentcy});
            this.barControl.LinkInterval = 0;
            this.barControl.Location = new System.Drawing.Point(0, 48);
            this.barControl.Name = "barControl";
            this.barControl.OptionsNavPane.ExpandedWidth = 162;
            this.barControl.OptionsNavPane.ShowOverflowPanel = false;
            this.barControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.barControl.Size = new System.Drawing.Size(212, 426);
            this.barControl.TabIndex = 5;
            this.barControl.Text = "Chương trình";
            this.barControl.HotTrackedLinkChanged += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.barControl_HotTrackedLinkChanged);
            // 
            // DocumentTool
            // 
            this.DocumentTool.Caption = "Cẩm nang hướng dẫn sử dụng";
            this.DocumentTool.Expanded = true;
            this.DocumentTool.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.DocumentTool.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnMasterControl),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnUseDocument)});
            this.DocumentTool.Name = "DocumentTool";
            // 
            // btnMasterControl
            // 
            this.btnMasterControl.Caption = "Quản lý hướng dẫn sử dụng các phần mềm";
            this.btnMasterControl.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMasterControl.LargeImage")));
            this.btnMasterControl.Name = "btnMasterControl";
            this.btnMasterControl.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnMasterControl_LinkClicked);
            // 
            // btnUseDocument
            // 
            this.btnUseDocument.Caption = "Cẩm nang hướng dẫn sử dụng các phần mềm";
            this.btnUseDocument.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnUseDocument.LargeImage")));
            this.btnUseDocument.Name = "btnUseDocument";
            this.btnUseDocument.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnUseDocument_LinkClicked);
            // 
            // WINDSSTool
            // 
            this.WINDSSTool.Caption = "FrontEnd Tools";
            this.WINDSSTool.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.WINDSSTool.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnScaleAdapterTool),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCheckPrice),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnInsertDataWinDSS),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnKHTVCheck),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btSyncPrice),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btbangbaogia),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btGhiNhanDonHang),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btCheckCKTM),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btKiemTraFileT),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btcheckcurrentcy)});
            this.WINDSSTool.Name = "WINDSSTool";
            this.WINDSSTool.TopVisibleLinkIndex = 2;
            // 
            // btnScaleAdapterTool
            // 
            this.btnScaleAdapterTool.Caption = "Tool Cân";
            this.btnScaleAdapterTool.LargeImageIndex = 0;
            this.btnScaleAdapterTool.Name = "btnScaleAdapterTool";
            this.btnScaleAdapterTool.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnScaleAdapterTool.SmallImage")));
            this.btnScaleAdapterTool.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnScaleAdapterTool_LinkClicked);
            // 
            // btnCheckPrice
            // 
            this.btnCheckPrice.Caption = "SKU Price, promotion check Tool";
            this.btnCheckPrice.Name = "btnCheckPrice";
            this.btnCheckPrice.Visible = false;
            this.btnCheckPrice.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCheckPrice_LinkClicked);
            // 
            // btnInsertDataWinDSS
            // 
            this.btnInsertDataWinDSS.Caption = "Backup WINDSS Data Tool";
            this.btnInsertDataWinDSS.Name = "btnInsertDataWinDSS";
            this.btnInsertDataWinDSS.Visible = false;
            // 
            // btnKHTVCheck
            // 
            this.btnKHTVCheck.Caption = "Kiểm Tra Sổ Giá KH";
            this.btnKHTVCheck.Name = "btnKHTVCheck";
            this.btnKHTVCheck.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnKHTVCheck.SmallImage")));
            this.btnKHTVCheck.Visible = false;
            this.btnKHTVCheck.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnKHTVCheck_LinkClicked);
            // 
            // btSyncPrice
            // 
            this.btSyncPrice.Caption = "Kiểm Tra Đồng Bộ Giá";
            this.btSyncPrice.Name = "btSyncPrice";
            this.btSyncPrice.SmallImage = ((System.Drawing.Image)(resources.GetObject("btSyncPrice.SmallImage")));
            this.btSyncPrice.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.SyncPrice_LinkClicked);
            // 
            // btbangbaogia
            // 
            this.btbangbaogia.Caption = "Bảng báo giá";
            this.btbangbaogia.Name = "btbangbaogia";
            this.btbangbaogia.SmallImage = ((System.Drawing.Image)(resources.GetObject("btbangbaogia.SmallImage")));
            this.btbangbaogia.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btbangbaogia_LinkClicked);
            // 
            // btGhiNhanDonHang
            // 
            this.btGhiNhanDonHang.Caption = "Ghi nhận đơn đặt hàng";
            this.btGhiNhanDonHang.Name = "btGhiNhanDonHang";
            this.btGhiNhanDonHang.SmallImage = ((System.Drawing.Image)(resources.GetObject("btGhiNhanDonHang.SmallImage")));
            this.btGhiNhanDonHang.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btGhiNhanDonHang_LinkClicked);
            // 
            // btCheckCKTM
            // 
            this.btCheckCKTM.Caption = "Kiểm tra SKU không CKTM";
            this.btCheckCKTM.Name = "btCheckCKTM";
            this.btCheckCKTM.SmallImage = ((System.Drawing.Image)(resources.GetObject("btCheckCKTM.SmallImage")));
            this.btCheckCKTM.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btCheckCKTM_LinkClicked);
            // 
            // btKiemTraFileT
            // 
            this.btKiemTraFileT.Caption = "K/tra MMS có file T WinDSS";
            this.btKiemTraFileT.LargeImage = global::SGC_Tool.Properties.Resources.CauHinhFax;
            this.btKiemTraFileT.Name = "btKiemTraFileT";
            this.btKiemTraFileT.Visible = false;
            this.btKiemTraFileT.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btKiemTraFileT_LinkClicked);
            // 
            // btcheckcurrentcy
            // 
            this.btcheckcurrentcy.Caption = "Kiểm tra Lỗi T1 CKTM";
            this.btcheckcurrentcy.Name = "btcheckcurrentcy";
            this.btcheckcurrentcy.SmallImage = ((System.Drawing.Image)(resources.GetObject("btcheckcurrentcy.SmallImage")));
            this.btcheckcurrentcy.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btcheckcurrentcy_LinkClicked);
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "navBarItem1";
            this.navBarItem1.Name = "navBarItem1";
            // 
            // IntroGroup
            // 
            this.IntroGroup.Caption = "Giới thiệu chung";
            this.IntroGroup.Expanded = true;
            this.IntroGroup.Name = "IntroGroup";
            // 
            // xtraTabbedMdiManager
            // 
            this.xtraTabbedMdiManager.MdiParent = this;
            this.xtraTabbedMdiManager.PageImagePosition = DevExpress.XtraTab.TabPageImagePosition.Center;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(500, 300);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "Scale Adapter Edi.bmp");
            this.imageCollection1.Images.SetKeyName(1, "Insert WINDSS.bmp");
            // 
            // ItemInsertWINDSS
            // 
            this.ItemInsertWINDSS.Caption = "";
            this.ItemInsertWINDSS.Name = "ItemInsertWINDSS";
            // 
            // ItemScaleAdapterTool
            // 
            this.ItemScaleAdapterTool.Caption = "";
            this.ItemScaleAdapterTool.Name = "ItemScaleAdapterTool";
            // 
            // ItemKiemTraSieuThi
            // 
            this.ItemKiemTraSieuThi.Caption = "";
            this.ItemKiemTraSieuThi.Name = "ItemKiemTraSieuThi";
            // 
            // ItemCheckPrice
            // 
            this.ItemCheckPrice.Caption = "";
            this.ItemCheckPrice.Name = "ItemCheckPrice";
            // 
            // btnInsertDSS_Intro
            // 
            this.btnInsertDSS_Intro.Caption = "navBarItem1";
            this.btnInsertDSS_Intro.Name = "btnInsertDSS_Intro";
            // 
            // btnGioiThieuWINDSSTool
            // 
            this.btnGioiThieuWINDSSTool.Caption = "";
            this.btnGioiThieuWINDSSTool.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGioiThieuWINDSSTool.LargeImage")));
            this.btnGioiThieuWINDSSTool.Name = "btnGioiThieuWINDSSTool";
            // 
            // btnIntro_InsertWINDSS
            // 
            this.btnIntro_InsertWINDSS.Caption = "Hỗ trợ Insert data vào chương trình WinDSS";
            this.btnIntro_InsertWINDSS.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnIntro_InsertWINDSS.LargeImage")));
            this.btnIntro_InsertWINDSS.Name = "btnIntro_InsertWINDSS";
            this.btnIntro_InsertWINDSS.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnIntro_InsertWINDSS.SmallImage")));
            // 
            // barInsertWINDSS
            // 
            this.barInsertWINDSS.Caption = "Insert Data WINDSS";
            this.barInsertWINDSS.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnIntro_InsertWINDSS)});
            this.barInsertWINDSS.Name = "barInsertWINDSS";
            this.barInsertWINDSS.NavigationPaneVisible = false;
            // 
            // barScaleAdapterTool
            // 
            this.barScaleAdapterTool.Caption = "Scale AdapterTool";
            this.barScaleAdapterTool.Name = "barScaleAdapterTool";
            this.barScaleAdapterTool.NavigationPaneVisible = false;
            // 
            // barKiemTraSieuThi
            // 
            this.barKiemTraSieuThi.Caption = "Kiểm tra siêu thị";
            this.barKiemTraSieuThi.Name = "barKiemTraSieuThi";
            this.barKiemTraSieuThi.NavigationPaneVisible = false;
            // 
            // barCheckPrice
            // 
            this.barCheckPrice.Caption = "Check Price Tool";
            this.barCheckPrice.Expanded = true;
            this.barCheckPrice.Name = "barCheckPrice";
            this.barCheckPrice.NavigationPaneVisible = false;
            // 
            // barIntro
            // 
            this.barIntro.ActiveGroup = this.barCheckPrice;
            this.barIntro.AllowSelectedLink = true;
            this.barIntro.ContentButtonHint = null;
            this.barIntro.Dock = System.Windows.Forms.DockStyle.Right;
            this.barIntro.EachGroupHasSelectedLink = true;
            this.barIntro.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.barInsertWINDSS,
            this.barScaleAdapterTool,
            this.barKiemTraSieuThi,
            this.barCheckPrice});
            this.barIntro.HideGroupCaptions = true;
            this.barIntro.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.ItemInsertWINDSS,
            this.ItemScaleAdapterTool,
            this.ItemKiemTraSieuThi,
            this.ItemCheckPrice,
            this.btnInsertDSS_Intro,
            this.btnGioiThieuWINDSSTool,
            this.btnIntro_InsertWINDSS});
            this.barIntro.Location = new System.Drawing.Point(218, 48);
            this.barIntro.Name = "barIntro";
            this.barIntro.NavigationPaneOverflowPanelUseSmallImages = false;
            this.barIntro.OptionsNavPane.AnimationFramesCount = 1;
            this.barIntro.OptionsNavPane.ExpandedWidth = 530;
            this.barIntro.OptionsNavPane.ShowExpandButton = false;
            this.barIntro.OptionsNavPane.ShowOverflowPanel = false;
            this.barIntro.OptionsNavPane.ShowSplitter = false;
            this.barIntro.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.barIntro.SelectLinkOnPress = false;
            this.barIntro.ShowGroupHint = false;
            this.barIntro.Size = new System.Drawing.Size(472, 426);
            this.barIntro.TabIndex = 11;
            this.barIntro.Visible = false;
            this.barIntro.Click += new System.EventHandler(this.barIntro_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(393, 614);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "CIM Check Tool";
            this.navBarItem2.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItem2.LargeImage")));
            this.navBarItem2.Name = "navBarItem2";
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 499);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.barIntro);
            this.Controls.Add(this.barControl);
            this.Controls.Add(this.ribbon);
            this.Controls.Add(this.ribbonStatusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "FrontEnd Utilities";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barIntro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarStaticItem txtDBname;
        private DevExpress.XtraBars.BarStaticItem txtLogIn;
        private DevExpress.XtraBars.BarStaticItem txtDate;
        private DevExpress.XtraNavBar.NavBarControl barControl;
        private DevExpress.XtraNavBar.NavBarGroup WINDSSTool;
        private DevExpress.XtraNavBar.NavBarItem btnInsertDataWinDSS;
        private DevExpress.XtraNavBar.NavBarItem btnScaleAdapterTool;
        private DevExpress.XtraNavBar.NavBarItem btbangbaogia;
        private DevExpress.XtraNavBar.NavBarItem btnCheckPrice;
        private DevExpress.XtraNavBar.NavBarGroup IntroGroup;
        private DevExpress.XtraNavBar.NavBarGroup DocumentTool;
        private DevExpress.XtraNavBar.NavBarItem btnMasterControl;
        private DevExpress.XtraNavBar.NavBarItem btnUseDocument;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem btnKHTVCheck;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraNavBar.NavBarControl barIntro;
        private DevExpress.XtraNavBar.NavBarGroup barScaleAdapterTool;
        private DevExpress.XtraNavBar.NavBarGroup barInsertWINDSS;
        private DevExpress.XtraNavBar.NavBarItem btnIntro_InsertWINDSS;
        private DevExpress.XtraNavBar.NavBarGroup barKiemTraSieuThi;
        private DevExpress.XtraNavBar.NavBarGroup barCheckPrice;
        private DevExpress.XtraNavBar.NavBarItem ItemInsertWINDSS;
        private DevExpress.XtraNavBar.NavBarItem ItemScaleAdapterTool;
        private DevExpress.XtraNavBar.NavBarItem ItemKiemTraSieuThi;
        private DevExpress.XtraNavBar.NavBarItem ItemCheckPrice;
        private DevExpress.XtraNavBar.NavBarItem btnInsertDSS_Intro;
        private DevExpress.XtraNavBar.NavBarItem btnGioiThieuWINDSSTool;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit6;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraNavBar.NavBarItem btSyncPrice;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraBars.BarStaticItem storename;
        private DevExpress.XtraNavBar.NavBarItem btGhiNhanDonHang;
        public DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private DevExpress.XtraNavBar.NavBarItem btCheckCKTM;
        private DevExpress.XtraNavBar.NavBarItem btKiemTraFileT;
        private DevExpress.XtraNavBar.NavBarItem btcheckcurrentcy;
    }
}