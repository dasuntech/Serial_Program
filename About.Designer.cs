namespace Serial_Program
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblProgramName = new System.Windows.Forms.Label();
            this.lblBuildCount = new System.Windows.Forms.Label();
            this.lblBuildDate = new System.Windows.Forms.Label();
            this.lnkCompany = new System.Windows.Forms.LinkLabel();
            this.lblEmail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // lblProgramName
            // 
            this.lblProgramName.AutoSize = true;
            this.lblProgramName.Font = new System.Drawing.Font("±¼¸²", 12F, System.Drawing.FontStyle.Bold);
            this.lblProgramName.Location = new System.Drawing.Point(152, 22);
            this.lblProgramName.Name = "lblProgramName";
            this.lblProgramName.Size = new System.Drawing.Size(122, 20);
            this.lblProgramName.TabIndex = 1;
            this.lblProgramName.Text = "Program";
            // 
            // lblBuildCount
            // 
            this.lblBuildCount.AutoSize = true;
            this.lblBuildCount.Location = new System.Drawing.Point(152, 60);
            this.lblBuildCount.Name = "lblBuildCount";
            this.lblBuildCount.Size = new System.Drawing.Size(126, 18);
            this.lblBuildCount.TabIndex = 2;
            this.lblBuildCount.Text = "ºôµå È½¼ö: 0";
            // 
            // lblBuildDate
            // 
            this.lblBuildDate.AutoSize = true;
            this.lblBuildDate.Location = new System.Drawing.Point(152, 86);
            this.lblBuildDate.Name = "lblBuildDate";
            this.lblBuildDate.Size = new System.Drawing.Size(142, 18);
            this.lblBuildDate.TabIndex = 3;
            this.lblBuildDate.Text = "ºôµå ³¯Â¥: 2020-01-01";
            // 
            // lnkCompany
            // 
            this.lnkCompany.AutoSize = true;
            this.lnkCompany.Location = new System.Drawing.Point(152, 112);
            this.lnkCompany.Name = "lnkCompany";
            this.lnkCompany.Size = new System.Drawing.Size(62, 18);
            this.lnkCompany.TabIndex = 4;
            this.lnkCompany.TabStop = true;
            this.lnkCompany.Text = "È¸»ç¸í";
            this.lnkCompany.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCompany_LinkClicked);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(152, 138);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(172, 18);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "dasuntech.inc@gmail.com";
            // 
            // About
            // 
            this.ClientSize = new System.Drawing.Size(420, 160);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lnkCompany);
            this.Controls.Add(this.lblBuildDate);
            this.Controls.Add(this.lblBuildCount);
            this.Controls.Add(this.lblProgramName);
            this.Controls.Add(this.pictureBoxLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label lblProgramName;
        private System.Windows.Forms.Label lblBuildCount;
        private System.Windows.Forms.Label lblBuildDate;
        private System.Windows.Forms.LinkLabel lnkCompany;
        private System.Windows.Forms.Label lblEmail;
    }
}
