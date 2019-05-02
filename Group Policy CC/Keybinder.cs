using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class Keybinder : Form
    {
        public Keybinder()
        {
            InitializeComponent();
        }
        //------------------------------------------------Button Functions------------------------------------------------\\
        private void Button1_Click(object sender, EventArgs e)
        {
            //Configure the MessageBox
            string message = "Not Implemented";
            string caption = "Error";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);

            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
