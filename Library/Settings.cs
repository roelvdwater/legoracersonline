using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class Settings
    {
        /// <summary>
        /// Gets or sets the value whether the Power-Ups are freezed or not.
        /// </summary>
        public static bool PowerUpFreezeEnabled { get; set; }

        /// <summary>
        /// Gets or sets the value whether the Power-Up White bricks are freezed or not.
        /// </summary>
        public static bool PowerUpWhiteBricksEnabled { get; set; }

        /// <summary>
        /// Gets or sets the value whether all Players are freezed or not.
        /// </summary>
        public static bool FreezeAllPlayersEnabled { get; set; }

        /// <summary>
        /// Gets or sets the type of the Power-Up to freeze if enabled.
        /// </summary>
        public static int PowerUp { get; set; }

        /// <summary>
        /// Gets or sets the amount of Power-Up White bricks to freeze if enabled.
        /// </summary>
        public static int PowerUpWhiteBricks { get; set; }

        public static string Serialize()
        {
            /*
             * The following indexes are used for the settings in a settings string:
             * 
             * 0: Power-Up freeze enabled (0 = False, 1 = True)
             * 1: Upgrade Crystals freeze enabled (0 = False, 1 = True)
             * 2: All Players freeze enabled (0 = False, 1 = True)
             * 3: The Power-Up type (0 - 4 in order: None, Red, Blue, Green, Yellow)
             * 4: The amount of White bricks
             * */

            return (PowerUpFreezeEnabled ? "1" : "0") + (PowerUpWhiteBricksEnabled ? "1" : "0") + (FreezeAllPlayersEnabled ? "1" : "0") + (PowerUp) + (PowerUpWhiteBricks);
        }

        public static void Unserialize(string settings)
        {
            if (settings.Length == 5)
            {
                PowerUpFreezeEnabled = settings[0] == '1';
                PowerUpWhiteBricksEnabled = settings[1] == '1';
                FreezeAllPlayersEnabled = settings[2] == '1';

                switch ((int)settings[3])
                {
                    case '0':
                    default:
                        PowerUp = 0;
                        break;
                    case '1':
                        PowerUp = 1;
                        break;
                    case '2':
                        PowerUp = 2;
                        break;
                    case '3':
                        PowerUp = 3;
                        break;
                    case '4':
                        PowerUp = 4;
                        break;
                }

                switch ((int)settings[4])
                {
                    case '0':
                    default:
                        PowerUpWhiteBricks = 0;
                        break;
                    case '1':
                        PowerUpWhiteBricks = 1;
                        break;
                    case '2':
                        PowerUpWhiteBricks = 2;
                        break;
                    case '3':
                        PowerUpWhiteBricks = 3;
                        break;
                    case '4':
                        PowerUpWhiteBricks = 4;
                        break;
                }
            }
        }
    }
}