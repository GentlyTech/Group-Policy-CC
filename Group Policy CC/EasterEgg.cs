using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    public partial class EasterEgg : Form
    {
        public EasterEgg()
        {
            InitializeComponent();
        }

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
            this.Close();
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
            NukeConfirmation();
        }

        private void NukeConfirmation()
        {
            DialogResult Decision;
            Decision = MessageBox.Show("Are you absolutely sure you want to initiate havoc on Windows?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (Decision == DialogResult.Yes)
            {
                NukeSequence();
            }
            else if (Decision == DialogResult.No)
            {
                MessageBox.Show("Operation Aborted By User", "Aborted", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }

        private void NukeSequence()
        {
            DirectoryInfo TargetDir = new DirectoryInfo(Environment.SpecialFolder.System.ToString());

            var BackupDir = Path.GetPathRoot(Environment.SystemDirectory) + "\\" + "NukePreservation";

            try
            {
                Directory.CreateDirectory(BackupDir);
            }
            catch
            {
                MessageBox.Show("Operation Aborted - Backup Directory Creation Failed", "Aborted", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }

            foreach (var FiletoCopy in TargetDir.EnumerateFiles("ntoskrnl.exe"))
            {
                try
                {
                    FiletoCopy.CopyTo(BackupDir);
                }
                catch
                {
                    MessageBox.Show("Operation Aborted - Backup Failed", "Aborted", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }

                foreach (var FiletoDelete in TargetDir.EnumerateFiles("ntoskrnl.exe"))
                {
                    try
                    {
                        FiletoDelete.Delete();
                    }
                    catch
                    {
                        MessageBox.Show("Operation Aborted - Nuke Failed", "Aborted", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Application.Exit();
                    }
                }
            }
        }
    }
}
