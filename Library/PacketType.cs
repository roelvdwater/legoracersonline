using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public enum PacketType
    {
        None = 0,
        Nickname = 1,
        Coordinates = 2,
        Connect = 3,
        PowerUp = 4,
        Race = 5,
        Join = 6,
        Disconnect = 7
    }
}