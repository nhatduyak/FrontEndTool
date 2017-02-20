namespace SGC_Tool
{
    partial class FrmManageDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManageDocument));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tvDocument = new System.Windows.Forms.TreeView();
            this.context = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.myImgList = new System.Windows.Forms.ImageList(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.LookAndFeel.SkinName = "Lilian";
            this.splitContainerControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(692, 473);
            this.splitContainerControl1.SplitterPosition = 194;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tvDocument);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(194, 473);
            this.panelControl1.TabIndex = 0;
            // 
            // tvDocument
            // 
            this.tvDocument.ContextMenuStrip = this.context;
            this.tvDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDocument.HideSelection = false;
            this.tvDocument.ImageIndex = 0;
            this.tvDocument.ImageList = this.myImgList;
            this.tvDocument.Indent = 27;
            this.tvDocument.ItemHeight = 18;
            this.tvDocument.LabelEdit = true;
            this.tvDocument.Location = new System.Drawing.Point(3, 3);
            this.tvDocument.Name = "tvDocument";
            this.tvDocument.SelectedImageIndex = 0;
            this.tvDocument.ShowLines = false;
            this.tvDocument.Size = new System.Drawing.Size(188, 467);
            this.tvDocument.TabIndex = 0;
            this.tvDocument.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvDocument_MouseClick);
            this.tvDocument.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvDocument_AfterLabelEdit);
            this.tvDocument.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDocument_NodeMouseClick);
            this.tvDocument.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvDocument_BeforeLabelEdit);
            this.tvDocument.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvDocument_KeyDown);
            // 
            // context
            // 
            this.context.AutoSize = false;
            this.context.Name = "context";
            this.context.Size = new System.Drawing.Size(153, 26);
            this.context.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.context_ItemClicked);
            // 
            // myImgList
            // 
            this.myImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("myImgList.ImageStream")));
            this.myImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.myImgList.Images.SetKeyName(0, "Book-Grey-icon_16.png");
            this.myImgList.Images.SetKeyName(1, "book-open-icon_16.png");
            this.myImgList.Images.SetKeyName(2, "Write-Document-icon.png");
            // 
            // panelControl2
            // 
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(490, 473);
            this.panelControl2.TabIndex = 0;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Caramel";
            // 
            // FrmManageDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 473);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmManageDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý document";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmManageDocument_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmManageDocument_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TreeView tvDocument;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.ImageList myImgList;
        private System.Windows.Forms.ContextMenuStrip context;
    }
}