using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class WallpaperChanger : Form
    {
        public WallpaperChanger()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);

        private const uint SPI_SETDESKWALLPAPER = 0x14;
        private const uint SPIF_UPDATEINIFILE = 0x1;
        private const uint SPIF_SENDWININICHANGE = 0x2;

        string OSFriendlyName;
        string DesktopWallpaperPath = string.Empty;
        string LockscreenWallpaperPath = string.Empty;

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

            ResetWin10Options();
            //ResetWin8Options();
            //ResetWin7Options();
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

        #region Windows 10

        private void ResetWin10Options()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;

            Win10Change1.Enabled = false;
            Win10Change2.Enabled = false;

            Win10FilePathBox1.Enabled = false;
            Win10FilePathBox2.Enabled = false;

            label5.Enabled = false;
            label4.Enabled = false;

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;

            SetWin10.Enabled = false;
        }
        //------------------------------------------------------------Button Click Event Handlers------------------------------------------------------------------------\\

        private void Win10Change1_Click(object sender, EventArgs e)
        {
            string Dir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Dir;
                openFileDialog.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff" + "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|";
                openFileDialog.FilterIndex = 0;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    DesktopWallpaperPath = openFileDialog.FileName.ToString();
                    Win10FilePathBox1.Text = DesktopWallpaperPath;
                    pictureBox1.ImageLocation = DesktopWallpaperPath;
                }
            }
        }

        private void Win10Change2_Click(object sender, EventArgs e)
        {
            string Dir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Dir;
                openFileDialog.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff" + "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|";
                openFileDialog.FilterIndex = 0;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    LockscreenWallpaperPath = openFileDialog.FileName.ToString();
                    Win10FilePathBox2.Text = LockscreenWallpaperPath;
                    pictureBox2.ImageLocation = LockscreenWallpaperPath;
                }
            }
        }

        private void CancelWin10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetWin10_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (Win10FilePathBox1.Text != "Click 'Choose Wallpaper' above to pick a wallpaper.")
                {
                    SetDesktopWallpaper(update_registry:true);
                }
                else
                {
                    MessageBox.Show("Unable to set wallpaper because no wallpaper was supplied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (checkBox2.Checked)
            {
                if (Win10FilePathBox2.Text != "Click 'Choose Wallpaper' above to pick a wallpaper.")
                {
                    SetLockScreenWallpaper();
                }
                else
                {
                    MessageBox.Show("Unable to set wallpaper because no wallpaper was supplied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No option was selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDesktopWallpaper(bool update_registry)
        {
            try
            {
                using (RegistryKey desiredKey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true))
                {
                    desiredKey.SetValue("WallPaper", DesktopWallpaperPath);
                    desiredKey.Close();
                }

                uint flags = 0;
                if (update_registry)
                    flags = SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE;

                if (!SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, DesktopWallpaperPath, flags)) { }

                    MessageBox.Show("Desktop wallpaper set successfully!", "Wallpaper Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("There was an error setting the desktop wallpaper.", "Unable to Set Wallpaper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetLockScreenWallpaper()
        {
            MessageBox.Show("Not Implemented", "Unable to Set Wallpaper", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //------------------------------------------------------------Checkbox Handlers------------------------------------------------------------------------\\
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Win10Change1.Enabled = true;
                Win10FilePathBox1.Enabled = true;

                label4.Enabled = true;
                pictureBox1.Visible = true;

                ToggleSetButton();
            }
            else
            {
                Win10Change1.Enabled = false;
                Win10FilePathBox1.Enabled = false;

                label4.Enabled = false;
                pictureBox1.Visible = false;

                ToggleSetButton();
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                Win10Change2.Enabled = true;
                Win10FilePathBox2.Enabled = true;


                label5.Enabled = true;
                pictureBox2.Visible = true;

                ToggleSetButton();
            }
            else
            {
                Win10Change2.Enabled = false;
                Win10FilePathBox2.Enabled = false;

                label5.Enabled = false;
                pictureBox2.Visible = false;

                ToggleSetButton();
            }
        }

        private void ToggleSetButton()
        {
            if (checkBox1.Checked || checkBox2.Checked)
            {
                SetWin10.Enabled = true;
            }
            else
            {
                SetWin10.Enabled = false;
            }
        }

        #endregion

        #region Windows 8

        #endregion

        #region Windows 7

        #endregion

        #region Unsupported

        private void Unsupported_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
