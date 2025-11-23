using System;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Adjust namespace to match installed NuGet package if different
using DasunTech.Licensing;

namespace Serial_Program
{
    public partial class MainForm : Form
    {
        private Color _rxColor = Color.DodgerBlue;
        private Color _txColor = Color.LimeGreen;
        private CheckBox chkAppendCrlf; // CR/LF 자동 추가 체크박스

        public MainForm()
        {
            InitializeComponent();
            InitializeUi();

            // Update license status in the status strip
            TryShowLicenseStatus();
        }
                
        /// <summary>
        /// 폼의 주요 UI 요소와 초기 시리얼 설정 콤보들을 초기화합니다.
        /// - 포트 목록 로드
        /// - 전송/수신 색상 미리보기 설정
        /// - CR/LF 자동 추가 체크박스 생성
        /// </summary>
        private void InitializeUi()
        {
            // 콤보 초기화
            cmbBaud.Items.AddRange(new object[]
            {
                300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600,
                115200, 128000, 230400, 256000, 460800, 921600
            });
            cmbBaud.SelectedItem = 115200;

            cmbDataBits.Items.AddRange(new object[] { 5, 6, 7, 8 });
            cmbDataBits.SelectedItem = 8;

            cmbParity.Items.AddRange(Enum.GetNames(typeof(Parity)));
            cmbParity.SelectedItem = Parity.None.ToString();

            // StopBits.None는 일반 시리얼에서 부적합하므로 제외
            var stopBitsNames = new[] { StopBits.One, StopBits.OnePointFive, StopBits.Two }
                .Select(sb => sb.ToString())
                .ToArray();
            cmbStopBits.Items.AddRange(stopBitsNames);
            cmbStopBits.SelectedItem = StopBits.One.ToString();

            cmbHandshake.Items.AddRange(Enum.GetNames(typeof(Handshake)));
            cmbHandshake.SelectedItem = Handshake.None.ToString();

            // 포트 목록 로드
            LoadPorts();

            // 색상 미리보기
            pnlRxColor.BackColor = _rxColor;
            pnlTxColor.BackColor = _txColor;

            // 로그 글꼴 가독성
            rtbLog.Font = new Font(FontFamily.GenericMonospace, 10f);

            // CR/LF 자동 추가 체크박스(동적 추가)
            chkAppendCrlf = new CheckBox
            {
                AutoSize = true,
                Text = "CR/LF 자동 추가",
                Checked = true,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };
            // txtSend 아래에 배치
            chkAppendCrlf.Location = new Point(txtSend.Left, txtSend.Bottom + 5);
            this.Controls.Add(chkAppendCrlf);

            // 라이센스 상태 표시 관련 코드는 NuGet 패키지로 대체되었으므로 여기서는 처리하지 않습니다.
        }
        
        /// <summary>
        /// 시스템에 연결된 시리얼 포트 목록을 갱신하고 콤보박스를 재설정합니다.
        /// </summary>
        /// <remarks>This method retrieves the current serial port names from the system, sorts them
        /// alphabetically, and repopulates the port selection control. If the previously selected port is still
        /// available, it remains selected; otherwise, the first available port is selected. This ensures the port list
        /// reflects the current state of connected devices.</remarks>
        private void LoadPorts()
        {
            var names = SerialPort.GetPortNames();
            Array.Sort(names, StringComparer.OrdinalIgnoreCase);

            var selected = cmbPort.SelectedItem as string;
            cmbPort.Items.Clear();
            cmbPort.Items.AddRange(names.Cast<object>().ToArray());

            if (!string.IsNullOrEmpty(selected) && names.Contains(selected))
                cmbPort.SelectedItem = selected;
            else if (names.Length > 0)
                cmbPort.SelectedIndex = 0;
        }

        /// <summary>
        /// UI에서 선택된 설정을 시리얼포트 객체에 적용합니다.
        /// </summary>
        /// <exception cref="InvalidOperationException">포트가 선택되어 있지 않으면 발생합니다.</exception>
        private void ApplySerialSettings()
        {
            if (cmbPort.SelectedItem == null)
                throw new InvalidOperationException("포트를 선택하세요.");

            serialPort1.PortName = cmbPort.SelectedItem.ToString();
            serialPort1.BaudRate = Convert.ToInt32(cmbBaud.SelectedItem);
            serialPort1.DataBits = Convert.ToInt32(cmbDataBits.SelectedItem);

            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.SelectedItem.ToString());
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.SelectedItem.ToString());
            serialPort1.Handshake = (Handshake)Enum.Parse(typeof(Handshake), cmbHandshake.SelectedItem.ToString());

