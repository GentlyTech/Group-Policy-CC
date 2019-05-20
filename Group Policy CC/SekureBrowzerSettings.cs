using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class SekureBrowzerSettings : Form
    {
        public SekureBrowzerSettings()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            try
            {
                Process Proc = new Process();

                Proc.StartInfo.FileName = "chrome.exe";

                Proc.Start();

                this.Close();
            }
            catch
            {
                Process Proc = new Process();

                Proc.StartInfo.FileName = "explorer.exe";
                Proc.StartInfo.Arguments = "https://www.google.com/chrome/";

                Proc.Start();

                this.Close();
            }
        }
    }
}
