using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class PolicyRemoverWizard : Form
    {
        public PolicyRemoverWizard()
        {
            InitializeComponent();
        }

        private void PolicyRemoverWizard_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome to the Group Policy Remover Wizard";
            label2.Visible = true;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        //------------------------------------------------Service Functions------------------------------------------------\\
        static Process svc = new Process();
        static Process svc2 = new Process();

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                svcmsg = " " + "and disable the group policy service";
            }
            else
            {
                svcmsg = " " + "and enable the group policy service";
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
        static string OptionName;
        static string svcmsg;

        private void Button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                OptionName = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                OptionName = radioButton2.Text;
            }
            else if (radioButton3.Checked == true)
            {
                OptionName = radioButton3.Text;
            }

            if (radioButton1.Checked == true | radioButton2.Checked == true | radioButton3.Checked == true)
            {
                label1.Text = "Confirm...";
                label2.Visible = false;

                //Configure the MessageBox
                string message = $"Are you sure you want to strip the policies for the selected option [{OptionName}]{svcmsg}?";
                string caption = "Confirm";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
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
                            string svcmessage0 = "The operation completed successfully!";
                            string svccaption0 = "Success";
                            MessageBoxButtons svcbuttons0 = MessageBoxButtons.OK;
                            DialogResult svcresult0;

                            // Displays the MessageBox.
                            svcresult0 = MessageBox.Show(svcmessage0, svccaption0, svcbuttons0, MessageBoxIcon.Information);
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
                            string svcmessage = "Service Enabled Successfully!";
                            string svccaption = "Success";
                            MessageBoxButtons svcbuttons = MessageBoxButtons.OK;
                            DialogResult svcresult;

                            // Displays the MessageBox.
                            svcresult = MessageBox.Show(svcmessage, svccaption, svcbuttons, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //Configure the MessageBox
                            string svcmessage1 = "Something went wrong while enabling the group policy service (e.g. The service is already running).\n\nPlease try again or do it manually through powershell/command prompt.";
                            string svccaption1 = "Error - Unable to Enable Service";
                            MessageBoxButtons svcbuttons1 = MessageBoxButtons.OK;
                            DialogResult svcresult1;

                            // Displays the MessageBox.
                            svcresult1 = MessageBox.Show(svcmessage1, svccaption1, svcbuttons1, MessageBoxIcon.Error);
                        }

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
                            RegistrySecurity ACL = new RegistrySecurity();
                            string toAdd = "Everyone";
                            ACL.AddAccessRule(new RegistryAccessRule(toAdd, RegistryRights.WriteKey | RegistryRights.ReadKey | RegistryRights.Delete | RegistryRights.FullControl, AccessControlType.Allow));

                            RegistryKey desiredKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                            desiredKey.DeleteSubKeyTree("Policies");

                            desiredKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion", true);
                            desiredKey.DeleteSubKeyTree("Policies");
                        }
                        //Both
                        else if (radioButton3.Checked)
                        {
                            RegistrySecurity ACL = new RegistrySecurity();
                            string toAdd = "Everyone";
                            ACL.AddAccessRule(new RegistryAccessRule(toAdd, RegistryRights.WriteKey | RegistryRights.ReadKey | RegistryRights.Delete | RegistryRights.FullControl, AccessControlType.Allow));

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
            else
            {
                //Configure the MessageBox
                string message2 = "No level of action was selected.\n\nPlease select one and try again.";
                string caption2 = "Error - No Selection";
                MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                DialogResult result2;

                // Displays the MessageBox.
                result2 = MessageBox.Show(message2, caption2, buttons2, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}