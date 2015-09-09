using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerParticipant : Participant
    {
        public TcpClient Client { get; private set; }
        public bool RemoveFromServer { get; set; }

        /// <summary>
        /// Gets or sets the DateTime the Participant contacted the Server the last time.
        /// </summary>
        public DateTime LastActivity { get; set; }

        public ServerParticipant(TcpClient client)
        {
            this.Client = client;
        }
    }
}