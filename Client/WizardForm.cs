using LEGORacersAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class WizardForm : Form
    {
        private string gameClientDirectory;

        public WizardForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tries to identify the game client version.
        /// </summary>
        /// <param name="process"></param>
        private void Identify(Process process)
        {
            GameClient gameClient = GameClientFactory.GetGameClient(process, false);

            if (gameClient != null)
            {
                lblStatus.Text = "You were successfully identified as:" + Environment.NewLine + gameClient.FormattedName;

                btnNext.Enabled = true;

                gameClientDirectory = Path.GetDirectoryName(process.MainModule.FileName);
            }
            else
            {
                string md5hash = LEGORacersAPI.Toolbox.GetMD5Hash(process.MainModule.FileName);

                Clipboard.SetText(md5hash);
                MessageBox.Show("We had some trouble to identify you. Your game client files MD5 hash was copied to your clipboard.", "Couldn't find your client");
                lblStatus.Text = "You were not identified.";
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            btnConfirm.Visible = false;
            pnlIntro.Visible = false;
            pnlIdentify.Visible = true;
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Process[] processess = Process.GetProcessesByName("LEGORacers");

            if (processess.Count() > 0)
            {
                timer.Enabled = false;

                Process gameClient = processess[0];
                ProcessModule mainModule = gameClient.MainModule;

                Identify(gameClient);

                gameClient.Kill();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNext.Visible = false;
            btnFinish.Visible = true;
            btnFinish.Enabled = true;
            pnlFinished.Visible = true;
            pnlIdentify.Visible = false;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.GameClientDirectory = gameClientDirectory;
            Properties.Settings.Default.Save();

            (new LauncherForm()).Show();

            Hide();
        }

        private void WizardForm_Load(object sender, EventArgs e)
        {
            if (!Toolbox.IsAdministrator())
            {
                MessageBox.Show("Please restart the application with Administrator rights.", "Error");

                Close();
            }
        }
    }
}