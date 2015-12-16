namespace AISC_Team10_AI_Symptom_Checker
{
    partial class frmMainUser
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
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.asdf = new System.Windows.Forms.Panel();
            this.grpBoxActivityLog = new System.Windows.Forms.GroupBox();
            this.lblState = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnLogout = new System.Windows.Forms.Button();
            this.linklblViewDiagnostic = new System.Windows.Forms.LinkLabel();
            this.linklblViewPrecription = new System.Windows.Forms.LinkLabel();
            this.linklblLinkAccMng = new System.Windows.Forms.LinkLabel();
            this.linklblAppoinment = new System.Windows.Forms.LinkLabel();
            this.linklblCheckHealth = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.usrCtrlAvatar = new AISC_Team10_AI_Symptom_Checker.usrCtrlAvatar();
            this.timerUpdateRequestCount = new System.Windows.Forms.Timer(this.components);
            this.timerUpdateUserState = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(913, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 566);
            this.label6.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(222, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 566);
            this.label1.TabIndex = 38;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // linkLabel6
            // 
            this.linkLabel6.AutoSize = true;
            this.linkLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel6.Location = new System.Drawing.Point(5, 301);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(57, 16);
            this.linkLabel6.TabIndex = 40;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Text = "Games";
            // 
            // asdf
            // 
            this.asdf.Location = new System.Drawing.Point(239, 337);
            this.asdf.Name = "asdf";
            this.asdf.Size = new System.Drawing.Size(668, 253);
            this.asdf.TabIndex = 35;
            // 
            // grpBoxActivityLog
            // 
            this.grpBoxActivityLog.Location = new System.Drawing.Point(239, 67);
            this.grpBoxActivityLog.Name = "grpBoxActivityLog";
            this.grpBoxActivityLog.Size = new System.Drawing.Size(668, 247);
            this.grpBoxActivityLog.TabIndex = 34;
            this.grpBoxActivityLog.TabStop = false;
            this.grpBoxActivityLog.Text = "Activity log";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(238, 33);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(287, 15);
            this.lblState.TabIndex = 0;
            this.lblState.Text = "hh:mm:ss # heartbeat - emotion - sentiment";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(929, 24);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(201, 566);
            this.listView1.TabIndex = 33;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(47, 555);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 32;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // linklblViewDiagnostic
            // 
            this.linklblViewDiagnostic.AutoSize = true;
            this.linklblViewDiagnostic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblViewDiagnostic.Location = new System.Drawing.Point(8, 232);
            this.linklblViewDiagnostic.Name = "linklblViewDiagnostic";
            this.linklblViewDiagnostic.Size = new System.Drawing.Size(117, 16);
            this.linklblViewDiagnostic.TabIndex = 31;
            this.linklblViewDiagnostic.TabStop = true;
            this.linklblViewDiagnostic.Text = "View diagnostic";
            // 
            // linklblViewPrecription
            // 
            this.linklblViewPrecription.AutoSize = true;
            this.linklblViewPrecription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblViewPrecription.Location = new System.Drawing.Point(5, 270);
            this.linklblViewPrecription.Name = "linklblViewPrecription";
            this.linklblViewPrecription.Size = new System.Drawing.Size(127, 16);
            this.linklblViewPrecription.TabIndex = 30;
            this.linklblViewPrecription.TabStop = true;
            this.linklblViewPrecription.Text = "View precriptions";
            // 
            // linklblLinkAccMng
            // 
            this.linklblLinkAccMng.AutoSize = true;
            this.linklblLinkAccMng.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblLinkAccMng.Location = new System.Drawing.Point(8, 197);
            this.linklblLinkAccMng.Name = "linklblLinkAccMng";
            this.linklblLinkAccMng.Size = new System.Drawing.Size(147, 16);
            this.linklblLinkAccMng.TabIndex = 29;
            this.linklblLinkAccMng.TabStop = true;
            this.linklblLinkAccMng.Text = "Linking Account - (0)";
            this.linklblLinkAccMng.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblLinkAccMng_LinkClicked);
            // 
            // linklblAppoinment
            // 
            this.linklblAppoinment.AutoSize = true;
            this.linklblAppoinment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblAppoinment.Location = new System.Drawing.Point(8, 160);
            this.linklblAppoinment.Name = "linklblAppoinment";
            this.linklblAppoinment.Size = new System.Drawing.Size(90, 16);
            this.linklblAppoinment.TabIndex = 28;
            this.linklblAppoinment.TabStop = true;
            this.linklblAppoinment.Text = "Appoinment";
            // 
            // linklblCheckHealth
            // 
            this.linklblCheckHealth.AutoSize = true;
            this.linklblCheckHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblCheckHealth.Location = new System.Drawing.Point(8, 123);
            this.linklblCheckHealth.Name = "linklblCheckHealth";
            this.linklblCheckHealth.Size = new System.Drawing.Size(97, 16);
            this.linklblCheckHealth.TabIndex = 27;
            this.linklblCheckHealth.TabStop = true;
            this.linklblCheckHealth.Text = "Check health";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1130, 24);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // usrCtrlAvatar
            // 
            this.usrCtrlAvatar.Info = null;
            this.usrCtrlAvatar.Location = new System.Drawing.Point(8, 33);
            this.usrCtrlAvatar.Name = "usrCtrlAvatar";
            this.usrCtrlAvatar.Size = new System.Drawing.Size(208, 53);
            this.usrCtrlAvatar.TabIndex = 37;
            // 
            // timerUpdateRequestCount
            // 
            this.timerUpdateRequestCount.Interval = 10000;
            this.timerUpdateRequestCount.Tick += new System.EventHandler(this.timerUpdateRequestCount_Tick);
            // 
            // timerUpdateUserState
            // 
            this.timerUpdateUserState.Interval = 1000;
            this.timerUpdateUserState.Tick += new System.EventHandler(this.timerUpdateUserState_Tick);
            // 
            // frmMainUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 590);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usrCtrlAvatar);
            this.Controls.Add(this.linkLabel6);
            this.Controls.Add(this.asdf);
            this.Controls.Add(this.grpBoxActivityLog);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.linklblViewDiagnostic);
            this.Controls.Add(this.linklblViewPrecription);
            this.Controls.Add(this.linklblLinkAccMng);
            this.Controls.Add(this.linklblAppoinment);
            this.Controls.Add(this.linklblCheckHealth);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmMainUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainUser_FormClosing);
            this.Load += new System.EventHandler(this.frmMainUser_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private usrCtrlAvatar usrCtrlAvatar;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel6;
        private System.Windows.Forms.Panel asdf;
        private System.Windows.Forms.GroupBox grpBoxActivityLog;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.LinkLabel linklblViewDiagnostic;
        private System.Windows.Forms.LinkLabel linklblViewPrecription;
        private System.Windows.Forms.LinkLabel linklblLinkAccMng;
        private System.Windows.Forms.LinkLabel linklblAppoinment;
        private System.Windows.Forms.LinkLabel linklblCheckHealth;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Timer timerUpdateRequestCount;
        private System.Windows.Forms.Timer timerUpdateUserState;

    }
}