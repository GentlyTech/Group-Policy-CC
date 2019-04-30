using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_Policy_Disabler
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
            if(radioButton1.Checked == true)
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
                if (radioButton1.Checked)
                {

                }
                else if (radioButton2.Checked)
                {

                }
                else if (radioButton3.Checked)
                {

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
                string message2 = "The user cancelled the action.";
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
            //Configure the MessageBox
            string message = "The user cancelled the action.";
            string caption = "Cancelled";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);

            this.Close();
        }
    }
}