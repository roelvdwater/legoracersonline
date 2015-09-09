namespace Library
{
    partial class ErrorForm
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
            this.tabError = new System.Windows.Forms.TabPage();
            this.lblExceptionDetailsValue = new System.Windows.Forms.Label();
            this.lblExceptionDetails = new System.Windows.Forms.Label();
            this.picWarning = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblInformation = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabError);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(388, 224);
            this.tabControl.TabIndex = 20;
            // 
            // tabError
            // 
            this.tabError.Controls.Add(this.lblExceptionDetailsValue);
            this.tabError.Controls.Add(this.lblExceptionDetails);
            this.tabError.Controls.Add(this.picWarning);
            this.tabError.Controls.Add(this.lblMessage);
            this.tabError.Controls.Add(this.lblInformation);
            this.tabError.Location = new System.Drawing.Point(4, 22);
            this.tabError.Name = "tabError";
            this.tabError.Padding = new System.Windows.Forms.Padding(3);
            this.tabError.Size = new System.Drawing.Size(380, 198);
            this.tabError.TabIndex = 0;
            this.tabError.Text = "Error";
            this.tabError.UseVisualStyleBackColor = true;
            // 
            // lblExceptionDetailsValue
            // 
            this.lblExceptionDetailsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExceptionDetailsValue.Location = new System.Drawing.Point(6, 88);
            this.lblExceptionDetailsValue.Name = "lblExceptionDetailsValue";
            this.lblExceptionDetailsValue.Size = new System.Drawing.Size(368, 104);
            this.lblExceptionDetailsValue.TabIndex = 26;
            this.lblExceptionDetailsValue.Text = "-";
            // 
            // lblExceptionDetails
            // 
            this.lblExceptionDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExceptionDetails.Location = new System.Drawing.Point(6, 69);
            this.lblExceptionDetails.Name = "lblExceptionDetails";
            this.lblExceptionDetails.Size = new System.Drawing.Size(368, 19);
            this.lblExceptionDetails.TabIndex = 25;
            this.lblExceptionDetails.Text = "The Exception threw the following message:";
            // 
            // picWarning
            // 
            this.picWarning.Image = global::Library.Properties.Resources.Warning;
            this.picWarning.Location = new System.Drawing.Point(8, 8);
            this.picWarning.Name = "picWarning";
            this.picWarning.Size = new System.Drawing.Size(48, 48);
            this.picWarning.TabIndex = 24;
            this.picWarning.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(62, 27);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(312, 29);
            this.lblMessage.TabIndex = 23;
            this.lblMessage.Text = "-";
            // 
            // lblInformation
            // 
            this.lblInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformation.Location = new System.Drawing.Point(62, 8);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(249, 19);
            this.lblInformation.TabIndex = 20;
            this.lblInformation.Text = "Unfortunately, an error occured:";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(321, 242);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 21;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 275);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Error";
            this.tabControl.ResumeLayout(false);
            this.tabError.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWarning)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabError;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblExceptionDetailsValue;
        private System.Windows.Forms.Label lblExceptionDetails;
        private System.Windows.Forms.PictureBox picWarning;

    }
}