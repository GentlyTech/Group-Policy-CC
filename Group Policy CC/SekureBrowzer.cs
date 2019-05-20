using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class SekureBrowzer : Form
    {
        public SekureBrowzer()
        {            
            InitializeComponent();

            webBrowser1.ScriptErrorsSuppressed = true;
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        string URL;

        private void SekureBrowzer_Load(object sender, EventArgs e)
        {
            timer1.Start();

            ModernBrowser.Modernize();

                BrowserFeatures.SupressCookiePersist();

                URL = string.Empty;

                webBrowser1.Navigate("https://www.google.ca");

                button1.Enabled = false;
                button2.Enabled = false;
        }

        private void WebBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            URL = webBrowser1.Url.ToString();

            if (!webBrowser1.CanGoBack)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }

            if (!webBrowser1.CanGoForward)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                URL = textBox1.Text;
                webBrowser1.Navigate(URL);
            }
        }

        private void WebBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.Text = webBrowser1.Url.ToString();

            if (!webBrowser1.CanGoBack)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }

            if (!webBrowser1.CanGoForward)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void SekureBrowzer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true; // this cancels the close event.
        }

        private void SekureBrowzer_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            BrowserFeatures.EndBrowserSession();
        }

        private void WebBrowser1_ProgressChanged(Object sender, WebBrowserProgressChangedEventArgs e)
        {
            progressBar1.Maximum = (int)e.MaximumProgress;
            progressBar1.Value = (int)e.CurrentProgress;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            CheckForInternetConnection();

            if (CheckForInternetConnection())
            {
                webBrowser1.Visible = true;
            }
            else if (!CheckForInternetConnection())
            {
                webBrowser1.Visible = false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            URL = textBox1.Text;
            webBrowser1.Navigate(URL);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            try
            {
                Process Proc = new Process();

                Proc.StartInfo.FileName = "chrome.exe";

                Proc.Start();
            }
            catch
            {

            }
        }
    }
}
