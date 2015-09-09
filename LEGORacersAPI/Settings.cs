namespace LEGORacersAPI
{
    /// <summary>
    /// Represents global settings determing how the API works.
    /// </summary>
    public abstract class Settings
    {
        /// <summary>
        /// Gets or sets the refresh rate of internal threads.
        /// </summary>
        public static RefreshRate RefreshRate { get; set; }

        /// <summary>
        /// Gets or sets the decision to automatically initialize instances if possible.
        /// </summary>
        public static bool AutoInitialize { get; set; }

        static Settings()
        {
            // Set default settings

            RefreshRate = RefreshRate.Medium;
            AutoInitialize = true;
        }
    }
}