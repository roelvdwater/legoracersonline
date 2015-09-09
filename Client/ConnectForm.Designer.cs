namespace Client
{
    partial class ConnectForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabConnect = new System.Windows.Forms.TabPage();
            this.nrPort = new System.Windows.Forms.NumericUpDown();
            this.lblInformation = new System.Windows.Forms.Label();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.lblNickname = new System.Windows.Forms.Label();
            this.txtServerAddress = new System.Windows.Forms.TextBox();
            this.lblServerAddress = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabConnect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrPort)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabConnect);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(294, 175);
            this.tabControl.TabIndex = 0;
            // 
            // tabConnect
            // 
            this.tabConnect.Controls.Add(this.nrPort);
            this.tabConnect.Controls.Add(this.lblInformation);
            this.tabConnect.Controls.Add(this.txtNickname);
            this.tabConnect.Controls.Add(this.lblNickname);
            this.tabConnect.Controls.Add(this.txtServerAddress);
            this.tabConnect.Controls.Add(this.lblServerAddress);
            this.tabConnect.Location = new System.Drawing.Point(4, 22);
            this.tabConnect.Name = "tabConnect";
            this.tabConnect.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnect.Size = new System.Drawing.Size(286, 149);
            this.tabConnect.TabIndex = 0;
            this.tabConnect.Text = "Connect to Server";
            this.tabConnect.UseVisualStyleBackColor = true;
            // 
            // nrPort
            // 
            this.nrPort.Location = new System.Drawing.Point(193, 71);
            this.nrPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nrPort.Name = "nrPort";
            this.nrPort.Size = new System.Drawing.Size(71, 20);
            this.nrPort.TabIndex = 1;
            // 
            // lblInformation
            // 
            this.lblInformation.Location = new System.Drawing.Point(15, 15);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(249, 29);
            this.lblInformation.TabIndex = 20;
            this.lblInformation.Text = "Please specify the Server Address, Port and your favourite Nickname.";
            // 
            // txtNickname
            // 
            this.txtNickname.Location = new System.Drawing.Point(18, 113);
            this.txtNickname.MaxLength = 9;
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(169, 20);
            this.txtNickname.TabIndex = 2;
            // 
            // lblNickname
            // 
            this.lblNickname.AutoSize = true;
            this.lblNickname.Location = new System.Drawing.Point(15, 97);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(58, 13);
            this.lblNickname.TabIndex = 17;
            this.lblNickname.Text = "Nickname:";
            // 
            // txtServerAddress
            // 
            this.txtServerAddress.Location = new System.Drawing.Point(18, 71);
            this.txtServerAddress.Name = "txtServerAddress";
            this.txtServerAddress.Size = new System.Drawing.Size(169, 20);
            this.txtServerAddress.TabIndex = 0;
            // 
            // lblServerAddress
            // 
            this.lblServerAddress.AutoSize = true;
            this.lblServerAddress.Location = new System.Drawing.Point(15, 55);
            this.lblServerAddress.Name = "lblServerAddress";
            this.lblServerAddress.Size = new System.Drawing.Size(82, 13);
            this.lblServerAddress.TabIndex = 15;
            this.lblServerAddress.Text = "Server Address:";
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(231, 195);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // ConnectForm
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 230);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Connect to Server";
            this.Load += new System.EventHandler(this.ConnectForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabConnect.ResumeLayout(false);
            this.tabConnect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabConnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtNickname;
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.TextBox txtServerAddress;
        private System.Windows.Forms.Label lblServerAddress;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.NumericUpDown nrPort;

    }
}