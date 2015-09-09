namespace LEGORacersAPI
{
    /// <summary>
    /// Specifies values for in-game menus.
    /// </summary>
    public enum Menu
    {
        /// <summary>
        /// The loading screen where the LEGO logo is displayed.
        /// </summary>
        Loading = 0x1,
        /// <summary>
        /// The initializing screen which is displayed between the Loading and MainMenu screen.
        /// </summary>
        Initializing = 0x32,
        /// <summary>
        /// The Main menu screen.
        /// </summary>
        MainMenu = 0x2,
        /// <summary>
        /// The building screen.
        /// </summary>
        Build = 0x3,
        /// <summary>
        /// The circuit selection screen.
        /// </summary>
        Circuit = 0x5,
        /// <summary>
        /// The single race selection screen.
        /// </summary>
        SingleRace = 0x6,
        /// <summary>
        /// The options screen.
        /// </summary>
        Options = 0x8,
        /// <summary>
        /// The control options screen.
        /// </summary>
        Controls = 0x9,           // Read only! Can not be used as a target.
        /// <summary>
        /// The control options screen for player 1.
        /// </summary>
        ControlsP1 = 0xA,
        /// <summary>
        /// The control options screen for player 2.
        /// </summary>
        ControlsP2 = 0xB,
        /// <summary>
        /// The create driver screen.
        /// </summary>
        CreateDriver = 0xF,
        /// <summary>
        /// The create license screen.
        /// </summary>
        CreateLicense = 0x10,
        /// <summary>
        /// The build target screen.
        /// </summary>
        BuildCar = 0x11,
        /// <summary>
        /// The racer selection screen.
        /// </summary>
        ChooseRacer = 0x13,
        /// <summary>
        /// The time attack screen.
        /// </summary>
        TimeAttack = 0x1D,
        /// <summary>
        /// The language selection screen.
        /// </summary>
        ChooseLanguage = 0x2C,
        /// <summary>
        /// The credits screen.
        /// </summary>
        Credits = 0x30,
        /// <summary>
        /// The display options screen.
        /// </summary>
        DisplayOptions = 0x301,               // Target only! Cannot be read.
        /// <summary>
        /// The game options screen.
        /// </summary>
        GameOptions = 0x302,
        /// <summary>
        /// The racer deletion screen.
        /// </summary>
        DeleteRacer = 0x303,
        /// <summary>
        /// The racer deletion cancel screen.
        /// </summary>
        CancelDriver = 0x304,
        /// <summary>
        /// The racer copy screen.
        /// </summary>
        CopyRacer = 0x305,
        /// <summary>
        /// The racer edit screen.
        /// </summary>
        EditRacer = 0x306,
        /// <summary>
        /// The start race screen.
        /// </summary>
        StartRace = 0x307,
        /// <summary>
        /// The options display prompt screen.
        /// </summary>
        PromptDisplayOptions = 0x601,
        /// <summary>
        /// The Yes prompt screen.
        /// </summary>
        PromptYes = 0x602,
        /// <summary>
        /// The No prompt screen.
        /// </summary>
        PromptNo = 0x603
    }
}