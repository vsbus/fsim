using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Units
{
    public class fsCharacteristic
    {
        #region fsCharacteristic

        public struct fsUnit
        {
            #region fsUnit

            public string Name { get; private set; }

            public double Coefficient { get; private set; }

            public fsUnit(string name, double coefficient)
                : this()
            {
                Name = name;
                Coefficient = coefficient;
            }

            #endregion

            #region Units Listing

            public static fsUnit NoUnit = new fsUnit("-", 1);
            public static fsUnit MilliMeter = new fsUnit("mm", 1e-3);
            public static fsUnit SantiMeter = new fsUnit("sm", 1e-2);
            public static fsUnit DeciMeter = new fsUnit("dm", 1e-1);
            public static fsUnit Meter = new fsUnit("m", 1);
            public static fsUnit SquareMeter = new fsUnit("m2", 1);
            public static fsUnit SquareDeciMeter = new fsUnit("dm2", 1e-2);
            public static fsUnit SquareSantiMeter = new fsUnit("cm2", 1e-4);
            public static fsUnit SquareMilliMeter = new fsUnit("mm2", 1e-6);
            public static fsUnit Bar = new fsUnit("bar", 1e5);
            public static fsUnit Pascal = new fsUnit("Pa", 1);
            public static fsUnit Second = new fsUnit("s", 1);
            public static fsUnit Minute = new fsUnit("min", 60);
            public static fsUnit Hour = new fsUnit("h", 3600);
            public static fsUnit PerSecond = new fsUnit("1/s", 1);
            public static fsUnit PerMinute = new fsUnit("1/min", 1.0 / 60);
            public static fsUnit Percent = new fsUnit("%", 1e-2);
            public static fsUnit GrammeOverKilogram = new fsUnit("g/kg", 1e-3);
            public static fsUnit MilliGrammOverKiloGramme = new fsUnit("mg/kg", 1e-6);
            public static fsUnit GrammePerLiter = new fsUnit("g/l", 1);
            public static fsUnit GrammePerCubicSantiMeter = new fsUnit("g/cm3", 1e-3/1e-6);
            public static fsUnit KiloGrammePerCubicMeter = new fsUnit("kg/m3", 1);
            public static fsUnit MilliPascalSecond = new fsUnit("mPa s", 1e-3);
            public static fsUnit PascalSecond = new fsUnit("Pa s", 1);
            public static fsUnit MilliNewtonPerMeter = new fsUnit("mili N/m", 1e-3);
            public static fsUnit NewtonPerMeter = new fsUnit("N/m", 1);
            public static fsUnit Ton = new fsUnit("t", 1e3);
            public static fsUnit KiloGramme = new fsUnit("kg", 1);
            public static fsUnit Gramme = new fsUnit("g", 1e-3);
            public static fsUnit Liter = new fsUnit("l", 1e-3);
            public static fsUnit MilliLiter = new fsUnit("ml", 1e-6);
            public static fsUnit CubicMeter = new fsUnit("m3", 1);
            public static fsUnit TonPerHour = new fsUnit("t/h", 1000 / 3600.0);
            public static fsUnit KiloGrammePerHour = new fsUnit("kg/h", 1 / 3600.0);
            public static fsUnit KiloGrammePerMin = new fsUnit("kg/min", 1 / 60.0);
            public static fsUnit KiloGrammePerSec = new fsUnit("kg/s", 1.0);
            public static fsUnit PerTen13SquareMeter = new fsUnit("10-13m2", 1e-13);
            public static fsUnit Ten13PerSquareMeter = new fsUnit("10+13m-2", 1e13);
            public static fsUnit Ten10MeterPerKiloGramme = new fsUnit("10+10m/kg", 1e10);

            #endregion

            public static fsUnit UnitFromText(string unitName)
            {
                Type type = typeof(fsUnit);
                FieldInfo[] fields = type.GetFields();
                foreach (var field in fields)
                {
                    var unit = ((fsUnit)field.GetValue(null));
                    if (unit.Name == unitName)
                    {
                        return unit;
                    }
                }
                throw new Exception("Desiren name doesn't correspond to any units.");
            }
        }

        private string m_name;
        public string Name
        {
            get { return m_name; }            
        }
        
        private readonly fsUnit [] m_units;
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
                fsUnit.SquareMeter,
                fsUnit.SquareDeciMeter,
                fsUnit.SquareSantiMeter,
                //fsUnit.SquareMilliMeter
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
                fsUnit.Ton,
                fsUnit.KiloGramme,
                fsUnit.Gramme
            }
        );

        public static fsCharacteristic Volume = new fsCharacteristic(
            "Volume",
            new[] {
                fsUnit.Liter,
                fsUnit.MilliLiter,
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
