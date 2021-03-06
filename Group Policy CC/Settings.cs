﻿using System;
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
            ToggleWelcomeBannerText();
            ToggleImageBannerText();
            ToggleFullscreenText();

            timer1.Start();
        }

        //------------------------------------------------------------Button Event Handlers------------------------------------------------------------------------\\

        private void Button1_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["Hub"] as Hub).ToggleWelcomeBanner();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["Hub"] as Hub).ToggleFullscreen();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["Hub"] as Hub).ToggleImageBanner();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["Hub"] as Hub).ResetSettings();
            button7.Text = "The default settings will apply the next time you launch the program.";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //------------------------------------------------------------Return Functions from Main------------------------------------------------------------------------\\
        public void ToggleWelcomeBannerText()
        {
            if ((Application.OpenForms["Hub"] as Hub).WelcomeBanner1.Visible)
            {
                button1.Text = "Hide Welcome Banner";
            }
            else if (!(Application.OpenForms["Hub"] as Hub).WelcomeBanner1.Visible)
            {
                button1.Text = "Show Welcome Banner";
            }
        }

        public void ToggleImageBannerText()
        {
            if ((Application.OpenForms["Hub"] as Hub).ImageBanner1.Visible)
            {
                button3.Text = "Hide Image Banner";
            }
            else if (!(Application.OpenForms["Hub"] as Hub).ImageBanner1.Visible)
            {
                button3.Text = "Show Image Banner";
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
                button5.Text = "Exit Fullscreen";
            }
            else
            {
                button5.Text = "Enter Fullscreen";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ToggleWelcomeBannerText();
            ToggleImageBannerText();
            ToggleFullscreenText();
        }
    }
}
