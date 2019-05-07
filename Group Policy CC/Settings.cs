using System;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class Settings : Form
    {
        public Settings()
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

        //------------------------------------------------------------Button Event Handlers------------------------------------------------------------------------\\

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
