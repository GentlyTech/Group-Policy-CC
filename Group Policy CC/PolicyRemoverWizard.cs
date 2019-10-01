using Microsoft.Win32;
using System;
using System.Windows.Forms;
using System.Management;
using System.Security.AccessControl;
using System.Runtime.InteropServices;

namespace Group_Policy_CC
{
    public partial class PolicyRemoverWizard : Form
    {
        public PolicyRemoverWizard()
        {
            InitializeComponent();
        }

        #region PInvoke SHDeleteKey

        [DllImport("Advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int RegOpenKeyEx(UIntPtr hKey, string lpSubKey, int ulOptions, int samDesired, out UIntPtr phkResult);

        [DllImport("Advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int RegCloseKey(UIntPtr hKey);

        [DllImport("Shlwapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int SHDeleteKey(UIntPtr hKey, string pszSubKey);

        public const uint HKEY_LOCAL_MACHINE = 0x80000002;
        public const uint HKEY_CURRENT_USER = 0x80000001;

        public const int READ_CONTROL = 0x00020000;
        public const int SYNCHRONIZE = 0x00100000;

        public const int STANDARD_RIGHTS_READ = READ_CONTROL;
        public const int STANDARD_RIGHTS_WRITE = READ_CONTROL;

        public const int KEY_QUERY_VALUE = 0x0001;
        public const int KEY_SET_VALUE = 0x0002;
        public const int KEY_CREATE_SUB_KEY = 0x0004;
        public const int KEY_ENUMERATE_SUB_KEYS = 0x0008;
        public const int KEY_NOTIFY = 0x0010;
        public const int KEY_CREATE_LINK = 0x0020;
        public const int KEY_READ = ((STANDARD_RIGHTS_READ |
                                                           KEY_QUERY_VALUE |
                                                           KEY_ENUMERATE_SUB_KEYS |
                                                           KEY_NOTIFY)
                                                          &
                                                          (~SYNCHRONIZE));

        public const int KEY_WRITE = ((STANDARD_RIGHTS_WRITE |
                                                           KEY_SET_VALUE |
                                                           KEY_CREATE_SUB_KEY)
                                                          &
                                                          (~SYNCHRONIZE));
        public const int KEY_WOW64_64KEY = 0x0100;
        public const int KEY_WOW64_32KEY = 0x0200;

        public const int DELETE = 0x00010000;

        #endregion

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void PolicyRemoverWizard_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome to the Group Policy Remover Wizard";
            label2.Visible = true;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;


            checkBox1.Checked = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
        }

        //------------------------------------------------Button Functions------------------------------------------------\\
        static string OptionName;

        private void Button1_Click(object sender, EventArgs e)
        {
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
                string message = $"Are you sure you want to strip the policies for the selected option [{OptionName}]?";
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
                        DelHKCU();
                    }
                    //Local Machine
                    else if (radioButton2.Checked)
                    {
                        DelHKLM();
                    }
                    //Both
                    else if (radioButton3.Checked)
                    {
                        DelBoth();
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
                label1.Text = "Welcome to the Group Policy Remover Wizard";
                label2.Visible = true;

                MessageBox.Show("No level of action was selected.\n\nPlease select one and try again.", "Error - No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //------------------------------------------------Policy Modification Functions------------------------------------------------\\

        private void DelHKCU()
        {
            try
            {
                UIntPtr hKey;
                int nStatus = RegOpenKeyEx((UIntPtr)HKEY_CURRENT_USER, @"SOFTWARE\Microsoft\Windows\CurrentVersion", 0, DELETE | KEY_READ | KEY_WRITE | KEY_WOW64_64KEY, out hKey);
                if (nStatus == 0)
                {
                    SHDeleteKey(hKey, @"Policies");
                    RegCloseKey(hKey);
                }

                UIntPtr hKey1;
                int nStatus1 = RegOpenKeyEx((UIntPtr)HKEY_CURRENT_USER, @"SOFTWARE", 0, DELETE | KEY_READ | KEY_WRITE | KEY_WOW64_64KEY, out hKey1);
                if (nStatus1 == 0)
                {
                    SHDeleteKey(hKey1, @"Policies");
                    RegCloseKey(hKey1);
                }

                MessageBox.Show("The [Current User] policies were deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                /*using (RegistryKey desiredKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true))
                {
                    desiredKey.DeleteSubKeyTree("Policies");
                }

                using (RegistryKey desiredKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion", true))
                {
                    desiredKey.DeleteSubKeyTree("Policies");
                }
                MessageBox.Show("The [Current User] policies were deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("The [Current User] policies could not be deleted because access is denied.", "Error While Stripping Policies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The [Current User] policies could not be deleted because they do not exist..", "Error While Stripping Policies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void DelHKLM()
        {
            try
            {
                UIntPtr hKey1;
                int nStatus1 = RegOpenKeyEx((UIntPtr)HKEY_LOCAL_MACHINE, @"SOFTWARE\Microsoft\Windows\CurrentVersion", 0, DELETE | KEY_READ | KEY_WRITE | KEY_WOW64_64KEY, out hKey1);
                if (nStatus1 == 0)
                {
                    SHDeleteKey(hKey1, @"Policies");
                    RegCloseKey(hKey1);
                }

                UIntPtr hKey2;
                int nStatus2 = RegOpenKeyEx((UIntPtr)HKEY_LOCAL_MACHINE, @"SOFTWARE", 0, DELETE | KEY_READ | KEY_WRITE | KEY_WOW64_64KEY, out hKey2);
                if (nStatus2 == 0)
                {
                    SHDeleteKey(hKey2, @"Policies");
                    RegCloseKey(hKey2);
                }

                MessageBox.Show("The [Local Machine] policies were deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("The [Local Machine] policies could not be deleted because access is denied.", "Error While Stripping Policies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The [Local Machine] policies could not be deleted because they do not exist.", "Error While Stripping Policies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void DelBoth()
        {
            DelHKCU();
            DelHKLM();
        }

        //------------------------------------------------CheckBox Function------------------------------------------------\\

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
            }
            else
            {
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
            }
        }
    }
}
