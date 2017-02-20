namespace TOOLChuyenDuLieu.MyForm.FrmmainCheckPrice
{
    partial class Frmkiot
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.labthongbao = new System.Windows.Forms.Label();
            this.GrDSPriceSKU = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CSKU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labWMa = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labWmuano = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.labWLoaiKH = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.labWSogia = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.labWngaychinhsua = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.labWngaytao = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radKHTT = new System.Windows.Forms.RadioButton();
            this.radWDSS = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrDSPriceSKU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 600;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox1.Location = new System.Drawing.Point(139, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 23);
            this.label2.TabIndex = 38;
            this.label2.Text = "Mã khách hàng :";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 70);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl1.Size = new System.Drawing.Size(708, 505);
            this.xtraTabControl1.TabIndex = 39;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2});
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.labthongbao);
            this.xtraTabPage2.Controls.Add(this.GrDSPriceSKU);
            this.xtraTabPage2.Controls.Add(this.linkLabel1);
            this.xtraTabPage2.Controls.Add(this.labWMa);
            this.xtraTabPage2.Controls.Add(this.label20);
            this.xtraTabPage2.Controls.Add(this.label16);
            this.xtraTabPage2.Controls.Add(this.label7);
            this.xtraTabPage2.Controls.Add(this.labWmuano);
            this.xtraTabPage2.Controls.Add(this.label23);
            this.xtraTabPage2.Controls.Add(this.labWLoaiKH);
            this.xtraTabPage2.Controls.Add(this.label21);
            this.xtraTabPage2.Controls.Add(this.labWSogia);
            this.xtraTabPage2.Controls.Add(this.label19);
            this.xtraTabPage2.Controls.Add(this.labWngaychinhsua);
            this.xtraTabPage2.Controls.Add(this.label17);
            this.xtraTabPage2.Controls.Add(this.labWngaytao);
            this.xtraTabPage2.Controls.Add(this.label15);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(701, 476);
            this.xtraTabPage2.Text = "Kiểm tra thông tin trên WinDSS";
            // 
            // labthongbao
            // 
            this.labthongbao.BackColor = System.Drawing.Color.Transparent;
            this.labthongbao.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.labthongbao.ForeColor = System.Drawing.Color.Crimson;
            this.labthongbao.Location = new System.Drawing.Point(360, 21);
            this.labthongbao.Name = "labthongbao";
            this.labthongbao.Size = new System.Drawing.Size(327, 23);
            this.labthongbao.TabIndex = 59;
            this.labthongbao.Text = "Vui lòng kiểm tra mã KH khác";
            this.labthongbao.Visible = false;
            // 
            // GrDSPriceSKU
            // 
            this.GrDSPriceSKU.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GrDSPriceSKU.Location = new System.Drawing.Point(9, 237);
            this.GrDSPriceSKU.MainView = this.gridView1;
            this.GrDSPriceSKU.Name = "GrDSPriceSKU";
            this.GrDSPriceSKU.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.GrDSPriceSKU.Size = new System.Drawing.Size(688, 232);
            this.GrDSPriceSKU.TabIndex = 58;
            this.GrDSPriceSKU.UseEmbeddedNavigator = true;
            this.GrDSPriceSKU.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Blue;
            this.gridView1.Appearance.Row.Options.UseForeColor = true;
            this.gridView1.Appearance.SelectedRow.BorderColor = System.Drawing.Color.Blue;
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Blue;
            this.gridView1.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CCheck,
            this.CSKU,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn3});
            this.gridView1.GridControl = this.GrDSPriceSKU;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
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
            this.CSKU.Caption = "Cust ID";
            this.CSKU.FieldName = "CUSTID";
            this.CSKU.Name = "CSKU";
            this.CSKU.OptionsColumn.ReadOnly = true;
            this.CSKU.Visible = true;
            this.CSKU.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Price Book";
            this.gridColumn2.FieldName = "PRICEBOOK";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "DATE UP";
            this.gridColumn1.FieldName = "DATE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Price Book POS";
            this.gridColumn3.FieldName = "Pricecategory";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.linkLabel1.LinkColor = System.Drawing.Color.RoyalBlue;
            this.linkLabel1.Location = new System.Drawing.Point(38, 217);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(581, 17);
            this.linkLabel1.TabIndex = 57;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Import Excell (file excell phải có colum CUSTID, PRICEBOOK,DATE và phải nằm trong" +
                " Sheek1)";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labWMa
            // 
            this.labWMa.BackColor = System.Drawing.Color.Transparent;
            this.labWMa.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labWMa.ForeColor = System.Drawing.Color.Blue;
            this.labWMa.Location = new System.Drawing.Point(206, 44);
            this.labWMa.Name = "labWMa";
            this.labWMa.Size = new System.Drawing.Size(305, 23);
            this.labWMa.TabIndex = 53;
            this.labWMa.Text = "_ _ _";
            this.labWMa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(62, 44);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 23);
            this.label20.TabIndex = 52;
            this.label20.Text = "Mã KH:";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label16.Location = new System.Drawing.Point(38, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(327, 23);
            this.label16.TabIndex = 51;
            this.label16.Text = "Thông tin khách hàng trên chương trình WinDSS";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.OliveDrab;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Location = new System.Drawing.Point(38, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(575, 3);
            this.label7.TabIndex = 50;
            this.label7.Text = "___________________________________";
            // 
            // labWmuano
            // 
            this.labWmuano.BackColor = System.Drawing.Color.Transparent;
            this.labWmuano.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labWmuano.ForeColor = System.Drawing.Color.Blue;
            this.labWmuano.Location = new System.Drawing.Point(206, 144);
            this.labWmuano.Name = "labWmuano";
            this.labWmuano.Size = new System.Drawing.Size(305, 23);
            this.labWmuano.TabIndex = 49;
            this.labWmuano.Text = "_ _ _";
            this.labWmuano.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(62, 148);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(100, 23);
            this.label23.TabIndex = 48;
            this.label23.Text = "Được mua nợ ?:";
            // 
            // labWLoaiKH
            // 
            this.labWLoaiKH.BackColor = System.Drawing.Color.Transparent;
            this.labWLoaiKH.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labWLoaiKH.ForeColor = System.Drawing.Color.Blue;
            this.labWLoaiKH.Location = new System.Drawing.Point(206, 119);
            this.labWLoaiKH.Name = "labWLoaiKH";
            this.labWLoaiKH.Size = new System.Drawing.Size(305, 23);
            this.labWLoaiKH.TabIndex = 47;
            this.labWLoaiKH.Text = "_ _ _";
            this.labWLoaiKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label21.Location = new System.Drawing.Point(62, 122);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 23);
            this.label21.TabIndex = 46;
            this.label21.Text = "Loại KH:";
            // 
            // labWSogia
            // 
            this.labWSogia.BackColor = System.Drawing.Color.Transparent;
            this.labWSogia.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labWSogia.ForeColor = System.Drawing.Color.Blue;
            this.labWSogia.Location = new System.Drawing.Point(206, 94);
            this.labWSogia.Name = "labWSogia";
            this.labWSogia.Size = new System.Drawing.Size(305, 23);
            this.labWSogia.TabIndex = 45;
            this.labWSogia.Text = "_ _ _";
            this.labWSogia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label19.Location = new System.Drawing.Point(62, 96);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 23);
            this.label19.TabIndex = 44;
            this.label19.Text = "Sổ giá:";
            // 
            // labWngaychinhsua
            // 
            this.labWngaychinhsua.BackColor = System.Drawing.Color.Transparent;
            this.labWngaychinhsua.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labWngaychinhsua.ForeColor = System.Drawing.Color.Blue;
            this.labWngaychinhsua.Location = new System.Drawing.Point(206, 169);
            this.labWngaychinhsua.Name = "labWngaychinhsua";
            this.labWngaychinhsua.Size = new System.Drawing.Size(305, 23);
            this.labWngaychinhsua.TabIndex = 43;
            this.labWngaychinhsua.Text = "_ _ _";
            this.labWngaychinhsua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(62, 174);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 23);
            this.label17.TabIndex = 42;
            this.label17.Text = "Trạng thái mã :";
            // 
            // labWngaytao
            // 
            this.labWngaytao.BackColor = System.Drawing.Color.Transparent;
            this.labWngaytao.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labWngaytao.ForeColor = System.Drawing.Color.Blue;
            this.labWngaytao.Location = new System.Drawing.Point(206, 69);
            this.labWngaytao.Name = "labWngaytao";
            this.labWngaytao.Size = new System.Drawing.Size(305, 23);
            this.labWngaytao.TabIndex = 41;
            this.labWngaytao.Text = "_ _ _";
            this.labWngaytao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(62, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 23);
            this.label15.TabIndex = 40;
            this.label15.Text = "Ngày tạo:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.label6.Location = new System.Drawing.Point(12, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 23);
            this.label6.TabIndex = 40;
            this.label6.Text = "(Mã KH 10-13 ký tự)";
            // 
            // radKHTT
            // 
            this.radKHTT.Location = new System.Drawing.Point(350, 22);
            this.radKHTT.Name = "radKHTT";
            this.radKHTT.Size = new System.Drawing.Size(169, 41);
            this.radKHTT.TabIndex = 41;
            this.radKHTT.Text = "Kiểm tra thông tin tham gia KHTT-TV (Điểm,Cấp độ....)";
            this.radKHTT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radKHTT.UseVisualStyleBackColor = true;
            this.radKHTT.Visible = false;
            this.radKHTT.CheckedChanged += new System.EventHandler(this.radKHTT_CheckedChanged);
            // 
            // radWDSS
            // 
            this.radWDSS.Checked = true;
            this.radWDSS.Location = new System.Drawing.Point(525, 25);
            this.radWDSS.Name = "radWDSS";
            this.radWDSS.Size = new System.Drawing.Size(178, 41);
            this.radWDSS.TabIndex = 42;
            this.radWDSS.TabStop = true;
            this.radWDSS.Text = "Kiểm tra thông tin trên chương trình WinDSS (Sổ giá.....)";
            this.radWDSS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radWDSS.UseVisualStyleBackColor = true;
            this.radWDSS.Visible = false;
            this.radWDSS.CheckedChanged += new System.EventHandler(this.radWDSS_CheckedChanged);
            // 
            // Frmkiot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 575);
            this.Controls.Add(this.radWDSS);
            this.Controls.Add(this.radKHTT);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frmkiot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frmkiot";
            this.Load += new System.EventHandler(this.Frmkiot_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frmkiot_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrDSPriceSKU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radKHTT;
        private System.Windows.Forms.RadioButton radWDSS;
        private System.Windows.Forms.Label labWmuano;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label labWLoaiKH;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label labWSogia;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label labWngaychinhsua;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label labWngaytao;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labWMa;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private DevExpress.XtraGrid.GridControl GrDSPriceSKU;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn CCheck;
        private DevExpress.XtraGrid.Columns.GridColumn CSKU;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.Label labthongbao;
    }
}