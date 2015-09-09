using Library;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using System.Threading;
using System;

namespace Server
{
    class Server
    {
        private bool started;
        private byte[] sendBytes;
        private byte[] receiveBytes;
        private TcpListener tcpServer;
        private UdpClient udpServer;
        private List<ServerParticipant> participants;
        private IPEndPoint ipEndPoint;
        private Thread tcpListenerThread;
        private Thread udpListenerThread;

        public bool Started
        {
            get
            {
                return started;
            }
        }

        public List<ServerParticipant> Participants
        {
            get
            {
                return participants;
            }
        }

        public delegate void ServerUpdatedHandler(object sender, ServerUpdatedEventArgs data);
        public event ServerUpdatedHandler ServerUpdated;

        protected void OnServerUpdated(object sender, ServerUpdatedEventArgs data)
        {
            if (ServerUpdated != null)
            {
                ServerUpdated(this, data);
            }
        }

        public Server()
        {
            tcpServer = new TcpListener(new IPEndPoint(IPAddress.Any, 3031));
            udpServer = new UdpClient();

            ipEndPoint = new IPEndPoint(IPAddress.Any, 3030);

            udpServer.Client.Bind(ipEndPoint);

            participants = new List<ServerParticipant>();

            started = false;

            tcpListenerThread = new Thread(TcpListener);
            tcpListenerThread.Start();

            udpListenerThread = new Thread(UdpListener);
            udpListenerThread.Start();
        }

        public void Start()
        {
            tcpServer.Start();

            if (!tcpListenerThread.IsAlive)
            {
                tcpListenerThread.Start();
            }

            if (!udpListenerThread.IsAlive)
            {
                udpListenerThread.Start();
            }

            started = true;
        }

        public void Stop()
        {
            if (tcpListenerThread.IsAlive)
            {
                tcpListenerThread.Abort();
            }

            if (udpListenerThread.IsAlive)
            {
                udpListenerThread.Abort();
            }

            tcpServer.Stop();
            udpServer.Close();

            started = false;
        }

        private void TcpListener()
        {
            try
            {
                byte[] bytes = new byte[64];
                string data = "";

                while (true)
                {
                    if (started)
                    {
                        if (tcpServer.Pending())
                        {
                            participants.Add(new ServerParticipant(tcpServer.AcceptTcpClient()));
                        }

                        foreach (ServerParticipant participant in participants)
                        {
                            NetworkStream stream = participant.Client.GetStream();

                            if (stream.DataAvailable)
                            {
                                int i;

                                while (stream.DataAvailable && (i = stream.Read(bytes, 0, bytes.Length)) != 0)
                                {
                                    data = Encoding.ASCII.GetString(bytes, 0, i);

                                    Packet packet = Packet.Populate(data);

                                    if (packet.PacketType == PacketType.Connect)
                                    {
                                        if (participants.Count() >= 6)
                                        {
                                            participant.RemoveFromServer = true;

                                            Send(stream, new Packet()
                                            {
                                                PacketType = PacketType.Connect,
                                                Content = "FULL"
                                            });
                                        }
                                        else if (participants.Where(p => p.Nickname == packet.Content).Count() > 0)
                                        {
                                            participant.RemoveFromServer = true;

                                            Send(stream, new Packet()
                                                {
                                                    PacketType = PacketType.Connect,
                                                    Content = "UNAVAILABLE"
                                                });
                                        }
                                        else
                                        {
                                            participant.Nickname = packet.Content;

                                            Send(stream, new Packet()
                                            {
                                                PacketType = PacketType.Connect,
                                                Content = String.Join("|", participants.Select(p => p.Nickname))
                                            });

                                            SendAll(new Packet()
                                                {
                                                    PacketType = PacketType.Join,
                                                    Content = packet.Content
                                                }, packet.Content);

                                            OnServerUpdated(this, new ServerUpdatedEventArgs(participants));
                                        }
                                    }
                                    else if (packet.PacketType == PacketType.Disconnect)
                                    {
                                        if (participant.Nickname == packet.Content)
                                        {
                                            SendAll(new Packet()
                                            {
                                                PacketType = PacketType.Disconnect,
                                                Content = participant.Nickname
                                            }, participant.Nickname);
                                            participant.RemoveFromServer = true;
                                            OnServerUpdated(this, new ServerUpdatedEventArgs(participants.Where(p => !p.RemoveFromServer).ToList<ServerParticipant>()));
                                        }
                                    }
                                    else if (packet.PacketType == PacketType.PowerUp)
                                    {
                                        foreach (ServerParticipant receiver in participants.Where(p => !p.RemoveFromServer && p.Nickname != participant.Nickname))
                                        {
                                            NetworkStream receiverStream = receiver.Client.GetStream();

                                            Send(receiverStream, packet);
                                        }
                                    }
                                }
                            }
                        }

                        participants.RemoveAll(p => p.RemoveFromServer);
                    }
                }
            }
            catch (Exception exc)
            {
                if (exc.GetType() != typeof(ThreadAbortException))
                    ErrorHandler.ShowDialog("TCP Packet could not be read", "The receiving or reading of a TCP Packet caused an error.", exc);
            }
        }

