using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LEGORacersAPI;

namespace API_testapp
{
    public partial class Form1 : Form
    {

        public static GameClient game;
        Timer maintimer;
        public Form1()
        {
            InitializeComponent();
            maintimer = new Timer();
            maintimer.Interval = 100;
            maintimer.Enabled = false;
            maintimer.Tick += maintimer_Tick;
        }

        void maintimer_Tick(object sender, EventArgs e)
        {
            initializedlabel.Text = game.InitializedType.ToString();
            isracerunninglabel.Text = game.IsRaceRunning.ToString();
            checkBox2.Checked = game.RunInBackground;
            if (game.IsRaceRunning)
            {
                panel2.Enabled = true;
                RacePaucedLabel.Text = game.Paused.ToString();
            }
            else
                panel2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameClient[] clients = GameClientFactory.GetActiveGameClients();
            if (clients.Length > 0)
            {
                game = clients[0];
                statuslabel.Text = "attached";
                enablestuff(true);
            }
            else
                statuslabel.Text = "failed to attach";
        }

        private void enablestuff(bool value)
        {
            checkBox1.Enabled = value;
            checkBox1.Checked = value && false;
            button2.Enabled = value;
            panel1.Enabled = value;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (game!=null)
            {
                game.Unload();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maintimer_Tick(sender, new EventArgs());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            maintimer.Enabled = checkBox1.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (game.Paused)
            {
                game.Paused = false;
                button3.Text = "Pause race";
            }
            else
            {
                game.Paused = true;
                button3.Text = "Unause race";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == checkBox2)
                game.RunInBackground = checkBox2.Checked;
        }
    }
}
