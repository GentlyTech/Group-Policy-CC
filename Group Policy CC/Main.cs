using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using Shell32;

namespace Group_Policy_CC
{
    public partial class Main : Form
    {
        //------------------------------------------------------------Local Event Handlers & Initialization------------------------------------------------------------------------\\
        //Instantiate Forms
        Form Settings = new Settings();
        Form About = new About();

        Form PolicyRemoverWizard = new PolicyRemoverWizard();
        Form AdminHijacker = new AdminHijackerWizard();
        Form Keybinder = new KeybindWizard();
        Form WallpaperChanger = new WallpaperChanger();
        Form WifiPasswordsList = new WiFiPasswordsList();
        Form WifiPasswordsListRaw = new WiFiPasswordsListRaw();
        Form Run = new Run();
        Form EasterEgg = new EasterEgg();

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


        public Main()
        {
            InitializeComponent();
            timer1.Start();
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

            //Settings Initialization
            ClockVisible = true;
            BannerVisible = true;

            Is64Bit();
            WinBuildInfo();
        }



        private void Lockdown()
        {
            this.Text = this.Text + " " + "(Limited User)";
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;

            //Configure the MessageBox
            string message = "This program was not run with Administrator Privileges.\n\nIn order to use the majority of the features in this application (e.g. change the password or strip policies), Administrator Privileges are required.\n\nPlease 'Run As Administrator' to enable these functionalities.";
            string caption = "Error: Limited User";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
        }

        private void AddressAdministrativeItemsListAsAdministrator()
        {
            netplWizardToolStripMenuItem.Image = null;
            userAccountControlToolStripMenuItem.Image = null;

            microsoftManagementConsoleToolStripMenuItem.Image = null;
            rootConsoleToolStripMenuItem.Image = null;
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
            string message = "Haha... no.";
            string caption = "Install Fortnite";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Stop);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            WifiPasswordsListRaw.ShowDialog();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            WallpaperChanger.ShowDialog();
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

        public bool ClockVisible;
        public bool BannerVisible;

        public void ToggleClock()
        {
            if (Clock1.Visible || Clock2.Visible)
            {
                Clock1.Visible = false;
                Clock2.Visible = false;
                tableLayoutPanel1.ColumnCount = 1;
                tableLayoutPanel3.ColumnCount = 1;

                ClockVisible = false;

                (Application.OpenForms["Settings"] as Settings).ToggleClockText();
            }
            else
            {
                Clock1.Visible = true;
                Clock2.Visible = true;
                tableLayoutPanel1.ColumnCount = 2;
                tableLayoutPanel3.ColumnCount = 2;

                ClockVisible = true;

                (Application.OpenForms["Settings"] as Settings).ToggleClockText();
            }
        }

        public void ToggleBanner()
        {
            if (Banner1.Visible || Banner2.Visible)
            {
                Banner1.Visible = false;
                Banner2.Visible = false;

                BannerVisible = false;

                (Application.OpenForms["Settings"] as Settings).ToggleBannerText();
            }
            else
            {
                Banner1.Visible = true;
                Banner2.Visible = true;

                BannerVisible = true;

                (Application.OpenForms["Settings"] as Settings).ToggleBannerText();
            }
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
    }
}