using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerForm : Form
    {
        private Server gameServer;

        public ServerForm()
        {
            InitializeComponent();

            Settings.PowerUpFreezeEnabled = false;
            Settings.PowerUpWhiteBricksEnabled = false;
            Settings.PowerUp = 0;
            Settings.PowerUpWhiteBricks = 0;
            Settings.FreezeAllPlayersEnabled = false;

            try
            {
                gameServer = new Server();
                gameServer.Start();

                SetStatus("Online");

                newChallengeToolStripMenuItem.Enabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Server failed to start: " + exc.Message, "Error");
            }
        }

        void gameServer_ServerUpdated(object sender, ServerUpdatedEventArgs data)
        {
            dataGridPlayers.Invoke(new MethodInvoker(() =>
            {
                dataGridPlayers.DataSource = data.Participants.ToList();

                for (int i = 0; i < dataGridPlayers.Columns.Count; i++)
                {
                    dataGridPlayers.Columns[i].Visible = false;
                }

                dataGridPlayers.Columns["Nickname"].Visible = true;

                lblPlayers.Text = "Players: " + data.Participants.Count();
            }));
        }

        /// <summary>
        /// Sets the status in the status strip.
        /// </summary>
        /// <param name="status">The status to set in the status strip.</param>
        private void SetStatus(string status)
        {
            lblStatus.Text = "Status: " + status;
        }

        /// <summary>
        /// Reloads the current settings into the status bar.
        /// </summary>
        private void ReloadSettings()
        {
            if (Settings.PowerUpFreezeEnabled)
            {
                lblPowerUps.Text = "Power-Ups: ";

                switch (Settings.PowerUp)
                {
                    case 0:
                        lblPowerUps.Text += "None";
                        break;
                    case 1:
                        lblPowerUps.Text += "Red (weapon)";
                        break;
                    case 2:
                        lblPowerUps.Text += "Blue (defense)";
                        break;
                    case 3:
                        lblPowerUps.Text += "Green (speed)";
                        break;
                    case 4:
                        lblPowerUps.Text += "Yellow (sabotage)";
                        break;
                }
            }
            else
            {
                lblPowerUps.Text = "Power-Ups: Free";
            }

            if (Settings.PowerUpWhiteBricksEnabled)
            {
                lblUpgradeCrystals.Text = "Upgrade Crystals: ";

                switch (Settings.PowerUpWhiteBricks)
                {
                    case 0:
                        lblUpgradeCrystals.Text += "None";
                        break;
                    case 1: case 2: case 3: case 4:
                        lblUpgradeCrystals.Text += Settings.PowerUpWhiteBricks.ToString();
                        break;
                }
            }
            else
            {
                lblUpgradeCrystals.Text = "Upgrade Crystals: Free";
            }

            lblAllPlayersFreeze.Text = "All Players Freeze: " + (Settings.FreezeAllPlayersEnabled ? "Yes" : "No");
        }

        /// <summary>
        /// Clears all the checkmarks from the Power-Ups menu.
        /// </summary>
        private void ClearPowerUpChecks()
        {
            noneToolStripMenuItem.Checked = false;
            redbombToolStripMenuItem.Checked = false;
            bluedefenseToolStripMenuItem.Checked = false;
            greenspeedToolStripMenuItem.Checked = false;
            yellowsabotageToolStripMenuItem.Checked = false;
        }

        /// <summary>
        /// Clears all the checkmarks from the Power-Up White bricks menu.
        /// </summary>
        private void ClearWhiteBricksChecks()
        {
            zeroWhiteBricksToolStripMenuItem.Checked = false;
            oneWhiteBricksToolStripMenuItem.Checked = false;
            twoWhiteBricksToolStripMenuItem.Checked = false;
            threeWhiteBricksToolStripMenuItem.Checked = false;
        }

        private void ServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                gameServer.DisconnectAll();
                gameServer.Stop();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPowerUpChecks();

            noneToolStripMenuItem.Checked = true;
            Settings.PowerUp = 0;

            ReloadSettings();
        }

        private void redbombToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPowerUpChecks();

            redbombToolStripMenuItem.Checked = true;
            Settings.PowerUp = 1;

            ReloadSettings();
        }

        private void bluedefenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPowerUpChecks();

            bluedefenseToolStripMenuItem.Checked = true;
            Settings.PowerUp = 2;

            ReloadSettings();
        }

        private void greenspeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPowerUpChecks();

            greenspeedToolStripMenuItem.Checked = true;
            Settings.PowerUp = 3;

            ReloadSettings();
        }

        private void yellowsabotageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPowerUpChecks();

            yellowsabotageToolStripMenuItem.Checked = true;
            Settings.PowerUp = 4;

            ReloadSettings();
        }

        private void allPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.FreezeAllPlayersEnabled = !allPlayersToolStripMenuItem.Checked;
            allPlayersToolStripMenuItem.Checked = !allPlayersToolStripMenuItem.Checked;

            ReloadSettings();
        }

        private void newChallengeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NewRaceForm challengeForm = new NewRaceForm())
            {
                challengeForm.ShowDialog();

                if (challengeForm.SelectedCircuit != null)
                {
                    string packetContent = "";

                    if (challengeForm.Mirror)
                    {
                        packetContent = challengeForm.SelectedCircuit.MirrorBlockNumber + "|" + challengeForm.SelectedCircuit.MirrorNumber;
                    }
                    else
                    {
                        packetContent = challengeForm.SelectedCircuit.BlockNumber + "|" + challengeForm.SelectedCircuit.Number;
                    }

                    gameServer.SendAll(new Packet()
                        {
                            PacketType = PacketType.Race,
                            Content = packetContent
                        });
                }
            }
        }

        private void timerCleanUp_Tick(object sender, EventArgs e)
        {
            //gameServer.Participants.RemoveAll(p => p.LastActivity < DateTime.Now.AddSeconds(-5));

            //ReloadPlayers();
        }

        private void threeWhiteBricksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearWhiteBricksChecks();

            threeWhiteBricksToolStripMenuItem.Checked = true;
            Settings.PowerUpWhiteBricks = 3;

            ReloadSettings();
        }

        private void twoWhiteBricksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearWhiteBricksChecks();

            twoWhiteBricksToolStripMenuItem.Checked = true;
            Settings.PowerUpWhiteBricks = 2;

            ReloadSettings();
        }

        private void oneWhiteBricksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearWhiteBricksChecks();

            oneWhiteBricksToolStripMenuItem.Checked = true;
            Settings.PowerUpWhiteBricks = 1;

            ReloadSettings();
        }

        private void zeroWhiteBricksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearWhiteBricksChecks();

            zeroWhiteBricksToolStripMenuItem.Checked = true;
            Settings.PowerUpWhiteBricks = 0;

            ReloadSettings();
        }

        private void whiteBricksEnabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            whiteBricksEnabledToolStripMenuItem.Checked = !whiteBricksEnabledToolStripMenuItem.Checked;
            Settings.PowerUpWhiteBricksEnabled = whiteBricksEnabledToolStripMenuItem.Checked;

            if (Settings.PowerUpWhiteBricks == 0)
            {
                powerUpEnabledToolStripMenuItem_Click(null, null);
            }
            else
            {
                ReloadSettings();
            }
        }

        private void powerUpEnabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            powerUpEnabledToolStripMenuItem.Checked = !powerUpEnabledToolStripMenuItem.Checked;
            Settings.PowerUpFreezeEnabled = powerUpEnabledToolStripMenuItem.Checked;

            if (Settings.PowerUp == 0)
            {
                noneToolStripMenuItem_Click(null, null);
            }
            else
            {
                ReloadSettings();
            }
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            gameServer.ServerUpdated += gameServer_ServerUpdated;
        }

        private void dataGridPlayers_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            Console.WriteLine(e.RowIndex + "," + e.ColumnIndex);
            dataGridPlayers.Tag = new int[] { e.RowIndex, e.ColumnIndex };
        }

        private void kickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameServer.DisconnectParticipant(gameServer.Participants[((int[])dataGridPlayers.Tag)[0]]);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int[] selection = dataGridPlayers.Tag as int[];
            if (selection == null || selection[0] == -1 || selection[1] == -1)
            {
                e.Cancel = true;
            }
            else
            {
                dataGridPlayers.CurrentCell = dataGridPlayers.Rows[selection[0]].Cells[selection[1]];
            }
        }
    }
}