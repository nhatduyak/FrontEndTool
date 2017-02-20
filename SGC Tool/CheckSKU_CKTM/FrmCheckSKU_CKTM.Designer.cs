namespace SGC_Tool.CheckSKU_CKTM
{
    partial class FrmCheckSKU_CKTM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckSKU_CKTM));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.BTHienthi = new System.Windows.Forms.ToolStripButton();
            this.BTthoat = new System.Windows.Forms.ToolStripButton();
            this.btexportExcell = new System.Windows.Forms.ToolStripButton();
            this.BTXuatfile = new System.Windows.Forms.ToolStripButton();
            this.BTLoadDS = new System.Windows.Forms.ToolStripButton();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.CSKU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrDSPriceSKU = new DevExpress.XtraGrid.GridControl();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrDSPriceSKU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Controls.Add(this.toolStrip1);
            this.groupBox4.Location = new System.Drawing.Point(12, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(753, 69);
            this.groupBox4.TabIndex = 73;
            this.groupBox4.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F);
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(66, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kiểm Tra SKU Không chi CKTM";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SGC_Tool.Properties.Resources.CheckCKTM1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.BTHienthi});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(3, 17);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(747, 49);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(100, 46);
            this.toolStripButton1.Text = "Exit";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.ToolTipText = "Thoát chương trình";
            this.toolStripButton1.Click += new System.EventHandler(this.BTthoat_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.Image = global::SGC_Tool.Properties.Resources.fwExcel;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(100, 46);
            this.toolStripButton2.Text = "Export Excell file";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.ToolTipText = "Xuất danh sách ra file excell";
            this.toolStripButton2.Visible = false;
            this.toolStripButton2.Click += new System.EventHandler(this.btexportExcell_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(120, 46);
            this.toolStripButton3.Text = "Create, Active CKTM";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.ToolTipText = "Create, Active Price file";
            this.toolStripButton3.Click += new System.EventHandler(this.BTXuatfile_Click);
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
            this.BTHienthi.Click += new System.EventHandler(this.BTLoadDS_Click);
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
            // BTLoadDS
            // 
            this.BTLoadDS.AutoSize = false;
            this.BTLoadDS.Image = ((System.Drawing.Image)(resources.GetObject("BTLoadDS.Image")));
            this.BTLoadDS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTLoadDS.Name = "BTLoadDS";
            this.BTLoadDS.Size = new System.Drawing.Size(100, 46);
            this.BTLoadDS.Text = "Load data";
            this.BTLoadDS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTLoadDS.ToolTipText = "Load giá danh mục";
            this.BTLoadDS.Click += new System.EventHandler(this.BTLoadDS_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CCheck,
            this.CSKU,
            this.gridColumn2,
            this.gridColumn1});
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
            this.CCheck.ColumnEdit = this.repositoryItemCheckEdit2;
            this.CCheck.FieldName = "Check";
            this.CCheck.MaxWidth = 75;
            this.CCheck.Name = "CCheck";
            this.CCheck.Visible = true;
            this.CCheck.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.DisplayValueChecked = "1";
            this.repositoryItemCheckEdit2.DisplayValueUnchecked = "0";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
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
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "CKTM";
            this.gridColumn1.FieldName = "Disc_Flag";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // GrDSPriceSKU
            // 
            this.GrDSPriceSKU.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GrDSPriceSKU.Location = new System.Drawing.Point(12, 84);
            this.GrDSPriceSKU.MainView = this.gridView1;
            this.GrDSPriceSKU.Name = "GrDSPriceSKU";
            this.GrDSPriceSKU.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.GrDSPriceSKU.Size = new System.Drawing.Size(753, 388);
            this.GrDSPriceSKU.TabIndex = 69;
            this.GrDSPriceSKU.UseEmbeddedNavigator = true;
            this.GrDSPriceSKU.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // FrmCheckSKU_CKTM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 480);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.GrDSPriceSKU);
            this.Name = "FrmCheckSKU_CKTM";
            this.Text = "Form Check SKU CKTM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCheckSKU_CKTM_FormClosing);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrDSPriceSKU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton BTthoat;
        private System.Windows.Forms.ToolStripButton btexportExcell;
        private System.Windows.Forms.ToolStripButton BTXuatfile;
        private System.Windows.Forms.ToolStripButton BTLoadDS;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn CSKU;
        private DevExpress.XtraGrid.Columns.GridColumn CCheck;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl GrDSPriceSKU;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton BTHienthi;
    }
}