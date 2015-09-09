using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class PacketReceivedEventArgs : EventArgs
    {
        public ProtocolType Protocol { get; internal set; }
        public Packet Packet { get; internal set; }

        public PacketReceivedEventArgs(ProtocolType protocol, Packet packet)
        {
            Protocol = protocol;
            Packet = packet;
        }
    }
}