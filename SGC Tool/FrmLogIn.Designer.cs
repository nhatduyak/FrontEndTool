﻿namespace SGC_Tool
{
    partial class FrmLogIn
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
            this.panelControl = new DevExpress.XtraEditors.PanelControl();
            this.groupLogIn = new DevExpress.XtraEditors.GroupControl();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.ckHienMatKhau = new DevExpress.XtraEditors.CheckEdit();
            this.btnLogIn = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblTenDangNhap = new DevExpress.XtraEditors.LabelControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).BeginInit();
            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupLogIn)).BeginInit();
            this.groupLogIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckHienMatKhau.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(186)))), ((int)(((byte)(79)))));
            this.panelControl.Appearance.Options.UseBackColor = true;
            this.panelControl.Controls.Add(this.groupLogIn);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(692, 473);
            this.panelControl.TabIndex = 0;
            // 
            // groupLogIn
            // 
            this.groupLogIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupLogIn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(62)))));
            this.groupLogIn.Appearance.ForeColor = System.Drawing.Color.White;
            this.groupLogIn.Appearance.Options.UseBackColor = true;
            this.groupLogIn.Appearance.Options.UseForeColor = true;
            this.groupLogIn.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.groupLogIn.Controls.Add(this.txtPassword);
            this.groupLogIn.Controls.Add(this.txtUserName);
            this.groupLogIn.Controls.Add(this.ckHienMatKhau);
            this.groupLogIn.Controls.Add(this.btnLogIn);
            this.groupLogIn.Controls.Add(this.labelControl1);
            this.groupLogIn.Controls.Add(this.lblTenDangNhap);
            this.groupLogIn.Location = new System.Drawing.Point(202, 134);
            this.groupLogIn.Name = "groupLogIn";
            this.groupLogIn.Size = new System.Drawing.Size(288, 141);
            this.groupLogIn.TabIndex = 1;
            this.groupLogIn.TabStop = true;
            this.groupLogIn.Text = "Thông tin đăng nhập";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(96, 57);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(180, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(96, 31);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(180, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // ckHienMatKhau
            // 
            this.ckHienMatKhau.Location = new System.Drawing.Point(94, 85);
            this.ckHienMatKhau.Name = "ckHienMatKhau";
            this.ckHienMatKhau.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.ckHienMatKhau.Properties.Appearance.Options.UseForeColor = true;
            this.ckHienMatKhau.Properties.Caption = "Hiển thị mật khẩu";
            this.ckHienMatKhau.Size = new System.Drawing.Size(118, 19);
            this.ckHienMatKhau.TabIndex = 19;
            this.ckHienMatKhau.CheckedChanged += new System.EventHandler(this.ckHienMatKhau_CheckedChanged);
            // 
            // btnLogIn
            // 
            this.btnLogIn.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnLogIn.Appearance.Options.UseForeColor = true;
            this.btnLogIn.Location = new System.Drawing.Point(96, 109);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(83, 23);
            this.btnLogIn.TabIndex = 3;
            this.btnLogIn.Text = "Đăng nhập";
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(19, 57);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 13);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "Mật khẩu";
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblTenDangNhap.Appearance.Options.UseForeColor = true;
            this.lblTenDangNhap.Location = new System.Drawing.Point(18, 31);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(72, 13);
            this.lblTenDangNhap.TabIndex = 16;
            this.lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // FrmLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(185)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(692, 473);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmLogIn";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLogIn_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).EndInit();
            this.panelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupLogIn)).EndInit();
            this.groupLogIn.ResumeLayout(false);
            this.groupLogIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckHienMatKhau.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl;
        private DevExpress.XtraEditors.GroupControl groupLogIn;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private DevExpress.XtraEditors.CheckEdit ckHienMatKhau;
        private DevExpress.XtraEditors.SimpleButton btnLogIn;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblTenDangNhap;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}