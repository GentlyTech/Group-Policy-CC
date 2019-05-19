using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class EasterEgg : Form
    {
        public EasterEgg()
        {
            InitializeComponent();
        }

        [DllImport("ntdll.dll")]
        public static extern uint RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

        [DllImport("ntdll.dll")]
        public static extern uint NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);

        private void EasterEgg_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = true;

            Nuke.Enabled = false;
            Nuke.BackColor = Color.Gray;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && radioButton2.Checked)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("You must close the cover before aborting!", "Protocol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Nuke.Enabled = true;
                Nuke.BackColor = Color.Red;

                radioButton1.Enabled = false;
            }
            else
            {
                radioButton1.Enabled = true;
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Nuke.Enabled = false;
                Nuke.BackColor = Color.Gray;

                radioButton2.Enabled = false;
            }
            else
            {
                radioButton2.Enabled = true;
            }
        }

        private void Nuke_Click(object sender, EventArgs e)
        {
            bool t1;
            uint t2;
            RtlAdjustPrivilege(19, true, false, out t1);
            NtRaiseHardError(0xc0000022, 0, 0, IntPtr.Zero, 6, out t2);
        }
    }
}