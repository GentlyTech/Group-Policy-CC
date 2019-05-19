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

                //Configure the MessageBox
                string message2 = "No level of action was selected.\n\nPlease select one and try again.";
                string caption2 = "Error - No Selection";
                MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                DialogResult result2;

                // Displays the MessageBox.
                result2 = MessageBox.Show(message2, caption2, buttons2, MessageBoxIcon.Error);
            }
        }

        //------------------------------------------------Policy Modification Functions------------------------------------------------\\

        private void DelHKCU()
        {
            try
            {
                using (RegistryKey desiredKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true))
                {
                    desiredKey.DeleteSubKeyTree("Policies");
                }

                using (RegistryKey desiredKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion", true))
                {
                    desiredKey.DeleteSubKeyTree("Policies");
                }

                //Configure the MessageBox
                string message1 = "The [Current User] policies were deleted successfully!";
                string caption1 = "Success";
                MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                DialogResult result1;

                // Displays the MessageBox.
                result1 = MessageBox.Show(message1, caption1, buttons1, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException)
            {
                //Configure the MessageBox
                string message1 = "The [Current User] policies could not be deleted because access is denied.";
                string caption1 = "Error While Stripping Policies";
                MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                DialogResult result1;

                // Displays the MessageBox.
                result1 = MessageBox.Show(message1, caption1, buttons1, MessageBoxIcon.Error);
            }
            catch (ArgumentException)
            {
                //Configure the MessageBox
                string message1 = "The [Current User] policies could not be deleted because they do not exist.";
                string caption1 = "Error While Stripping Policies";
                MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                DialogResult result1;

                // Displays the MessageBox.
                result1 = MessageBox.Show(message1, caption1, buttons1, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void DelHKLM()
        {
            try
            {
                using (RegistryKey desiredKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true))
                {
                    desiredKey.DeleteSubKeyTree("Policies");
                }
            }
            catch (UnauthorizedAccessException)
            {
                //Do not add any exceptions here
            }
            catch (ArgumentException)
            {
                //Configure the MessageBox
                string message1 = "The [Local Machine] policies could not be deleted because they do not exist.";
                string caption1 = "Error While Stripping Policies";
                MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                DialogResult result1;

                // Displays the MessageBox.
                result1 = MessageBox.Show(message1, caption1, buttons1, MessageBoxIcon.Error);
            }
            try
            {
                using (RegistryKey desiredKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion", true))
                {
                    desiredKey.DeleteSubKeyTree("Policies");
                }

                //Configure the MessageBox
                string message1 = "The [Local Machine] policies were deleted successfully!";
                string caption1 = "Success";
                MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                DialogResult result1;

                // Displays the MessageBox.
                result1 = MessageBox.Show(message1, caption1, buttons1, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException)
            {
                //Configure the MessageBox
                string message1 = "The [Local Machine] policies could not be deleted because access is denied.";
                string caption1 = "Error While Stripping Policies";
                MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                DialogResult result1;

                // Displays the MessageBox.
                result1 = MessageBox.Show(message1, caption1, buttons1, MessageBoxIcon.Error);
            }
            catch (ArgumentException)
            {
                //Configure the MessageBox
                string message1 = "The [Local Machine] policies could not be deleted because they do not exist.";
                string caption1 = "Error While Stripping Policies";
                MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                DialogResult result1;

                // Displays the MessageBox.
                result1 = MessageBox.Show(message1, caption1, buttons1, MessageBoxIcon.Error);
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
