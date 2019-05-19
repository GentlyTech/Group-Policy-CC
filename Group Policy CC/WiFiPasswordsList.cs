using System;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class WiFiPasswordsList : Form
    {
        Form WifiPasswordsListRaw = new WiFiPasswordsListRaw();

        public WiFiPasswordsList()
        {
            InitializeComponent();
        }

        private void WiFiPasswordsList_Load(object sender, EventArgs e)
        {
            GetNetworkProfiles();
        }

        private void GetNetworkProfiles()
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GetNetworkProfiles();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            WifiPasswordsListRaw.ShowDialog();
        }
    }
}
