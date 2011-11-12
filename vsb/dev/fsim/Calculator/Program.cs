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

            fsCharacteristic.Time.CurrentName = "s";
            fsCharacteristic.Length.CurrentName = "mm";
            fsCharacteristic.Area.CurrentName = "cm2";
            fsCharacteristic.Mass.CurrentName = "g";
            fsCharacteristic.Volume.CurrentName = "ml";            

            Application.Run(new MainWindow());
        }
    }
}
