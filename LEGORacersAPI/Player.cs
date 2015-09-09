namespace LEGORacersAPI
{
    public class Player : Driver
    {
        /// <summary>
        /// Initializes a new instance of the in-game player.
        /// </summary>
        /// <param name="memoryManager">The Memory Manager for reading and writing in-game values.</param>
        /// <param name="baseAddress">The players base address.</param>
        /// <param name="baseOffsets">The players base offsets.</param>
        /// <param name="xCoordinateOffset">The players X-coordinate offset.</param>
        /// <param name="yCoordinateOffset">The players Y-coordinate offset.</param>
        /// <param name="zCoordinateOffset">The players Z-coordinate offset.</param>
        /// <param name="xSpeedOffset">The players X-speed offset.</param>
        /// <param name="ySpeedOffset">The players Y-speed offset.</param>
        /// <param name="zSpeedOffset">The players Z-speed offset.</param>
        /// <param name="vectorX1Offset">The players X1-vector offset.</param>
        /// <param name="vectorY1Offset">The players Y1-vector offset.</param>
        /// <param name="vectorZ1Offset">The players Z1-vector offset.</param>
        /// <param name="vectorX2Offset">The players X2-vector offset.</param>
        /// <param name="vectorY2Offset">The players Y2-vector offset.</param>
        /// <param name="vectorZ2Offset">The players Z2-vector offset.</param>
        /// <param name="powerUpTypeOffset">The players Power-up type offset.</param>
        /// <param name="powerUpWhiteBricksOffset">The players Power-up White bricks amount offset.</param>
        /// <param name="powerUpRed">The players Red Power-up address.</param>
        /// <param name="powerUpBlue">The players Blue Power-up address.</param>
        /// <param name="powerUpGreen">The players Green Power-up address.</param>
        /// <param name="powerUpYellow">The players Yellow Power-up address.</param>
        public Player(MemoryManager memoryManager, int baseAddress, int[] baseOffsets, int xCoordinateOffset, int yCoordinateOffset, int zCoordinateOffset, int xSpeedOffset, int ySpeedOffset, int zSpeedOffset, int vectorX1Offset, int vectorY1Offset, int vectorZ1Offset, int vectorX2Offset, int vectorY2Offset, int vectorZ2Offset, int powerUpTypeOffset, int powerUpWhiteBricksOffset, int powerUpRed, int powerUpBlue, int powerUpGreen, int powerUpYellow)
        {
            this.memoryManager = memoryManager;
            this.baseAddress = baseAddress;
            this.baseOffsets = baseOffsets;
            this.memoryBase = memoryManager.CalculatePointer(memoryManager.ReadInt(baseAddress), baseOffsets);
            this.xCoordinateOffset = xCoordinateOffset;
            this.yCoordinateOffset = yCoordinateOffset;
            this.zCoordinateOffset = zCoordinateOffset;
            this.xSpeedOffset = xSpeedOffset;
            this.ySpeedOffset = ySpeedOffset;
            this.zSpeedOffset = zSpeedOffset;
            this.vectorX1Offset = vectorX1Offset;
            this.vectorY1Offset = vectorY1Offset;
            this.vectorZ1Offset = vectorZ1Offset;
            this.vectorX2Offset = vectorX2Offset;
            this.vectorY2Offset = vectorY2Offset;
            this.vectorZ2Offset = vectorZ2Offset;
            this.powerUpTypeOffset = powerUpTypeOffset;
            this.powerUpwhiteBricksOffset = powerUpWhiteBricksOffset;
            this.powerUpRed = powerUpRed;
            this.powerUpBlue = powerUpBlue;
            this.powerUpGreen = powerUpGreen;
            this.powerUpYellow = powerUpYellow;

            Initialize();
        }
    }
}