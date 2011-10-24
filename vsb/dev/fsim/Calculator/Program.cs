using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Units;

namespace Calculator
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

            fsUnits.Time.CurrentName = "s";
            fsUnits.Length.CurrentName = "mm";
            fsUnits.Area.CurrentName = "cm2";
            fsUnits.Mass.CurrentName = "g";
            fsUnits.Volume.CurrentName = "ml";            

            Application.Run(new MainWindow());
        }
    }
}
