using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {
        private byte[] bytes;
        private bool tcpActive;
        private bool udpActive;
        private TcpClient tcpClient;
        private UdpClient udpClient;
        private NetworkStream stream;
        private Thread tcpListenerThread;
        private Thread udpListenerThread;
        private IPEndPoint ipEndPoint;

        public bool TcpConnected
        {
            get
            {
                return tcpClient.Connected;
            }
        }

        public bool UdpConnected
        {
            get
            {
                return udpClient.Client.Connected;
            }
        }

        public delegate void PacketReceivedHandler(object sender, PacketReceivedEventArgs data);
        public event PacketReceivedHandler PacketReceived;

        protected void OnPacketReceived(object sender, PacketReceivedEventArgs data)
        {
            if (PacketReceived != null)
            {
                PacketReceived(this, data);
            }
        }

        public Client()
        {
            tcpClient = new TcpClient();
            udpClient = new UdpClient();
            udpClient.Client.ReceiveTimeout = 20000;
            tcpListenerThread = new Thread(TcpListener);
            udpListenerThread = new Thread(UdpListener);

            bytes = new byte[64];
        }

        public void Disconnect()
        {
            tcpActive = false;
            udpActive = false;
        }

        private void TcpListener()
        {
            tcpActive = true;

            while (tcpActive)
            {
                if (TcpConnected)
                {
                    if (stream.DataAvailable)
                    {
                        int i;

                        while (stream.DataAvailable && (i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            Packet packet = Packet.Populate(Encoding.ASCII.GetString(bytes, 0, i));

                            PacketReceived(this, new PacketReceivedEventArgs(ProtocolType.Tcp, packet));
                        }
                    }
                }

                Thread.Sleep(10);
            }
            tcpClient.Close();
        }

        private void UdpListener()
        {
            udpActive = true;

            while (udpActive)
            {
                if (UdpConnected)
                {
                    try
                    {
                        bytes = udpClient.Receive(ref ipEndPoint);
                    }
                    catch (SocketException) // receive timeout
                    {
                        continue;
                    } 
                    Packet packet = Packet.Populate(Encoding.ASCII.GetString(bytes));

                    PacketReceived(this, new PacketReceivedEventArgs(ProtocolType.Udp, packet));
                }

                Thread.Sleep(10);
            }
            udpClient.Close();
        }

        public void Connect(IPAddress ipAddress, int tcpPort, int udpPort)
        {
            try
            {
                ipEndPoint = new IPEndPoint(ipAddress, udpPort);

                tcpClient.Connect(ipAddress, tcpPort);
                udpClient.Connect(ipEndPoint);

                stream = tcpClient.GetStream();

                tcpListenerThread.Start();
                udpListenerThread.Start();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void Send(ProtocolType protocolType, Packet packet)
        {
            switch (protocolType)
            {
                case ProtocolType.Tcp:
                    stream.Write(packet.ToBytes(), 0, packet.Length);
                    break;
                case ProtocolType.Udp:
                    udpClient.Send(packet.ToBytes(), packet.Length);
                    break;
            }
        }
    }
}