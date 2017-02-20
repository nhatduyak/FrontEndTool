namespace SGC_Tool.FrmBangbaoGia
{
    partial class FrmSearchBBGia
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSearchBBGia));
            this.GrDSSKU = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CSKU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUPC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cvendor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CTenHangHoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CGiaGoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grbtxoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtsku = new System.Windows.Forms.TextBox();
            this.txtupc = new System.Windows.Forms.TextBox();
            this.txttenhh = new System.Windows.Forms.TextBox();
            this.btnangcao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GrDSSKU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbtxoa)).BeginInit();
            this.SuspendLayout();
            // 
            // GrDSSKU
            // 
            this.GrDSSKU.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrDSSKU.Location = new System.Drawing.Point(0, 57);
            this.GrDSSKU.MainView = this.gridView1;
            this.GrDSSKU.Name = "GrDSSKU";
            this.GrDSSKU.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.grbtxoa});
            this.GrDSSKU.Size = new System.Drawing.Size(840, 345);
            this.GrDSSKU.TabIndex = 72;
            this.GrDSSKU.UseEmbeddedNavigator = true;
            this.GrDSSKU.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CSKU,
            this.CUPC,
            this.Cvendor,
            this.CTenHangHoa,
            this.CGiaGoc,
            this.CGhiChu,
            this.CXoa,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.GrDSSKU;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // CSKU
            // 
            this.CSKU.AppearanceCell.Options.UseTextOptions = true;
            this.CSKU.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CSKU.AppearanceHeader.Options.UseTextOptions = true;
            this.CSKU.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CSKU.Caption = "SKU";
            this.CSKU.FieldName = "SKU";
            this.CSKU.MaxWidth = 80;
            this.CSKU.MinWidth = 80;
            this.CSKU.Name = "CSKU";
            this.CSKU.OptionsColumn.AllowEdit = false;
            this.CSKU.OptionsColumn.ReadOnly = true;
            this.CSKU.Visible = true;
            this.CSKU.VisibleIndex = 0;
            this.CSKU.Width = 80;
            // 
            // CUPC
            // 
            this.CUPC.Caption = "UPC";
            this.CUPC.FieldName = "UPC";
            this.CUPC.MaxWidth = 120;
            this.CUPC.MinWidth = 120;
            this.CUPC.Name = "CUPC";
            this.CUPC.OptionsColumn.AllowEdit = false;
            this.CUPC.OptionsColumn.ReadOnly = true;
            this.CUPC.Visible = true;
            this.CUPC.VisibleIndex = 1;
            this.CUPC.Width = 120;
            // 
            // Cvendor
            // 
            this.Cvendor.Caption = "Vendor";
            this.Cvendor.FieldName = "VENDOR";
            this.Cvendor.MaxWidth = 80;
            this.Cvendor.MinWidth = 80;
            this.Cvendor.Name = "Cvendor";
            this.Cvendor.Width = 80;
            // 
            // CTenHangHoa
            // 
            this.CTenHangHoa.Caption = "Tên hàng hóa";
            this.CTenHangHoa.FieldName = "DESCRIPTION";
            this.CTenHangHoa.MinWidth = 10;
            this.CTenHangHoa.Name = "CTenHangHoa";
            this.CTenHangHoa.OptionsColumn.AllowEdit = false;
            this.CTenHangHoa.OptionsColumn.ReadOnly = true;
            this.CTenHangHoa.Visible = true;
            this.CTenHangHoa.VisibleIndex = 2;
            this.CTenHangHoa.Width = 170;
            // 
            // CGiaGoc
            // 
            this.CGiaGoc.AppearanceCell.Options.UseTextOptions = true;
            this.CGiaGoc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CGiaGoc.AppearanceHeader.Options.UseTextOptions = true;
            this.CGiaGoc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CGiaGoc.Caption = "Số lượng";
            this.CGiaGoc.DisplayFormat.FormatString = "N0";
            this.CGiaGoc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CGiaGoc.FieldName = "SoLuong";
            this.CGiaGoc.MaxWidth = 100;
            this.CGiaGoc.MinWidth = 100;
            this.CGiaGoc.Name = "CGiaGoc";
            this.CGiaGoc.Visible = true;
            this.CGiaGoc.VisibleIndex = 4;
            this.CGiaGoc.Width = 100;
            // 
            // CGhiChu
            // 
            this.CGhiChu.AppearanceCell.Options.UseTextOptions = true;
            this.CGhiChu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CGhiChu.AppearanceHeader.Options.UseTextOptions = true;
            this.CGhiChu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CGhiChu.Caption = "Ghi chú";
            this.CGhiChu.FieldName = "GhiChu";
            this.CGhiChu.MaxWidth = 200;
            this.CGhiChu.MinWidth = 200;
            this.CGhiChu.Name = "CGhiChu";
            this.CGhiChu.OptionsColumn.AllowEdit = false;
            this.CGhiChu.OptionsColumn.ReadOnly = true;
            this.CGhiChu.Width = 200;
            // 
            // CXoa
            // 
            this.CXoa.AppearanceHeader.Options.UseTextOptions = true;
            this.CXoa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CXoa.Caption = "Chọn";
            this.CXoa.ColumnEdit = this.grbtxoa;
            this.CXoa.MaxWidth = 80;
            this.CXoa.MinWidth = 80;
            this.CXoa.Name = "CXoa";
            this.CXoa.ToolTip = "Click vào để kiểm thêm mặt hàng vào đơn đặt hàng";
            this.CXoa.Visible = true;
            this.CXoa.VisibleIndex = 3;
            this.CXoa.Width = 80;
            // 
            // grbtxoa
            // 
            this.grbtxoa.AutoHeight = false;
            this.grbtxoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Chọn", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Click vào để kiểm tra giá của mặt hàng", null, null, true)});
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
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(840, 24);
            this.label5.TabIndex = 75;
            this.label5.Text = "Double click vào mặt hàng để xem thông tin khuyến mãi";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtsku
            // 
            this.txtsku.Location = new System.Drawing.Point(12, 30);
            this.txtsku.Name = "txtsku";
            this.txtsku.Size = new System.Drawing.Size(87, 21);
            this.txtsku.TabIndex = 76;
            this.txtsku.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsku_KeyDown);
            // 
            // txtupc
            // 
            this.txtupc.Location = new System.Drawing.Point(105, 30);
            this.txtupc.Name = "txtupc";
            this.txtupc.Size = new System.Drawing.Size(115, 21);
            this.txtupc.TabIndex = 77;
            this.txtupc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtupc_KeyDown);
            // 
            // txttenhh
            // 
            this.txttenhh.Location = new System.Drawing.Point(226, 30);
            this.txttenhh.Name = "txttenhh";
            this.txttenhh.Size = new System.Drawing.Size(390, 21);
            this.txttenhh.TabIndex = 78;
            this.txttenhh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttenhh_KeyDown);
            // 
            // btnangcao
            // 
            this.btnangcao.Location = new System.Drawing.Point(622, 29);
            this.btnangcao.Name = "btnangcao";
            this.btnangcao.Size = new System.Drawing.Size(58, 23);
            this.btnangcao.TabIndex = 79;
            this.btnangcao.Text = "Mở rộng";
            this.btnangcao.UseVisualStyleBackColor = true;
            this.btnangcao.Click += new System.EventHandler(this.btnangcao_Click);
            // 
            // FrmSearchBBGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 402);
            this.Controls.Add(this.btnangcao);
            this.Controls.Add(this.txttenhh);
            this.Controls.Add(this.txtupc);
            this.Controls.Add(this.txtsku);
            this.Controls.Add(this.GrDSSKU);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSearchBBGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm danh mục SKU";
            this.Load += new System.EventHandler(this.FrmSearchBBGia_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSearchBBGia_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GrDSSKU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbtxoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GrDSSKU;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn CSKU;
        private DevExpress.XtraGrid.Columns.GridColumn CUPC;
        private DevExpress.XtraGrid.Columns.GridColumn CTenHangHoa;
        private DevExpress.XtraGrid.Columns.GridColumn CGiaGoc;
        private DevExpress.XtraGrid.Columns.GridColumn CGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn CXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit grbtxoa;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.Columns.GridColumn Cvendor;
        private System.Windows.Forms.TextBox txtsku;
        private System.Windows.Forms.TextBox txtupc;
        private System.Windows.Forms.TextBox txttenhh;
        private System.Windows.Forms.Button btnangcao;
    }
}