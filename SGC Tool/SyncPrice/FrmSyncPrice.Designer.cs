namespace SGC_Tool.SyncPrice
{
    partial class FrmSyncPrice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSyncPrice));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radconfirNo = new System.Windows.Forms.RadioButton();
            this.radconfirYes = new System.Windows.Forms.RadioButton();
            this.radConfirAll = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radUPCNotNull = new System.Windows.Forms.RadioButton();
            this.radUPCALL = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radsaleEA = new System.Windows.Forms.RadioButton();
            this.radsaleKG = new System.Windows.Forms.RadioButton();
            this.radsaleAll = new System.Windows.Forms.RadioButton();
            this.GrDSPriceSKU = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CSKU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTthoat = new System.Windows.Forms.ToolStripButton();
            this.btexportExcell = new System.Windows.Forms.ToolStripButton();
            this.BTXuatfile = new System.Windows.Forms.ToolStripButton();
            this.BTHienthi = new System.Windows.Forms.ToolStripButton();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrDSPriceSKU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radconfirNo);
            this.groupBox2.Controls.Add(this.radconfirYes);
            this.groupBox2.Controls.Add(this.radConfirAll);
            this.groupBox2.Location = new System.Drawing.Point(448, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 97);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Confirm Price";
            // 
            // radconfirNo
            // 
            this.radconfirNo.AutoSize = true;
            this.radconfirNo.Checked = true;
            this.radconfirNo.Location = new System.Drawing.Point(6, 66);
            this.radconfirNo.Name = "radconfirNo";
            this.radconfirNo.Size = new System.Drawing.Size(38, 17);
            this.radconfirNo.TabIndex = 2;
            this.radconfirNo.TabStop = true;
            this.radconfirNo.Text = "No";
            this.radconfirNo.UseVisualStyleBackColor = true;
            // 
            // radconfirYes
            // 
            this.radconfirYes.AutoSize = true;
            this.radconfirYes.Location = new System.Drawing.Point(6, 43);
            this.radconfirYes.Name = "radconfirYes";
            this.radconfirYes.Size = new System.Drawing.Size(42, 17);
            this.radconfirYes.TabIndex = 1;
            this.radconfirYes.Text = "Yes";
            this.radconfirYes.UseVisualStyleBackColor = true;
            // 
            // radConfirAll
            // 
            this.radConfirAll.AutoSize = true;
            this.radConfirAll.Location = new System.Drawing.Point(6, 20);
            this.radConfirAll.Name = "radConfirAll";
            this.radConfirAll.Size = new System.Drawing.Size(42, 17);
            this.radConfirAll.TabIndex = 0;
            this.radConfirAll.Text = "ALL";
            this.radConfirAll.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radUPCNotNull);
            this.groupBox3.Controls.Add(this.radUPCALL);
            this.groupBox3.Location = new System.Drawing.Point(230, 85);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 97);
            this.groupBox3.TabIndex = 66;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Primary UPC";
            // 
            // radUPCNotNull
            // 
            this.radUPCNotNull.AutoSize = true;
            this.radUPCNotNull.Checked = true;
            this.radUPCNotNull.Location = new System.Drawing.Point(15, 43);
            this.radUPCNotNull.Name = "radUPCNotNull";
            this.radUPCNotNull.Size = new System.Drawing.Size(62, 17);
            this.radUPCNotNull.TabIndex = 7;
            this.radUPCNotNull.TabStop = true;
            this.radUPCNotNull.Text = "Not Null";
            this.radUPCNotNull.UseVisualStyleBackColor = true;
            // 
            // radUPCALL
            // 
            this.radUPCALL.AutoSize = true;
            this.radUPCALL.Location = new System.Drawing.Point(15, 20);
            this.radUPCALL.Name = "radUPCALL";
            this.radUPCALL.Size = new System.Drawing.Size(42, 17);
            this.radUPCALL.TabIndex = 6;
            this.radUPCALL.Text = "ALL";
            this.radUPCALL.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radsaleEA);
            this.groupBox1.Controls.Add(this.radsaleKG);
            this.groupBox1.Controls.Add(this.radsaleAll);
            this.groupBox1.Location = new System.Drawing.Point(12, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 97);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sale Unit";
            // 
            // radsaleEA
            // 
            this.radsaleEA.AutoSize = true;
            this.radsaleEA.Checked = true;
            this.radsaleEA.Location = new System.Drawing.Point(13, 66);
            this.radsaleEA.Name = "radsaleEA";
            this.radsaleEA.Size = new System.Drawing.Size(38, 17);
            this.radsaleEA.TabIndex = 5;
            this.radsaleEA.TabStop = true;
            this.radsaleEA.Text = "EA";
            this.radsaleEA.UseVisualStyleBackColor = true;
            // 
            // radsaleKG
            // 
            this.radsaleKG.AutoSize = true;
            this.radsaleKG.Location = new System.Drawing.Point(13, 43);
            this.radsaleKG.Name = "radsaleKG";
            this.radsaleKG.Size = new System.Drawing.Size(38, 17);
            this.radsaleKG.TabIndex = 4;
            this.radsaleKG.Text = "KG";
            this.radsaleKG.UseVisualStyleBackColor = true;
            // 
            // radsaleAll
            // 
            this.radsaleAll.AutoSize = true;
            this.radsaleAll.Location = new System.Drawing.Point(13, 20);
            this.radsaleAll.Name = "radsaleAll";
            this.radsaleAll.Size = new System.Drawing.Size(42, 17);
            this.radsaleAll.TabIndex = 3;
            this.radsaleAll.Text = "ALL";
            this.radsaleAll.UseVisualStyleBackColor = true;
            // 
            // GrDSPriceSKU
            // 
            this.GrDSPriceSKU.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GrDSPriceSKU.Location = new System.Drawing.Point(12, 185);
            this.GrDSPriceSKU.MainView = this.gridView1;
            this.GrDSPriceSKU.Name = "GrDSPriceSKU";
            this.GrDSPriceSKU.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.GrDSPriceSKU.Size = new System.Drawing.Size(753, 288);
            this.GrDSPriceSKU.TabIndex = 61;
            this.GrDSPriceSKU.UseEmbeddedNavigator = true;
            this.GrDSPriceSKU.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CCheck,
            this.CSKU,
            this.gridColumn2,
            this.gridColumn1,
            this.CPrice});
            this.gridView1.GridControl = this.GrDSPriceSKU;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // CCheck
            // 
            this.CCheck.AppearanceCell.Options.UseTextOptions = true;
            this.CCheck.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.CCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CCheck.Caption = "Check";
            this.CCheck.FieldName = "Check";
            this.CCheck.MaxWidth = 75;
            this.CCheck.Name = "CCheck";
            this.CCheck.Visible = true;
            this.CCheck.VisibleIndex = 0;
            // 
            // CSKU
            // 
            this.CSKU.AppearanceCell.Options.UseTextOptions = true;
            this.CSKU.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CSKU.AppearanceHeader.Options.UseTextOptions = true;
            this.CSKU.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CSKU.Caption = "SKU";
            this.CSKU.FieldName = "SKU";
            this.CSKU.Name = "CSKU";
            this.CSKU.OptionsColumn.ReadOnly = true;
            this.CSKU.Visible = true;
            this.CSKU.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Description";
            this.gridColumn2.FieldName = "Description";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "POS Price";
            this.gridColumn1.DisplayFormat.FormatString = "N0";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "PriceMMS";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // CPrice
            // 
            this.CPrice.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.CPrice.AppearanceCell.Options.UseBackColor = true;
            this.CPrice.Caption = "MMS Price";
            this.CPrice.DisplayFormat.FormatString = "N0";
            this.CPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CPrice.FieldName = "Price";
            this.CPrice.Name = "CPrice";
            this.CPrice.OptionsColumn.ReadOnly = true;
            this.CPrice.Visible = true;
            this.CPrice.VisibleIndex = 4;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Controls.Add(this.toolStrip1);
            this.groupBox4.Location = new System.Drawing.Point(12, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(753, 69);
            this.groupBox4.TabIndex = 68;
            this.groupBox4.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(83, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Giữa WinDSS và Intem(MMS Price)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(83, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kiểm tra đồng bộ giá bán(Regular Price)";
            // 
            // pictureBox1
            // 
            //this.pictureBox1.Image = global::SGC_Tool.Properties.Resources.pl_money;
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
            this.BTXuatfile,
            this.BTHienthi});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(3, 17);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(747, 49);
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
            this.BTthoat.Text = "Exit";
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
            this.btexportExcell.Size = new System.Drawing.Size(100, 46);
            this.btexportExcell.Text = "Export Excell file";
            this.btexportExcell.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btexportExcell.ToolTipText = "Xuất danh sách ra file excell";
            this.btexportExcell.Click += new System.EventHandler(this.btexportExcell_Click);
            // 
            // BTXuatfile
            // 
            this.BTXuatfile.AutoSize = false;
            this.BTXuatfile.Image = ((System.Drawing.Image)(resources.GetObject("BTXuatfile.Image")));
            this.BTXuatfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTXuatfile.Name = "BTXuatfile";
            this.BTXuatfile.Size = new System.Drawing.Size(120, 46);
            this.BTXuatfile.Text = "Create, Active Price file";
            this.BTXuatfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTXuatfile.ToolTipText = "Create, Active Price file";
            this.BTXuatfile.Click += new System.EventHandler(this.BTXuatfile_Click);
            // 
            // BTHienthi
            // 
            this.BTHienthi.AutoSize = false;
            this.BTHienthi.Image = ((System.Drawing.Image)(resources.GetObject("BTHienthi.Image")));
            this.BTHienthi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTHienthi.Name = "BTHienthi";
            this.BTHienthi.Size = new System.Drawing.Size(100, 46);
            this.BTHienthi.Text = "Load data";
            this.BTHienthi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTHienthi.ToolTipText = "Load giá danh mục";
            this.BTHienthi.Click += new System.EventHandler(this.BTHienthi_Click);
            // 
            // FrmSyncPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 480);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GrDSPriceSKU);
            this.Name = "FrmSyncPrice";
            this.Text = "Sync Price";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSyncPrice_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrDSPriceSKU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radconfirNo;
        private System.Windows.Forms.RadioButton radconfirYes;
        private System.Windows.Forms.RadioButton radConfirAll;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radUPCNotNull;
        private System.Windows.Forms.RadioButton radUPCALL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radsaleEA;
        private System.Windows.Forms.RadioButton radsaleKG;
        private System.Windows.Forms.RadioButton radsaleAll;
        private DevExpress.XtraGrid.GridControl GrDSPriceSKU;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn CCheck;
        private DevExpress.XtraGrid.Columns.GridColumn CSKU;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn CPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTthoat;
        private System.Windows.Forms.ToolStripButton BTHienthi;
        private System.Windows.Forms.ToolStripButton BTXuatfile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton btexportExcell;
    }
}