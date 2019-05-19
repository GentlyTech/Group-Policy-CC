using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class WiFiPasswordsListRaw : Form
    {
        public WiFiPasswordsListRaw()
        {
            InitializeComponent();
        }

        string SSID;

        private void WiFiPasswordsList_Load(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            GetNetworkProfiles();
        }

        private void GetNetworkProfiles()
        {
            Process netsh = new Process();
            netsh.StartInfo.FileName = "netsh.exe";
            netsh.StartInfo.Arguments = $"wlan show profiles {SSID} key=clear";
            netsh.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            netsh.StartInfo.CreateNoWindow = true;
            netsh.StartInfo.UseShellExecute = false;
            netsh.StartInfo.RedirectStandardOutput = true;
            netsh.Start();

            using (StreamReader reader = netsh.StandardOutput)
            {
                while (!netsh.StandardOutput.EndOfStream)
                {
                    string line = netsh.StandardOutput.ReadToEnd();

                    richTextBox1.Text = line;
                }


            }

            netsh.WaitForExit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GetNetworkProfiles();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SSID = textBox1.Text;
                GetNetworkProfiles();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            SSID = string.Empty;
            GetNetworkProfiles();
        }

        string filePath = string.Empty;

        private void Button4_Click(object sender, EventArgs e)
        {
            using (var Browser = new SaveFileDialog())
            {
                string InitialDir = Environment.SpecialFolder.UserProfile + "\\Downloads";

                Browser.Filter = "Text File (*.txt) | *.txt|All Files (*.*) | *.*";
                Browser.FileName = "Exported WiFi Profile";
                Browser.InitialDirectory = InitialDir;
                DialogResult result = Browser.ShowDialog();

                if (result == DialogResult.OK)
                {
                    filePath = Browser.FileName.ToString();

                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        FileOut();
                    }
                }
                else
                {
                    MessageBox.Show("Operation Cancellled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    private void FileOut()
    {
        try
        {
            File.WriteAllText(filePath, richTextBox1.Text);

            DialogResult Response;
            Response = MessageBox.Show("Data exported successfully. Would you like to open the file?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (Response == DialogResult.Yes)
            {
                Process.Start("explorer.exe", filePath);
            }

        }
        catch (UnauthorizedAccessException)
        {
            MessageBox.Show("Access is denied. Try writing to a different location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
}