        private void UdpListener()
        {
            string data = "";

            while (true)
            {
                try
                {
                    receiveBytes = udpServer.Receive(ref ipEndPoint);
                    data = Encoding.ASCII.GetString(receiveBytes);

                    Packet packet = Packet.Populate(data);

                    switch (packet.PacketType)
                    {
                        case PacketType.Coordinates:
                            string[] contentParts = packet.Content.Split('|');

                            var foundPlayers = from p in Participants
                                               where p.Nickname == contentParts[0]
                                               select p;

                            if (foundPlayers != null && foundPlayers.Count() == 1)
                            {
                                if (!Settings.FreezeAllPlayersEnabled)
                                {
                                    ServerParticipant foundPlayer = foundPlayers.First();

                                    foundPlayer.X = float.Parse(contentParts[1]);
                                    foundPlayer.Y = float.Parse(contentParts[2]);
                                    foundPlayer.Z = float.Parse(contentParts[3]);
                                    foundPlayer.SpeedX = float.Parse(contentParts[4]);
                                    foundPlayer.SpeedY = float.Parse(contentParts[5]);
                                    foundPlayer.SpeedZ = float.Parse(contentParts[6]);
                                    foundPlayer.VectorX1 = float.Parse(contentParts[7]);
                                    foundPlayer.VectorY1 = float.Parse(contentParts[8]);
                                    foundPlayer.VectorZ1 = float.Parse(contentParts[9]);
                                    foundPlayer.VectorX2 = float.Parse(contentParts[10]);
                                    foundPlayer.VectorY2 = float.Parse(contentParts[11]);
                                    foundPlayer.VectorZ2 = float.Parse(contentParts[12]);

                                    foundPlayer.LastActivity = DateTime.Now;
                                }

                                string stringToSend = PacketType.Coordinates + "|" + Settings.Serialize();

                                foreach (ServerParticipant player in participants)
                                {
                                    stringToSend += "|" + player.Nickname + ";" + player.X + ";" + player.Y + ";" + player.Z + ";" + player.SpeedX + ";" + player.SpeedY + ";" + player.SpeedZ + ";" + player.VectorX1 + ";" + player.VectorY1 + ";" + player.VectorZ1 + ";" + player.VectorX2 + ";" + player.VectorY2 + ";" + player.VectorZ2 + ";" + player.PowerUpType + ";" + player.PowerUpWhiteBricks;
                                }

                                sendBytes = Encoding.ASCII.GetBytes(stringToSend);
                                udpServer.Send(sendBytes, sendBytes.GetLength(0), ipEndPoint);
                            }
                            break;
                    }
                }
                catch (SocketException exc)
                {
                    if (exc.ErrorCode == 10054)
                    {
                        // Participant closed the Client - no action is required as the Server will clean it up automatically
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }

                //Console.WriteLine("Handling client at " + ipEndPoint + " - ");
                //Console.WriteLine("Message Received " + data.TrimEnd());

                //server.Send(receivedBytes, receivedBytes.Length, remoteIPEndPoint);
                //Console.WriteLine("Message Echoed to" + remoteIPEndPoint + data);
            }
        }

        private void Send(NetworkStream stream, Packet packet)
        {
            stream.Write(packet.ToBytes(), 0, packet.Length);
        }

        public void SendAll(Packet packet)
        {
            foreach (ServerParticipant receiver in participants)
            {
                NetworkStream receiverStream = receiver.Client.GetStream();

                Send(receiverStream, packet);
            }
        }

        public void SendAll(Packet packet, string except)
        {
            foreach (ServerParticipant receiver in participants.Where(p => p.Nickname != except))
            {
                NetworkStream receiverStream = receiver.Client.GetStream();

                Send(receiverStream, packet);
            }
        }

        public void DisconnectParticipant(ServerParticipant participant)
        {
            SendAll(new Packet()
            {
                PacketType = PacketType.Disconnect,
                Content = participant.Nickname
            });
            participant.RemoveFromServer = true;
            List<ServerParticipant> ps = participants.Where(p => !p.RemoveFromServer).ToList<ServerParticipant>();
            OnServerUpdated(this, new ServerUpdatedEventArgs(ps));
        }

        public void DisconnectAll()
        {
            foreach (ServerParticipant participant in participants)
            {
                SendAll(new Packet()
                {
                    PacketType = PacketType.Disconnect,
                    Content = participant.Nickname
                });
            }
            participants.ForEach(p => { p.RemoveFromServer = true; });
        }
    }
}