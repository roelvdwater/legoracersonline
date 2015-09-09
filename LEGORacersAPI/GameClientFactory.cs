using System.Collections.Generic;
using System.Diagnostics;

namespace LEGORacersAPI
{
    /// <summary>
    /// Represents a factory for retrieving GameClient instances.
    /// </summary>
    public abstract class GameClientFactory
    {
        /// <summary>
        /// Creates and returns a new instance of a GameClient based on the game clients file MD5 hash.
        /// </summary>
        /// <param name="process">The LEGO Racers game client Process.</param>
        /// <returns>Returns a GameClient instance.</returns>
        public static GameClient GetGameClient(Process process)
        {
            return GetGameClient(process, true);
        }

        /// <summary>
        /// Creates and returns a new instance of a GameClient based on the game clients file MD5 hash.
        /// </summary>
        /// <param name="process">The LEGO Racers game client Process.</param>
        /// <param name="initialize">Determines whether to initialize the GameClient instance automatically.</param>
        /// <returns>Returns a GameClient instance.</returns>
        public static GameClient GetGameClient(Process process, bool initialize)
        {
            string md5hash = Toolbox.GetMD5Hash(process.MainModule.FileName);
            GameClient gameClient = null;

            switch (md5hash)
            {
                case "80c9577841476a26ed76749b8e4b4a9f": case "8c4bb866a9b5d313584831834aec8158":
                    gameClient = new Client_1999NoDRM(process, initialize);
                    break;
                case "a0007cfe64097651e5505fba15ab5cc1":
                    gameClient = new Client_1999NoDRM(process, initialize);
                    break;
                case "325cbbedc9d745107bca4a8654fce4db":
                    gameClient = new Client_2001(process, initialize);
                    break;
            }

            return gameClient;
        }

        /// <summary>
        /// Retrieves an array with active game clients.
        /// </summary>
        /// <returns>Returns an array with active game clients.</returns>
        public static GameClient[] GetActiveGameClients()
        {
            List<GameClient> gameClients = new List<GameClient>();

            Process[] gameProcesses = Process.GetProcessesByName("LEGORacers");

            foreach (Process gameProcess in gameProcesses)
            {
                GameClient gameClient = GetGameClient(gameProcess);

                if (gameClient != null)
                {
                    gameClients.Add(gameClient);
                }
            }

            return gameClients.ToArray();
        }
    }
}