namespace Serial_Program
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnRefreshPorts = new System.Windows.Forms.Button();
            this.lblHandshake = new System.Windows.Forms.Label();
            this.cmbHandshake = new System.Windows.Forms.ComboBox();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.lblParity = new System.Windows.Forms.Label();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.lblBaud = new System.Windows.Forms.Label();
            this.cmbBaud = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnRxColor = new System.Windows.Forms.Button();
            this.btnTxColor = new System.Windows.Forms.Button();
            this.pnlRxColor = new System.Windows.Forms.Panel();
            this.pnlTxColor = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.grpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSettings
            // 
            this.grpSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSettings.Controls.Add(this.btnClose);
            this.grpSettings.Controls.Add(this.btnOpen);
            this.grpSettings.Controls.Add(this.btnRefreshPorts);
            this.grpSettings.Controls.Add(this.lblHandshake);
            this.grpSettings.Controls.Add(this.cmbHandshake);
            this.grpSettings.Controls.Add(this.lblStopBits);
            this.grpSettings.Controls.Add(this.cmbStopBits);
            this.grpSettings.Controls.Add(this.lblParity);
            this.grpSettings.Controls.Add(this.cmbParity);
            this.grpSettings.Controls.Add(this.lblDataBits);
            this.grpSettings.Controls.Add(this.cmbDataBits);
            this.grpSettings.Controls.Add(this.lblBaud);
            this.grpSettings.Controls.Add(this.cmbBaud);
            this.grpSettings.Controls.Add(this.lblPort);
            this.grpSettings.Controls.Add(this.cmbPort);
            this.grpSettings.Location = new System.Drawing.Point(12, 12);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(860, 110);
            this.grpSettings.TabIndex = 0;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "시리얼 설정";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClose.Location = new System.Drawing.Point(767, 69);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOpen.Location = new System.Drawing.Point(767, 28);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 26);
            this.btnOpen.TabIndex = 13;
            this.btnOpen.Text = "열기";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnRefreshPorts
            // 
            this.btnRefreshPorts.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshPorts.Location = new System.Drawing.Point(210, 28);
            this.btnRefreshPorts.Name = "btnRefreshPorts";
            this.btnRefreshPorts.Size = new System.Drawing.Size(60, 26);
            this.btnRefreshPorts.TabIndex = 2;
            this.btnRefreshPorts.Text = "재확인";
            this.btnRefreshPorts.UseVisualStyleBackColor = true;
            this.btnRefreshPorts.Click += new System.EventHandler(this.btnRefreshPorts_Click);
            // 
            // lblHandshake
            // 
            this.lblHandshake.AutoSize = true;
            this.lblHandshake.Location = new System.Drawing.Point(472, 74);
            this.lblHandshake.Name = "lblHandshake";
            this.lblHandshake.Size = new System.Drawing.Size(97, 15);
            this.lblHandshake.TabIndex = 12;
            this.lblHandshake.Text = "플로우컨트롤";
            // 
            // cmbHandshake
            // 
            this.cmbHandshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHandshake.FormattingEnabled = true;
            this.cmbHandshake.Location = new System.Drawing.Point(559, 70);
            this.cmbHandshake.Name = "cmbHandshake";
            this.cmbHandshake.Size = new System.Drawing.Size(180, 23);
            this.cmbHandshake.TabIndex = 11;
            // 
            // lblStopBits
            // 
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Location = new System.Drawing.Point(245, 74);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(67, 15);
            this.lblStopBits.TabIndex = 10;
            this.lblStopBits.Text = "스톱비트";
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Location = new System.Drawing.Point(304, 70);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(150, 23);
            this.cmbStopBits.TabIndex = 9;
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Location = new System.Drawing.Point(16, 74);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(52, 15);
            this.lblParity.TabIndex = 8;
            this.lblParity.Text = "패리티";
            // 
            // cmbParity
            // 
            this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Location = new System.Drawing.Point(67, 70);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(160, 23);
            this.cmbParity.TabIndex = 7;
            // 
            // lblDataBits
            // 
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Location = new System.Drawing.Point(472, 33);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(87, 15);
            this.lblDataBits.TabIndex = 6;
            this.lblDataBits.Text = "데이터 비트";
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Location = new System.Drawing.Point(565, 29);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(117, 23);
            this.cmbDataBits.TabIndex = 5;
            // 
            // lblBaud
            // 
            this.lblBaud.AutoSize = true;
            this.lblBaud.Location = new System.Drawing.Point(245, 33);
            this.lblBaud.Name = "lblBaud";
            this.lblBaud.Size = new System.Drawing.Size(108, 15);
            this.lblBaud.TabIndex = 4;
            this.lblBaud.Text = "통신 속도(bps)";
            // 
            // cmbBaud
            // 
            this.cmbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaud.FormattingEnabled = true;
            this.cmbBaud.Location = new System.Drawing.Point(329, 29);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(130, 23);
            this.cmbBaud.TabIndex = 3;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(16, 33);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(37, 15);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "포트";
            // 
            // cmbPort
            // 
            this.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(51, 29);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(150, 23);
            this.cmbPort.TabIndex = 0;
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.Location = new System.Drawing.Point(12, 128);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(860, 370);
            this.rtbLog.TabIndex = 1;
            this.rtbLog.Text = "";
            // 
            // txtSend
            // 
            this.txtSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSend.Location = new System.Drawing.Point(12, 510);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(668, 25);
            this.txtSend.TabIndex = 2;
            this.txtSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSend_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSend.Location = new System.Drawing.Point(686, 508);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(70, 25);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "전송";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnRxColor
            // 
            this.btnRxColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRxColor.Location = new System.Drawing.Point(762, 508);
            this.btnRxColor.Name = "btnRxColor";
            this.btnRxColor.Size = new System.Drawing.Size(50, 25);
            this.btnRxColor.TabIndex = 4;
            this.btnRxColor.Text = "수신색";
            this.btnRxColor.UseVisualStyleBackColor = true;
            this.btnRxColor.Click += new System.EventHandler(this.btnRxColor_Click);
            // 
            // btnTxColor
            // 
            this.btnTxColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTxColor.Location = new System.Drawing.Point(822, 508);
            this.btnTxColor.Name = "btnTxColor";
            this.btnTxColor.Size = new System.Drawing.Size(50, 25);
            this.btnTxColor.TabIndex = 5;
            this.btnTxColor.Text = "송신색";
            this.btnTxColor.UseVisualStyleBackColor = true;
            this.btnTxColor.Click += new System.EventHandler(this.btnTxColor_Click);
            // 
            // pnlRxColor
            // 
            this.pnlRxColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRxColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRxColor.Location = new System.Drawing.Point(762, 538);
            this.pnlRxColor.Name = "pnlRxColor";
            this.pnlRxColor.Size = new System.Drawing.Size(50, 10);
            this.pnlRxColor.TabIndex = 6;
            // 
            // pnlTxColor
            // 
            this.pnlTxColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTxColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTxColor.Location = new System.Drawing.Point(822, 538);
            this.pnlTxColor.Name = "pnlTxColor";
            this.pnlTxColor.Size = new System.Drawing.Size(50, 10);
            this.pnlTxColor.TabIndex = 7;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.pnlTxColor);
            this.Controls.Add(this.pnlRxColor);
            this.Controls.Add(this.btnTxColor);
            this.Controls.Add(this.btnRxColor);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.grpSettings);
            this.MinimumSize = new System.Drawing.Size(720, 480);
            this.Name = "Form1";
            this.Text = "시리얼 통신 프로그램";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnRefreshPorts;
        private System.Windows.Forms.Label lblHandshake;
        private System.Windows.Forms.ComboBox cmbHandshake;
        private System.Windows.Forms.Label lblStopBits;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.Label lblDataBits;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.Label lblBaud;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnRxColor;
        private System.Windows.Forms.Button btnTxColor;
        private System.Windows.Forms.Panel pnlRxColor;
        private System.Windows.Forms.Panel pnlTxColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

