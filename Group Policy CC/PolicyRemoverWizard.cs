using Microsoft.Win32;
using System;
using System.Windows.Forms;
using System.Management;
using System.Security.AccessControl;

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

            string wmiQuery = "SELECT * FROM Win32_Service WHERE Name='gpsvc'";
            var searcher = new ManagementObjectSearcher(wmiQuery);
            var results = searcher.Get();

            foreach (ManagementObject service in results)
            {
                Status = service["StartMode"].ToString();
            }
        }


        //------------------------------------------------Check For SVC Status------------------------------------------------\\
        private static string Status;

        //Checks for the enabled startup state of the service
        private static bool CheckForSvc()
        {
            if (!Status.Equals("Disabled"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //------------------------------------------------Service Functions------------------------------------------------\\

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

        //------------------------------------------------Button Functions------------------------------------------------\\
        static string OptionName;
        static string svcmsg;

        private void Button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                DisableSvc();
            }

            ExecuteReg();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //------------------------------------------------Policy Removal Function------------------------------------------------\\

        private void ExecuteReg()
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
            else
            {
                label1.Text = "Welcome to the Group Policy Remover Wizard";
                label2.Visible = true;

                //Configure the MessageBox
                string message2 = "No level of action was selected.\n\nPlease select one and try again.";
                string caption2 = "Error - No Selection";
                MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                DialogResult result2;

                // Displays the MessageBox.
                result2 = MessageBox.Show(message2, caption2, buttons2, MessageBoxIcon.Error);
            }
        }

        //------------------------------------------------Service Modification------------------------------------------------\\

        private void DisableSvc()
        {
            if (CheckForSvc())
            {
                    RegistryKey key;
                    key = Registry.LocalMachine.OpenSubKey(@"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\services\\gpsvc", true);
                    RegistrySecurity rs = new RegistrySecurity();
                    rs = key.GetAccessControl();
                    string Object = "Administrators";
                    rs.AddAccessRule(new RegistryAccessRule(Object, RegistryRights.WriteKey | RegistryRights.ReadKey | RegistryRights.Delete | RegistryRights.FullControl, AccessControlType.Allow));
                

                //Configure the MessageBox
                string svcmessage0 = "The service was disabled successfully! Please reboot the computer for changes to take effect.";
                string svccaption0 = "Success";
                MessageBoxButtons svcbuttons0 = MessageBoxButtons.OK;
                DialogResult svcresult0;

                // Displays the MessageBox.
                svcresult0 = MessageBox.Show(svcmessage0, svccaption0, svcbuttons0, MessageBoxIcon.Information);
            }
        }
     }
}
