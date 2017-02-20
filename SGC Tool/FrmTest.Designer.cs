namespace SGC_Tool
{
    partial class FrmTest
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
            this.button1 = new System.Windows.Forms.Button();
            this.GridDSMa = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CMaLoaiBo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CheckMa = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.CSKU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUPC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CCurencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridDSMa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckMa)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GridDSMa
            // 
            this.GridDSMa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GridDSMa.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.GridDSMa.Location = new System.Drawing.Point(3, 12);
            this.GridDSMa.MainView = this.gridView1;
            this.GridDSMa.Name = "GridDSMa";
            this.GridDSMa.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.CheckMa});
            this.GridDSMa.Size = new System.Drawing.Size(693, 277);
            this.GridDSMa.TabIndex = 3;
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
            this.CPrice,
            this.CCurencyCode,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.GridDSMa;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
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
            this.CUPC.Caption = "Code";
            this.CUPC.FieldName = "CODE";
            this.CUPC.Name = "CUPC";
            this.CUPC.OptionsColumn.AllowEdit = false;
            this.CUPC.Visible = true;
            this.CUPC.VisibleIndex = 2;
            this.CUPC.Width = 221;
            // 
            // CPrice
            // 
            this.CPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.CPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CPrice.Caption = "Price";
            this.CPrice.DisplayFormat.FormatString = "N2";
            this.CPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CPrice.FieldName = "PRICE";
            this.CPrice.MaxWidth = 120;
            this.CPrice.Name = "CPrice";
            this.CPrice.OptionsColumn.AllowEdit = false;
            this.CPrice.Visible = true;
            this.CPrice.VisibleIndex = 3;
            this.CPrice.Width = 108;
            // 
            // CCurencyCode
            // 
            this.CCurencyCode.AppearanceCell.Options.UseTextOptions = true;
            this.CCurencyCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CCurencyCode.AppearanceHeader.Options.UseTextOptions = true;
            this.CCurencyCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CCurencyCode.Caption = "DisPrice";
            this.CCurencyCode.DisplayFormat.FormatString = "N0";
            this.CCurencyCode.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CCurencyCode.FieldName = "DISCPRICE";
            this.CCurencyCode.MaxWidth = 120;
            this.CCurencyCode.MinWidth = 60;
            this.CCurencyCode.Name = "CCurencyCode";
            this.CCurencyCode.Visible = true;
            this.CCurencyCode.VisibleIndex = 4;
            this.CCurencyCode.Width = 120;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Method";
            this.gridColumn1.FieldName = "METHOD";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Start";
            this.gridColumn2.FieldName = "START";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 6;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Stop";
            this.gridColumn3.FieldName = "STOP";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(418, 318);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 50);
            this.button2.TabIndex = 4;
            this.button2.Text = "Export";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 380);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.GridDSMa);
            this.Controls.Add(this.button1);
            this.Name = "FrmTest";
            this.Text = "FrmTest";
            ((System.ComponentModel.ISupportInitialize)(this.GridDSMa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckMa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.GridControl GridDSMa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn CMaLoaiBo;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit CheckMa;
        private DevExpress.XtraGrid.Columns.GridColumn CSKU;
        private DevExpress.XtraGrid.Columns.GridColumn CUPC;
        private DevExpress.XtraGrid.Columns.GridColumn CPrice;
        private DevExpress.XtraGrid.Columns.GridColumn CCurencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.Button button2;
    }
}