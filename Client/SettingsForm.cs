using System;
using System.Windows.Forms;

namespace Client
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            txtDefaultNickname.Text = Properties.Settings.Default.Nickname;
            txtDefaultServerAddress.Text = Properties.Settings.Default.Server;
            nrDefaultPort.Value = Properties.Settings.Default.Port;
            chkWindowedMode.Checked = Properties.Settings.Default.WindowMode;
            chkSkipIntroVideo.Checked = Properties.Settings.Default.SkipIntroVideo;
            chkOverwriteDefaults.Checked = Properties.Settings.Default.OverwriteDefaults;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Nickname = txtDefaultNickname.Text;
            Properties.Settings.Default.Server = txtDefaultServerAddress.Text;
            Properties.Settings.Default.Port = (int)nrDefaultPort.Value;
            Properties.Settings.Default.WindowMode = chkWindowedMode.Checked;
            Properties.Settings.Default.SkipIntroVideo = chkSkipIntroVideo.Checked;
            Properties.Settings.Default.OverwriteDefaults = chkOverwriteDefaults.Checked;

            Properties.Settings.Default.Save();

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lnkResetSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("If you would like to restore to the original settings, you can reset them here. Please note that you will have you identify your installation again after restarting. The application will restart after resetting the settings.", "Reset settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();

                Application.Restart();
            }
        }
    }
}