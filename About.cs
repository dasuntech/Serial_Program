using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Serial_Program
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            LoadInfo();
        }

        private void LoadInfo()
        {
            // Program name from Program.ProgramName
            lblProgramName.Text = Program.ProgramName;

            // Try to load logo from res folder in application directory
            try
            {
                var logoPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "res", "dasuntech_CI.jpg");
                if (System.IO.File.Exists(logoPath))
                {
                    // Dispose existing image if any
                    try { if (pictureBoxLogo.Image != null) pictureBoxLogo.Image.Dispose(); } catch { }
                    pictureBoxLogo.Image = Image.FromFile(logoPath);
                }
                else
                {
                    // Try to load from project's resources (Properties.Resources.dasuntech_CI) if available
                    try
                    {
                        var resType = Type.GetType("Serial_Program.Properties.Resources, Serial_Program");
                        if (resType != null)
                        {
                            var prop = resType.GetProperty("dasuntech_CI", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                            if (prop != null)
                            {
                                var img = prop.GetValue(null) as Image;
                                if (img != null)
                                {
                                    pictureBoxLogo.Image = new Bitmap(img);
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }

            // Build count and date
            try
            {
                var asm = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
                var fileVersion = asm.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
                if (!string.IsNullOrEmpty(fileVersion))
                {
                    lblBuildCount.Text = "ºôµå È½¼ö: " + GetBuildCountFromVersion(fileVersion).ToString();
                }
                else
                {
                    lblBuildCount.Text = "ºôµå È½¼ö: ¾Ë¼ö¾øÀ½";
                }

                // Use file last write time of the assembly for a reliable build date
                var buildDate = GetAssemblyFileWriteTime(asm);
                lblBuildDate.Text = "ºôµå ³¯Â¥: " + buildDate.ToString("yyyy-MM-dd");
            }
            catch
            {
                lblBuildCount.Text = "ºôµå È½¼ö: ¾Ë¼ö¾øÀ½";
                lblBuildDate.Text = "ºôµå ³¯Â¥: ¾Ë¼ö¾øÀ½";
            }

            // Company link
            lnkCompany.Text = "´Ù¼±Å×Å©";
            lnkCompany.Links.Clear();
            lnkCompany.Links.Add(0, lnkCompany.Text.Length, "http://www.dasuntech.com");

            lblEmail.Text = "dasuntech.inc@gmail.com";
        }

        private int GetBuildCountFromVersion(string version)
        {
            // version format: major.minor.build.revision
            var parts = version.Split('.');
            if (parts.Length >= 3 && int.TryParse(parts[2], out int build))
                return build;
            return 0;
        }

        // Use assembly file's last write time as the build date (reliable for generated output)
        private DateTime GetAssemblyFileWriteTime(Assembly assembly)
        {
            try
            {
                var filePath = assembly.Location;
                if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
                {
                    return DateTime.Now;
                }
                // Use UTC to avoid timezone confusion then convert to local
                var utc = System.IO.File.GetLastWriteTimeUtc(filePath);
                return utc.ToLocalTime();
            }
            catch
            {
                return DateTime.Now;
            }
        }

        private void lnkCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var target = e.Link.LinkData as string;
            if (!string.IsNullOrEmpty(target))
            {
                try { Process.Start(target); } catch { }
            }
        }
    }
}
