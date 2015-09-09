using LEGORacersAPI;
using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {
        private IPEndPoint ipEndPoint;
        private Thread thread;
        private Process gameProcess;
        private LauncherForm launcherForm;
        private ProcessModule mainModule;
        private ClientState clientState;
        private List<Participant> participants;
        private GameClient gameClient;
        private Opponent[] opponents;
        private Participant participant;
        private Player gamePlayer;
        private int playerCount;
        private byte[] sendBytes;
        private byte[] receiveBytes;
        private bool engineInitialized;
        private int lastKnownPowerUpType;
        private int lastKnownPowerUpWhiteBricks;
        private bool sentLastUsedPowerUp;
        private int[] powerUpsUsed;
        private TcpClient tcpClient;
        private NetworkStream stream;
        private Thread listenerThread;
        private Client client;
        private MemoryManager memoryManager;
        private bool updateClient;

        public ClientForm(Process gameProcess, LauncherForm launcherForm)
        {
            InitializeComponent();

            this.gameProcess = gameProcess;
            this.launcherForm = launcherForm;

            tcpClient = new TcpClient();
            //listenerThread = new Thread(ServerListener);
        }

        /// <summary>
        /// Transforms a Packet object to an array of bytes and sends it to the Server.
        /// </summary>
        /// <param name="packet">The Packet object to transform and send to the Server.</param>
        /// <returns>Returns a response Packet from the Server.</returns>
        private Packet SendPacket(Packet packet)
        {
            return null;
            //try
            //{
            //    // Transforms the Packet object into an array of bytes
            //    sendBytes = Encoding.ASCII.GetBytes(packet.PacketType + "|" + packet.Content);

            //    // Sends the bytes to the Server
            //    client.Send(sendBytes, sendBytes.Length);

            //    // Read the response from the Server
            //    receiveBytes = client.Receive(ref ipEndPoint);

            //    // Transform the response to a string that can be populated
            //    string data = Encoding.ASCII.GetString(receiveBytes);

            //    // Populate the Packet from the given string and return it to the sender
            //    return Packet.Populate(data);
            //}
            //catch (Exception exc)
            //{
            //    ErrorHandler.ShowDialog("Communication error with the Server", "The given Packet was not sent to the Server or the received Packet was corrupt.", exc);

            //    return null;
            //}
        }

        /// <summary>
        /// Sets the status in the status strip.
        /// </summary>
        /// <param name="status">The status to set in the status strip.</param>
        private void SetStatus(string status)
        {
            lblStatus.Text = "Status: " + status;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            try
            {
                engineInitialized = false;

                sentLastUsedPowerUp = true;
                powerUpsUsed = new int[5];

                for (int i = 0; i < 5; i++)
                {
                    powerUpsUsed[i] = 0;
                }

                gameClient = GameClientFactory.GetGameClient(gameProcess);

                gameClient.Initialized += gameClient_Initialized;

                participants = new List<Participant>();

                // Set the amount of players to zero
                playerCount = 0;

                // Create a new Player object that is going to hold the local Player information
                participant = new Participant()
                {
                    Nickname = "Player"
                };

                if (!Toolbox.IsAdministrator())
                {
                    throw new Win32Exception();
                }

                for (int i = 0; i < dataGridPlayers.Columns.Count; i++)
                {
                    dataGridPlayers.Columns[i].Visible = false;
                }

                mainModule = gameProcess.MainModule;

                memoryManager = new MemoryManager(gameProcess);
                //codeInjector = new CodeInjector(memoryManager);

                SetStatus("Not Connected");

                clientState = ClientState.Disconnected;

                // Creates and starts a new thread that will be responsible for updating the client

                thread = new Thread(UpdateClient);
                thread.Start();
            }
            catch (Win32Exception)
            {
                // The Client was (probably) not started with Administrator rights
                MessageBox.Show("Error while finding LEGO Racers process. Please restart the application with Administrator rights.", "Error");

                Close();
            }
            catch (Exception exc)
            {
                // An unknown error occured
                ErrorHandler.ShowDialog("Failed to initialize", "The Client failed to initialize.", exc);

                Close();
            }
        }

        void gameClient_Initialized(InitializedType type)
        {
            switch (type)
            {
                case InitializedType.Core:
                    MessageBox.Show("Core initialized");
                    gameClient.RunInBackground = true;
                    gameClient.LoadRRB = false;
                    break;
                case InitializedType.Drivers:
                    MessageBox.Show("Drivers initialized");
                    Console.WriteLine("Player X: " + gameClient.Player.X);
                    Console.WriteLine("Opponent 1 X: " + gameClient.Opponents[0].X);
                    gameClient.Player.PowerUpUsed += Player_PowerUpUsed;
                    break;
            }
        }

        void gameClient_GameClientInitialized()
        {
            gameClient.RunInBackground = true;
            gameClient.LoadRRB = false;
            //InitializeEngine();

            //gameClient.Player.PowerUpUsed += Player_PowerUpUsed;
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clientState == ClientState.Disconnected)
            {
                try
                {
                    using (ConnectForm connectForm = new ConnectForm())
                    {
                        // THIS IS CONFIRMED TO WORK!
                        //float playerBase = codeInjector.ReadFloat(codeInjector.ReadUInt(codeInjector.ReadUInt(codeInjector.ReadUInt(codeInjector.ReadUInt(codeInjector.ReadUInt(0x004C67BC) + 0x60) + 0xA8) + 0x114) + 0x40) + 0x130);
                        //Console.WriteLine(playerBase);
                        connectForm.ShowDialog();
                        participant.Nickname = connectForm.Nickname;

                        client = new Client();
                        client.PacketReceived += client_PacketReceived;
                        client.Connect(IPAddress.Parse(connectForm.Server), 3031, 3030);
                        client.Send(ProtocolType.Tcp, new Packet()
                            {
                                PacketType = PacketType.Connect,
                                Content = connectForm.Nickname
                            });
                        clientState = ClientState.Connecting;

                        /*if (connectForm.Server != null && connectForm.Nickname != null)
                        {
                            ipEndPoint = new IPEndPoint(IPAddress.Parse(connectForm.Server), 3030);

                            tcpClient.Connect(new IPEndPoint(IPAddress.Parse(connectForm.Server), 3031));

                            stream = tcpClient.GetStream();

                            Packet packet = new Packet()
                            {
                                PacketType = PacketType.Connect,
                                Content = connectForm.Nickname
                            };

                            stream.Write(packet.ToBytes(), 0, packet.Length);

                            listenerThread.Start();

                            /*

                            client = new UdpClient();
                            client.Connect(ipEndPoint);

                            Packet packet = SendPacket(new Packet()
                                {
                                    PacketType = PacketType.Nickname,
                                    Content = connectForm.Nickname
                                });

                            if (packet.PacketType != PacketType.Nickname || packet.Content != "OK")
                            {
                                MessageBox.Show("An error occured during the handshake with the Server. A response was received, but the Server rejected your request. Please try again.", "Error while handshaking");
                            }
                            else
                            {
                                participants = new List<Participant>();
                                playerCount = 0;
                                participant.Nickname = connectForm.Nickname;
                                clientState = ClientState.Connected;

                                SetStatus("Connected (" + connectForm.Server + ")");
                            }
                        }*/
                    }
                }
                catch (Exception exc)
                {
                    ErrorHandler.ShowDialog("Connect dialog failed to load", "The connect dialog failed to load.", exc);
                }
            }
            else
            {
                MessageBox.Show("Disconnect from the current game to connect to a new game.","Already connected");
            }
        }

        private void AddPlayer(string nickname)
        {
            participants.Add(new Participant()
                {
                    Nickname = nickname
                });

            UpdateList();
        }
        
        private void RemovePlayer(string nickname)
        {
            participants.RemoveAll(p => p.Nickname == nickname);
            UpdateList();
        }

        private void UpdateList()
        {
            dataGridPlayers.Invoke(new MethodInvoker(() =>
            {
                dataGridPlayers.DataSource = participants.ToList();

                dataGridPlayers.Columns[1].Visible = false;
                dataGridPlayers.Columns[2].Visible = false;
            }));
        }

        void client_PacketReceived(object sender, PacketReceivedEventArgs data)
        {
            if (data.Protocol == ProtocolType.Tcp)
            {
                switch (data.Packet.PacketType)
                {
                    case PacketType.Connect:
                        switch (data.Packet.Content)
                        {
                            case "FULL":
                                MessageBox.Show("The Server you were trying to join is full.", "Server full");
                                clientState = ClientState.Disconnected;
                                break;
                            case "UNAVAILABLE":
                                MessageBox.Show("The chosen Nickname is already in use.", "Nickname unavailable");
                                clientState = ClientState.Disconnected;
                                break;
                            default:
                                string[] players = data.Packet.Content.Split('|');

                                foreach (string player in players)
                                {
                                    AddPlayer(player);
                                }

                                clientState = ClientState.Connected;

                                SetStatus("Connected");
                                break;
                        }
                        break;
                    case PacketType.PowerUp:
                        dataGridPlayers.Invoke(new MethodInvoker(() =>
                        {
                            MessageBox.Show(data.Packet.Content);
                        }));
                        break;
                    case PacketType.Race:
                        string[] packetPart = data.Packet.Content.Split('|');

                        gameClient.SetupRace(Int32.Parse(packetPart[0]), Int32.Parse(packetPart[1]));
                        break;
                    case PacketType.Join:
                        AddPlayer(data.Packet.Content);
                        break;
                    case PacketType.Disconnect:
                        if (data.Packet.Content == participant.Nickname)
                        {
                            client.Disconnect();
                            participants.Clear();
                            UpdateList();
                            clientState = ClientState.Disconnected;
                            SetStatus("Not Connected");
                            MessageBox.Show("You were disconnected by the server","Disconnected");
                        }
                        else
                        {
                            RemovePlayer(data.Packet.Content);
                        }
                        break;
                }
            }
            else if (data.Protocol == ProtocolType.Udp)
            {
                string[] responseParts = data.Packet.Content.Split('|');

                Library.Settings.Unserialize(responseParts[0]);

                /*bool updateList = false;

                if (responseParts.Count() - 1 != playerCount)
                {
                    // New player, add it to the list

                    updateList = true;

                    playerCount = responseParts.Count() - 1;

                    foreach (string responsePlayer in responseParts.Skip(1))
                    {
                        string[] playerPart = responsePlayer.Split(';');

                        var existingPlayer = from p in participants
                                             where p.Nickname == playerPart[0]
                                             select p;

                        if (existingPlayer == null || existingPlayer.Count() == 0)
                        {
                            participants.Add(new Participant()
                            {
                                Nickname = playerPart[0],
                                X = float.Parse(playerPart[1]),
                                Y = float.Parse(playerPart[2]),
                                Z = float.Parse(playerPart[3]),
                                SpeedX = float.Parse(playerPart[4]),
                                SpeedY = float.Parse(playerPart[5]),
                                SpeedZ = float.Parse(playerPart[6]),
                                VectorX1 = float.Parse(playerPart[7]),
                                VectorY1 = float.Parse(playerPart[8]),
                                VectorZ1 = float.Parse(playerPart[9]),
                                VectorX2 = float.Parse(playerPart[10]),
                                VectorY2 = float.Parse(playerPart[11]),
                                VectorZ2 = float.Parse(playerPart[12]),
                                PowerUpType = int.Parse(playerPart[13]),
                                PowerUpWhiteBricks = int.Parse(playerPart[14])
                            });
                        }
                        else
                        {
                            participant.X = float.Parse(playerPart[1]);
                            participant.Y = float.Parse(playerPart[2]);
                            participant.Z = float.Parse(playerPart[3]);
                            participant.SpeedX = float.Parse(playerPart[4]);
                            participant.SpeedY = float.Parse(playerPart[5]);
                            participant.SpeedZ = float.Parse(playerPart[6]);
                            participant.VectorX1 = float.Parse(playerPart[7]);
                            participant.VectorY1 = float.Parse(playerPart[8]);
                            participant.VectorZ1 = float.Parse(playerPart[9]);
                            participant.VectorX2 = float.Parse(playerPart[10]);
                            participant.VectorY2 = float.Parse(playerPart[11]);
                            participant.VectorZ2 = float.Parse(playerPart[12]);
                            participant.PowerUpType = int.Parse(playerPart[13]);
                            participant.PowerUpWhiteBricks = int.Parse(playerPart[14]);
                        }
                    }
                }
                else
                {*/
                    foreach (string responsePlayer in responseParts.Skip(1))
                    {
                        string[] playerPart = responsePlayer.Split(';');

                        var foundPlayers = from p in participants
                                           where p.Nickname == playerPart[0]
                                           select p;

                        if (foundPlayers != null && foundPlayers.Count() == 1)
                        {
                            Participant foundPlayer = foundPlayers.First();

                            foundPlayer.X = float.Parse(playerPart[1]);
                            foundPlayer.Y = float.Parse(playerPart[2]);
                            foundPlayer.Z = float.Parse(playerPart[3]);
                            foundPlayer.SpeedX = float.Parse(playerPart[4]);
                            foundPlayer.SpeedY = float.Parse(playerPart[5]);
                            foundPlayer.SpeedZ = float.Parse(playerPart[6]);
                            foundPlayer.VectorX1 = float.Parse(playerPart[7]);
                            foundPlayer.VectorY1 = float.Parse(playerPart[8]);
                            foundPlayer.VectorZ1 = float.Parse(playerPart[9]);
                            foundPlayer.VectorX2 = float.Parse(playerPart[10]);
                            foundPlayer.VectorY2 = float.Parse(playerPart[11]);
                            foundPlayer.VectorZ2 = float.Parse(playerPart[12]);
                            foundPlayer.PowerUpType = int.Parse(playerPart[13]);
                            foundPlayer.PowerUpWhiteBricks = int.Parse(playerPart[14]);
                        }
                    }
                //}

                /*if (updateList)
                {
                    dataGridPlayers.Invoke(new MethodInvoker(() =>
                    {
                        dataGridPlayers.DataSource = participants.ToList();

                        dataGridPlayers.Columns[1].Visible = false;
                        dataGridPlayers.Columns[2].Visible = false;
                    }));
                }*/

                foreach (Participant enemy in participants.Where(p => p.Nickname != participant.Nickname))
                {
                    /*if (powerUpsUsed[i] != enemy.PowerUpsUsed)
                    {
                        powerUpsUsed[i] = enemy.PowerUpsUsed;

                        //gameClient.UsePowerUp(enemy.PowerUpType, enemy.PowerUpWhiteBricks, i + 1);
                    }*/

                    gameClient.Opponents[0].X = enemy.X;
                    gameClient.Opponents[0].Y = enemy.Y;
                    gameClient.Opponents[0].Z = enemy.Z;
                    gameClient.Opponents[0].SpeedX = enemy.SpeedX;
                    gameClient.Opponents[0].SpeedY = enemy.SpeedY;
                    gameClient.Opponents[0].SpeedZ = enemy.SpeedZ;
                    gameClient.Opponents[0].VectorX1 = enemy.VectorX1;
                    gameClient.Opponents[0].VectorY1 = enemy.VectorY1;
                    //opponents[0].VectorZ1 = enemy.VectorZ1;
                    gameClient.Opponents[0].VectorX2 = enemy.VectorX2;
                    gameClient.Opponents[0].VectorY2 = enemy.VectorY2;
                    //opponents[0].VectorZ2 = enemy.VectorZ2;
                    //if (GetActiveWindowTitle() == "LEGO Racers")
                    //{
                    //    g.DrawString("Knoest:\nX: " + enemy.X + "\nY: " + enemy.Y + "\nZ: " + enemy.Z, font, brush, new PointF(20, 20));
                    //}

                    break;
                }
            }
        }

        private void GameClosed()
        {
            Invoke(new MethodInvoker(() =>
            {
                launcherForm.Show();

                Close();
            }));
        }

        private void UpdateClient()
        {
            updateClient = true;

            while (updateClient)
            {
                if (gameProcess.HasExited)
                {
                    GameClosed();
                    break;
                }
                else
                {
                    if (gameClient.InitializedType == InitializedType.Both)
                    {
                        /*for (int i = 0; i < 5; i++)
                        {
                            opponents[i].PowerUpType = 0;
                        }*/

                        if (clientState == ClientState.Connected)
                        {
                            string packetContent = participant.Nickname + "|" + gameClient.Player.X + "|" + gameClient.Player.Y + "|" + gameClient.Player.Z + "|" + gameClient.Player.SpeedX + "|" + gameClient.Player.SpeedY + "|" + gameClient.Player.SpeedZ + "|" + gameClient.Player.VectorX1 + "|" + gameClient.Player.VectorY1 + "|" + gameClient.Player.VectorZ1 + "|" + gameClient.Player.VectorX2 + "|" + gameClient.Player.VectorY2 + "|" + gameClient.Player.VectorZ2;

                            /*if (!sentLastUsedPowerUp)
                            {
                                client.Send(ProtocolType.Tcp, new Packet()
                                    {
                                        PacketType = PacketType.PowerUp,
                                        Content = lastKnownPowerUpType + "|" + lastKnownPowerUpWhiteBricks
                                    });
                            }*/

                            client.Send(ProtocolType.Udp, new Packet()
                            {
                                PacketType = PacketType.Coordinates,
                                Content = packetContent
                            });

                            /*if (response != null)
                            {
                                if (sentLastUsedPowerUp == false)
                                {
                                    sentLastUsedPowerUp = true;

                                    lastKnownPowerUpType = gamePlayer.PowerUpType;
                                    lastKnownPowerUpWhiteBricks = gamePlayer.PowerUpWhiteBricks;
                                }

                                string[] responseParts = response.Content.Split('|');

                                Settings.Unserialize(responseParts[0]);

                                bool updateList = false;

                                if (responseParts.Count() - 1 != playerCount)
                                {
                                    // New player, add it to the list

                                    updateList = true;

                                    playerCount = responseParts.Count() - 1;

                                    foreach (string responsePlayer in responseParts.Skip(1))
                                    {
                                        string[] playerPart = responsePlayer.Split(';');

                                        var existingPlayer = from p in participants
                                                             where p.Nickname == playerPart[0]
                                                             select p;

                                        if (existingPlayer == null || existingPlayer.Count() == 0)
                                        {
                                            participants.Add(new Participant()
                                            {
                                                Nickname = playerPart[0],
                                                X = float.Parse(playerPart[1]),
                                                Y = float.Parse(playerPart[2]),
                                                Z = float.Parse(playerPart[3]),
                                                SpeedX = float.Parse(playerPart[4]),
                                                SpeedY = float.Parse(playerPart[5]),
                                                SpeedZ = float.Parse(playerPart[6]),
                                                VectorX1 = float.Parse(playerPart[7]),
                                                VectorY1 = float.Parse(playerPart[8]),
                                                VectorZ1 = float.Parse(playerPart[9]),
                                                VectorX2 = float.Parse(playerPart[10]),
                                                VectorY2 = float.Parse(playerPart[11]),
                                                VectorZ2 = float.Parse(playerPart[12]),
                                                PowerUpType = int.Parse(playerPart[13]),
                                                PowerUpWhiteBricks = int.Parse(playerPart[14]),
                                                PowerUpsUsed = int.Parse(playerPart[15]),
                                            });
                                        }
                                        else
                                        {
                                            participant.X = float.Parse(playerPart[1]);
                                            participant.Y = float.Parse(playerPart[2]);
                                            participant.Z = float.Parse(playerPart[3]);
                                            participant.SpeedX = float.Parse(playerPart[4]);
                                            participant.SpeedY = float.Parse(playerPart[5]);
                                            participant.SpeedZ = float.Parse(playerPart[6]);
                                            participant.VectorX1 = float.Parse(playerPart[7]);
                                            participant.VectorY1 = float.Parse(playerPart[8]);
                                            participant.VectorZ1 = float.Parse(playerPart[9]);
                                            participant.VectorX2 = float.Parse(playerPart[10]);
                                            participant.VectorY2 = float.Parse(playerPart[11]);
                                            participant.VectorZ2 = float.Parse(playerPart[12]);
                                            participant.PowerUpType = int.Parse(playerPart[13]);
                                            participant.PowerUpWhiteBricks = int.Parse(playerPart[14]);
                                            participant.PowerUpsUsed = int.Parse(playerPart[15]);
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (string responsePlayer in responseParts.Skip(1))
                                    {
                                        string[] playerPart = responsePlayer.Split(';');

                                        var foundPlayers = from p in participants
                                                           where p.Nickname == playerPart[0]
                                                           select p;

                                        if (foundPlayers != null && foundPlayers.Count() == 1)
                                        {
                                            Participant foundPlayer = foundPlayers.First();

                                            foundPlayer.X = float.Parse(playerPart[1]);
                                            foundPlayer.Y = float.Parse(playerPart[2]);
                                            foundPlayer.Z = float.Parse(playerPart[3]);
                                            foundPlayer.SpeedX = float.Parse(playerPart[4]);
                                            foundPlayer.SpeedY = float.Parse(playerPart[5]);
                                            foundPlayer.SpeedZ = float.Parse(playerPart[6]);
                                            foundPlayer.VectorX1 = float.Parse(playerPart[7]);
                                            foundPlayer.VectorY1 = float.Parse(playerPart[8]);
                                            foundPlayer.VectorZ1 = float.Parse(playerPart[9]);
                                            foundPlayer.VectorX2 = float.Parse(playerPart[10]);
                                            foundPlayer.VectorY2 = float.Parse(playerPart[11]);
                                            foundPlayer.VectorZ2 = float.Parse(playerPart[12]);
                                            foundPlayer.PowerUpType = int.Parse(playerPart[13]);
                                            foundPlayer.PowerUpWhiteBricks = int.Parse(playerPart[14]);
                                            foundPlayer.PowerUpsUsed = int.Parse(playerPart[15]);
                                        }
                                    }
                                }

                                if (updateList)
                                {
                                    dataGridPlayers.Invoke(new MethodInvoker(() =>
                                    {
                                        dataGridPlayers.DataSource = participants.ToList();

                                        dataGridPlayers.Columns[1].Visible = false;
                                        dataGridPlayers.Columns[2].Visible = false;
                                    }));
                                }
                            }

                            int i = 0;

                            foreach (Participant enemy in participants.Where(p => p.Nickname != participant.Nickname))
                            {
                                if (powerUpsUsed[i] != enemy.PowerUpsUsed)
                                {
                                    powerUpsUsed[i] = enemy.PowerUpsUsed;

                                    //gameClient.UsePowerUp(enemy.PowerUpType, enemy.PowerUpWhiteBricks, i + 1);
                                }

                                opponents[0].X = enemy.X;
                                opponents[0].Y = enemy.Y;
                                opponents[0].Z = enemy.Z;
                                opponents[0].SpeedX = enemy.SpeedX;
                                opponents[0].SpeedY = enemy.SpeedY;
                                opponents[0].SpeedZ = enemy.SpeedZ;
                                opponents[0].VectorX1 = enemy.VectorX1;
                                opponents[0].VectorY1 = enemy.VectorY1;
                                //opponents[0].VectorZ1 = enemy.VectorZ1;
                                opponents[0].VectorX2 = enemy.VectorX2;
                                opponents[0].VectorY2 = enemy.VectorY2;
                                //opponents[0].VectorZ2 = enemy.VectorZ2;
                                //if (GetActiveWindowTitle() == "LEGO Racers")
                                //{
                                //    g.DrawString("Knoest:\nX: " + enemy.X + "\nY: " + enemy.Y + "\nZ: " + enemy.Z, font, brush, new PointF(20, 20));
                                //}

                                i++;
                            }*/
                        }
                    }

                    /*if (lastKnownPowerUpType != gameClient.Player.PowerUpType && gameClient.Player.PowerUpType == 0)
                    {
                        sentLastUsedPowerUp = false;
                    }

                    if (sentLastUsedPowerUp)
                    {
                        lastKnownPowerUpType = gameClient.Player.PowerUpType;
                        lastKnownPowerUpWhiteBricks = gameClient.Player.PowerUpWhiteBricks;
                    }*/

                    System.Threading.Thread.Sleep(10);
                }
            }

            //GameClosed();
        }

        void Player_PowerUpUsed(object sender, PowerUpUsedEventArgs data)
        {
            client.Send(ProtocolType.Tcp, new Packet()
            {
                PacketType = PacketType.PowerUp,
                Content = (int)data.BrickType + "|" + (int)data.WhiteBricksAmount
            });
            Console.WriteLine(data);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (thread != null)
            //{
            //    thread.Abort();
            //}

            //if (client != null)
            //{
            //    client.Close();
            //    client = null;
            //}
            updateClient = false;
            gameClient.Unload();
            if (client != null)
            {
                
                client.Send(ProtocolType.Tcp, new Packet()
                {
                    PacketType = PacketType.Disconnect,
                    Content = participant.Nickname
                });

                client.Disconnect();
            }

            if (!gameProcess.HasExited)
                Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SettingsForm settingsForm = new SettingsForm())
            {
                settingsForm.ShowDialog();
            }
        }

        private bool initialized = false;

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //memoryManager.WriteByte(0x00417602, 0xEB);

            //if (!initialized)
            //{
            //    gameClient.Initialize(memoryManager);
            //    gameClient.LoadRRB(false);

            //    initialized = true;
            //}

            //gameClient.Player.UsePowerUp(1, 0);
            //gameClient.Opponents[0].UsePowerUp(1, 0);

            //gameClient.UsePowerUp(1, 0, 0);
            //gameClient.SetupRace(1, 1);
            //codeInjector.setDoLoadRRB(false);
            //uint autoPointer = memoryManager.CalculatePointer(memoryManager.ReadUInt(0x004C67BC), new uint[] { 0x60, 0xA8, 0x114, 0x40, 0x130 });
            //uint handPointer = codeInjector.ReadUInt(codeInjector.ReadUInt(codeInjector.ReadUInt(codeInjector.ReadUInt(codeInjector.ReadUInt(0x004C67BC) + 0x60) + 0xA8) + 0x114) + 0x40) + 0x130;

            //InitializeEngine();

            //Console.WriteLine(opponents[0].X);

            //Console.WriteLine("Pointer: {0}", autoPointer);
            //Console.WriteLine("Hand: {0}", handPointer);

            //Console.WriteLine("Pointer X: {0}", memoryManager.ReadFloat(autoPointer));
            //Console.WriteLine("Hand X: {0}", codeInjector.ReadFloat(handPointer));
            //float playerBase = codeInjector.ReadFloat(codeInjector.ReadUInt(codeInjector.ReadUInt(codeInjector.ReadUInt(codeInjector.ReadUInt(codeInjector.ReadUInt(0x004C67BC) + 0x60) + 0xA8) + 0x114) + 0x40) + 0x130);
            //Console.WriteLine(playerBase);
            //memoryManager.WriteByte(0x00417602, 0xEB);
            //codeInjector.setupRace(1, 2);
            //codeInjector.GotoMenu(CodeInjector.Menu.ControlsP1);
            //uint x = codeInjector.Pointer(codeInjector.ReadUInt(0x004C67BC), new uint[] { 0x60, 0xa8, 0x114, 0x40, 0x130 });
            //float playerBase = codeInjector.ReadFloat(codeInjector.ReadUInt(codeInjector.ReadUInt(codeInjector.ReadUInt(codeInjector.ReadUInt(codeInjector.ReadUInt(0x004C67BC) + 0x60) + 0xA8) + 0x114) + 0x40) + 0x130);
            //Console.WriteLine(codeInjector.ReadFloat(x));
            //int test = memoryReader.ReadMultiLevelPointer(memoryReader.ReadProcess.Threads[0].StartAddress.ToInt32() - 0x168, 4, new int[] { 0xbc });
            //Console.WriteLine(test);
            //Console.WriteLine(memoryReader.ReadUInt(0x0012FEA0));
            //codeInjector.gotoMenu(CodeInjector.Menu.DisplayOptionsWarningprompt);
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clientState == ClientState.Connected)
            {
                client.Send(ProtocolType.Tcp, new Packet()
                {
                    PacketType = PacketType.Disconnect,
                    Content = participant.Nickname
                });
                client.Disconnect();
                participants.Clear();
                UpdateList();
                clientState = ClientState.Disconnected;
                SetStatus("Not Connected");
            }
        }
    }
}