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

        string URL;

        private void SekureBrowzer_Load(object sender, EventArgs e)
        {
            BrowserFeatures.SupressCookiePersist();

            URL = string.Empty;

            webBrowser1.Navigate("https://www.bing.ca");

            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void WebBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            URL = webBrowser1.Url.ToString();
            Status.Text = "Loading...";

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
            Status.Text = "Done";

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

        private void WebBrowser1_ProgressChanged(Object sender, WebBrowserProgressChangedEventArgs e)
        {
            progressBar1.Maximum = (int)e.MaximumProgress;
            progressBar1.Value = (int)e.CurrentProgress;
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
            webBrowser1.Navigate("https://www.bing.ca");
        }

        private void TextBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                textBox2.Text = "Bing Search";
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            try
            {
                Process Proc = new Process();

                Proc.StartInfo.FileName = "chrome.exe";

                Proc.Start();

                this.Hide();
            }
            catch
            {
                Process Proc = new Process();

                Proc.StartInfo.FileName = "explorer.exe";
                Proc.StartInfo.Arguments = "https://www.google.com/chrome/";

                Proc.Start();

                this.Hide();
            }
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox2.Text != string.Empty && textBox2.Text != "Bing Search")
                {
                    webBrowser1.Navigate("https://www.bing.com/search?q=" + textBox2.Text);
                }
            }
        }

        private void SekureBrowzer_FormClosing(object sender, FormClosingEventArgs e)
        {
            BrowserFeatures.EndBrowserSession();
            e.Cancel = true;
            this.Hide();
        }
    }
}
