using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Units
{
    public class fsCharacteristic
    {
        #region fsCharacteristic

        private string m_name;
        public string Name
        {
            get { return m_name; }
        }

        private readonly fsUnit[] m_units;
        public fsUnit[] Units
        {
            get { return m_units; }
        }

        private fsUnit m_currentUnit;
        public fsUnit CurrentUnit
        {
            get { return m_currentUnit; }
            set { m_currentUnit = value; }
        }
        private fsCharacteristic(string name, params fsUnit[] units)
        {
            m_name = name;
            m_units = new fsUnit[units.Length];
            for (int i = 0; i < units.Length; ++i)
            {
                m_units[i] = units[i];
            }
            CurrentUnit = m_units[0];
        }


        #endregion

        #region Characteristic Listing

        public static fsCharacteristic NoUnits = new fsCharacteristic(
            "No units",
            new[] {
                fsUnit.NoUnit
            }
        );

        public static fsCharacteristic Length = new fsCharacteristic(
            "Length",
            new[] {
                fsUnit.MilliMeter,
                fsUnit.SantiMeter,
                fsUnit.DeciMeter,
                fsUnit.Meter
            }
        );

        public static fsCharacteristic Area = new fsCharacteristic(
            "Area",
            new[] {
                fsUnit.SquareSantiMeter,
                fsUnit.SquareDeciMeter,
                fsUnit.SquareMeter,
            }
        );

        public static fsCharacteristic Pressure = new fsCharacteristic(
            "Pressure",
            new[] {
                fsUnit.Bar,
                fsUnit.Pascal
            }
        );

        public static fsCharacteristic Time = new fsCharacteristic(
            "Time",
            new[] {
                fsUnit.Second,
                fsUnit.Minute,
                fsUnit.Hour
            }
        );

        public static fsCharacteristic Frequency = new fsCharacteristic(
            "Frequency",
            new[] {
                fsUnit.PerSecond,
                fsUnit.PerMinute
            }
        );

        public static fsCharacteristic Concentration = new fsCharacteristic(
            "Concentration",
            new[] {
                fsUnit.Percent,
                fsUnit.NoUnit
            }
        );


        public static fsCharacteristic CakeWashOutContent = new fsCharacteristic(
            "Cake with wash out content",
            new[] {
                fsUnit.GrammeOverKilogram,
                fsUnit.Percent,
                fsUnit.MilliGrammOverKiloGramme
            }
        );

        public static fsCharacteristic SolidsConcentration = new fsCharacteristic(
            "Solids concentration",
            new[] {
                fsUnit.GrammePerLiter
            }
        );

        public static fsCharacteristic Density = new fsCharacteristic(
            "Density",
            new[] {
                fsUnit.KiloGrammePerCubicMeter,
                fsUnit.GrammePerCubicSantiMeter
            }
        );

        public static fsCharacteristic Viscosity = new fsCharacteristic(
            "Viscosity",
            new[] {
                fsUnit.MilliPascalSecond,
                fsUnit.PascalSecond
            }
        );

        public static fsCharacteristic SurfaceTension = new fsCharacteristic(
            "Surface tension",
            new[] {
                fsUnit.MilliNewtonPerMeter,
                fsUnit.NewtonPerMeter
            }
        );

        public static fsCharacteristic Mass = new fsCharacteristic(
            "Mass",
            new[] {
                fsUnit.Gramme,
                fsUnit.KiloGramme,
                fsUnit.Ton
            }
        );

        public static fsCharacteristic Volume = new fsCharacteristic(
            "Volume",
            new[] {
                fsUnit.MilliLiter,
                fsUnit.Liter,
                fsUnit.CubicMeter
            }
        );

        public static fsCharacteristic MassFlowrate = new fsCharacteristic(
            "Mass flowrate",
            new[] {
                fsUnit.KiloGrammePerSec,
                fsUnit.KiloGrammePerMin,
                fsUnit.KiloGrammePerHour,
                fsUnit.TonPerHour
            }
        );

        public static fsCharacteristic CakePermeability = new fsCharacteristic(
            "Cake permeability",
            new[] {
                fsUnit.PerTen13SquareMeter
            }
        );

        public static fsCharacteristic CakeResistance = new fsCharacteristic(
            "Cake resistance",
            new[] {
                fsUnit.Ten13PerSquareMeter
            }
        );

        public static fsCharacteristic CakeResistanceAlpha = new fsCharacteristic(
            "Cake resistance alpha",
            new[] {
                fsUnit.Ten10MeterPerKiloGramme
            }
        );

        public static fsCharacteristic FilterMediumResistance = new fsCharacteristic(
            "Filter medium resistance",
            new[] {
                fsUnit.Ten10MeterPerKiloGramme
            }
        );

        #endregion
    }
}
