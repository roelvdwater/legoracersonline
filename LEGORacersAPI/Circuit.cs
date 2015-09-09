using System.Collections.Generic;
using System.Linq;

namespace LEGORacersAPI
{
    /// <summary>
    /// Represents an in-game circuit.
    /// </summary>
    public class Circuit
    {
        /// <summary>
        /// Gets the number of the circuit.
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Gets the number within the block where the circuit belongs to.
        /// </summary>
        public int BlockNumber { get; private set; }

        /// <summary>
        /// Gets the number of the mirrored circuit.
        /// </summary>
        public int MirrorNumber { get; private set; }

        /// <summary>
        /// Gets the number within the block where the mirrored circuit belongs to.
        /// </summary>
        public int MirrorBlockNumber { get; private set; }

        /// <summary>
        /// Gets the name of the circuit.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of a circuit.
        /// </summary>
        /// <param name="number">The number of the circuit.</param>
        /// <param name="blockNumber">The number of the circuit within the block where the circuit belongs to.</param>
        /// <param name="mirrorNumber">The number of the mirrored version circuit.</param>
        /// <param name="mirrorBlockNumber">The number of the circuit within the block where the mirrored circuit belonags to.</param>
        /// <param name="name">The name of the circuit.</param>
        private Circuit(int number, int blockNumber, int mirrorNumber, int mirrorBlockNumber, string name)
        {
            Number = number;
            BlockNumber = blockNumber;
            MirrorNumber = mirrorNumber;
            MirrorBlockNumber = mirrorBlockNumber;
            Name = name;
        }

        /// <summary>
        /// Retrieves a list of all circuits in the game.
        /// </summary>
        /// <returns>Returns a list containing all circuits in the game.</returns>
        public static List<Circuit> GetAll()
        {
            List<Circuit> circuits = new List<Circuit>();

            // Block 1 and 4
            circuits.Add(new Circuit(0, 0, 2, 3, "Imperial Grand Prix"));
            circuits.Add(new Circuit(1, 0, 2, 2, "Dark Forest Dash"));
            circuits.Add(new Circuit(2, 0, 2, 1, "Magma Moon Marathon"));
            circuits.Add(new Circuit(3, 0, 2, 0, "Desert Adventure Driveaway"));

            // Block 2 and 5
            circuits.Add(new Circuit(0, 1, 3, 4, "Tribal Island Trail"));
            circuits.Add(new Circuit(1, 1, 2, 4, "Royal Knights Railway"));
            circuits.Add(new Circuit(2, 1, 1, 4, "Ice Planet Pathway"));
            circuits.Add(new Circuit(3, 1, 0, 4, "Amazon Adventure Alley"));
            
            // Block 3 and 6
            circuits.Add(new Circuit(0, 2, 20, 3, "Knightmare-athon"));
            circuits.Add(new Circuit(1, 2, 21, 2, "Pirate Skull Pass"));
            circuits.Add(new Circuit(2, 2, 22, 1, "Adventure Temple Trail"));
            circuits.Add(new Circuit(3, 2, 23, 0, "Alien Rally Asteroid"));

            // Block 7
            circuits.Add(new Circuit(0, 6, 1, 6, "Rocket Racer Run"));

            return circuits;
        }

        /// <summary>
        /// Retrieves a circuit.
        /// </summary>
        /// <param name="name">The name of the circuit.</param>
        /// <returns>Returns a circuit.</returns>
        public static Circuit GetByName(string name)
        {
            return GetAll().Where(m => m.Name == name).FirstOrDefault();
        }
    }
}