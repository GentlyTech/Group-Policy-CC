using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class AdminHijacker : Form
    {
        public AdminHijacker()
        {
            InitializeComponent();
        }

        static Process net = new Process();

        private void AdminHijacker_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome to the Local Administrator password changer";
            label2.Visible = true;

            textBox1.Text = "";
            textBox2.Text = "";
        }

        //------------------------------------------------Button Functions------------------------------------------------\\
        private void Button1_Click(object sender, EventArgs e)
        {
            //Configure the MessageBox
            string message = "Are you sure you want to change the password for the Local Administrator account?\n\nYour Administrator will not be able to log on with their credentials anymore.";
            string caption = "Confirm";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Exclamation);

            if(result == DialogResult.Yes)
            {
                label1.Text = "Verifying...";
                label2.Visible = false;

                string password = textBox1.Text.ToString();
                string confirmpassword = textBox2.Text.ToString();

                if (!password.Contains("*") && !password.Equals(""))
                {
                    if (password == confirmpassword)
                    {
                        net.StartInfo.FileName = "net.exe";
                        net.StartInfo.Arguments = $"user Administrator {password} /active:yes";

                        net.StartInfo.CreateNoWindow = true;
                        net.StartInfo.UseShellExecute = false;

                        net.Start();
                        net.WaitForExit();

                        PasswordChangeStatus();

                        if (PasswordChangeStatus())
                        {
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
                            string message1 = "An error occurred and the password was not set.\n\nPlease try again.";
                            string caption1 = "Error - Unable to Set Password";
                            MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                            DialogResult result1;

                            // Displays the MessageBox.
                            result1 = MessageBox.Show(message1, caption1, buttons1, MessageBoxIcon.Error);

                            this.Close();
                        }
                    }
                    else if (password != confirmpassword)
                    {
                        //Configure the MessageBox
                        string message2 = "The passwords entered do not match.\n\nPlease try again.";
                        string caption2 = "Non-Matching Passwords";
                        MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                        DialogResult result2;

                        // Displays the MessageBox.
                        result2 = MessageBox.Show(message2, caption2, buttons2, MessageBoxIcon.Error);

                        this.Close();
                    }
                }
                else if (password.Contains("*"))
                {
                    //Configure the MessageBox
                    string message1 = "An invalid character was entered.\n\nPlease try again.";
                    string caption1 = "Invalid Password";
                    MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                    DialogResult result1;

                    // Displays the MessageBox.
                    result1 = MessageBox.Show(message1, caption1, buttons1, MessageBoxIcon.Error);

                    this.Close();
                }
                else if (password.Equals(""))
                {
                    //Configure the MessageBox
                    string message1 = "No password was supplied.\n\nPlease try again.";
                    string caption1 = "Invalid Password";
                    MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                    DialogResult result1;

                    // Displays the MessageBox.
                    result1 = MessageBox.Show(message1, caption1, buttons1, MessageBoxIcon.Error);

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

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //------------------------------------------------Bool Functions (To check if an operation was completed)------------------------------------------------\\

        private bool PasswordChangeStatus()
        {
            if (net.ExitCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //------------------------------------------------Checkbox Function------------------------------------------------\\
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Process net = new Process();

                net.StartInfo.FileName = "net.exe";
                net.StartInfo.Arguments = "accounts /minpwlen:0";

                net.StartInfo.CreateNoWindow = true;
                net.StartInfo.UseShellExecute = false;

                net.Start();

            }
        }
    }
}