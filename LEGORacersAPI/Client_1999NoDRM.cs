using System.Diagnostics;

namespace LEGORacersAPI
{
    /// <summary>
    /// Represents the client of the LEGO Racers 1999 NoDRM edition.
    /// </summary>
    public class Client_1999NoDRM : GameClient
    {
        /// <summary>
        /// Initializes a new instance of the LEGO Racers 1999 NoDRM edition client.
        /// </summary>
        /// <param name="process">The LEGO Racers game client Process.</param>
        /// <param name="initialize">Determines whether to initialize the GameClient instance automatically.</param>
        public Client_1999NoDRM(Process process, bool initialize)
        {
            this.process = process;

            CLIENT_FORMATTED_NAME = "1999 NoDRM";

            LOAD_RRB_BASE = 0x0043329F;
            POWERUP_FUNCTION_BASE = 0x00439104;
            POWERUP_RED_ADDRESS = 0x0045A950;
            POWERUP_BLUE_ADDRESS = 0x0045B030;
            POWERUP_GREEN_ADDRESS = 0x0045B1E0;
            POWERUP_YELLOW_ADDRESS = 0x0045A9B0;
            RUN_IN_BACKGROUND_ADDRESS = 0x00417602;
            AI_COUNT_ADDRESS = 0x004C55F4;
            MAINMENU_BUTTONS_BASE = 0x00480F4D;
            RACERSELECT_BUTTONS_BASE = 0x00484DE7;

            MENU_BASE = 0x004C4918;
            TARGETMENU_ECX_OFFSET = 0x4cc8;
            TARGETMENU_ESI_OFFSET = 0x4dc8;
            CURRENT_MENU_OFFSET = 0x4dc0;
            SELECTED_RACE_OFFSETS = new int[] { 0x4dc8, 0x202c };
            SELECTED_CIRCUIT_OFFSETS = new int[] { 0x4dc8, 0x1904 };
            CIRCUIT_BASE_OFFSETS = new int[] { 0x4dc8, 0x354, 0x4358 };
            MENUSTRINGS_ECX_OFFSETS = new int[] { 0x4dc8, 0x354, 0x4d00 };
            MENUSTRINGS_FILESTART_OFFSETS = new int[] { 0x4dc8, 0x354, 0x4cfc };
			
			INRACE_BASE = 0x004C4914;
			DRIVERCOUNT_OFFSET = 0x598;
			INRACE_ESI_OFFSET = 0x98;
			INRACE_PAUSED_OFFSET = 0x3158;
			PAUSED_SELECTED_INDEX_OFFSET = 0x3140;
			PAUSED_CURRENT_MENU_OFFSET = 0x33f8;
			PAUSE_FUNCTION_ADDRESS = 0x00436010;
			UNPAUSE_FUNCTION_ADDRESS = 0x00436160;

            DRIVER_BASE = 0x004C530C;
            PLAYER_BASE_OFFSETS = new int[] { 0x98, 0x4f0, 0x188, 0x548, 0x0 };
            ENEMY_1_BASE_OFFSETS = new int[] { 0x98, 0x4f0, 0x188, 0x54c, 0x0 };
            ENEMY_2_BASE_OFFSETS = new int[] { 0x98, 0x4f0, 0x188, 0x550, 0x0 };
            ENEMY_3_BASE_OFFSETS = new int[] { 0x98, 0x4f0, 0x188, 0x554, 0x0 };
            ENEMY_4_BASE_OFFSETS = new int[] { 0x98, 0x4f0, 0x188, 0x558, 0x0 };
            ENEMY_5_BASE_OFFSETS = new int[] { 0x98, 0x4f0, 0x188, 0x55c, 0x0 };

            DRIVER_OFFSET_COORDINATE_X = 0x518;
            DRIVER_OFFSET_COORDINATE_Y = 0x51c;
            DRIVER_OFFSET_COORDINATE_Z = 0x520;
            DRIVER_OFFSET_SPEED_X = 0x3f0;
            DRIVER_OFFSET_SPEED_Y = 0x3f4;
            DRIVER_OFFSET_SPEED_Z = 0x3f8;
            DRIVER_OFFSET_VECTOR_X1 = 0x4f4;
            DRIVER_OFFSET_VECTOR_Y1 = 0x4f8;
            DRIVER_OFFSET_VECTOR_Z1 = 0x4fc;
            DRIVER_OFFSET_VECTOR_X2 = 0x50c;
            DRIVER_OFFSET_VECTOR_Y2 = 0x510;
            DRIVER_OFFSET_VECTOR_Z2 = 0x514;
            DRIVER_OFFSET_BRICK = 0xCCC;
            DRIVER_OFFSET_WHITEBRICKS = 0xD58;

            if (Settings.AutoInitialize && initialize)
            {
                //Initialize();
            }
        }
    }
}