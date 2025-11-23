using System;
using System.Windows.Forms;

// Replace with actual namespace of the installed NuGet package if different
using DasunTech.Licensing;

namespace Serial_Program
{
    internal static class Program
    {
        // Default for license check when no command-line arg or environment variable is provided.
        // Set to "1" to enable license checking by default.
        private const string LICENSE_CHECK = "1";

        // Public program name for About dialog
        public static string ProgramName = "시리얼 통신 프로그램";

        // Public program version for About dialog
        public static string ProgramVersion = "1.0.0";

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Determine LICENSE_CHECK setting: command-line args take precedence, then environment variable, then LICENSE_CHECK
            string licenseCheck = GetLicenseCheckFromArgs(args) ?? Environment.GetEnvironmentVariable("LICENSE_CHECK") ?? LICENSE_CHECK;
            if (licenseCheck == "1")
            {
                try
                {
                    // 네임스페이스 변경에 따라 LicenseService, LicenseException 사용
                    var svc = new LicenseService();
                    var info = svc.VerifyLicense();

                    // Optionally, you can expose these values to the rest of the app via static properties or other means.
                    // Program.LicenseVolume = info.Volume; // if you re-add such properties
                    // Program.LicenseExpiry = info.Expiry;
                }
                catch (LicenseException lex)
                {
                    MessageBox.Show(lex.Message, "라이센스 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("라이센스 오류: " + ex.Message, "라이센스 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        // Parse command-line args for license check flag. Supported forms:
        // --license_check=0 or --license-check=0 or /license_check:0 or --license_check 0
        private static string GetLicenseCheckFromArgs(string[] args)
        {
            if (args == null || args.Length == 0) return null;
            for (int i = 0; i < args.Length; i++)
            {
                var a = args[i];
                if (string.IsNullOrWhiteSpace(a)) continue;
                var s = a.Trim();
                if (s.StartsWith("--license_check=", StringComparison.OrdinalIgnoreCase) || s.StartsWith("--license-check=", StringComparison.OrdinalIgnoreCase))
                {
                    int p = s.IndexOf('=');
                    if (p >= 0 && p + 1 < s.Length) return s.Substring(p + 1);
                }
                else if (s.StartsWith("/license_check:", StringComparison.OrdinalIgnoreCase) || s.StartsWith("/license-check:", StringComparison.OrdinalIgnoreCase))
                {
                    int p = s.IndexOf(':');
                    if (p >= 0 && p + 1 < s.Length) return s.Substring(p + 1);
                }
                else if (s.Equals("--license_check", StringComparison.OrdinalIgnoreCase) || s.Equals("--license-check", StringComparison.OrdinalIgnoreCase))
                {
                    if (i + 1 < args.Length) return args[i + 1];
                }
                else if (s.Equals("/license_check", StringComparison.OrdinalIgnoreCase) || s.Equals("/license-check", StringComparison.OrdinalIgnoreCase))
                {
                    if (i + 1 < args.Length) return args[i + 1];
                }
            }
            return null;
        }
    }
}
