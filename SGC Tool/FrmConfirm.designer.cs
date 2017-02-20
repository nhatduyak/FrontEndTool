namespace SGC_Tool
{
    partial class FrmConfirm
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
            this.grp = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grp)).BeginInit();
            this.grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.Controls.Add(this.btnCancel);
            this.grp.Controls.Add(this.lblThongBao);
            this.grp.Controls.Add(this.btnOK);
            this.grp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp.Location = new System.Drawing.Point(0, 0);
            this.grp.LookAndFeel.SkinName = "Caramel";
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(346, 117);
            this.grp.TabIndex = 0;
            this.grp.Text = "Thông báo";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(214, 82);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblThongBao
            // 
            this.lblThongBao.AllowDrop = true;
            this.lblThongBao.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.Location = new System.Drawing.Point(5, 25);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(336, 49);
            this.lblThongBao.TabIndex = 2;
            this.lblThongBao.Text = "Thông báo";
            this.lblThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(51, 82);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 117);
            this.Controls.Add(this.grp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConfirm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConfirm";
            ((System.ComponentModel.ISupportInitialize)(this.grp)).EndInit();
            this.grp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grp;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.Label lblThongBao;
        private DevExpress.XtraEditors.SimpleButton btnCancel;

    }
}