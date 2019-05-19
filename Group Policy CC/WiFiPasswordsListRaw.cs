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

        private void WiFiPasswordsList_Load(object sender, EventArgs e)
        {
            GetNetworkProfiles();
        }

        private void GetNetworkProfiles()
        {
            Process netsh = new Process();
            netsh.StartInfo.FileName = "netsh.exe";
            netsh.StartInfo.Arguments = "wlan show profiles * key=clear";
            netsh.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            netsh.StartInfo.CreateNoWindow = true;
            netsh.StartInfo.UseShellExecute = false;
            netsh.StartInfo.RedirectStandardOutput = true;
            netsh.Start();

            using (StreamReader reader = netsh.StandardOutput)
            {
                string result = reader.ReadToEnd();
                richTextBox1.Text = result;
            }

            netsh.WaitForExit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GetNetworkProfiles();
        }
    }
}
