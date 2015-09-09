using System;

namespace LEGORacersAPI
{
    public class PickedUpBrickEventArgs : EventArgs
    {
        public Brick BrickType { get; private set; }

        public PickedUpBrickEventArgs(Brick brickType)
        {
            BrickType = brickType;
        }
    }
}