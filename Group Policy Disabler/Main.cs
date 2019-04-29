using System;
using System.Globalization;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Clock
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            timer1.Start();
        }

        [DllImport("ntdll.dll")]
        public static extern uint RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

        [DllImport("ntdll.dll")]
        public static extern uint NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);

        //------------------------------------------------------------------------------------------------------------------------------------\\
        private void timer1_Tick(object sender, EventArgs e)
        {
            var CurrentTime = DateTime.Now;

            string formattedTimeNow = CurrentTime.ToString("h:mm:ss tt", CultureInfo.InvariantCulture);

            Time.Text = formattedTimeNow;
        }

        //------------------------------------------------------------Tool Strip Functions------------------------------------------------------------------------\\

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void RelaunchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }

        private void shutdownThisPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Configure the MessageBox
            string message = "Are you sure you want to blue screen this computer?\n\nAny unsaved work will be lost, and there is a risk that something could break (e.g. There is a Windows Update in progress).\n\nWe are not responsible for any damage or data loss caused as a result of this feature.";
            string caption = "Confirm Blue Screen";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                bool t1;
                uint t2;
                RtlAdjustPrivilege(19, true, false, out t1);
                NtRaiseHardError(0xc0000022, 0, 0, IntPtr.Zero, 6, out t2);
            }
        }
    }
}
