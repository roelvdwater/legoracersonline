using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Provides a set of tools that can be used within the application.
    /// </summary>
    abstract class Toolbox
    {
        /// <summary>
        /// Checks whether the current Windows user is an Administrator.
        /// </summary>
        /// <returns></returns>
        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                    .IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}