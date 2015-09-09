using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEGORacersAPI
{
    public class PowerUpUsedEventArgs : EventArgs
    {
        public Brick BrickType { get; private set; }

        public int WhiteBricksAmount { get; private set; }

        public PowerUpUsedEventArgs(Brick brickType, int whiteBricksAmount)
        {
            BrickType = brickType;
            WhiteBricksAmount = whiteBricksAmount;
        }
    }
}