namespace SGC_Tool.FrmDonDatHang
{
    partial class FrmDonDatHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDonDatHang));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTthoat = new System.Windows.Forms.ToolStripButton();
            this.btexportExcell = new System.Windows.Forms.ToolStripButton();
            this.btsearch = new System.Windows.Forms.ToolStripButton();
            this.btclear = new System.Windows.Forms.ToolStripButton();
            this.btSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.GrDSSKU = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CSKU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUPC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CTenHangHoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CGiaGoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CGIAKM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CThanhTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grbtxoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txthotenKH = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.txtsoluong = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrDSSKU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbtxoa)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsoluong)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Controls.Add(this.toolStrip1);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(901, 69);
            this.groupBox4.TabIndex = 69;
            this.groupBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F);
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(66, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Đơn Đặt Hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 16F);
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(66, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ghi Nhận";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SGC_Tool.Properties.Resources.CauHinhMaPhieu;
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTthoat,
            this.btexportExcell,
            this.btsearch,
            this.btclear,
            this.btSave,
            this.toolStripButton1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(3, 17);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(895, 49);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTthoat
            // 
            this.BTthoat.AutoSize = false;
            this.BTthoat.Image = ((System.Drawing.Image)(resources.GetObject("BTthoat.Image")));
            this.BTthoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTthoat.Name = "BTthoat";
            this.BTthoat.Size = new System.Drawing.Size(100, 46);
            this.BTthoat.Text = "Thoát";
            this.BTthoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTthoat.ToolTipText = "Thoát chương trình";
            this.BTthoat.Click += new System.EventHandler(this.BTthoat_Click);
            // 
            // btexportExcell
            // 
            this.btexportExcell.AutoSize = false;
            this.btexportExcell.Image = global::SGC_Tool.Properties.Resources.fwExcel;
            this.btexportExcell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btexportExcell.Name = "btexportExcell";
            this.btexportExcell.Size = new System.Drawing.Size(110, 46);
            this.btexportExcell.Text = "Xuất Excell file [F6]";
            this.btexportExcell.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btexportExcell.ToolTipText = "Xuất danh sách ra file excell";
            this.btexportExcell.Click += new System.EventHandler(this.btexportExcell_Click);
            // 
            // btsearch
            // 
            this.btsearch.AutoSize = false;
            this.btsearch.Image = global::SGC_Tool.Properties.Resources.fwPrintPreview;
            this.btsearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btsearch.Name = "btsearch";
            this.btsearch.Size = new System.Drawing.Size(100, 46);
            this.btsearch.Text = "Tìm Kiếm[F4]";
            this.btsearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btsearch.Click += new System.EventHandler(this.btsearch_Click);
            // 
            // btclear
            // 
            this.btclear.AutoSize = false;
            this.btclear.Image = ((System.Drawing.Image)(resources.GetObject("btclear.Image")));
            this.btclear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btclear.Name = "btclear";
            this.btclear.Size = new System.Drawing.Size(100, 46);
            this.btclear.Text = "Tạo mới DDH[F5]";
            this.btclear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btclear.Click += new System.EventHandler(this.btclear_Click);
            // 
            // btSave
            // 
            this.btSave.AutoSize = false;
            this.btSave.Image = global::SGC_Tool.Properties.Resources.save_32_1;
            this.btSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(100, 46);
            this.btSave.Text = "&Lưu DDH[F7]";
            this.btSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Image = global::SGC_Tool.Properties.Resources.CauHinhFax1;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(110, 46);
            this.toolStripButton1.Text = "QL Đơn Đặt Hàng[F8]";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(8, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "Họ tên KH :";
            // 
            // GrDSSKU
            // 
            this.GrDSSKU.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GrDSSKU.Location = new System.Drawing.Point(310, 140);
            this.GrDSSKU.MainView = this.gridView1;
            this.GrDSSKU.Name = "GrDSSKU";
            this.GrDSSKU.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.grbtxoa});
            this.GrDSSKU.Size = new System.Drawing.Size(615, 264);
            this.GrDSSKU.TabIndex = 6;
            this.GrDSSKU.UseEmbeddedNavigator = true;
            this.GrDSSKU.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CSKU,
            this.CUPC,
            this.CTenHangHoa,
            this.CSoLuong,
            this.CGiaGoc,
            this.CGIAKM,
            this.CThanhTien,
            this.CGhiChu,
            this.CXoa,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.GrDSSKU;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // CSKU
            // 
            this.CSKU.AppearanceCell.Options.UseTextOptions = true;
            this.CSKU.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CSKU.AppearanceHeader.Options.UseTextOptions = true;
            this.CSKU.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CSKU.Caption = "SKU";
            this.CSKU.FieldName = "SKU";
            this.CSKU.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.CSKU.MaxWidth = 70;
            this.CSKU.MinWidth = 70;
            this.CSKU.Name = "CSKU";
            this.CSKU.OptionsColumn.ReadOnly = true;
            this.CSKU.Visible = true;
            this.CSKU.VisibleIndex = 0;
            this.CSKU.Width = 70;
            // 
            // CUPC
            // 
            this.CUPC.Caption = "UPC";
            this.CUPC.FieldName = "UPC";
            this.CUPC.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.CUPC.MaxWidth = 120;
            this.CUPC.MinWidth = 120;
            this.CUPC.Name = "CUPC";
            this.CUPC.OptionsColumn.ReadOnly = true;
            this.CUPC.Visible = true;
            this.CUPC.VisibleIndex = 1;
            this.CUPC.Width = 120;
            // 
            // CTenHangHoa
            // 
            this.CTenHangHoa.Caption = "Tên hàng hóa";
            this.CTenHangHoa.FieldName = "Description";
            this.CTenHangHoa.MaxWidth = 170;
            this.CTenHangHoa.MinWidth = 170;
            this.CTenHangHoa.Name = "CTenHangHoa";
            this.CTenHangHoa.OptionsColumn.FixedWidth = true;
            this.CTenHangHoa.OptionsColumn.ReadOnly = true;
            this.CTenHangHoa.Visible = true;
            this.CTenHangHoa.VisibleIndex = 2;
            this.CTenHangHoa.Width = 170;
            // 
            // CSoLuong
            // 
            this.CSoLuong.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.CSoLuong.Caption = "Số lượng";
            this.CSoLuong.DisplayFormat.FormatString = "N0";
            this.CSoLuong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CSoLuong.FieldName = "SoLuong";
            this.CSoLuong.MaxWidth = 75;
            this.CSoLuong.MinWidth = 75;
            this.CSoLuong.Name = "CSoLuong";
            this.CSoLuong.OptionsColumn.FixedWidth = true;
            this.CSoLuong.SummaryItem.DisplayFormat = "{0:n0}";
            this.CSoLuong.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.CSoLuong.Visible = true;
            this.CSoLuong.VisibleIndex = 3;
            this.CSoLuong.Width = 60;
            // 
            // CGiaGoc
            // 
            this.CGiaGoc.Caption = "Giá Gốc";
            this.CGiaGoc.DisplayFormat.FormatString = "N0";
            this.CGiaGoc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CGiaGoc.FieldName = "GiaGoc";
            this.CGiaGoc.MaxWidth = 100;
            this.CGiaGoc.MinWidth = 100;
            this.CGiaGoc.Name = "CGiaGoc";
            this.CGiaGoc.OptionsColumn.ReadOnly = true;
            this.CGiaGoc.Visible = true;
            this.CGiaGoc.VisibleIndex = 4;
            this.CGiaGoc.Width = 100;
            // 
            // CGIAKM
            // 
            this.CGIAKM.Caption = "Giá khuyến mãi";
            this.CGIAKM.DisplayFormat.FormatString = "N0";
            this.CGIAKM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CGIAKM.FieldName = "GiaKM";
            this.CGIAKM.MaxWidth = 120;
            this.CGIAKM.MinWidth = 120;
            this.CGIAKM.Name = "CGIAKM";
            this.CGIAKM.OptionsColumn.ReadOnly = true;
            this.CGIAKM.Visible = true;
            this.CGIAKM.VisibleIndex = 5;
            this.CGIAKM.Width = 120;
            // 
            // CThanhTien
            // 
            this.CThanhTien.Caption = "Thành tiền";
            this.CThanhTien.DisplayFormat.FormatString = "N2";
            this.CThanhTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CThanhTien.FieldName = "ThanhTien";
            this.CThanhTien.MaxWidth = 120;
            this.CThanhTien.MinWidth = 120;
            this.CThanhTien.Name = "CThanhTien";
            this.CThanhTien.OptionsColumn.ReadOnly = true;
            this.CThanhTien.SummaryItem.DisplayFormat = "{0:c2}";
            this.CThanhTien.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.CThanhTien.Visible = true;
            this.CThanhTien.VisibleIndex = 6;
            this.CThanhTien.Width = 120;
            // 
            // CGhiChu
            // 
            this.CGhiChu.Caption = "Ghi chú";
            this.CGhiChu.FieldName = "GhiChu";
            this.CGhiChu.MaxWidth = 200;
            this.CGhiChu.MinWidth = 200;
            this.CGhiChu.Name = "CGhiChu";
            this.CGhiChu.OptionsColumn.FixedWidth = true;
            this.CGhiChu.OptionsColumn.ReadOnly = true;
            this.CGhiChu.Visible = true;
            this.CGhiChu.VisibleIndex = 7;
            this.CGhiChu.Width = 200;
            // 
            // CXoa
            // 
            this.CXoa.Caption = "Xóa";
            this.CXoa.ColumnEdit = this.grbtxoa;
            this.CXoa.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.CXoa.MaxWidth = 60;
            this.CXoa.MinWidth = 60;
            this.CXoa.Name = "CXoa";
            this.CXoa.Visible = true;
            this.CXoa.VisibleIndex = 8;
            this.CXoa.Width = 60;
            // 
            // grbtxoa
            // 
            this.grbtxoa.AutoHeight = false;
            this.grbtxoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Xóa", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.grbtxoa.Name = "grbtxoa";
            this.grbtxoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.grbtxoa.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.grbtxoa_ButtonClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Method";
            this.gridColumn1.FieldName = "Method";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "DISCPRICE";
            this.gridColumn2.FieldName = "DISCPRICE";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "QTY1";
            this.gridColumn3.FieldName = "QTY1";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(8, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "SKU/UPC :";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.simpleButton1);
            this.groupBox1.Controls.Add(this.pictureEdit1);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtghichu);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtDienThoai);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txthotenKH);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.pictureEdit2);
            this.groupBox1.Controls.Add(this.txtsoluong);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSKU);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(4, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 323);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::SGC_Tool.Properties.Resources.F03;
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.simpleButton1.Location = new System.Drawing.Point(213, 211);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 89;
            this.simpleButton1.Text = "Add";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::SGC_Tool.Properties.Resources.F01;
            this.pictureEdit1.Location = new System.Drawing.Point(253, 53);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(35, 25);
            this.pictureEdit1.TabIndex = 88;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDiaChi.Location = new System.Drawing.Point(79, 103);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(209, 42);
            this.txtDiaChi.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.Color.Blue;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(6, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(289, 24);
            this.label12.TabIndex = 87;
            this.label12.Text = "Thông tin sản phẩm";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.Blue;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(289, 24);
            this.label11.TabIndex = 76;
            this.label11.Text = "Thông tin khách hàng";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtghichu
            // 
            this.txtghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtghichu.Location = new System.Drawing.Point(79, 235);
            this.txtghichu.Multiline = true;
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(209, 81);
            this.txtghichu.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(8, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 85;
            this.label10.Text = "Điạ chỉ :";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDienThoai.Location = new System.Drawing.Point(79, 78);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(209, 21);
            this.txtDienThoai.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(8, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 83;
            this.label9.Text = "Điện thoại :";
            // 
            // txthotenKH
            // 
            this.txthotenKH.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txthotenKH.Location = new System.Drawing.Point(79, 53);
            this.txthotenKH.Name = "txthotenKH";
            this.txthotenKH.Size = new System.Drawing.Size(168, 21);
            this.txthotenKH.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(8, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 80;
            this.label7.Text = "Ghi chú :";
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.EditValue = global::SGC_Tool.Properties.Resources.F02;
            this.pictureEdit2.Location = new System.Drawing.Point(253, 185);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Size = new System.Drawing.Size(35, 25);
            this.pictureEdit2.TabIndex = 77;
            // 
            // txtsoluong
            // 
            this.txtsoluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtsoluong.Location = new System.Drawing.Point(79, 210);
            this.txtsoluong.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtsoluong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.Size = new System.Drawing.Size(128, 21);
            this.txtsoluong.TabIndex = 4;
            this.txtsoluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsoluong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtsoluong.Enter += new System.EventHandler(this.txtsoluong_Enter);
            this.txtsoluong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluong_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(8, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "Số Lượng :";
            // 
            // txtSKU
            // 
            this.txtSKU.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtSKU.Location = new System.Drawing.Point(79, 185);
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Size = new System.Drawing.Size(168, 21);
            this.txtSKU.TabIndex = 3;
            this.txtSKU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSKU.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSKU_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(310, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(230, 13);
            this.label8.TabIndex = 75;
            this.label8.Text = "(Không hỗ trợ xem giá khuyến mãi theo sổ giá)";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.Blue;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(310, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(603, 24);
            this.label5.TabIndex = 74;
            this.label5.Text = "Danh Sách Các Mặt Hàng Trong Đơn Đặt Hàng";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmDonDatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 416);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GrDSSKU);
            this.Controls.Add(this.groupBox4);
            this.KeyPreview = true;
            this.Name = "FrmDonDatHang";
            this.Text = "Đơn đặt hàng";
            this.Shown += new System.EventHandler(this.FrmbangBaoGia_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmbangBaoGia_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDonDatHang_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmbangBaoGia_KeyDown);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrDSSKU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbtxoa)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsoluong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTthoat;
        private System.Windows.Forms.ToolStripButton btexportExcell;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl GrDSSKU;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn CSKU;
        private DevExpress.XtraGrid.Columns.GridColumn CUPC;
        private DevExpress.XtraGrid.Columns.GridColumn CTenHangHoa;
        private DevExpress.XtraGrid.Columns.GridColumn CSoLuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown txtsoluong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSKU;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn CGiaGoc;
        private DevExpress.XtraGrid.Columns.GridColumn CGIAKM;
        private DevExpress.XtraGrid.Columns.GridColumn CThanhTien;
        private DevExpress.XtraGrid.Columns.GridColumn CGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn CXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit grbtxoa;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.ToolStripButton btclear;
        private System.Windows.Forms.ToolStripButton btsearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txthotenKH;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.ToolStripButton btSave;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}