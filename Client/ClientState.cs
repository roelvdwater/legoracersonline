using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Specifies values representing a state for the Client application.
    /// </summary>
    enum ClientState
    {
        GameNotFound,
        Disconnected,
        Connected,
        Connecting
    }
}