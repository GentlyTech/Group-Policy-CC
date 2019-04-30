using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class AdminHijacker : Form
    {
        public AdminHijacker()
        {
            InitializeComponent();
        }

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
            label1.Text = "Confirm...";
            label2.Visible = false;

            string password = textBox1.Text.ToString();
            string confirmpassword = textBox2.Text.ToString();

            if (password == confirmpassword)
            {
                Process net = new Process();

                net.StartInfo.FileName = "net.exe";
                net.StartInfo.Arguments = $"user Administrator {password}";

                net.StartInfo.CreateNoWindow = true;
                net.StartInfo.UseShellExecute = false;

                net.Start();

                //Configure the MessageBox
                string message1 = "The operation completed successfully!";
                string caption1 = "Success";
                MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                DialogResult result1;

                // Displays the MessageBox.
                result1 = MessageBox.Show(message1, caption1, buttons1, MessageBoxIcon.Information);

                this.Close();

            }
            else if (password != confirmpassword)
            {
                //Configure the MessageBox
                string message2 = "The passwords entered do not match. Please try again.";
                string caption2 = "Non-Matching Passwords";
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
