using System;
using System.Collections.Generic;
using System.Threading;

namespace LEGORacersAPI
{
    /// <summary>
    /// Represents an in-game driver.
    /// </summary>
    public class Driver
    {
        protected MemoryManager memoryManager;
        protected int baseAddress;
        protected int[] baseOffsets;
        protected int memoryBase;
        protected int xCoordinateOffset;
        protected int yCoordinateOffset;
        protected int zCoordinateOffset;
        protected int xSpeedOffset;
        protected int ySpeedOffset;
        protected int zSpeedOffset;
        protected int vectorX1Offset;
        protected int vectorY1Offset;
        protected int vectorZ1Offset;
        protected int vectorX2Offset;
        protected int vectorY2Offset;
        protected int vectorZ2Offset;
        protected int powerUpTypeOffset;
        protected int powerUpwhiteBricksOffset;
        protected int powerUpRed;
        protected int powerUpBlue;
        protected int powerUpGreen;
        protected int powerUpYellow;

        private bool active;
        private Brick lastKnownBrick;
        private int lastKnownWhiteBricks;
        private int driverNumber;
        private static int currentDriverNumber;

        /// <summary>
        /// Gets or sets the drivers X-coordinate.
        /// </summary>
        public float X
        {
            get
            {
                return memoryManager.ReadFloat(memoryBase + xCoordinateOffset);
            }
            set
            {
                memoryManager.WriteFloat(memoryBase + xCoordinateOffset, value);
            }
        }

        /// <summary>
        /// Gets or sets the drivers Y-coordinate.
        /// </summary>
        public float Y
        {
            get
            {
                return memoryManager.ReadFloat(memoryBase + yCoordinateOffset);
            }
            set
            {
                memoryManager.WriteFloat(memoryBase + yCoordinateOffset, value);
            }
        }

        /// <summary>
        /// Gets or sets the drivers Z-coordinate.
        /// </summary>
        public float Z
        {
            get
            {
                return memoryManager.ReadFloat(memoryBase + zCoordinateOffset);
            }
            set
            {
                memoryManager.WriteFloat(memoryBase + zCoordinateOffset, value);
            }
        }

        /// <summary>
        /// Gets or sets the drivers X-speed.
        /// </summary>
        public float SpeedX
        {
            get
            {
                return memoryManager.ReadFloat(memoryBase + xSpeedOffset);
            }
            set
            {
                memoryManager.WriteFloat(memoryBase + xSpeedOffset, value);
            }
        }

        /// <summary>
        /// Gets or sets the drivers Y-speed.
        /// </summary>
        public float SpeedY
        {
            get
            {
                return memoryManager.ReadFloat(memoryBase + ySpeedOffset);
            }
            set
            {
                memoryManager.WriteFloat(memoryBase + ySpeedOffset, value);
            }
        }

        /// <summary>
        /// Gets or sets the drivers Z-speed.
        /// </summary>
        public float SpeedZ
        {
            get
            {
                return memoryManager.ReadFloat(memoryBase + zSpeedOffset);
            }
            set
            {
                memoryManager.WriteFloat(memoryBase + zSpeedOffset, value);
            }
        }

        /// <summary>
        /// Gets or sets the drivers X1-vector.
        /// </summary>
        public float VectorX1
        {
            get
            {
                return memoryManager.ReadFloat(memoryBase + vectorX1Offset);
            }
            set
            {
                memoryManager.WriteFloat(memoryBase + vectorX1Offset, value);
            }
        }

        /// <summary>
        /// Gets or sets the drivers Y1-vector.
        /// </summary>
        public float VectorY1
        {
            get
            {
                return memoryManager.ReadFloat(memoryBase + vectorY1Offset);
            }
            set
            {
                memoryManager.WriteFloat(memoryBase + vectorY1Offset, value);
            }
        }

        /// <summary>
        /// Gets or sets the drivers Z1-vector.
        /// </summary>
        public float VectorZ1
        {
            get
            {
                return memoryManager.ReadFloat(memoryBase + vectorZ1Offset);
            }
            set
            {
                memoryManager.WriteFloat(memoryBase + vectorZ1Offset, value);
            }
        }

        /// <summary>
        /// Gets or sets the drivers X2-vector.
        /// </summary>
        public float VectorX2
        {
            get
            {
                return memoryManager.ReadFloat(memoryBase + vectorX2Offset);
            }
            set
            {
                memoryManager.WriteFloat(memoryBase + vectorX2Offset, value);
            }
        }

        /// <summary>
        /// Gets or sets the drivers Y2-vector.
        /// </summary>
        public float VectorY2
        {
            get
            {
                return memoryManager.ReadFloat(memoryBase + vectorY2Offset);
            }
            set
            {
                memoryManager.WriteFloat(memoryBase + vectorY2Offset, value);
            }
        }

