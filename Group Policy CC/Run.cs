using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class Run : Form
    {
        public Run()
        {
            InitializeComponent();
        }

        private string filePath = string.Empty;

        private void Run_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            button1.Enabled = false;
            filePath = string.Empty;

            textBox1.Focus();

            CheckElevation();
        }


        private void CheckElevation()
        {
            if (Hub.IsAdministrator())
            {
                label3.Visible = true;
                pictureBox2.Visible = true;
            }
            else
            {
                label3.Visible = false;
                pictureBox2.Visible = false;
            }
        }

        private void RunProcessSelector()
        {
            if (Hub.IsAdministrator())
            {
                RunProcessAdmin();
            }
            else
            {
                RunProcessLimited();
            }
        }

        private void RunProcessAdmin()
        {
            try
            {
                Process Proc = new Process();
                Proc.StartInfo.Verb = "runas";
                Proc.StartInfo.FileName = filePath;

                Proc.Start();

                this.Close();
            }
            catch
            {
                string Body = $"Windows cannot find '{filePath}'. Make sure you've typed the name correctly, then try again.";

                MessageBox.Show(Body, filePath, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RunProcessLimited()
        {
            try
            {
                Process Proc = new Process();
                Proc.StartInfo.FileName = filePath;

                Proc.Start();

                this.Close();
            }
            catch
            {
                string Body = $"Windows cannot find '{filePath}'. Make sure you've typed the name correctly, then try again.";

                MessageBox.Show(Body, filePath, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RunProcessSelector();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string WinDir = Environment.GetEnvironmentVariable("windir");

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = WinDir + "\\System32";
                openFileDialog.Filter = "Executable files (*.exe) | *.exe";
                openFileDialog.FilterIndex = 2;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName.ToString();
                    textBox1.Text = filePath.ToString();
                }
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            filePath = textBox1.Text;

            if (textBox1.Text.Equals(""))
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RunProcessSelector();
            }
        }

        private void Run_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
        }
    }
}
