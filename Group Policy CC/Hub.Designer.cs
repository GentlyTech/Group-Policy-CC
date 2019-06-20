using System.Drawing;
using System.Windows.Forms;

namespace Group_Policy_CC
{
    partial class Hub
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hub));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relaunchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsControlPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openModernSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openClassicControlPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.netplWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userAccountControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registryEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.microsoftManagementConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rootConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computerManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.groupPolicyEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localUsersAndGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Clock1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Banner1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Banner2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Clock2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.Version = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Banner1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Banner2)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.settingsControlPanelToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1136, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.relaunchToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // relaunchToolStripMenuItem
            // 
            this.relaunchToolStripMenuItem.Image = global::Group_Policy_CC.Properties.Resources.UACShield;
            this.relaunchToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.relaunchToolStripMenuItem.Name = "relaunchToolStripMenuItem";
            this.relaunchToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.relaunchToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.relaunchToolStripMenuItem.Text = "Run as Administrator";
            this.relaunchToolStripMenuItem.Click += new System.EventHandler(this.RelaunchToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // settingsControlPanelToolStripMenuItem
            // 
            this.settingsControlPanelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskManagerToolStripMenuItem,
            this.windowsSettingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.netplWizardToolStripMenuItem,
            this.userAccountControlToolStripMenuItem,
            this.registryEditorToolStripMenuItem,
            this.toolStripSeparator1,
            this.microsoftManagementConsoleToolStripMenuItem});
            this.settingsControlPanelToolStripMenuItem.Name = "settingsControlPanelToolStripMenuItem";
            this.settingsControlPanelToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.settingsControlPanelToolStripMenuItem.Text = "Administrative Programs";
            // 
            // taskManagerToolStripMenuItem
            // 
            this.taskManagerToolStripMenuItem.Name = "taskManagerToolStripMenuItem";
            this.taskManagerToolStripMenuItem.Size = new System.Drawing.Size(304, 26);
            this.taskManagerToolStripMenuItem.Text = "Task Manager";
            this.taskManagerToolStripMenuItem.Click += new System.EventHandler(this.TaskManagerToolStripMenuItem_Click);
            // 
            // windowsSettingsToolStripMenuItem
            // 
            this.windowsSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openModernSettingsToolStripMenuItem,
            this.openClassicControlPanelToolStripMenuItem});
            this.windowsSettingsToolStripMenuItem.Name = "windowsSettingsToolStripMenuItem";
            this.windowsSettingsToolStripMenuItem.Size = new System.Drawing.Size(304, 26);
            this.windowsSettingsToolStripMenuItem.Text = "Windows Settings";
            // 
            // openModernSettingsToolStripMenuItem
            // 
            this.openModernSettingsToolStripMenuItem.Name = "openModernSettingsToolStripMenuItem";
            this.openModernSettingsToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.openModernSettingsToolStripMenuItem.Text = "Open Modern Settings (Windows 10 Only)";
            this.openModernSettingsToolStripMenuItem.Click += new System.EventHandler(this.OpenModernSettingsToolStripMenuItem_Click_1);
            // 
            // openClassicControlPanelToolStripMenuItem
            // 
            this.openClassicControlPanelToolStripMenuItem.Name = "openClassicControlPanelToolStripMenuItem";
            this.openClassicControlPanelToolStripMenuItem.Size = new System.Drawing.Size(370, 26);
            this.openClassicControlPanelToolStripMenuItem.Text = "Open Classic Control Panel";
            this.openClassicControlPanelToolStripMenuItem.Click += new System.EventHandler(this.OpenClassicControlPanelToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(301, 6);
            // 
            // netplWizardToolStripMenuItem
            // 
            this.netplWizardToolStripMenuItem.Image = global::Group_Policy_CC.Properties.Resources.UACShield;
            this.netplWizardToolStripMenuItem.Name = "netplWizardToolStripMenuItem";
            this.netplWizardToolStripMenuItem.Size = new System.Drawing.Size(304, 26);
            this.netplWizardToolStripMenuItem.Text = "Net Places Wizard (Netplwiz)";
            this.netplWizardToolStripMenuItem.Click += new System.EventHandler(this.NetplWizardToolStripMenuItem_Click);
            // 
            // userAccountControlToolStripMenuItem
            // 
            this.userAccountControlToolStripMenuItem.Image = global::Group_Policy_CC.Properties.Resources.UACShield;
            this.userAccountControlToolStripMenuItem.Name = "userAccountControlToolStripMenuItem";
            this.userAccountControlToolStripMenuItem.Size = new System.Drawing.Size(304, 26);
            this.userAccountControlToolStripMenuItem.Text = "User Account Control";
            this.userAccountControlToolStripMenuItem.Click += new System.EventHandler(this.UserAccountControlToolStripMenuItem_Click);
            // 
            // registryEditorToolStripMenuItem
            // 
            this.registryEditorToolStripMenuItem.Image = global::Group_Policy_CC.Properties.Resources.UACShield;
            this.registryEditorToolStripMenuItem.Name = "registryEditorToolStripMenuItem";
            this.registryEditorToolStripMenuItem.Size = new System.Drawing.Size(304, 26);
            this.registryEditorToolStripMenuItem.Text = "Registry Editor";
            this.registryEditorToolStripMenuItem.Click += new System.EventHandler(this.RegistryEditorToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(301, 6);
            // 
            // microsoftManagementConsoleToolStripMenuItem
            // 
            this.microsoftManagementConsoleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rootConsoleToolStripMenuItem,
            this.computerManagementToolStripMenuItem,
            this.toolStripMenuItem2,
            this.groupPolicyEditorToolStripMenuItem,
            this.localUsersAndGroupsToolStripMenuItem,
            this.servicesToolStripMenuItem});
            this.microsoftManagementConsoleToolStripMenuItem.Image = global::Group_Policy_CC.Properties.Resources.UACShield;
            this.microsoftManagementConsoleToolStripMenuItem.Name = "microsoftManagementConsoleToolStripMenuItem";
            this.microsoftManagementConsoleToolStripMenuItem.Size = new System.Drawing.Size(304, 26);
            this.microsoftManagementConsoleToolStripMenuItem.Text = "Microsoft Management Console";
            // 
            // rootConsoleToolStripMenuItem
            // 
            this.rootConsoleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rootConsoleToolStripMenuItem.Image")));
            this.rootConsoleToolStripMenuItem.Name = "rootConsoleToolStripMenuItem";
            this.rootConsoleToolStripMenuItem.Size = new System.Drawing.Size(339, 26);
            this.rootConsoleToolStripMenuItem.Text = "Root Console";
            this.rootConsoleToolStripMenuItem.Click += new System.EventHandler(this.RootConsoleToolStripMenuItem_Click);
            // 
            // computerManagementToolStripMenuItem
            // 
            this.computerManagementToolStripMenuItem.Image = global::Group_Policy_CC.Properties.Resources.UACShield;
            this.computerManagementToolStripMenuItem.Name = "computerManagementToolStripMenuItem";
            this.computerManagementToolStripMenuItem.Size = new System.Drawing.Size(339, 26);
            this.computerManagementToolStripMenuItem.Text = "Computer Management";
            this.computerManagementToolStripMenuItem.Click += new System.EventHandler(this.ComputerManagementToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(336, 6);
            // 
            // groupPolicyEditorToolStripMenuItem
            // 
            this.groupPolicyEditorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("groupPolicyEditorToolStripMenuItem.Image")));
            this.groupPolicyEditorToolStripMenuItem.Name = "groupPolicyEditorToolStripMenuItem";
            this.groupPolicyEditorToolStripMenuItem.Size = new System.Drawing.Size(339, 26);
            this.groupPolicyEditorToolStripMenuItem.Text = "Group Policy Editor";
            this.groupPolicyEditorToolStripMenuItem.Click += new System.EventHandler(this.GroupPolicyEditorToolStripMenuItem_Click);
            // 
            // localUsersAndGroupsToolStripMenuItem
            // 
            this.localUsersAndGroupsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("localUsersAndGroupsToolStripMenuItem.Image")));
            this.localUsersAndGroupsToolStripMenuItem.Name = "localUsersAndGroupsToolStripMenuItem";
            this.localUsersAndGroupsToolStripMenuItem.Size = new System.Drawing.Size(339, 26);
            this.localUsersAndGroupsToolStripMenuItem.Text = "Local Users and Groups (lusrmgr.msc)";
            this.localUsersAndGroupsToolStripMenuItem.Click += new System.EventHandler(this.LocalUsersAndGroupsToolStripMenuItem_Click);
            // 
            // servicesToolStripMenuItem
            // 
            this.servicesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("servicesToolStripMenuItem.Image")));
            this.servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            this.servicesToolStripMenuItem.Size = new System.Drawing.Size(339, 26);
            this.servicesToolStripMenuItem.Text = "Services";
            this.servicesToolStripMenuItem.Click += new System.EventHandler(this.ServicesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutProgramToolStripMenuItem,
            this.aboutWindowsToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // AboutProgramToolStripMenuItem
            // 
            this.AboutProgramToolStripMenuItem.Name = "AboutProgramToolStripMenuItem";
            this.AboutProgramToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.AboutProgramToolStripMenuItem.Text = "About Group Policy CC";
            this.AboutProgramToolStripMenuItem.Click += new System.EventHandler(this.READMEToolStripMenuItem_Click);
            // 
            // aboutWindowsToolStripMenuItem
            // 
            this.aboutWindowsToolStripMenuItem.Name = "aboutWindowsToolStripMenuItem";
            this.aboutWindowsToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.aboutWindowsToolStripMenuItem.Text = "About Windows";
            this.aboutWindowsToolStripMenuItem.Click += new System.EventHandler(this.AboutWindowsToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Arial", 16.2F);
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(555, 159);
            this.button1.TabIndex = 2;
            this.button1.Text = "Strip Group Policies";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("Arial", 16.2F);
            this.button2.Location = new System.Drawing.Point(564, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(555, 159);
            this.button2.TabIndex = 1;
            this.button2.Text = "Hijack Administrator Account";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Font = new System.Drawing.Font("Arial", 16.2F);
            this.button4.Location = new System.Drawing.Point(564, 168);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(555, 159);
            this.button4.TabIndex = 5;
            this.button4.Text = "Run Program";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button5_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.button4, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.button5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.button6, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 127);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1122, 530);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Font = new System.Drawing.Font("Arial", 16.2F);
            this.button3.Location = new System.Drawing.Point(3, 168);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(555, 159);
            this.button3.TabIndex = 3;
            this.button3.Text = "Bind Shift to Launch Program";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Font = new System.Drawing.Font("Arial", 16.2F);
            this.button5.Location = new System.Drawing.Point(3, 333);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(555, 194);
            this.button5.TabIndex = 7;
            this.button5.Text = "Get Wifi Passwords";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button9_Click);
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold);
            this.button6.Location = new System.Drawing.Point(564, 333);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(555, 194);
            this.button6.TabIndex = 6;
            this.button6.Text = ">> More Options >>";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // button9
            // 
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.Font = new System.Drawing.Font("Arial", 16.2F);
            this.button9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button9.Location = new System.Drawing.Point(3, 168);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(555, 159);
            this.button9.TabIndex = 4;
            this.button9.Text = "Change Wallpapers";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Button10_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Clock1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1122, 98);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // Clock1
            // 
            this.Clock1.AutoSize = true;
            this.Clock1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Clock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Clock1.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Bold);
            this.Clock1.Location = new System.Drawing.Point(564, 0);
            this.Clock1.Name = "Clock1";
            this.Clock1.Size = new System.Drawing.Size(555, 98);
            this.Clock1.TabIndex = 16;
            this.Clock1.Text = "[Time]";
            this.Clock1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(555, 98);
            this.label1.TabIndex = 17;
            this.label1.Text = "Welcome to the Group Policy Control Centre!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            this.label1.DoubleClick += new System.EventHandler(this.Label1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1136, 669);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Banner1);
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1128, 660);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Page 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Banner1
            // 
            this.Banner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Banner1.Image = global::Group_Policy_CC.Properties.Resources.Banner;
            this.Banner1.Location = new System.Drawing.Point(3, 101);
            this.Banner1.Name = "Banner1";
            this.Banner1.Size = new System.Drawing.Size(1122, 26);
            this.Banner1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Banner1.TabIndex = 11;
            this.Banner1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Banner2);
            this.tabPage2.Controls.Add(this.tableLayoutPanel3);
            this.tabPage2.Controls.Add(this.tableLayoutPanel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1128, 660);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Page 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Banner2
            // 
            this.Banner2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Banner2.Image = global::Group_Policy_CC.Properties.Resources.Banner;
            this.Banner2.Location = new System.Drawing.Point(3, 101);
            this.Banner2.Name = "Banner2";
            this.Banner2.Size = new System.Drawing.Size(1122, 26);
            this.Banner2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Banner2.TabIndex = 13;
            this.Banner2.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.Clock2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1122, 98);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // Clock2
            // 
            this.Clock2.AutoSize = true;
            this.Clock2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Clock2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Clock2.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Bold);
            this.Clock2.Location = new System.Drawing.Point(564, 0);
            this.Clock2.Name = "Clock2";
            this.Clock2.Size = new System.Drawing.Size(555, 98);
            this.Clock2.TabIndex = 16;
            this.Clock2.Text = "[Time]";
            this.Clock2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(555, 98);
            this.label3.TabIndex = 17;
            this.label3.Text = "More Options";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.button7, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button8, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.button9, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.button10, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.button11, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.button12, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 127);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1122, 530);
            this.tableLayoutPanel4.TabIndex = 12;
            // 
            // button7
            // 
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold);
            this.button7.Location = new System.Drawing.Point(3, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(555, 159);
            this.button7.TabIndex = 2;
            this.button7.Text = "<< Go Back <<";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // button8
            // 
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Font = new System.Drawing.Font("Arial", 16.2F);
            this.button8.Location = new System.Drawing.Point(564, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(555, 159);
            this.button8.TabIndex = 1;
            this.button8.Text = "Install Fortnite";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // button10
            // 
            this.button10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button10.Font = new System.Drawing.Font("Arial", 16.2F);
            this.button10.Location = new System.Drawing.Point(564, 168);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(555, 159);
            this.button10.TabIndex = 5;
            this.button10.Text = "Sekure Browzer";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Button10_Click_1);
            // 
            // button11
            // 
            this.button11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button11.Enabled = false;
            this.button11.Font = new System.Drawing.Font("Arial", 16.2F);
            this.button11.Location = new System.Drawing.Point(3, 333);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(555, 194);
            this.button11.TabIndex = 7;
            this.button11.Text = "[Not Implemented]";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button12.Enabled = false;
            this.button12.Font = new System.Drawing.Font("Arial", 16.2F);
            this.button12.Location = new System.Drawing.Point(564, 333);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(555, 194);
            this.button12.TabIndex = 6;
            this.button12.Text = "[Not Implemented]";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.Dock = System.Windows.Forms.DockStyle.Right;
            this.Version.Location = new System.Drawing.Point(949, 28);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(187, 17);
            this.Version.TabIndex = 12;
            this.Version.Text = "[Windows Version and Build]";
            // 
            // Hub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 697);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Hub";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group Policy CC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.OnResized);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Banner1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Banner2)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relaunchToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label Clock1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label Clock2;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel4;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button12;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Label Version;
        private ToolStripMenuItem settingsControlPanelToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem AboutProgramToolStripMenuItem;
        private ToolStripMenuItem aboutWindowsToolStripMenuItem;
        private ToolStripMenuItem taskManagerToolStripMenuItem;
        private ToolStripMenuItem windowsSettingsToolStripMenuItem;
        private ToolStripMenuItem openModernSettingsToolStripMenuItem;
        private ToolStripMenuItem openClassicControlPanelToolStripMenuItem;
        private ToolStripMenuItem userAccountControlToolStripMenuItem;
        private ToolStripMenuItem microsoftManagementConsoleToolStripMenuItem;
        private ToolStripMenuItem groupPolicyEditorToolStripMenuItem;
        private ToolStripMenuItem localUsersAndGroupsToolStripMenuItem;
        private ToolStripMenuItem netplWizardToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem rootConsoleToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem servicesToolStripMenuItem;
        private Button button11;
        private PictureBox Banner1;
        private PictureBox Banner2;
        private ToolStripMenuItem computerManagementToolStripMenuItem;
        private Button button5;
        private ToolStripMenuItem registryEditorToolStripMenuItem;
    }
}

