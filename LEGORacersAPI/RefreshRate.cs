using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEGORacersAPI
{
    /// <summary>
    /// Specifies values for refresh rates.
    /// </summary>
    public enum RefreshRate
    {
        /// <summary>
        /// Refreshes the data at a low rate (100ms).
        /// </summary>
        Low = 100,
        /// <summary>
        /// Refreshes the data at a medium rate (10ms).
        /// </summary>
        Medium = 10,
        /// <summary>
        /// Refreshes the data at a high rate (1ms).
        /// </summary>
        High = 1,
        /// <summary>
        /// Refreshes the data with no delay.
        /// </summary>
        Realtime = 0
    }
}