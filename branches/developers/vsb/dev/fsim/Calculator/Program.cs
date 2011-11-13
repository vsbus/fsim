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

            fsCharacteristic.Time.CurrentUnit = fsCharacteristic.fsUnit.Second;
            fsCharacteristic.Length.CurrentUnit = fsCharacteristic.fsUnit.MilliMeter;
            fsCharacteristic.Area.CurrentUnit = fsCharacteristic.fsUnit.SquareSantiMeter;
            fsCharacteristic.Mass.CurrentUnit = fsCharacteristic.fsUnit.Gramme;
            fsCharacteristic.Volume.CurrentUnit = fsCharacteristic.fsUnit.MilliLiter;

            Application.Run(new MainWindow());
        }
    }
}
