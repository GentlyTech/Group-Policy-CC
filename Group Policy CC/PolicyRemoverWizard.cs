using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class PolicyRemoverWizard : Form
    {
        string OptionName;

        public PolicyRemoverWizard()
        {
            InitializeComponent();
        }

        private void PolicyRemoverWizard_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome to the Group Policy Remover Wizard";
            label2.Visible = true;
        }

        //------------------------------------------------Radio Button Functions------------------------------------------------\\

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                OptionName = radioButton1.Text;
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                OptionName = radioButton2.Text;
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                OptionName = radioButton3.Text;
            }
        }

        //------------------------------------------------Service Functions------------------------------------------------\\
        static Process svc = new Process();
        static Process svc2 = new Process();

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                svc.StartInfo.FileName = "sc.exe";
                svc.StartInfo.Arguments = "stop gpsvc";

                svc2.StartInfo.FileName = "sc.exe";
                svc2.StartInfo.Arguments = "sc config gpsvc start=disabled";

                svc.StartInfo.CreateNoWindow = true;
                svc.StartInfo.UseShellExecute = false;

                svc2.StartInfo.CreateNoWindow = true;
                svc2.StartInfo.UseShellExecute = false;

                svc.Start();
                svc2.Start();

                svc.WaitForExit();
                svc2.WaitForExit();

                CheckForCompletion();

                if (CheckForCompletion())
                {
                    //Configure the MessageBox
                    string message = "The operation completed successfully!";
                    string caption = "Success";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
                }
                else
                {
                    //Configure the MessageBox
                    string message1 = "Something went wrong while disabling the group policy service (e.g. The service wasn't started).\n\nPlease try again or do it manually through powershell/command prompt.";
                    string caption1 = "Error - Unable to Disable Service";
                    MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                    DialogResult result1;

                    // Displays the MessageBox.
                    result1 = MessageBox.Show(message1, caption1, buttons1, MessageBoxIcon.Error);

                    checkBox1.CheckStateChanged -= CheckBox1_CheckedChanged;
                    checkBox1.Checked = false;
                    checkBox1.CheckStateChanged += CheckBox1_CheckedChanged;
                }
            }
            else
            {
                svc2.StartInfo.FileName = "sc.exe";
                svc2.StartInfo.Arguments = "sc config gpsvc start=auto";

                svc.StartInfo.FileName = "sc.exe";
                svc.StartInfo.Arguments = "start gpsvc";

                svc.StartInfo.CreateNoWindow = true;
                svc.StartInfo.UseShellExecute = false;

                svc2.StartInfo.CreateNoWindow = true;
                svc2.StartInfo.UseShellExecute = false;

                svc.Start();
                svc2.Start();

                svc.WaitForExit();
                svc2.WaitForExit();

                CheckForCompletion();

                if (CheckForCompletion())
                {
                    //Configure the MessageBox
                    string message = "Service Enabled Successfully!";
                    string caption = "Success";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
                }
                else
                {
                    //Configure the MessageBox
                    string message1 = "Something went wrong while enabling the group policy service (e.g. The service is already running).\n\nPlease try again or do it manually through powershell/command prompt.";
                    string caption1 = "Error - Unable to Enable Service";
                    MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                    DialogResult result1;

                    // Displays the MessageBox.
                    result1 = MessageBox.Show(message1, caption1, buttons1, MessageBoxIcon.Error);

                    checkBox1.CheckStateChanged -= CheckBox1_CheckedChanged;
                    checkBox1.Checked = true;
                    checkBox1.CheckStateChanged += CheckBox1_CheckedChanged;
                }
            }
        }

        private bool CheckForCompletion()
        {
            if (svc.ExitCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //------------------------------------------------Other Functions------------------------------------------------\\
        private void Button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Confirm...";
            label2.Visible = false;

            //Configure the MessageBox
            string message = $"Are you sure you want to strip the policies for the selected option ({OptionName})?";
            string caption = "Confirm";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                //Current User
                if (radioButton1.Checked)
                {
                    RegistryKey desiredKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                    desiredKey.DeleteSubKeyTree("Policies");

                    desiredKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion", true);
                    desiredKey.DeleteSubKeyTree("Policies");
                }
                //Local Machine
                else if (radioButton2.Checked)
                {
                    RegistryKey desiredKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                    desiredKey.DeleteSubKeyTree("Policies");

                    desiredKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion", true);
                    desiredKey.DeleteSubKeyTree("Policies");
                }
                //Both
                else if (radioButton3.Checked)
                {
                    RegistryKey desiredKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                    desiredKey.DeleteSubKeyTree("Policies");

                    desiredKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion", true);
                    desiredKey.DeleteSubKeyTree("Policies");

                    desiredKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                    desiredKey.DeleteSubKeyTree("Policies");

                    desiredKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion", true);
                    desiredKey.DeleteSubKeyTree("Policies");
                }

                //Configure the MessageBox
                string message1 = "The operation completed successfully!";
                string caption1 = "Success";
                MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                DialogResult result1;

                // Displays the MessageBox.
                result1 = MessageBox.Show(message1, caption1, buttons1, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                //Configure the MessageBox
                string message2 = "The operation was cancelled by the user.";
                string caption2 = "Cancelled";
                MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                DialogResult result2;

                // Displays the MessageBox.
                result2 = MessageBox.Show(message2, caption2, buttons2, MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}