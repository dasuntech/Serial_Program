using System;
using System.Windows.Forms;
using System.Reflection;

// Replace with actual namespace of the installed NuGet package if different
using DasunTech.Licensing;

namespace Serial_Program
{
    internal static class Program
    {
        // Default for license check when no command-line arg or environment variable is provided.
        // Set to "1" to enable license checking by default.
        private const string LICENSE_CHECK = "0";

        // Public flag indicating whether license checking is enabled for this run
        public static bool LicenseCheckEnabled = false;

        // Public program name for About dialog
        public static string ProgramName = "시리얼 통신 프로그램";

        // Public program version for About dialog (default)
        public static string ProgramVersion = "1.0.0";

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Determine LICENSE_CHECK setting: command-line args take precedence, then environment variable, then LICENSE_CHECK
            string argVal = GetLicenseCheckFromArgs(args);
            string envVal = Environment.GetEnvironmentVariable("LICENSE_CHECK");
            string raw = (argVal ?? envVal ?? LICENSE_CHECK)?.Trim();

            // Normalize to boolean: accept "1", "true", "yes" (case-insensitive) as enabled.
            bool licenseEnabled = false;
            if (!string.IsNullOrEmpty(raw))
            {
                if (string.Equals(raw, "1", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(raw, "true", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(raw, "yes", StringComparison.OrdinalIgnoreCase))
                {
                    licenseEnabled = true;
                }
            }

            LicenseCheckEnabled = licenseEnabled;

            // If license checking is enabled at startup, perform the verification here as before
            if (LicenseCheckEnabled)
            {
                try
                {
                    var svc = new LicenseService();
                    var info = svc.VerifyLicense();
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

            // Update ProgramVersion from compiled assembly's file version (generated during build)
            try
            {
                var asm = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
                var fileVer = asm.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
                var infoVer = asm.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
                if (!string.IsNullOrEmpty(fileVer))
                    ProgramVersion = fileVer;
                else if (!string.IsNullOrEmpty(infoVer))
                    ProgramVersion = infoVer;
                else if (asm.GetName().Version != null)
                    ProgramVersion = asm.GetName().Version.ToString();
            }
            catch { }

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
