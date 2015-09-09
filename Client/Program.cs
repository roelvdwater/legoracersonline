using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //MessageBox.Show("This software is not involved in ANY WAY with the the LEGO company. This means:" + Environment.NewLine + "- This software is not sponsored by the LEGO company in ANY WAY" + Environment.NewLine + "- This software recieves NO SUPPORT from the LEGO company" + Environment.NewLine + "- All the LEGO company copyrighted models, like logos, are NOT owned by the creators of this software and are owned by the LEGO company" + Environment.NewLine + Environment.NewLine + "By using this software, you agree that you will not (try to) make money with this software and agree that this software is in NO WAY involved with the LEGO company.", "Attention");
            //Properties.Settings.Default.GameClientDirectory = "";
            //Properties.Settings.Default.Save();
            if (String.IsNullOrWhiteSpace(Properties.Settings.Default.GameClientDirectory))
            {
                Application.Run(new WizardForm());
            }
            else
            {
                Application.Run(new LauncherForm());
            }
        }
    }
}