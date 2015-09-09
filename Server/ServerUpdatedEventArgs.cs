using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerUpdatedEventArgs : EventArgs
    {
        public List<ServerParticipant> Participants { get; internal set; }

        public ServerUpdatedEventArgs(List<ServerParticipant> participants)
        {
            Participants = participants;
        }
    }
}