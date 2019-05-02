using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class Main : Form
    {
        //Instantiate Forms
        Form PolicyRemoverWizard = new PolicyRemoverWizard();
        Form AdminHijacker = new AdminHijacker();
        Form Keybinder = new Keybinder();

        public Main()
        {
            InitializeComponent();
            timer1.Start();
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

            //Configure the MessageBox
            string message = "This program was not run with Administrator Privileges.\n\nIn order to change the password or strip policies, Administrator Privileges is required.\n\nPlease 'Run As Administrator' to enable functionality.";
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

        //------------------------------------------------------------Button Functions------------------------------------------------------------------------\\

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

        private void Button4_Click(object sender, EventArgs e)
        {
            Process PowerShell = new Process();
            // Configure the process using the StartInfo properties.
            PowerShell.StartInfo.FileName = "powershell.exe";
            PowerShell.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            PowerShell.Start();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Keybinder.ShowDialog();
        }

        //------------------------------------------------------------Tool Strip Functions------------------------------------------------------------------------\\

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RelaunchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void READMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Please note that administrative privileges are required for the program to successfully execute its functions.\n\nWe are not responsible for any data loss or damage caused by this program. Thank you for using our product.";
            string caption = "README - Please Note";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
        }

        //------------------------------------------------------------Clock------------------------------------------------------------------------\\
        private void timer1_Tick(object sender, EventArgs e)
        {
            var CurrentTime = DateTime.Now;

            string formattedTimeNow = CurrentTime.ToString("h:mm:ss tt", CultureInfo.InvariantCulture);

            Time.Text = formattedTimeNow;
        }

        private void InstallFortniteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Haha... no.";
            string caption = "Install Fortnite";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Stop);
        }
    }
}
