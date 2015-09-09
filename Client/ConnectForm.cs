using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ConnectForm : Form
    {
        /// <summary>
        /// Gets or sets the Server IP Address.
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// Gets or sets the Server Port number.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the Players Nickname.
        /// </summary>
        public string Nickname { get; set; }

        public ConnectForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txtServerAddress.Text) && !String.IsNullOrWhiteSpace(txtNickname.Text))
                {
                    using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                    {
                        try
                        {
                            // Currently commented out because this feature doesn't work (well) yet
                            //socket.Connect(txtServerAddress.Text, (int)nrPort.Value);

                            // Save the settings to the properties
                            Server = txtServerAddress.Text;
                            Port = (int)nrPort.Value;
                            Nickname = txtNickname.Text;

                            if (Properties.Settings.Default.OverwriteDefaults)
                            {
                                // Set and save the settings to the application settings
                                Properties.Settings.Default.Server = Server;
                                Properties.Settings.Default.Port = Port;
                                Properties.Settings.Default.Nickname = Nickname;

                                Properties.Settings.Default.Save();
                            }

                            // Close the form and return to the main screen
                            Close();
                        }
                        catch (SocketException ex)
                        {
                            // Occurs when the Client was unable to connect to the Server
                            MessageBox.Show("The given Server Address and Port does not seem to respond. Please check if the Server is available and retry again.", "Error while connecting");
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                // Occurs when the Client was unable to connect to the Server
                ErrorHandler.ShowDialog("Cannot connect to Server", "The Client was unable to establish a connection with the Server.", exc);
            }
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            // Load the settings into the controls

            txtServerAddress.Text = Properties.Settings.Default.Server;
            nrPort.Value = (int)Properties.Settings.Default.Port;
            txtNickname.Text = Properties.Settings.Default.Nickname;

            // Select the Server Address TextBox
            txtServerAddress.Select();
        }
    }
}