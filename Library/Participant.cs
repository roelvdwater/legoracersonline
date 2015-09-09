using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Participant
    {
        /// <summary>
        /// Gets or sets the Nickname of the Participant.
        /// </summary>
        public string Nickname { get; set; }        

        /// <summary>
        /// Gets or sets the X-coordinate of the Participants car.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Gets or sets the Y-coordinate of the Participants car.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Gets or sets the Z-coordinate of the Participants car.
        /// </summary>
        public float Z { get; set; }

        /// <summary>
        /// Gets or sets the X-speed of the Participants car.
        /// </summary>
        public float SpeedX { get; set; }

        /// <summary>
        /// Gets or sets the Y-speed of the Participants car.
        /// </summary>
        public float SpeedY { get; set; }

        /// <summary>
        /// Gets or sets the Z-speed of the Participants car.
        /// </summary>
        public float SpeedZ { get; set; }

        /// <summary>
        /// Gets or sets the X1-vector of the Participants car.
        /// </summary>
        public float VectorX1 { get; set; }

        /// <summary>
        /// Gets or sets the Y1-vector of the Participants car.
        /// </summary>
        public float VectorY1 { get; set; }

        /// <summary>
        /// Gets or sets the Z1-vector of the Participants car.
        /// </summary>
        public float VectorZ1 { get; set; }

        /// <summary>
        /// Gets or sets the X2-vector of the Participants car.
        /// </summary>
        public float VectorX2 { get; set; }

        /// <summary>
        /// Gets or sets the Y2-vector of the Participants car.
        /// </summary>
        public float VectorY2 { get; set; }

        /// <summary>
        /// Gets or sets the Z2-vector of the Participants car.
        /// </summary>
        public float VectorZ2 { get; set; }

        public int PowerUpType { get; set; }

        public int PowerUpWhiteBricks { get; set; }
    }
}