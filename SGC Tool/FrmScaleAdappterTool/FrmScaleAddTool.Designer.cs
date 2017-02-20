namespace SGC_Tool.FrmScaleAdappterTool
{
    partial class FrmScaleAddTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScaleAddTool));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTthoat = new System.Windows.Forms.ToolStripButton();
            this.BTHienthi = new System.Windows.Forms.ToolStripButton();
            this.locPLU = new System.Windows.Forms.ToolStripButton();
            this.LuuPLU = new System.Windows.Forms.ToolStripButton();
            this.BTselectPriceupd = new System.Windows.Forms.ToolStripButton();
            this.BTXuatfile = new System.Windows.Forms.ToolStripButton();
            this.BTDSSKULoaiBo = new System.Windows.Forms.ToolStripButton();
            this.BTLuu = new System.Windows.Forms.ToolStripButton();
            this.GridDSMa = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CMaLoaiBo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CheckMa = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.CSKU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUPC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CCurencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labhandung = new System.Windows.Forms.Label();
            this.labhd1 = new System.Windows.Forms.Label();
            this.labHD3 = new System.Windows.Forms.Label();
            this.labHD2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDSMa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckMa)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(933, 69);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SGC_Tool.Properties.Resources.book_blue_next;
            this.pictureBox1.Location = new System.Drawing.Point(6, 13);
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
            this.locPLU,
            this.LuuPLU,
            this.BTHienthi,
            this.BTselectPriceupd,
            this.BTXuatfile,
            this.BTDSSKULoaiBo,
            this.BTLuu});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(3, 17);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(927, 49);
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
            this.BTthoat.Size = new System.Drawing.Size(83, 46);
            this.BTthoat.Text = "Exit";
            this.BTthoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTthoat.ToolTipText = "Thoát chương trình";
            this.BTthoat.Click += new System.EventHandler(this.BTthoat_Click);
            // 
            // BTHienthi
            // 
            this.BTHienthi.AutoSize = false;
            this.BTHienthi.Image = ((System.Drawing.Image)(resources.GetObject("BTHienthi.Image")));
            this.BTHienthi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTHienthi.Name = "BTHienthi";
            this.BTHienthi.Size = new System.Drawing.Size(83, 46);
            this.BTHienthi.Text = "Load PLU data";
            this.BTHienthi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTHienthi.ToolTipText = "Load danh mục hàng hóa";
            this.BTHienthi.Click += new System.EventHandler(this.BTHienthi_Click);
            // 
            // locPLU
            // 
            this.locPLU.Image = global::SGC_Tool.Properties.Resources.filter1;
            this.locPLU.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.locPLU.Name = "locPLU";
            this.locPLU.Size = new System.Drawing.Size(92, 46);
            this.locPLU.Text = "Loc PLU Thay doi";
            this.locPLU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.locPLU.ToolTipText = "Lọc PLU Thay đổi so với DM gốc đã lưu";
            this.locPLU.Visible = false;
            this.locPLU.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // LuuPLU
            // 
            this.LuuPLU.Image = global::SGC_Tool.Properties.Resources.Misc_Download_Database_icon;
            this.LuuPLU.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LuuPLU.Name = "LuuPLU";
            this.LuuPLU.Size = new System.Drawing.Size(88, 46);
            this.LuuPLU.Text = "Luu DM PLU Goc";
            this.LuuPLU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.LuuPLU.ToolTipText = "Lưu DM PLU làm danh mục gốc để so sánh lần sau";
            this.LuuPLU.Visible = false;
            this.LuuPLU.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // BTselectPriceupd
            // 
            this.BTselectPriceupd.Image = ((System.Drawing.Image)(resources.GetObject("BTselectPriceupd.Image")));
            this.BTselectPriceupd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTselectPriceupd.Name = "BTselectPriceupd";
            this.BTselectPriceupd.Size = new System.Drawing.Size(115, 46);
            this.BTselectPriceupd.Text = "Get price changed file";
            this.BTselectPriceupd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTselectPriceupd.ToolTipText = "Lấy file chỉnh giá PRCUPD";
            this.BTselectPriceupd.Click += new System.EventHandler(this.BTselectPriceupd_Click);
            // 
            // BTXuatfile
            // 
            this.BTXuatfile.AutoSize = false;
            this.BTXuatfile.Image = ((System.Drawing.Image)(resources.GetObject("BTXuatfile.Image")));
            this.BTXuatfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTXuatfile.Name = "BTXuatfile";
            this.BTXuatfile.Size = new System.Drawing.Size(83, 46);
            this.BTXuatfile.Text = "Export CSV file";
            this.BTXuatfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTXuatfile.ToolTipText = "Xuất file CSV cho cân";
            this.BTXuatfile.Click += new System.EventHandler(this.BTXuatfile_Click);
            // 
            // BTDSSKULoaiBo
            // 
            this.BTDSSKULoaiBo.Image = ((System.Drawing.Image)(resources.GetObject("BTDSSKULoaiBo.Image")));
            this.BTDSSKULoaiBo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTDSSKULoaiBo.Name = "BTDSSKULoaiBo";
            this.BTDSSKULoaiBo.Size = new System.Drawing.Size(88, 46);
            this.BTDSSKULoaiBo.Text = "View remove list";
            this.BTDSSKULoaiBo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTDSSKULoaiBo.ToolTipText = "Xem và Import danh sách các SKU loại bỏ";
            this.BTDSSKULoaiBo.Click += new System.EventHandler(this.BTDSSKULoaiBo_Click);
            // 
            // BTLuu
            // 
            this.BTLuu.Image = ((System.Drawing.Image)(resources.GetObject("BTLuu.Image")));
            this.BTLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTLuu.Name = "BTLuu";
            this.BTLuu.Size = new System.Drawing.Size(90, 46);
            this.BTLuu.Text = "Save remove list";
            this.BTLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTLuu.ToolTipText = "Lưu danh sách các SKU loại bỏ";
            this.BTLuu.Click += new System.EventHandler(this.BTLuu_Click);
            // 
            // GridDSMa
            // 
            this.GridDSMa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GridDSMa.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.GridDSMa.Location = new System.Drawing.Point(12, 133);
            this.GridDSMa.MainView = this.gridView1;
            this.GridDSMa.Name = "GridDSMa";
            this.GridDSMa.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.CheckMa});
            this.GridDSMa.Size = new System.Drawing.Size(933, 437);
            this.GridDSMa.TabIndex = 2;
            this.GridDSMa.UseEmbeddedNavigator = true;
            this.GridDSMa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CMaLoaiBo,
            this.CSKU,
            this.CUPC,
            this.CDescription,
            this.CPrice,
            this.CCurencyCode,
            this.CDonVi});
            this.gridView1.GridControl = this.GridDSMa;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // CMaLoaiBo
            // 
            this.CMaLoaiBo.AppearanceCell.Options.UseTextOptions = true;
            this.CMaLoaiBo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CMaLoaiBo.AppearanceHeader.Options.UseTextOptions = true;
            this.CMaLoaiBo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CMaLoaiBo.Caption = "Remove";
            this.CMaLoaiBo.ColumnEdit = this.CheckMa;
            this.CMaLoaiBo.FieldName = "Check";
            this.CMaLoaiBo.MaxWidth = 100;
            this.CMaLoaiBo.Name = "CMaLoaiBo";
            this.CMaLoaiBo.Visible = true;
            this.CMaLoaiBo.VisibleIndex = 0;
            this.CMaLoaiBo.Width = 100;
            // 
            // CheckMa
            // 
            this.CheckMa.AutoHeight = false;
            this.CheckMa.Name = "CheckMa";
            // 
            // CSKU
            // 
            this.CSKU.AppearanceCell.Options.UseTextOptions = true;
            this.CSKU.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CSKU.AppearanceHeader.Options.UseTextOptions = true;
            this.CSKU.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CSKU.Caption = "SKU";
            this.CSKU.FieldName = "SKU";
            this.CSKU.MaxWidth = 100;
            this.CSKU.Name = "CSKU";
            this.CSKU.OptionsColumn.AllowEdit = false;
            this.CSKU.Visible = true;
            this.CSKU.VisibleIndex = 1;
            this.CSKU.Width = 90;
            // 
            // CUPC
            // 
            this.CUPC.AppearanceCell.Options.UseTextOptions = true;
            this.CUPC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CUPC.AppearanceHeader.Options.UseTextOptions = true;
            this.CUPC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CUPC.Caption = "UPC";
            this.CUPC.FieldName = "UPC";
            this.CUPC.Name = "CUPC";
            this.CUPC.OptionsColumn.AllowEdit = false;
            this.CUPC.Visible = true;
            this.CUPC.VisibleIndex = 2;
            this.CUPC.Width = 221;
            // 
            // CDescription
            // 
            this.CDescription.Caption = "Description";
            this.CDescription.FieldName = "Description";
            this.CDescription.Name = "CDescription";
            this.CDescription.OptionsColumn.AllowEdit = false;
            this.CDescription.Visible = true;
            this.CDescription.VisibleIndex = 3;
            this.CDescription.Width = 223;
            // 
            // CPrice
            // 
            this.CPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.CPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CPrice.Caption = "Price";
            this.CPrice.DisplayFormat.FormatString = "N2";
            this.CPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CPrice.FieldName = "Price";
            this.CPrice.MaxWidth = 120;
            this.CPrice.Name = "CPrice";
            this.CPrice.OptionsColumn.AllowEdit = false;
            this.CPrice.Visible = true;
            this.CPrice.VisibleIndex = 4;
            this.CPrice.Width = 108;
            // 
            // CCurencyCode
            // 
            this.CCurencyCode.AppearanceCell.Options.UseTextOptions = true;
            this.CCurencyCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CCurencyCode.AppearanceHeader.Options.UseTextOptions = true;
            this.CCurencyCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CCurencyCode.Caption = "Hạn sử dụng";
            this.CCurencyCode.FieldName = "HanDung";
            this.CCurencyCode.MaxWidth = 120;
            this.CCurencyCode.MinWidth = 60;
            this.CCurencyCode.Name = "CCurencyCode";
            this.CCurencyCode.Visible = true;
            this.CCurencyCode.VisibleIndex = 5;
            this.CCurencyCode.Width = 120;
            // 
            // CDonVi
            // 
            this.CDonVi.AppearanceCell.Options.UseTextOptions = true;
            this.CDonVi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CDonVi.AppearanceHeader.Options.UseTextOptions = true;
            this.CDonVi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CDonVi.Caption = "Unit";
            this.CDonVi.FieldName = "Sell_Unit";
            this.CDonVi.MaxWidth = 100;
            this.CDonVi.Name = "CDonVi";
            this.CDonVi.OptionsColumn.AllowEdit = false;
            this.CDonVi.Visible = true;
            this.CDonVi.VisibleIndex = 6;
            this.CDonVi.Width = 50;
            // 
            // labhandung
            // 
            this.labhandung.AutoSize = true;
            this.labhandung.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.labhandung.ForeColor = System.Drawing.Color.Red;
            this.labhandung.Location = new System.Drawing.Point(15, 96);
            this.labhandung.Name = "labhandung";
            this.labhandung.Size = new System.Drawing.Size(205, 17);
            this.labhandung.TabIndex = 4;
            this.labhandung.Text = "Định nghĩa hạn sử dụng cho cân";
            // 
            // labhd1
            // 
            this.labhd1.AutoSize = true;
            this.labhd1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.labhd1.ForeColor = System.Drawing.Color.Blue;
            this.labhd1.Location = new System.Drawing.Point(81, 113);
            this.labhd1.Name = "labhd1";
            this.labhd1.Size = new System.Drawing.Size(187, 17);
            this.labhd1.TabIndex = 4;
            this.labhd1.Text = "Định nghĩa hạn dùng cho cân";
            // 
            // labHD3
            // 
            this.labHD3.AutoSize = true;
            this.labHD3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.labHD3.ForeColor = System.Drawing.Color.Blue;
            this.labHD3.Location = new System.Drawing.Point(561, 113);
            this.labHD3.Name = "labHD3";
            this.labHD3.Size = new System.Drawing.Size(187, 17);
            this.labHD3.TabIndex = 4;
            this.labHD3.Text = "Định nghĩa hạn dùng cho cân";
            // 
            // labHD2
            // 
            this.labHD2.AutoSize = true;
            this.labHD2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.labHD2.ForeColor = System.Drawing.Color.Blue;
            this.labHD2.Location = new System.Drawing.Point(326, 113);
            this.labHD2.Name = "labHD2";
            this.labHD2.Size = new System.Drawing.Size(187, 17);
            this.labHD2.TabIndex = 4;
            this.labHD2.Text = "Định nghĩa hạn dùng cho cân";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(294, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "||";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(530, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "||";
            // 
            // FrmScaleAddTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 582);
            this.Controls.Add(this.labHD2);
            this.Controls.Add(this.labHD3);
            this.Controls.Add(this.labhd1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labhandung);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GridDSMa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmScaleAddTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmScaleAddTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmScaleAddTool_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDSMa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckMa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripButton BTthoat;
        private System.Windows.Forms.ToolStripButton BTHienthi;
        private DevExpress.XtraGrid.GridControl GridDSMa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn CSKU;
        private DevExpress.XtraGrid.Columns.GridColumn CUPC;
        private DevExpress.XtraGrid.Columns.GridColumn CDescription;
        private DevExpress.XtraGrid.Columns.GridColumn CPrice;
        private DevExpress.XtraGrid.Columns.GridColumn CCurencyCode;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTDSSKULoaiBo;
        private System.Windows.Forms.ToolStripButton BTXuatfile;
        private DevExpress.XtraGrid.Columns.GridColumn CDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn CMaLoaiBo;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit CheckMa;
        private System.Windows.Forms.ToolStripButton BTLuu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton BTselectPriceupd;
        private System.Windows.Forms.Label labhandung;
        private System.Windows.Forms.Label labhd1;
        private System.Windows.Forms.Label labHD3;
        private System.Windows.Forms.Label labHD2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripButton LuuPLU;
        private System.Windows.Forms.ToolStripButton locPLU;
    }
}