            // 일반 기본값
            serialPort1.Encoding = Encoding.ASCII;
            serialPort1.NewLine = "\r\n";
            serialPort1.ReadTimeout = 500;
            serialPort1.WriteTimeout = 500;
        }

        private void btnRefreshPorts_Click(object sender, EventArgs e)
        {
            LoadPorts();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen) return;

                ApplySerialSettings();
                serialPort1.Open();

                ToggleControls(isOpen: true);
                AppendLog($"[OPEN] {serialPort1.PortName} {serialPort1.BaudRate}bps {serialPort1.DataBits}{serialPort1.Parity}{serialPort1.StopBits} {serialPort1.Handshake}\r\n", Color.Gray);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"포트를 열 수 없습니다.\r\n{ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serialPort1.IsOpen) return;

                serialPort1.Close();
                ToggleControls(isOpen: false);
                AppendLog("[CLOSE]\r\n", Color.Gray);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"포트를 닫는 중 오류가 발생했습니다.\r\n{ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToggleControls(bool isOpen)
        {
            cmbPort.Enabled = !isOpen;
            cmbBaud.Enabled = !isOpen;
            cmbDataBits.Enabled = !isOpen;
            cmbParity.Enabled = !isOpen;
            cmbStopBits.Enabled = !isOpen;
            cmbHandshake.Enabled = !isOpen;
            btnRefreshPorts.Enabled = !isOpen;

            btnOpen.Enabled = !isOpen;
            btnClose.Enabled = isOpen;
            btnSend.Enabled = isOpen;
            txtSend.Enabled = isOpen;

            // chkAppendCrlf는 포트 상태와 무관하게 항상 변경 가능
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendFromTextbox();
        }

        private void txtSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendFromTextbox();
                e.SuppressKeyPress = true; // '삑' 소리 방지
            }
        }

        /// <summary>
        /// 텍스트박스의 내용을 시리얼로 전송합니다.
        /// CR/LF 자동 추가 체크 상태에 따라 Write 또는 WriteLine을 사용합니다.
        /// 전송 성공 시 로그에 송신 색상으로 표시합니다.
        /// </summary>
        private void SendFromTextbox()
        {
            try
            {
                if (!serialPort1.IsOpen) return;

                var text = txtSend.Text;
                if (string.IsNullOrEmpty(text)) return;

                if (chkAppendCrlf != null && chkAppendCrlf.Checked)
                {
                    // WriteLine은 serialPort1.NewLine(기본 \r\n)을 자동으로 덧붙임
                    serialPort1.WriteLine(text);
                    AppendLog(text + serialPort1.NewLine, _txColor);
                }
                else
                {
                    serialPort1.Write(text);
                    AppendLog(text, _txColor);
                }

                txtSend.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"전송 실패: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var data = serialPort1.ReadExisting(); // 인코딩 기반 문자열
                if (!string.IsNullOrEmpty(data))
                {
                    AppendLog(data, _rxColor);
                }
            }
            catch (Exception ex)
            {
                AppendLog($"[RX ERR] {ex.Message}\r\n", Color.Red);
            }
        }

        /// <summary>
        /// 로그(RichTextBox)에 텍스트를 지정한 색으로 추가하고 자동 스크롤합니다.
        /// 스레드 안전을 위해 InvokeRequired를 처리합니다.
        /// </summary>
        /// <param name="text">추가할 텍스트</param>
        /// <param name="color">텍스트 색상</param>
        private void AppendLog(string text, Color color)
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.BeginInvoke(new Action<string, Color>(AppendLog), text, color);
                return;
            }

            int start = rtbLog.TextLength;
            rtbLog.SelectionStart = start;
            rtbLog.SelectionLength = 0;
            rtbLog.SelectionColor = color;
            rtbLog.AppendText(text);
            rtbLog.SelectionColor = rtbLog.ForeColor;

            // 자동 스크롤
            rtbLog.SelectionStart = rtbLog.TextLength;
            rtbLog.ScrollToCaret();
        }

        private void btnRxColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = _rxColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                _rxColor = colorDialog1.Color;
                pnlRxColor.BackColor = _rxColor;
            }
        }

        private void btnTxColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = _txColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                _txColor = colorDialog1.Color;
                pnlTxColor.BackColor = _txColor;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                    serialPort1.Close();
            }
            catch
            {
                // 무시
            }
        }

        private void TryShowLicenseStatus()
        {
            // Respect global setting from Program. If license checking is disabled, show disabled labels and return.
            try
            {
                if (!Program.LicenseCheckEnabled)
                {
                    if (tslVolume != null)
                        tslVolume.Text = "볼륨: 체크 안함";
                    if (tslExpiry != null)
                        tslExpiry.Text = "만료일: 체크 안함";
                    return;
                }
            }
            catch { }

            try
            {
                var svc = new LicenseService();
                var info = svc.VerifyLicense();

                if (tslVolume != null)
                    tslVolume.Text = $"볼륨: {info.Volume}";
                if (tslExpiry != null)
                    tslExpiry.Text = info.Expiry.HasValue ? $"만료일: {info.Expiry.Value:yyyy-MM-dd}" : "만료일: 알수없음";
            }
            catch (LicenseException ex)
            {
                // 검증 실패 시 상태표시줄에 기본 텍스트 표시하고 오류 메시지는 팝업
                if (tslVolume != null)
                    tslVolume.Text = "볼륨: 알수없음";
                if (tslExpiry != null)
                    tslExpiry.Text = "만료일: 알수없음";
                try { MessageBox.Show(ex.Message, "라이센스 오류", MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { }
            }
            catch
            {
                if (tslVolume != null)
                    tslVolume.Text = "볼륨: 알수없음";
                if (tslExpiry != null)
                    tslExpiry.Text = "만료일: 알수없음";
            }
        }

        private void btnAbout_Click_1(object sender, EventArgs e)
        {
            try
            {
                var about = new About();
                // Load logo from resources path if exists
                try
                {
                    var logoPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "res", "dasuntech_CI.jpg");
                    if (System.IO.File.Exists(logoPath))
                    {
                        about.Controls.Find("pictureBoxLogo", true)[0].GetType().GetProperty("Image").SetValue(about.Controls.Find("pictureBoxLogo", true)[0], Image.FromFile(logoPath));
                    }
                }
                catch { }

                about.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "About 창을 열 수 없습니다:\r\n" + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