        /// <summary>
        /// Gets or sets the drivers Z2-vector.
        /// </summary>
        public float VectorZ2
        {
            get
            {
                return memoryManager.ReadFloat(memoryBase + vectorZ2Offset);
            }
            set
            {
                memoryManager.WriteFloat(memoryBase + vectorZ2Offset, value);
            }
        }

        /// <summary>
        /// Gets or sets the drivers Brick type.
        /// </summary>
        public Brick Brick
        {
            get
            {
                return (Brick)memoryManager.ReadInt(memoryBase + powerUpTypeOffset);
            }
            set
            {
                memoryManager.WriteInt(memoryBase + powerUpTypeOffset, (int)value);
            }
        }

        /// <summary>
        /// Gets or sets the drivers White bricks amount.
        /// </summary>
        public int WhiteBricks
        {
            get
            {
                return memoryManager.ReadInt(memoryBase + powerUpwhiteBricksOffset);
            }
            set
            {
                memoryManager.WriteInt(memoryBase + powerUpwhiteBricksOffset, value >= 0 && value <= 3 ? value : 0);
            }
        }

        /// <summary>
        /// Gets or sets the MemoryManager.
        /// </summary>
        public MemoryManager MemoryManager
        {
            get
            {
                return memoryManager;
            }
            private set
            {
                memoryManager = value;
            }
        }

        public delegate void PowerUpUsedHandler(object sender, PowerUpUsedEventArgs data);
        public event PowerUpUsedHandler PowerUpUsed;

        protected void OnPowerUpUsed(object sender, PowerUpUsedEventArgs data)
        {
            if (PowerUpUsed != null)
            {
                PowerUpUsed(this, data);
            }
        }

        public delegate void PickedUpBrickHandler(object sender, PickedUpBrickEventArgs data);

        /// <summary>
        /// Occurs when the Driver picks up a Brick. Does not fire when the Brick type or amount is the same as the previous.
        /// </summary>
        public event PickedUpBrickHandler PickedUpBrick;

        protected void OnPickedUpBrick(object sender, PickedUpBrickEventArgs data)
        {
            if (PickedUpBrick != null)
            {
                PickedUpBrick(this, data);
            }
        }

        /// <summary>
        /// Safely unloads the driver.
        /// </summary>
        public void Unload()
        {
            active = false;
        }

        /// <summary>
        /// Initializes the driver.
        /// </summary>
        protected void Initialize()
        {
            active = true;

            driverNumber = currentDriverNumber;
            currentDriverNumber++;

            Thread powerUpThread = new Thread(CheckPowerUp);
            powerUpThread.Start();
        }

        private void CheckPowerUp()
        {
            while (active)
            {
                if (lastKnownBrick != Brick)
                {
                    if (Brick == Brick.None)
                    {
                        OnPowerUpUsed(this, new PowerUpUsedEventArgs(lastKnownBrick, lastKnownWhiteBricks));
                    }
                    else
                    {
                        OnPickedUpBrick(this, new PickedUpBrickEventArgs(Brick));
                    }
                }

                if (WhiteBricks > lastKnownWhiteBricks)
                {
                    OnPickedUpBrick(this, new PickedUpBrickEventArgs(Brick.White));
                }

                lastKnownBrick = Brick;
                lastKnownWhiteBricks = WhiteBricks;

                Thread.Sleep((int)Settings.RefreshRate);
            }
        }

