using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class Hub : Form
    {
        //------------------------------------------------------------Local Event Handlers & Initialization------------------------------------------------------------------------\\
        //Instantiate Forms
        Form Settings = new Settings();
        Form About = new About();
        Form EasterEgg = new EasterEgg();

        Form PolicyRemoverWizard = new PolicyRemoverWizard();
        Form AdminHijacker = new AdminHijackerWizard();
        Form Keybinder = new KeybindWizard();
        Form WallpaperChanger = new WallpaperChanger();
        Form WifiPasswordFinder = new WiFiPasswordFinder();
        Form Run = new Run();
        Form Browser = new SekureBrowzer();

        public bool Is64Bit()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Hub()
        {
            InitializeComponent();
            timer1.Start();

            Username.Text = Environment.UserDomainName + "\\" + Environment.UserName;
        }

        private void LoadSettings()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\YDS\\GPCC\\Settings", true))
                {

                    if (key == null)
                    {
                        RegistryKey MakeKey = Registry.CurrentUser.CreateSubKey("Software\\YDS\\GPCC\\Settings", true);
                        MakeKey.SetValue("WelcomeBannerVisible", 1, RegistryValueKind.DWord);
                        MakeKey.SetValue("ImageBannerVisible", 1, RegistryValueKind.DWord);
                        MakeKey.SetValue("IsFullscreen", 0, RegistryValueKind.DWord);
                    }

                    object K1 = key.GetValue("WelcomeBannerVisible");
                    if (K1 != null)
                    {
                        if (K1.Equals(0))
                        {
                            ToggleWelcomeBanner();
                        }
                    }
                    else
                    {
                        key.SetValue("WelcomeBannerVisible", 1, RegistryValueKind.DWord);
                    }

                    object K2 = key.GetValue("ImageBannerVisible");
                    if (K2 != null)
                    {
                        if (K2.Equals(0))
                        {
                            ToggleImageBanner();
                        }
                    }
                    else
                    {
                        key.SetValue("ImageBannerVisible", 1, RegistryValueKind.DWord);
                    }

                    object K3 = key.GetValue("HKCU\\SOFTWARE\\YDS\\GPCC\\Settings\\IsFullscreen");
                    if (K3 != null)
                    {
                        if (K3.Equals(1))
                        {
                            ToggleFullscreen();
                        }
                    }
                    else
                    {
                        key.SetValue("IsFullscreen", 0, RegistryValueKind.DWord);
                    }
                }
            }
            catch
            {
                //MessageBox.Show("Unable to Load Settings", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ResetSettings()
        {
                RegistryKey MakeKey = Registry.CurrentUser.CreateSubKey("Software\\YDS\\GPCC\\Settings", true);
                MakeKey.SetValue("WelcomeBannerVisible", 1, RegistryValueKind.DWord);
                MakeKey.SetValue("ImageBannerVisible", 1, RegistryValueKind.DWord);
                MakeKey.SetValue("IsFullscreen", 0, RegistryValueKind.DWord);
        }

        private void WriteSettings(int SettingNumber, bool Value)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\YDS\\GPCC\\Settings", true))
            {
                if (key == null)
                {
                    RegistryKey MakeKey = Registry.CurrentUser.CreateSubKey("Software\\YDS\\GPCC\\Settings", true);
                    MakeKey.SetValue("WelcomeBannerVisible", 1, RegistryValueKind.DWord);
                    MakeKey.SetValue("ImageBannerVisible", 1, RegistryValueKind.DWord);
                    MakeKey.SetValue("IsFullscreen", 0, RegistryValueKind.DWord);
                }

                if (SettingNumber == 1)
                {
                    if (Value)
                    {
                        key.SetValue("WelcomeBannerVisible", 1, RegistryValueKind.DWord);
                    }
                    else
                    {
                        key.SetValue("WelcomeBannerVisible", 0, RegistryValueKind.DWord);
                    }
                }
                else if (SettingNumber == 2)
                {
                    if (Value)
                    {
                        key.SetValue("ImageBannerVisible", 1, RegistryValueKind.DWord);
                    }
                    else
                    {
                        key.SetValue("ImageBannerVisible", 0, RegistryValueKind.DWord);
                    }
                }
                else if (SettingNumber == 3)
                {
                    if (Value)
                    {
                        key.SetValue("IsFullscreen", 1, RegistryValueKind.DWord);
                    }
                    else
                    {
                        key.SetValue("IsFullscreen", 0, RegistryValueKind.DWord);
                    }
                }
                else
                {
                    throw new Exception("Something went wrong while saving settings! Please report this bug to the creator.");
                }
            }
        }

        private void OnResized(object sender, EventArgs e)
        {
            if (this.Width <= 1154)
            {
                this.Width = 1154;
            }

            if (this.Height < 744)
            {
                this.Height = 744;
            }
        }

        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadSettings();

            if (IsAdministrator())
            {
                this.Text = this.Text + " " + "(Administrator)";
                relaunchToolStripMenuItem.Text = "Relaunch Application";
                relaunchToolStripMenuItem.Image = null;

                AddressAdministrativeItemsListAsAdministrator();
            }
            else
            {
                Lockdown();
            }

            Is64Bit();
            WinBuildInfo();

            if (CheckDomain())
            {
                button8.Enabled = true;
            }
            else if (!CheckDomain())
            {
                button8.Enabled = false;
            }
        }

        bool CheckDomain()
        {
            try
            {
                Domain.GetComputerDomain();
                return true;
            }
            catch (ActiveDirectoryObjectNotFoundException)
            {
                return false;
            }
        }

        private void Lockdown()
        {
            this.Text = this.Text + " " + "(Limited User)";
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;

            //Configure the MessageBox
            string message = "This program was not run with Administrator Privileges.\n\nIn order to use the majority of the features in this application (e.g. change the password or strip policies), Administrator Privileges are required.\n\nPlease 'Run As Administrator' to enable these functionalities.";
            string caption = "Error - Limited User";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
        }

        private void AddressAdministrativeItemsListAsAdministrator()
        {
            netplWizardToolStripMenuItem.Image = null;
            userAccountControlToolStripMenuItem.Image = null;
            registryEditorToolStripMenuItem.Image = null;

            microsoftManagementConsoleToolStripMenuItem.Image = null;
            rootConsoleToolStripMenuItem.Image = null;
            computerManagementToolStripMenuItem.Image = null;
            groupPolicyEditorToolStripMenuItem.Image = null;
            localUsersAndGroupsToolStripMenuItem.Image = null;
            servicesToolStripMenuItem.Image = null;
        }

        public void WinBuildInfo()
        {
            //Windows & Build Info
            if (Is64Bit())
            {
                Version.Text = OSFriendlyName() + " " + "64-Bit";
            }
            else
            {
                Version.Text = OSFriendlyName() + " " + "32-Bit";
            }
        }

        public string OSFriendlyName()
        {
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            return name != null ? name.ToString() : "Unknown";
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        //------------------------------------------------------------Button Functions------------------------------------------------------------------------\\
        //Page 1
        private void Button1_Click(object sender, EventArgs e)
        {
            PolicyRemoverWizard.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AdminHijacker.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Keybinder.ShowDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Run.ShowDialog();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        //Page 2

        private void Button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("This function will come soon! Check back later!");
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            WifiPasswordFinder.ShowDialog();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            WallpaperChanger.ShowDialog();
        }

        private void Button10_Click_1(object sender, EventArgs e)
        {
            Browser.Show();
        }

        //------------------------------------------------------------Tool Strip Functions------------------------------------------------------------------------\\

        private void READMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About.ShowDialog();
        }

        private void AboutWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process Proc = new Process();
            Proc.StartInfo.FileName = "winver.exe";

            Proc.Start();

        }

        private void RelaunchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsAdministrator())
                {
                    string FileName = Assembly.GetEntryAssembly().Location.ToString();
                    Process ThisApp = new Process();

                    ThisApp.StartInfo.UseShellExecute = true;
                    ThisApp.StartInfo.Verb = "runas";
                    ThisApp.StartInfo.FileName = FileName;
                    ThisApp.Start();

                    Application.Exit();
                }
                else
                {
                    Application.Restart();
                }
            }
            catch
            {

            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //======Administrative Applications======\\

        private void TaskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process Proc = new Process();
                Proc.StartInfo.FileName = "taskmgr.exe";

                Proc.Start();
            }
            catch
            {

            }
        }

        private void OpenModernSettingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process Proc = new Process();
                Proc.StartInfo.FileName = @"ms-settings:home";

                Proc.Start();
            }
            catch
            {
                MessageBox.Show("This version of Windows does not have the Modern Control Panel", "Error - Invalid Windows Version", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenClassicControlPanelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process Proc = new Process();
                Proc.StartInfo.FileName = "control.exe";

                Proc.Start();
            }
            catch
            {

            }
        }

        private void NetplWizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process Proc = new Process();
                Proc.StartInfo.Verb = "runas";
                Proc.StartInfo.FileName = "netplwiz.exe";

                Proc.Start();
            }
            catch
            {

            }
        }

        private void UserAccountControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process Proc = new Process();
                Proc.StartInfo.Verb = "runas";
                Proc.StartInfo.FileName = "useraccountcontrolsettings.exe";

                Proc.Start();
            }
            catch
            {

            }
        }

        private void RegistryEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process Proc = new Process();
                Proc.StartInfo.Verb = "runas";
                Proc.StartInfo.FileName = "regedit.exe";

                Proc.Start();
            }
            catch
            {

            }
        }

        private void RootConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process Proc = new Process();
                Proc.StartInfo.Verb = "runas";
                Proc.StartInfo.FileName = "mmc.exe";

                Proc.Start();
            }
            catch
            {

            }
        }

        private void ComputerManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process Proc = new Process();
                Proc.StartInfo.Verb = "runas";
                Proc.StartInfo.FileName = "compmgmt.msc";

                Proc.Start();
            }
            catch
            {

            }
        }

        private void GroupPolicyEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process Proc = new Process();
                Proc.StartInfo.Verb = "runas";
                Proc.StartInfo.FileName = "gpedit.msc";

                Proc.Start();
            }
            catch
            {
                MessageBox.Show("This edition of Windows does not support Group Policy Editing", "Error - Unsupported Edition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LocalUsersAndGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process Proc = new Process();
                Proc.StartInfo.Verb = "runas";
                Proc.StartInfo.FileName = "lusrmgr.msc";

                Proc.Start();
            }
            catch
            {

            }
        }

        private void ServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process Proc = new Process();
                Proc.StartInfo.Verb = "runas";
                Proc.StartInfo.FileName = "services.msc";

                Proc.Start();
            }
            catch
            {

            }
        }

        //------------------------------------------------------------Clock------------------------------------------------------------------------\\
        private void timer1_Tick(object sender, EventArgs e)
        {
            var CurrentTime = DateTime.Now;

            string formattedTimeNow = CurrentTime.ToString("h:mm:ss tt", CultureInfo.InvariantCulture);

            Clock1.Text = formattedTimeNow;
            Clock2.Text = formattedTimeNow;
        }

        //------------------------------------------------------------Settings Functions------------------------------------------------------------------------\\
        public void ToggleWelcomeBanner()
        {
            if (WelcomeBanner1.Visible || WelcomeBanner2.Visible)
            {
                WelcomeBanner1.Visible = false;
                WelcomeBanner2.Visible = false;

                WriteSettings(1, false);

                //(Application.OpenForms["Settings"] as Settings).ToggleClockText();
            }
            else
            {
                WelcomeBanner1.Visible = true;
                WelcomeBanner2.Visible = true;

                WriteSettings(1, true);

                //(Application.OpenForms["Settings"] as Settings).ToggleClockText();
            }
        }

        public void ToggleImageBanner()
        {
            if (ImageBanner1.Visible || ImageBanner2.Visible)
            {
                ImageBanner1.Visible = false;
                ImageBanner2.Visible = false;

                tableLayoutPanel2.Dock = DockStyle.Fill;
                tableLayoutPanel4.Dock = DockStyle.Fill;

                WriteSettings(2, false);

                //(Application.OpenForms["Settings"] as Settings).ToggleImageBannerText();
            }
            else
            {
                ImageBanner1.Visible = true;
                ImageBanner2.Visible = true;

                tableLayoutPanel2.Dock = DockStyle.Bottom;
                tableLayoutPanel4.Dock = DockStyle.Bottom;

                WriteSettings(2, true);

                //(Application.OpenForms["Settings"] as Settings).ToggleImageBannerText();
            }
        }

        public void ToggleFullscreen()
        {
            if (this.FormBorderStyle != FormBorderStyle.None)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;

                WriteSettings(3, true);

                //(Application.OpenForms["Settings"] as Settings).ToggleFullscreenText();
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Maximized;

                WriteSettings(3, false);

                //(Application.OpenForms["Settings"] as Settings).ToggleFullscreenText();
            }
        }
        public void ToggleDarkMode()
        {

        }

        //------------------------------------------------------------Easter Egg------------------------------------------------------------------------\\

        int ClickCount = 0;

        private void Label1_Click(object sender, EventArgs e)
        {

            ClickCount++;

            if (ClickCount == 5)
            {
                Egg();
            }
        }

        private void Egg()
        {
            EasterEgg.ShowDialog();

            ClickCount = 0;
        }

        private void Hub_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F11)
                {
                    ToggleFullscreen();
                }
            }
            catch
            {

            }
        }
    }
}