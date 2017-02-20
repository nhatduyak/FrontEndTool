namespace SGC_Tool.FrmDonDatHang
{
    partial class FrmCTDonDatHang
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labHoTen = new DevExpress.XtraEditors.LabelControl();
            this.labDienThoai = new DevExpress.XtraEditors.LabelControl();
            this.labngayTao = new DevExpress.XtraEditors.LabelControl();
            this.labDiaChi = new DevExpress.XtraEditors.LabelControl();
            this.label5 = new System.Windows.Forms.Label();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labtongthanhtien = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labtongsoluong = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labreco = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.GrDSSKU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbtxoa)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(9, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Họ tên KH: ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(9, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(82, 19);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Điện thoại:  ";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(233, 33);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(74, 19);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Ngày tạo:  ";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(9, 54);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(64, 19);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Địa chỉ:   ";
            // 
            // labHoTen
            // 
            this.labHoTen.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labHoTen.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.labHoTen.Appearance.Options.UseFont = true;
            this.labHoTen.Appearance.Options.UseForeColor = true;
            this.labHoTen.Location = new System.Drawing.Point(97, 9);
            this.labHoTen.Name = "labHoTen";
            this.labHoTen.Size = new System.Drawing.Size(15, 19);
            this.labHoTen.TabIndex = 4;
            this.labHoTen.Text = "---";
            // 
            // labDienThoai
            // 
            this.labDienThoai.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labDienThoai.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.labDienThoai.Appearance.Options.UseFont = true;
            this.labDienThoai.Appearance.Options.UseForeColor = true;
            this.labDienThoai.Location = new System.Drawing.Point(97, 29);
            this.labDienThoai.Name = "labDienThoai";
            this.labDienThoai.Size = new System.Drawing.Size(15, 19);
            this.labDienThoai.TabIndex = 5;
            this.labDienThoai.Text = "---";
            // 
            // labngayTao
            // 
            this.labngayTao.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labngayTao.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.labngayTao.Appearance.Options.UseFont = true;
            this.labngayTao.Appearance.Options.UseForeColor = true;
            this.labngayTao.Location = new System.Drawing.Point(313, 36);
            this.labngayTao.Name = "labngayTao";
            this.labngayTao.Size = new System.Drawing.Size(15, 19);
            this.labngayTao.TabIndex = 6;
            this.labngayTao.Text = "---";
            // 
            // labDiaChi
            // 
            this.labDiaChi.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labDiaChi.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.labDiaChi.Appearance.Options.UseFont = true;
            this.labDiaChi.Appearance.Options.UseForeColor = true;
            this.labDiaChi.Location = new System.Drawing.Point(97, 51);
            this.labDiaChi.Name = "labDiaChi";
            this.labDiaChi.Size = new System.Drawing.Size(15, 19);
            this.labDiaChi.TabIndex = 7;
            this.labDiaChi.Text = "---";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(6, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(771, 24);
            this.label5.TabIndex = 78;
            this.label5.Text = "Danh Sách Sản phẩm";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GrDSSKU
            // 
            this.GrDSSKU.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GrDSSKU.Location = new System.Drawing.Point(9, 113);
            this.GrDSSKU.MainView = this.gridView1;
            this.GrDSSKU.Name = "GrDSSKU";
            this.GrDSSKU.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.grbtxoa});
            this.GrDSSKU.Size = new System.Drawing.Size(768, 179);
            this.GrDSSKU.TabIndex = 79;
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
            this.CTenHangHoa.FieldName = "TenSP";
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
            this.CXoa.Width = 60;
            // 
            // grbtxoa
            // 
            this.grbtxoa.AutoHeight = false;
            this.grbtxoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Xóa", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.grbtxoa.Name = "grbtxoa";
            this.grbtxoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.panel1.Controls.Add(this.labtongthanhtien);
            this.panel1.Controls.Add(this.labelControl10);
            this.panel1.Controls.Add(this.labtongsoluong);
            this.panel1.Controls.Add(this.labelControl8);
            this.panel1.Controls.Add(this.labreco);
            this.panel1.Controls.Add(this.labelControl6);
            this.panel1.Location = new System.Drawing.Point(9, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 59);
            this.panel1.TabIndex = 80;
            // 
            // labtongthanhtien
            // 
            this.labtongthanhtien.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labtongthanhtien.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.labtongthanhtien.Appearance.Options.UseFont = true;
            this.labtongthanhtien.Appearance.Options.UseForeColor = true;
            this.labtongthanhtien.Location = new System.Drawing.Point(645, 27);
            this.labtongthanhtien.Name = "labtongthanhtien";
            this.labtongthanhtien.Size = new System.Drawing.Size(18, 22);
            this.labtongthanhtien.TabIndex = 10;
            this.labtongthanhtien.Text = "---";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl10.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Appearance.Options.UseForeColor = true;
            this.labelControl10.Location = new System.Drawing.Point(508, 27);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(139, 22);
            this.labelControl10.TabIndex = 9;
            this.labelControl10.Text = "Tổng thành tiền: ";
            // 
            // labtongsoluong
            // 
            this.labtongsoluong.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labtongsoluong.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.labtongsoluong.Appearance.Options.UseFont = true;
            this.labtongsoluong.Appearance.Options.UseForeColor = true;
            this.labtongsoluong.Location = new System.Drawing.Point(645, 4);
            this.labtongsoluong.Name = "labtongsoluong";
            this.labtongsoluong.Size = new System.Drawing.Size(18, 22);
            this.labtongsoluong.TabIndex = 8;
            this.labtongsoluong.Text = "---";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseForeColor = true;
            this.labelControl8.Location = new System.Drawing.Point(508, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(128, 22);
            this.labelControl8.TabIndex = 7;
            this.labelControl8.Text = "Tổng số lượng: ";
            // 
            // labreco
            // 
            this.labreco.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labreco.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.labreco.Appearance.Options.UseFont = true;
            this.labreco.Appearance.Options.UseForeColor = true;
            this.labreco.Location = new System.Drawing.Point(175, 3);
            this.labreco.Name = "labreco";
            this.labreco.Size = new System.Drawing.Size(18, 22);
            this.labreco.TabIndex = 6;
            this.labreco.Text = "---";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(166, 22);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Số lượng sản phẩm: ";
            // 
            // FrmCTDonDatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 359);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GrDSSKU);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labDiaChi);
            this.Controls.Add(this.labngayTao);
            this.Controls.Add(this.labDienThoai);
            this.Controls.Add(this.labHoTen);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCTDonDatHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi Tiet Don Dat Hang";
            ((System.ComponentModel.ISupportInitialize)(this.GrDSSKU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbtxoa)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labHoTen;
        private DevExpress.XtraEditors.LabelControl labDienThoai;
        private DevExpress.XtraEditors.LabelControl labngayTao;
        private DevExpress.XtraEditors.LabelControl labDiaChi;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.GridControl GrDSSKU;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn CSKU;
        private DevExpress.XtraGrid.Columns.GridColumn CUPC;
        private DevExpress.XtraGrid.Columns.GridColumn CTenHangHoa;
        private DevExpress.XtraGrid.Columns.GridColumn CSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn CGiaGoc;
        private DevExpress.XtraGrid.Columns.GridColumn CGIAKM;
        private DevExpress.XtraGrid.Columns.GridColumn CThanhTien;
        private DevExpress.XtraGrid.Columns.GridColumn CGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn CXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit grbtxoa;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labtongthanhtien;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labtongsoluong;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labreco;
        private DevExpress.XtraEditors.LabelControl labelControl6;

    }
}