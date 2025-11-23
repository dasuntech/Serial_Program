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
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblBuildCount = new System.Windows.Forms.Label();
            this.lblBuildDate = new System.Windows.Forms.Label();
            this.lnkCompany = new System.Windows.Forms.LinkLabel();
            this.lblEmail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(39, 27);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(186, 174);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // lblProgramName
            // 
            this.lblProgramName.AutoSize = true;
            this.lblProgramName.Font = new System.Drawing.Font("±¼¸²", 12F, System.Drawing.FontStyle.Bold);
            this.lblProgramName.Location = new System.Drawing.Point(271, 27);
            this.lblProgramName.Name = "lblProgramName";
            this.lblProgramName.Size = new System.Drawing.Size(102, 24);
            this.lblProgramName.TabIndex = 1;
            this.lblProgramName.Text = "Program";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(271, 63);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(98, 18);
            this.lblVersion.TabIndex = 6;
            this.lblVersion.Text = "¹öÀü: 1.0.0";
            // 
            // lblBuildCount
            // 
            this.lblBuildCount.AutoSize = true;
            this.lblBuildCount.Location = new System.Drawing.Point(272, 93);
            this.lblBuildCount.Name = "lblBuildCount";
            this.lblBuildCount.Size = new System.Drawing.Size(108, 18);
            this.lblBuildCount.TabIndex = 2;
            this.lblBuildCount.Text = "ºôµå È½¼ö: 0";
            // 
            // lblBuildDate
            // 
            this.lblBuildDate.AutoSize = true;
            this.lblBuildDate.Location = new System.Drawing.Point(271, 123);
            this.lblBuildDate.Name = "lblBuildDate";
            this.lblBuildDate.Size = new System.Drawing.Size(196, 18);
            this.lblBuildDate.TabIndex = 3;
            this.lblBuildDate.Text = "ºôµå ³¯Â¥: 2020-01-01";
            // 
            // lnkCompany
            // 
            this.lnkCompany.AutoSize = true;
            this.lnkCompany.Location = new System.Drawing.Point(272, 153);
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
            this.lblEmail.Location = new System.Drawing.Point(271, 183);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(223, 18);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "dasuntech.inc@gmail.com";
            // 
            // About
            // 
            this.ClientSize = new System.Drawing.Size(520, 252);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lnkCompany);
            this.Controls.Add(this.lblBuildDate);
            this.Controls.Add(this.lblBuildCount);
            this.Controls.Add(this.lblProgramName);
            this.Controls.Add(this.lblVersion);
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
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblBuildCount;
        private System.Windows.Forms.Label lblBuildDate;
        private System.Windows.Forms.LinkLabel lnkCompany;
        private System.Windows.Forms.Label lblEmail;
    }
}
