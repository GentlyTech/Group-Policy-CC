using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class KeybindWizard : Form
    {
        public KeybindWizard()
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

        private void Button3_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            string WinDir = Environment.GetEnvironmentVariable("windir");

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = WinDir + "\\System32";
                openFileDialog.Filter = "Executable files (*.exe) | *.exe";
                openFileDialog.FileName = "cmd.exe";
                openFileDialog.FilterIndex = 2;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.SafeFileName;
                    textBox1.Text = filePath;
                }
            }

        }
    }
}
