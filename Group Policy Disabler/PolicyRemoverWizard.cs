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
        public PolicyRemoverWizard()
        {
            InitializeComponent();
        }

        //------------------------------------------------Radio Button Functions------------------------------------------------\\

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        //------------------------------------------------Other Functions------------------------------------------------\\
        private void Button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            label1.Text = "Group Policy Remover";
            label2.Visible = false;
        }
    }
}