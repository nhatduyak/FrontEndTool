namespace SGC_Tool
{
    partial class FrmAddComment
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
            this.richTextEdit1 = new SGC_Tool.MyControls.RichTextEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // richTextEdit1
            // 
            this.richTextEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextEdit1.Location = new System.Drawing.Point(0, 0);
            this.richTextEdit1.Name = "richTextEdit1";
            this.richTextEdit1.Size = new System.Drawing.Size(693, 484);
            this.richTextEdit1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmAddComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 484);
            this.Controls.Add(this.richTextEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAddComment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAddComment";
            this.ResumeLayout(false);

        }

        #endregion

        public SGC_Tool.MyControls.RichTextEdit richTextEdit1;
        private System.Windows.Forms.Timer timer1;

    }
}