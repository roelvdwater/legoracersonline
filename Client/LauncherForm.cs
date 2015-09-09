using Client.Properties;
using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class LauncherForm : Form
    {
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84: // WM_SETICON
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        public LauncherForm()
        {
            InitializeComponent();
        }

        private void btnLaunch_MouseEnter(object sender, EventArgs e)
        {
            btnLaunch.BackgroundImage = Resources.Button_Launch_Hover;
        }

        private void btnLaunch_MouseLeave(object sender, EventArgs e)
        {
            btnLaunch.BackgroundImage = Resources.Button_Launch;
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Resources.Close_Hover;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Resources.Close;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            try
            {
                Process[] processess = Process.GetProcessesByName("LEGORacers");

                if (processess.Count() > 0)
                {
                    MessageBox.Show("It seems that there is already a LEGO Racers process running on your system. In order to make everything work correctly, these processess will be terminated after closing this message.", "Attention");

                    foreach (Process process in processess)
                    {
                        process.Kill();
                    }
                }

                if (String.IsNullOrWhiteSpace(Properties.Settings.Default.GameClientDirectory))
                {
                    MessageBox.Show("Game client directory was not set. Please restart the client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Application.Exit();
                }
                else
                {
                    if (File.Exists(Path.Combine(Properties.Settings.Default.GameClientDirectory, "LEGORacers.exe")))
                    {
                        ProcessStartInfo processInfo = new ProcessStartInfo()
                        {
                            WorkingDirectory = Properties.Settings.Default.GameClientDirectory,
                            FileName = "LEGORacers.exe"
                        };

                        if (Properties.Settings.Default.WindowMode)
                        {
                            processInfo.Arguments = "-window";
                        }

                        if (Properties.Settings.Default.SkipIntroVideo)
                        {
                            processInfo.Arguments += " -novideo";
                        }

                        Process.Start(processInfo);

                        while (true)
                        {
                            processess = Process.GetProcessesByName("LEGORacers");

                            if (processess.Count() == 1)
                            {
                                (new ClientForm(processess[0], this)).Show();

                                Hide();
                                break;
                            }

                            System.Threading.Thread.Sleep(500);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The file 'LEGORacers.exe' was not found in the directory '" + Properties.Settings.Default.GameClientDirectory + "'. Please reinstall the game.", "Game file not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exc)
            {
                ErrorHandler.ShowDialog("Cannot launch the game", "The game could not be closed or launched.", exc);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (SettingsForm settingsForm = new SettingsForm())
            {
                settingsForm.ShowDialog();
            }
        }
    }
}