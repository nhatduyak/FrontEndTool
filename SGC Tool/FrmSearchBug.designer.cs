namespace SGC_Tool
{
    partial class FrmSearchBug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSearchBug));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labThongTinlienQuang = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txttree = new DevExpress.XtraEditors.TextEdit();
            this.tvDocument = new System.Windows.Forms.TreeView();
            this.myImgList = new System.Windows.Forms.ImageList(this.components);
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btviewCm = new DevExpress.XtraEditors.SimpleButton();
            this.btAddCm = new DevExpress.XtraEditors.SimpleButton();
            this.btprint = new DevExpress.XtraEditors.SimpleButton();
            this.Webdetail = new DevExpress.XtraRichEdit.RichEditControl();
            this.flowAtt = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtserch = new System.Windows.Forms.TextBox();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txttree.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.labThongTinlienQuang);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(827, 127);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // labThongTinlienQuang
            // 
            this.labThongTinlienQuang.AutoSize = true;
            this.labThongTinlienQuang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labThongTinlienQuang.Location = new System.Drawing.Point(3, 0);
            this.labThongTinlienQuang.Name = "labThongTinlienQuang";
            this.labThongTinlienQuang.Size = new System.Drawing.Size(135, 13);
            this.labThongTinlienQuang.TabIndex = 0;
            this.labThongTinlienQuang.Text = "Các thông tin liên quan";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.flowLayoutPanel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 414);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(839, 136);
            this.panelControl1.TabIndex = 13;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.LookAndFeel.SkinName = "Lilian";
            this.splitContainerControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl3);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(839, 414);
            this.splitContainerControl1.SplitterPosition = 184;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.TabStop = true;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txttree);
            this.panelControl2.Controls.Add(this.tvDocument);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(184, 414);
            this.panelControl2.TabIndex = 0;
            // 
            // txttree
            // 
            this.txttree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txttree.Location = new System.Drawing.Point(7, 6);
            this.txttree.Name = "txttree";
            this.txttree.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txttree.Properties.Appearance.Options.UseFont = true;
            this.txttree.Size = new System.Drawing.Size(174, 23);
            this.txttree.TabIndex = 1;
            this.txttree.EditValueChanged += new System.EventHandler(this.txttree_EditValueChanged);
            this.txttree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttree_KeyDown);
            // 
            // tvDocument
            // 
            this.tvDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvDocument.HideSelection = false;
            this.tvDocument.ImageIndex = 0;
            this.tvDocument.ImageList = this.myImgList;
            this.tvDocument.Indent = 27;
            this.tvDocument.ItemHeight = 18;
            this.tvDocument.Location = new System.Drawing.Point(7, 28);
            this.tvDocument.Name = "tvDocument";
            this.tvDocument.SelectedImageIndex = 0;
            this.tvDocument.ShowLines = false;
            this.tvDocument.Size = new System.Drawing.Size(174, 379);
            this.tvDocument.TabIndex = 0;
            this.tvDocument.DoubleClick += new System.EventHandler(this.tvDocument_DoubleClick);
            // 
            // myImgList
            // 
            this.myImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("myImgList.ImageStream")));
            this.myImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.myImgList.Images.SetKeyName(0, "Book-Grey-icon_16.png");
            this.myImgList.Images.SetKeyName(1, "book-open-icon_16.png");
            this.myImgList.Images.SetKeyName(2, "Write-Document-icon.png");
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.simpleButton1);
            this.panelControl3.Controls.Add(this.btviewCm);
            this.panelControl3.Controls.Add(this.btAddCm);
            this.panelControl3.Controls.Add(this.btprint);
            this.panelControl3.Controls.Add(this.Webdetail);
            this.panelControl3.Controls.Add(this.flowAtt);
            this.panelControl3.Controls.Add(this.label1);
            this.panelControl3.Controls.Add(this.txtserch);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(647, 414);
            this.panelControl3.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.ImageIndex = 1;
            this.simpleButton1.ImageList = this.imageList1;
            this.simpleButton1.Location = new System.Drawing.Point(564, 9);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(78, 24);
            this.simpleButton1.TabIndex = 25;
            this.simpleButton1.Text = "Search";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "blank.png");
            this.imageList1.Images.SetKeyName(1, "fwPrintPreview.png");
            // 
            // btviewCm
            // 
            this.btviewCm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btviewCm.Enabled = false;
            this.btviewCm.Image = global::SGC_Tool.Properties.Resources.icon_view;
            this.btviewCm.Location = new System.Drawing.Point(157, 382);
            this.btviewCm.Name = "btviewCm";
            this.btviewCm.Size = new System.Drawing.Size(138, 24);
            this.btviewCm.TabIndex = 24;
            this.btviewCm.Text = "View Comment";
            this.btviewCm.Click += new System.EventHandler(this.btviewCm_Click);
            // 
            // btAddCm
            // 
            this.btAddCm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAddCm.Image = global::SGC_Tool.Properties.Resources.comment_add2;
            this.btAddCm.Location = new System.Drawing.Point(318, 382);
            this.btAddCm.Name = "btAddCm";
            this.btAddCm.Size = new System.Drawing.Size(138, 24);
            this.btAddCm.TabIndex = 23;
            this.btAddCm.Text = "Add new comment";
            this.btAddCm.Click += new System.EventHandler(this.btAddCm_Click);
            // 
            // btprint
            // 
            this.btprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btprint.ImageIndex = 0;
            this.btprint.ImageList = this.imageList1;
            this.btprint.Location = new System.Drawing.Point(479, 383);
            this.btprint.Name = "btprint";
            this.btprint.Size = new System.Drawing.Size(138, 24);
            this.btprint.TabIndex = 22;
            this.btprint.Text = "Print";
            this.btprint.Click += new System.EventHandler(this.btprint_Click);
            // 
            // Webdetail
            // 
            this.Webdetail.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.Webdetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Webdetail.Location = new System.Drawing.Point(5, 40);
            this.Webdetail.Name = "Webdetail";
            this.Webdetail.ReadOnly = true;
            this.Webdetail.Size = new System.Drawing.Size(637, 335);
            this.Webdetail.TabIndex = 21;
            // 
            // flowAtt
            // 
            this.flowAtt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowAtt.Location = new System.Drawing.Point(6, 39);
            this.flowAtt.Name = "flowAtt";
            this.flowAtt.Size = new System.Drawing.Size(634, 33);
            this.flowAtt.TabIndex = 20;
            this.flowAtt.Visible = false;
            this.flowAtt.VisibleChanged += new System.EventHandler(this.flowAtt_VisibleChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Search";
            // 
            // txtserch
            // 
            this.txtserch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtserch.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtserch.Location = new System.Drawing.Point(60, 11);
            this.txtserch.Name = "txtserch";
            this.txtserch.Size = new System.Drawing.Size(498, 23);
            this.txtserch.TabIndex = 1;
            this.txtserch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtserch_KeyDown);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "document.png");
            // 
            // FrmSearchBug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 550);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmSearchBug";
            this.Text = "FrmSearchBug";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSearchBug_FormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txttree.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labThongTinlienQuang;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.TreeView tvDocument;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtserch;
        private System.Windows.Forms.ImageList myImgList;
        private System.Windows.Forms.FlowLayoutPanel flowAtt;
        private DevExpress.XtraRichEdit.RichEditControl Webdetail;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.SimpleButton btprint;
        private DevExpress.XtraEditors.TextEdit txttree;
        private System.Windows.Forms.ImageList imageList2;
        private DevExpress.XtraEditors.SimpleButton btAddCm;
        private DevExpress.XtraEditors.SimpleButton btviewCm;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;

    }
}