using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Group_Policy_CC;

namespace Group_Policy_CC
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------Button Event Handlers------------------------------------------------------------------------\\

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        public void Button2_Click(object sender, EventArgs e)
        {
            Main.MusicControl();
        }


    }
}
