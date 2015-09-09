namespace Server
{
    partial class ServerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freezeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerUpEnabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redbombToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bluedefenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenspeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yellowsabotageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteBricksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteBricksEnabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.zeroWhiteBricksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneWhiteBricksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoWhiteBricksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.threeWhiteBricksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.allPlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newChallengeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPlayers = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPowerUps = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUpgradeCrystals = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAllPlayersFreeze = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridPlayers = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerCleanUp = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlayers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.gameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(676, 24);
            this.menuStrip1.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::Server.Properties.Resources.delete;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.freezeToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // freezeToolStripMenuItem
            // 
            this.freezeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.powerUpToolStripMenuItem,
            this.whiteBricksToolStripMenuItem,
            this.toolStripSeparator3,
            this.allPlayersToolStripMenuItem});
            this.freezeToolStripMenuItem.Name = "freezeToolStripMenuItem";
            this.freezeToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.freezeToolStripMenuItem.Text = "Freeze...";
            // 
            // powerUpToolStripMenuItem
            // 
            this.powerUpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.powerUpEnabledToolStripMenuItem,
            this.toolStripSeparator1,
            this.noneToolStripMenuItem,
            this.redbombToolStripMenuItem,
            this.bluedefenseToolStripMenuItem,
            this.greenspeedToolStripMenuItem,
            this.yellowsabotageToolStripMenuItem});
            this.powerUpToolStripMenuItem.Name = "powerUpToolStripMenuItem";
            this.powerUpToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.powerUpToolStripMenuItem.Text = "Power-Up";
            // 
            // powerUpEnabledToolStripMenuItem
            // 
            this.powerUpEnabledToolStripMenuItem.Name = "powerUpEnabledToolStripMenuItem";
            this.powerUpEnabledToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.powerUpEnabledToolStripMenuItem.Text = "Enabled";
            this.powerUpEnabledToolStripMenuItem.Click += new System.EventHandler(this.powerUpEnabledToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.noneToolStripMenuItem.Text = "None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.noneToolStripMenuItem_Click);
            // 
            // redbombToolStripMenuItem
            // 
            this.redbombToolStripMenuItem.Name = "redbombToolStripMenuItem";
            this.redbombToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.redbombToolStripMenuItem.Text = "Red (attack)";
            this.redbombToolStripMenuItem.Click += new System.EventHandler(this.redbombToolStripMenuItem_Click);
            // 
            // bluedefenseToolStripMenuItem
            // 
            this.bluedefenseToolStripMenuItem.Name = "bluedefenseToolStripMenuItem";
            this.bluedefenseToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.bluedefenseToolStripMenuItem.Text = "Blue (defense)";
            this.bluedefenseToolStripMenuItem.Click += new System.EventHandler(this.bluedefenseToolStripMenuItem_Click);
            // 
            // greenspeedToolStripMenuItem
            // 
            this.greenspeedToolStripMenuItem.Name = "greenspeedToolStripMenuItem";
            this.greenspeedToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.greenspeedToolStripMenuItem.Text = "Green (speed)";
            this.greenspeedToolStripMenuItem.Click += new System.EventHandler(this.greenspeedToolStripMenuItem_Click);
            // 
            // yellowsabotageToolStripMenuItem
            // 
            this.yellowsabotageToolStripMenuItem.Name = "yellowsabotageToolStripMenuItem";
            this.yellowsabotageToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.yellowsabotageToolStripMenuItem.Text = "Yellow (sabotage)";
            this.yellowsabotageToolStripMenuItem.Click += new System.EventHandler(this.yellowsabotageToolStripMenuItem_Click);
            // 
            // whiteBricksToolStripMenuItem
            // 
            this.whiteBricksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whiteBricksEnabledToolStripMenuItem,
            this.toolStripSeparator2,
            this.zeroWhiteBricksToolStripMenuItem,
            this.oneWhiteBricksToolStripMenuItem,
            this.twoWhiteBricksToolStripMenuItem,
            this.threeWhiteBricksToolStripMenuItem});
            this.whiteBricksToolStripMenuItem.Name = "whiteBricksToolStripMenuItem";
            this.whiteBricksToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.whiteBricksToolStripMenuItem.Text = "White bricks";
            // 
            // whiteBricksEnabledToolStripMenuItem
            // 
            this.whiteBricksEnabledToolStripMenuItem.Name = "whiteBricksEnabledToolStripMenuItem";
            this.whiteBricksEnabledToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.whiteBricksEnabledToolStripMenuItem.Text = "Enabled";
            this.whiteBricksEnabledToolStripMenuItem.Click += new System.EventHandler(this.whiteBricksEnabledToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(113, 6);
            // 
            // zeroWhiteBricksToolStripMenuItem
            // 
            this.zeroWhiteBricksToolStripMenuItem.Name = "zeroWhiteBricksToolStripMenuItem";
            this.zeroWhiteBricksToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.zeroWhiteBricksToolStripMenuItem.Text = "None";
            this.zeroWhiteBricksToolStripMenuItem.Click += new System.EventHandler(this.zeroWhiteBricksToolStripMenuItem_Click);
            // 
            // oneWhiteBricksToolStripMenuItem
            // 
            this.oneWhiteBricksToolStripMenuItem.Name = "oneWhiteBricksToolStripMenuItem";
            this.oneWhiteBricksToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.oneWhiteBricksToolStripMenuItem.Text = "1";
            this.oneWhiteBricksToolStripMenuItem.Click += new System.EventHandler(this.oneWhiteBricksToolStripMenuItem_Click);
            // 
            // twoWhiteBricksToolStripMenuItem
            // 
            this.twoWhiteBricksToolStripMenuItem.Name = "twoWhiteBricksToolStripMenuItem";
            this.twoWhiteBricksToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.twoWhiteBricksToolStripMenuItem.Text = "2";
            this.twoWhiteBricksToolStripMenuItem.Click += new System.EventHandler(this.twoWhiteBricksToolStripMenuItem_Click);
            // 
            // threeWhiteBricksToolStripMenuItem
            // 
            this.threeWhiteBricksToolStripMenuItem.Name = "threeWhiteBricksToolStripMenuItem";
            this.threeWhiteBricksToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.threeWhiteBricksToolStripMenuItem.Text = "3";
            this.threeWhiteBricksToolStripMenuItem.Click += new System.EventHandler(this.threeWhiteBricksToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(136, 6);
            // 
            // allPlayersToolStripMenuItem
            // 
            this.allPlayersToolStripMenuItem.Name = "allPlayersToolStripMenuItem";
            this.allPlayersToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.allPlayersToolStripMenuItem.Text = "All Players";
            this.allPlayersToolStripMenuItem.Click += new System.EventHandler(this.allPlayersToolStripMenuItem_Click);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newChallengeToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newChallengeToolStripMenuItem
            // 
            this.newChallengeToolStripMenuItem.Enabled = false;
            this.newChallengeToolStripMenuItem.Name = "newChallengeToolStripMenuItem";
            this.newChallengeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newChallengeToolStripMenuItem.Text = "New challenge";
            this.newChallengeToolStripMenuItem.Click += new System.EventHandler(this.newChallengeToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblPlayers,
            this.lblPowerUps,
            this.lblUpgradeCrystals,
            this.lblAllPlayersFreeze});
            this.statusStrip.Location = new System.Drawing.Point(0, 281);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(676, 24);
            this.statusStrip.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(85, 19);
            this.lblStatus.Text = "Status: Offline";
            // 
            // lblPlayers
            // 
            this.lblPlayers.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(60, 19);
            this.lblPlayers.Text = "Players: 0";
            // 
            // lblPowerUps
            // 
            this.lblPowerUps.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblPowerUps.Name = "lblPowerUps";
            this.lblPowerUps.Size = new System.Drawing.Size(97, 19);
            this.lblPowerUps.Text = "Power-Ups: Free";
            // 
            // lblUpgradeCrystals
            // 
            this.lblUpgradeCrystals.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblUpgradeCrystals.Name = "lblUpgradeCrystals";
            this.lblUpgradeCrystals.Size = new System.Drawing.Size(128, 19);
            this.lblUpgradeCrystals.Text = "Upgrade Crystals: Free";
            // 
            // lblAllPlayersFreeze
            // 
            this.lblAllPlayersFreeze.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblAllPlayersFreeze.Name = "lblAllPlayersFreeze";
            this.lblAllPlayersFreeze.Size = new System.Drawing.Size(123, 19);
            this.lblAllPlayersFreeze.Text = "All Players Freeze: No";
            // 
            // dataGridPlayers
            // 
            this.dataGridPlayers.AllowUserToAddRows = false;
            this.dataGridPlayers.AllowUserToDeleteRows = false;
            this.dataGridPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPlayers.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPlayers.Location = new System.Drawing.Point(0, 24);
            this.dataGridPlayers.Name = "dataGridPlayers";
            this.dataGridPlayers.ReadOnly = true;
            this.dataGridPlayers.Size = new System.Drawing.Size(676, 257);
            this.dataGridPlayers.TabIndex = 2;
            this.dataGridPlayers.VirtualMode = true;
            this.dataGridPlayers.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridPlayers_CellContextMenuStripNeeded);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kickToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(72, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // kickToolStripMenuItem
            // 
            this.kickToolStripMenuItem.Name = "kickToolStripMenuItem";
            this.kickToolStripMenuItem.Size = new System.Drawing.Size(71, 22);
            this.kickToolStripMenuItem.Text = "Kick";
            this.kickToolStripMenuItem.Click += new System.EventHandler(this.kickToolStripMenuItem_Click);
            // 
            // timerCleanUp
            // 
            this.timerCleanUp.Enabled = true;
            this.timerCleanUp.Interval = 5000;
            this.timerCleanUp.Tick += new System.EventHandler(this.timerCleanUp_Tick);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 305);
            this.Controls.Add(this.dataGridPlayers);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ServerForm";
            this.Text = "LEGO Racers Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerForm_FormClosed);
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlayers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.DataGridView dataGridPlayers;
        private System.Windows.Forms.ToolStripStatusLabel lblPlayers;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freezeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem powerUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redbombToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bluedefenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenspeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yellowsabotageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteBricksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zeroWhiteBricksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneWhiteBricksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoWhiteBricksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem threeWhiteBricksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem powerUpEnabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem whiteBricksEnabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel lblPowerUps;
        private System.Windows.Forms.ToolStripStatusLabel lblUpgradeCrystals;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem allPlayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblAllPlayersFreeze;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newChallengeToolStripMenuItem;
        private System.Windows.Forms.Timer timerCleanUp;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kickToolStripMenuItem;
    }
}

