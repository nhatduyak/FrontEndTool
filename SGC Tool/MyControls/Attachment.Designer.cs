namespace SGC_Tool.MyControls
{
    partial class Attachment
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAtt = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtAtt
            // 
            this.txtAtt.AcceptsTab = true;
            this.txtAtt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAtt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAtt.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAtt.ForeColor = System.Drawing.Color.Blue;
            this.txtAtt.Location = new System.Drawing.Point(1, 1);
            this.txtAtt.Multiline = false;
            this.txtAtt.Name = "txtAtt";
            this.txtAtt.Size = new System.Drawing.Size(438, 20);
            this.txtAtt.TabIndex = 8;
            this.txtAtt.Text = "";
            this.txtAtt.WordWrap = false;
            // 
            // Attachment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.txtAtt);
            this.Name = "Attachment";
            this.Size = new System.Drawing.Size(440, 22);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox txtAtt;

    }
}
