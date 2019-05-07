using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class Main : Form
    {
        //------------------------------------------------------------Local Event Handlers & Initialization------------------------------------------------------------------------\\
        //Instantiate Forms
        Form PolicyRemoverWizard = new PolicyRemoverWizard();
        Form AdminHijacker = new AdminHijackerWizard();
        Form Keybinder = new KeybindWizard();
        Form Settings = new Settings();


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
            }
            else
            {
                Lockdown();
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
            string caption = "Error: Limited User";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
        }

        [DllImport("ntdll.dll")]
        public static extern uint RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

        [DllImport("ntdll.dll")]
        public static extern uint NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

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

        private void Button4_Click(object sender, EventArgs e)
        {
            //Configure the MessageBox
            string message = "Are you sure you want to blue screen this computer?\n\nAny unsaved work will be lost, and there is a risk that something could break (e.g. There is a Windows Update in progress).\n\nWe are not responsible for any damage or data loss caused as a result of this feature.\n\nYou have been warned...";
            string caption = "Confirm Blue Screen";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                bool t1;
                uint t2;
                RtlAdjustPrivilege(19, true, false, out t1);
                NtRaiseHardError(0xc0000022, 0, 0, IntPtr.Zero, 6, out t2);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Process PowerShell = new Process();
            // Configure the process using the StartInfo properties.
            PowerShell.StartInfo.FileName = "powershell.exe";
            PowerShell.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            PowerShell.Start();
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

        //------------------------------------------------------------Tool Strip Functions------------------------------------------------------------------------\\

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OpenModernSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process Proc = new Process();
            Proc.StartInfo.FileName = @"ms-settings:home";

            Proc.Start();
        }

        private void OpenClassicControlPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process Proc = new Process();
            Proc.StartInfo.FileName = "control.exe";

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

        private void READMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Program Description:\n\n" +
                "This program can help you circumvent windows group policies set by your administrator/organization.\n\n" +
                "At the moment, Administrator Priviliges are required to complete the tasks, but this program makes it faster and easier to take control over a machine.\n\n" +
                "This works because some administrators enforce policies but give the students admin.\n\n" +

                "Disclaimer:\n\n" +
                "We are not responsible for any data loss or damage caused by this program.\n\n" +
                "Thank you for using our product!";

            string caption = "README - Please Note";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //------------------------------------------------------------Clock------------------------------------------------------------------------\\
        private void timer1_Tick(object sender, EventArgs e)
        {
            var CurrentTime = DateTime.Now;

            string formattedTimeNow = CurrentTime.ToString("h:mm:ss tt", CultureInfo.InvariantCulture);

            Clock1.Text = formattedTimeNow;
            Clock2.Text = formattedTimeNow;
        }

    }
}
