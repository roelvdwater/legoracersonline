namespace Client
{
    partial class WizardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardForm));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlIntro = new System.Windows.Forms.Panel();
            this.lblIntroContent = new System.Windows.Forms.Label();
            this.lblIntroTitle = new System.Windows.Forms.Label();
            this.pnlIdentify = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblIdentifyContent = new System.Windows.Forms.Label();
            this.lblIdentifyTitle = new System.Windows.Forms.Label();
            this.pnlFinished = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFinished = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnFinish = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlIntro.SuspendLayout();
            this.pnlIdentify.SuspendLayout();
            this.pnlFinished.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.picLogo);
            this.pnlMain.Controls.Add(this.pnlIntro);
            this.pnlMain.Controls.Add(this.pnlIdentify);
            this.pnlMain.Controls.Add(this.pnlFinished);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(644, 160);
            this.pnlMain.TabIndex = 3;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::Client.Properties.Resources.lego;
            this.picLogo.Location = new System.Drawing.Point(12, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(136, 136);
            this.picLogo.TabIndex = 5;
            this.picLogo.TabStop = false;
            // 
            // pnlIntro
            // 
            this.pnlIntro.Controls.Add(this.lblIntroContent);
            this.pnlIntro.Controls.Add(this.lblIntroTitle);
            this.pnlIntro.Location = new System.Drawing.Point(154, 12);
            this.pnlIntro.Name = "pnlIntro";
            this.pnlIntro.Size = new System.Drawing.Size(478, 136);
            this.pnlIntro.TabIndex = 7;
            // 
            // lblIntroContent
            // 
            this.lblIntroContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntroContent.Location = new System.Drawing.Point(3, 33);
            this.lblIntroContent.Name = "lblIntroContent";
            this.lblIntroContent.Size = new System.Drawing.Size(472, 103);
            this.lblIntroContent.TabIndex = 8;
            this.lblIntroContent.Text = resources.GetString("lblIntroContent.Text");
            // 
            // lblIntroTitle
            // 
            this.lblIntroTitle.AutoSize = true;
            this.lblIntroTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntroTitle.Location = new System.Drawing.Point(0, 0);
            this.lblIntroTitle.Name = "lblIntroTitle";
            this.lblIntroTitle.Size = new System.Drawing.Size(308, 33);
            this.lblIntroTitle.TabIndex = 7;
            this.lblIntroTitle.Text = "LEGO Racers Online";
            // 
            // pnlIdentify
            // 
            this.pnlIdentify.Controls.Add(this.lblStatus);
            this.pnlIdentify.Controls.Add(this.lblIdentifyContent);
            this.pnlIdentify.Controls.Add(this.lblIdentifyTitle);
            this.pnlIdentify.Location = new System.Drawing.Point(154, 12);
            this.pnlIdentify.Name = "pnlIdentify";
            this.pnlIdentify.Size = new System.Drawing.Size(478, 136);
            this.pnlIdentify.TabIndex = 9;
            this.pnlIdentify.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(3, 86);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(222, 20);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Waiting for the game to start...";
            // 
            // lblIdentifyContent
            // 
            this.lblIdentifyContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentifyContent.Location = new System.Drawing.Point(3, 33);
            this.lblIdentifyContent.Name = "lblIdentifyContent";
            this.lblIdentifyContent.Size = new System.Drawing.Size(472, 103);
            this.lblIdentifyContent.TabIndex = 8;
            this.lblIdentifyContent.Text = "In order to make everything work as expected, please run the game once so we can " +
    "identify your game installation details. After identifying, the game will close " +
    "automatically..";
            // 
            // lblIdentifyTitle
            // 
            this.lblIdentifyTitle.AutoSize = true;
            this.lblIdentifyTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentifyTitle.Location = new System.Drawing.Point(0, 0);
            this.lblIdentifyTitle.Name = "lblIdentifyTitle";
            this.lblIdentifyTitle.Size = new System.Drawing.Size(421, 33);
            this.lblIdentifyTitle.TabIndex = 7;
            this.lblIdentifyTitle.Text = "Let\'s identify your installation";
            // 
            // pnlFinished
            // 
            this.pnlFinished.Controls.Add(this.label1);
            this.pnlFinished.Controls.Add(this.lblFinished);
            this.pnlFinished.Location = new System.Drawing.Point(154, 12);
            this.pnlFinished.Name = "pnlFinished";
            this.pnlFinished.Size = new System.Drawing.Size(478, 136);
            this.pnlFinished.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(472, 103);
            this.label1.TabIndex = 8;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // lblFinished
            // 
            this.lblFinished.AutoSize = true;
            this.lblFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinished.Location = new System.Drawing.Point(0, 0);
            this.lblFinished.Name = "lblFinished";
            this.lblFinished.Size = new System.Drawing.Size(213, 33);
            this.lblFinished.TabIndex = 7;
            this.lblFinished.Text = "We\'re finished";
            // 
            // btnConfirm
            // 
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConfirm.Location = new System.Drawing.Point(532, 170);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 23);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Got it, let\'s go!";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(532, 170);
            this.btnNext.Name = "btnNext";
            this.btnNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNext.Size = new System.Drawing.Size(100, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnFinish
            // 
            this.btnFinish.Enabled = false;
            this.btnFinish.Location = new System.Drawing.Point(532, 170);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnFinish.Size = new System.Drawing.Size(100, 23);
            this.btnFinish.TabIndex = 6;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Visible = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // WizardForm
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 204);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFinish);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LEGO Racers Online";
            this.Load += new System.EventHandler(this.WizardForm_Load);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlIntro.ResumeLayout(false);
            this.pnlIntro.PerformLayout();
            this.pnlIdentify.ResumeLayout(false);
            this.pnlIdentify.PerformLayout();
            this.pnlFinished.ResumeLayout(false);
            this.pnlFinished.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel pnlIntro;
        private System.Windows.Forms.Label lblIntroContent;
        private System.Windows.Forms.Label lblIntroTitle;
        private System.Windows.Forms.Panel pnlIdentify;
        private System.Windows.Forms.Label lblIdentifyContent;
        private System.Windows.Forms.Label lblIdentifyTitle;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Panel pnlFinished;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFinished;

    }
}