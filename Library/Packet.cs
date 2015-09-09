using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Packet
    {
        /// <summary>
        /// Gets or sets the packet type.
        /// </summary>
        public PacketType PacketType { get; set; }

        /// <summary>
        /// Gets or sets the packet content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets the length of the complete Packet.
        /// </summary>
        public int Length
        {
            get
            {
                return (Enum.GetName(PacketType.GetType(), PacketType) + '|' + Content).Length;
            }
        }

        /// <summary>
        /// Populates a raw packet into a Packet object.
        /// </summary>
        /// <param name="packet">The raw packet data.</param>
        /// <returns>Returns the populated Packet object.</returns>
        public static Packet Populate(string packet)
        {
            string[] packetParts = packet.Split('|');

            PacketType packetType = PacketType.None;

            switch (packetParts[0])
            {
                case "Connect":
                    packetType = PacketType.Connect;
                    break;
                case "None":
                    break;
                case "Nickname":
                    packetType = PacketType.Nickname;
                    break;
                case "Coordinates":
                    packetType = PacketType.Coordinates;
                    break;
                case "PowerUp":
                    packetType = PacketType.PowerUp;
                    break;
                case "Race":
                    packetType = PacketType.Race;
                    break;
                case "Join":
                    packetType = PacketType.Join;
                    break;
                case "Disconnect":
                    packetType = PacketType.Disconnect;
                    break;
            }

            if (packetType == PacketType.None)
            {
                throw new Exception("Invalid PacketType in Packet.");
            }

            return new Packet()
            {
                PacketType = packetType,
                Content = String.Join("|", packetParts.Skip(1))
            };
        }

        /// <summary>
        /// Converts the Packet into bytes.
        /// </summary>
        /// <returns>Returns an Array of bytes.</returns>
        public byte[] ToBytes()
        {
            return ASCIIEncoding.ASCII.GetBytes(PacketType + "|" + Content);
        }
    }
}