        /// <summary>
        /// Uses a Power-up from the driver. This does not trigger the PowerUpUsed event.
        /// </summary>
        /// <param name="brick">The Brick type to use.</param>
        /// <param name="whiteBricks">Amount of White bricks to use.</param>
        public void UsePowerUp(Brick brick, int whiteBricks)
        {
            if (driverNumber >= 0 && driverNumber <= 5 && brick != Brick.White && brick != Brick.None)
            {
                int function = 0;

                switch (brick)
                {
                    case Brick.Red:
                        // Red Power-up
                        function = powerUpRed;
                        break;
                    case Brick.Blue:
                        // Blue Power-up
                        function = powerUpBlue;
                        break;
                    case Brick.Green:
                        // Green Power-up
                        function = powerUpGreen;
                        break;
                    case Brick.Yellow:
                        // Yellow Power-up
                        function = powerUpYellow;
                        break;
                    default:
                        return;
                }

                int raceraddress;

                if (driverNumber == 0)
                {
                    raceraddress = memoryManager.ReadInt(memoryManager.ReadInt(memoryManager.ReadInt(memoryManager.ReadInt(memoryManager.ReadInt(0x004C67BC) + 0x60) + 0xA8) + 0x114) + 0x40) - 0x121C;
                }
                else
                {
                    raceraddress = memoryManager.ReadInt(memoryManager.ReadInt(memoryManager.ReadInt(memoryManager.ReadInt(memoryManager.ReadInt(0x004C67BC) + 0x60) + 0xA8) + 0x110 + (int)driverNumber * 4) + 0x40) - 0x3e8;
                }

                int ecx = memoryManager.ReadInt(memoryManager.ReadInt(memoryManager.ReadInt(memoryManager.ReadInt(memoryManager.ReadInt(memoryManager.ReadInt(0x004C67BC) + 0x60) + 0xA8) + 0x114) + 0x40) - 0x121C + 0x8);
                int ebx = 0;
                int edx = 0;

                switch (driverNumber)
                {
                    case 0: // Local player
                        ebx = ecx - 0x498;
                        edx = ecx - 0x444;
                        break;
                    case 1: // Opponent 1
                        edx = 0xD1;
                        break;
                    case 2: // Opponent 2
                        edx = 0xA4;
                        break;
                    case 3: // Opponent 3
                        edx = 0xBA;
                        break;
                    case 4: // Opponent 4
                        edx = 0x49;
                        break;
                    case 5: // Opponent 5
                        edx = 0x8D;
                        break;
                    default:
                        return;
                }

                List<byte> codeToInject = new List<byte>();

                codeToInject.Add(0xBB);
                codeToInject.AddRange(BitConverter.GetBytes(ebx)); // mov ebx,neededEBX
                codeToInject.Add(0xB9);
                codeToInject.AddRange(BitConverter.GetBytes(ecx)); // mov ecx,neededECX
                codeToInject.Add(0xBA);
                codeToInject.AddRange(BitConverter.GetBytes(edx)); // mov edx,neededEDX
                codeToInject.Add(0x6A);
                codeToInject.Add((byte)whiteBricks); // push whitebricks
                codeToInject.Add(0x68);
                codeToInject.AddRange(BitConverter.GetBytes(raceraddress)); // push raceraddress
                codeToInject.Add(0xE8);
                codeToInject.AddRange(BitConverter.GetBytes((int)(-(memoryManager.NewMemory + codeToInject.Count + 4) + function))); // call function
                codeToInject.Add(0xC3); // ret

                // Write code to the assigned memory and execute it
                memoryManager.WriteBytes((int)memoryManager.NewMemory, codeToInject.ToArray());
                memoryManager.Execute(memoryManager.NewMemory);

                /*int raceraddress;

                int ecx = memoryManager.ReadInt(memoryManager.CalculatePointer(DRIVER_BASE, ENEMY_1_BASE_OFFSETS) + 0x8);
                int ebx = 0;
                int edx = 0;

                switch (driverNumber)
                {
                    case 0: // Player
                        raceraddress = memoryManager.ReadInt(memoryManager.CalculatePointer(DRIVER_BASE, PLAYER_BASE_OFFSETS));
                        ebx = ecx - 0x498;
                        edx = ecx - 0x444;
                        break;
                    case 1: // AI 1
                        raceraddress = memoryManager.ReadInt(memoryManager.CalculatePointer(DRIVER_BASE, ENEMY_1_BASE_OFFSETS));
                        edx = 0xD1;
                        break;
                    case 2: // AI 2
                        raceraddress = memoryManager.ReadInt(memoryManager.CalculatePointer(DRIVER_BASE, ENEMY_2_BASE_OFFSETS));
                        edx = 0xA4;
                        break;
                    case 3: // AI 3
                        raceraddress = memoryManager.ReadInt(memoryManager.CalculatePointer(DRIVER_BASE, ENEMY_3_BASE_OFFSETS));
                        edx = 0xBA;
                        break;
                    case 4: // AI 4
                        raceraddress = memoryManager.ReadInt(memoryManager.CalculatePointer(DRIVER_BASE, ENEMY_4_BASE_OFFSETS));
                        edx = 0x49;
                        break;
                    case 5: // AI 5
                        raceraddress = memoryManager.ReadInt(memoryManager.CalculatePointer(DRIVER_BASE, ENEMY_5_BASE_OFFSETS));
                        edx = 0x8D;
                        break;
                }

                List<byte> codeToInject = new List<byte>();

                codeToInject.Add(0xBB);
                codeToInject.AddRange(BitConverter.GetBytes(ebx)); // mov ebx,neededEBX
                codeToInject.Add(0xB9);
                codeToInject.AddRange(BitConverter.GetBytes(ecx)); // mov ecx,neededECX
                codeToInject.Add(0xBA);
                codeToInject.AddRange(BitConverter.GetBytes(edx)); // mov edx,neededEDX
                codeToInject.Add(0x6A);
                codeToInject.Add((byte)whiteBricks); // push whitebricks
                codeToInject.Add(0x68);
                codeToInject.AddRange(BitConverter.GetBytes(raceraddress)); // push raceraddress
                codeToInject.Add(0xE8);
                codeToInject.AddRange(BitConverter.GetBytes(function - (int)(MemoryManager.NewMemory + codeToInject.Count + 4))); // call function
                codeToInject.Add(0xC3); // ret
                memoryManager.WriteBytes((int)memoryManager.NewMemory, codeToInject.ToArray());
                memoryManager.Execute(MemoryManager.NewMemory);*/
            }
        }
    }
}