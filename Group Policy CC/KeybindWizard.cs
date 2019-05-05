using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class KeybindWizard : Form
    {
        public KeybindWizard()
        {
            InitializeComponent();
        }

        private void KeybindWizard_Load(object sender, EventArgs e)
        {
            sethcExists();
        }

        //------------------------------------------------Variables------------------------------------------------\\

        string UserInput;

        public static bool sethcExists()
        {
            RegistryKey IFEO = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\sethc.exe");

            if (IFEO != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //------------------------------------------------Button Functions------------------------------------------------\\
        private void Button1_Click(object sender, EventArgs e)
        {
            UserInput = textBox1.Text;

            AddDebugger();

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
                    filePath = openFileDialog.FileName;
                    textBox1.Text = filePath;
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            RemoveDebugger();
        }

        //------------------------------------------------Void Functions------------------------------------------------\\

        private void AddDebugger()
        {
            if (!sethcExists())
            {
                RegistryKey sethc = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options", true);
                sethc.CreateSubKey("sethc.exe", true);
            }

            RegistryKey AddDebugger = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\sethc.exe", true);

            AddDebugger.SetValue("Debugger", UserInput, RegistryValueKind.String);

            //Configure the MessageBox
            string message = "Keybind Sucessfully Created";
            string caption = "Success";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
        }

        private void RemoveDebugger()
        {
            if (sethcExists())
            {
                RegistryKey sethc = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options", true);
                sethc.DeleteSubKey("sethc.exe");

                //Configure the MessageBox
                string message = "Keybind Sucessfully Deleted";
                string caption = "Success";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
            }
            else
            {
                //Configure the MessageBox
                string message = "The keybind was not bound to begin with.";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);

                this.Close();
            }
        }
    }
}