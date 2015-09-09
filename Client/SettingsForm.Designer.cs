namespace Client
{
    partial class SettingsForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkSkipIntroVideo = new System.Windows.Forms.CheckBox();
            this.chkOverwriteDefaults = new System.Windows.Forms.CheckBox();
            this.chkWindowedMode = new System.Windows.Forms.CheckBox();
            this.nrDefaultPort = new System.Windows.Forms.NumericUpDown();
            this.txtDefaultServerAddress = new System.Windows.Forms.TextBox();
            this.lblDefaultServerAddress = new System.Windows.Forms.Label();
            this.txtDefaultNickname = new System.Windows.Forms.TextBox();
            this.lblDefaultNickname = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lnkResetSettings = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrDefaultPort)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lnkResetSettings);
            this.panel1.Controls.Add(this.chkSkipIntroVideo);
            this.panel1.Controls.Add(this.chkOverwriteDefaults);
            this.panel1.Controls.Add(this.chkWindowedMode);
            this.panel1.Controls.Add(this.nrDefaultPort);
            this.panel1.Controls.Add(this.txtDefaultServerAddress);
            this.panel1.Controls.Add(this.lblDefaultServerAddress);
            this.panel1.Controls.Add(this.txtDefaultNickname);
            this.panel1.Controls.Add(this.lblDefaultNickname);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 168);
            this.panel1.TabIndex = 0;
            // 
            // chkSkipIntroVideo
            // 
            this.chkSkipIntroVideo.AutoSize = true;
            this.chkSkipIntroVideo.Location = new System.Drawing.Point(15, 116);
            this.chkSkipIntroVideo.Name = "chkSkipIntroVideo";
            this.chkSkipIntroVideo.Size = new System.Drawing.Size(99, 17);
            this.chkSkipIntroVideo.TabIndex = 9;
            this.chkSkipIntroVideo.Text = "Skip intro video";
            this.chkSkipIntroVideo.UseVisualStyleBackColor = true;
            // 
            // chkOverwriteDefaults
            // 
            this.chkOverwriteDefaults.AutoSize = true;
            this.chkOverwriteDefaults.Location = new System.Drawing.Point(15, 139);
            this.chkOverwriteDefaults.Name = "chkOverwriteDefaults";
            this.chkOverwriteDefaults.Size = new System.Drawing.Size(211, 17);
            this.chkOverwriteDefaults.TabIndex = 8;
            this.chkOverwriteDefaults.Text = "Overwrite defaults when joining a game";
            this.chkOverwriteDefaults.UseVisualStyleBackColor = true;
            // 
            // chkWindowedMode
            // 
            this.chkWindowedMode.AutoSize = true;
            this.chkWindowedMode.Location = new System.Drawing.Point(15, 93);
            this.chkWindowedMode.Name = "chkWindowedMode";
            this.chkWindowedMode.Size = new System.Drawing.Size(186, 17);
            this.chkWindowedMode.TabIndex = 7;
            this.chkWindowedMode.Text = "Launch game in Windowed Mode";
            this.chkWindowedMode.UseVisualStyleBackColor = true;
            // 
            // nrDefaultPort
            // 
            this.nrDefaultPort.Location = new System.Drawing.Point(190, 67);
            this.nrDefaultPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nrDefaultPort.Name = "nrDefaultPort";
            this.nrDefaultPort.Size = new System.Drawing.Size(71, 20);
            this.nrDefaultPort.TabIndex = 6;
            // 
            // txtDefaultServerAddress
            // 
            this.txtDefaultServerAddress.Location = new System.Drawing.Point(15, 67);
            this.txtDefaultServerAddress.Name = "txtDefaultServerAddress";
            this.txtDefaultServerAddress.Size = new System.Drawing.Size(169, 20);
            this.txtDefaultServerAddress.TabIndex = 5;
            // 
            // lblDefaultServerAddress
            // 
            this.lblDefaultServerAddress.AutoSize = true;
            this.lblDefaultServerAddress.Location = new System.Drawing.Point(12, 51);
            this.lblDefaultServerAddress.Name = "lblDefaultServerAddress";
            this.lblDefaultServerAddress.Size = new System.Drawing.Size(119, 13);
            this.lblDefaultServerAddress.TabIndex = 2;
            this.lblDefaultServerAddress.Text = "Default Server Address:";
            // 
            // txtDefaultNickname
            // 
            this.txtDefaultNickname.Location = new System.Drawing.Point(15, 25);
            this.txtDefaultNickname.Name = "txtDefaultNickname";
            this.txtDefaultNickname.Size = new System.Drawing.Size(169, 20);
            this.txtDefaultNickname.TabIndex = 1;
            // 
            // lblDefaultNickname
            // 
            this.lblDefaultNickname.AutoSize = true;
            this.lblDefaultNickname.Location = new System.Drawing.Point(12, 9);
            this.lblDefaultNickname.Name = "lblDefaultNickname";
            this.lblDefaultNickname.Size = new System.Drawing.Size(95, 13);
            this.lblDefaultNickname.TabIndex = 0;
            this.lblDefaultNickname.Text = "Default Nickname:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(363, 178);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(282, 178);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lnkResetSettings
            // 
            this.lnkResetSettings.AutoSize = true;
            this.lnkResetSettings.Location = new System.Drawing.Point(369, 5);
            this.lnkResetSettings.Name = "lnkResetSettings";
            this.lnkResetSettings.Size = new System.Drawing.Size(74, 13);
            this.lnkResetSettings.TabIndex = 10;
            this.lnkResetSettings.TabStop = true;
            this.lnkResetSettings.Text = "Reset settings";
            this.lnkResetSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkResetSettings_LinkClicked);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 213);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrDefaultPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDefaultServerAddress;
        private System.Windows.Forms.TextBox txtDefaultNickname;
        private System.Windows.Forms.Label lblDefaultNickname;
        private System.Windows.Forms.NumericUpDown nrDefaultPort;
        private System.Windows.Forms.TextBox txtDefaultServerAddress;
        private System.Windows.Forms.CheckBox chkWindowedMode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkOverwriteDefaults;
        private System.Windows.Forms.CheckBox chkSkipIntroVideo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel lnkResetSettings;
    }
}