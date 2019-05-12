using System;
using System.Media;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class WallpaperChanger : Form
    {
        public WallpaperChanger()
        {
            InitializeComponent();
        }

        string OSFriendlyName;

        private void WallpaperChanger_Load(object sender, EventArgs e)
        {
            OSFriendlyName = (Application.OpenForms["Main"] as Main).OSFriendlyName();

            if (OSFriendlyName.Contains("Windows 10"))
            {
                Windows10WallpaperChanger();
            }
            else if (OSFriendlyName.Contains("Windows 8"))
            {
                Windows8WallpaperChanger();
            }
            else if (OSFriendlyName.Contains("Windows 7"))
            {
                Windows7WallpaperChanger();
            }
            else
            {
                Unsupported();
            }
        }

        public void Windows10WallpaperChanger()
        {
            tabControl1.SelectedIndex = 0;
        }

        public void Windows8WallpaperChanger()
        {
            tabControl1.SelectedIndex = 1;
        }

        public void Windows7WallpaperChanger()
        {
            tabControl1.SelectedIndex = 2;
        }

        public void Unsupported()
        {
            tabControl1.SelectedIndex = 3;
        }

        //------------------------------------------------------------Button Click Event Handlers------------------------------------------------------------------------\\

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
