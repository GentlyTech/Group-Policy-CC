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

        private void Settings_Load(object sender, EventArgs e)
        {
            //Check Settings State
            ToggleClockText();
            ToggleBannerText();
            ToggleFullscreenText();
        }

        //------------------------------------------------------------Button Event Handlers------------------------------------------------------------------------\\

        private void Button1_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["Hub"] as Hub).ToggleClock();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["Hub"] as Hub).ToggleFullscreen();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["Hub"] as Hub).ToggleBanner();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //------------------------------------------------------------Return Functions from Main------------------------------------------------------------------------\\
        public void ToggleClockText()
        {
            if ((Application.OpenForms["Hub"] as Hub).ClockVisible)
            {
                button1.Text = "Hide Clock";
            }
            else if (!(Application.OpenForms["Hub"] as Hub).ClockVisible)
            {
                button1.Text = "Show Clock";
            }
        }

        public void ToggleBannerText()
        {
            if ((Application.OpenForms["Hub"] as Hub).BannerVisible)
            {
                button3.Text = "Hide Banner";
            }
            else if (!(Application.OpenForms["Hub"] as Hub).BannerVisible)
            {
                button3.Text = "Show Banner";
            }
        }

        /*public void ToggleDarkModeText()
        {
            if ((Application.OpenForms["Hub"] as Hub).DarkMode)
            {
                
            }
            else if (!(Application.OpenForms["Hub"] as Hub).DarkMode)
            {
                
            }
        }*/

        public void ToggleFullscreenText()
        {
            if ((Application.OpenForms["Hub"] as Hub).FormBorderStyle == FormBorderStyle.None)
            {
                button2.Text = "Exit Fullscreen";
            }
            else
            {
                button2.Text = "Enter Fullscreen";
            }
        }
    }
}
