using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEGORacersAPI
{
    /// <summary>
    /// Represents types of initializations.
    /// </summary>
    public enum InitializedType
    {
        /// <summary>
        /// Nothing is initialized yet.
        /// </summary>
        None,
        /// <summary>
        /// The core is initialized.
        /// </summary>
        Core,
        /// <summary>
        /// The drivers are initialized.
        /// </summary>
        Drivers,
        /// <summary>
        /// Both types are initialzed.
        /// </summary>
        Both
    }
}