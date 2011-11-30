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

            fsCharacteristic.Time.CurrentUnit = fsUnit.Second;
            fsCharacteristic.Length.CurrentUnit = fsUnit.MilliMeter;
            fsCharacteristic.Area.CurrentUnit = fsUnit.SquareSantiMeter;
            fsCharacteristic.Mass.CurrentUnit = fsUnit.Gramme;
            fsCharacteristic.Volume.CurrentUnit = fsUnit.MilliLiter;

            Application.Run(new MainWindow());
        }
    }
}
