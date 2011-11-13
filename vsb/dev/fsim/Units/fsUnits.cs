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
            public static fsUnit Meter = new fsUnit("m", 1);
            public static fsUnit SquareMeter = new fsUnit("m2", 1);
            public static fsUnit SquareSantiMeter = new fsUnit("cm2", 1e-4);
            public static fsUnit SquareMilliMeter = new fsUnit("mm2", 1e-6);
            public static fsUnit Bar = new fsUnit("bar", 1e5);
            public static fsUnit Pascal = new fsUnit("Pa", 1);
            public static fsUnit Second = new fsUnit("s", 1);
            public static fsUnit Minute = new fsUnit("min", 60);
            public static fsUnit PerSecond = new fsUnit("1/s", 1);
            public static fsUnit PerMinute = new fsUnit("1/min", 1.0 / 60);
            public static fsUnit Percent = new fsUnit("%", 1e-2);
            public static fsUnit GrammeOverKilogramSolids = new fsUnit("g/kg_solids", 1e-3);
            public static fsUnit MilliGrammHPlusOverKiloGramme = new fsUnit("mg H+/kg solids", 1e-6);
            public static fsUnit GrammePerLiter = new fsUnit("g/l", 1);
            public static fsUnit KiloGrammePerCubicMeter = new fsUnit("kg/m3", 1);
            public static fsUnit MilliPascalSecond = new fsUnit("mPa s", 1e-3);
            public static fsUnit MilliNewtonPerMeter = new fsUnit("10-3 N m-1", 1e-3);
            public static fsUnit KiloGramme = new fsUnit("kg", 1);
            public static fsUnit Gramme = new fsUnit("g", 1e-3);
            public static fsUnit Liter = new fsUnit("l", 1e-3);
            public static fsUnit MilliLiter = new fsUnit("ml", 1e-6);
            public static fsUnit CubicMeter = new fsUnit("m3", 1);
            public static fsUnit KiloGrammePerHour = new fsUnit("kg/h", 1 / 3600.0);
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

        private readonly fsUnit [] m_units;
        public fsUnit[] Units
        {
            get { return m_units; }
        }

        private fsUnit m_currentUnit;

        private fsCharacteristic(params fsUnit[] units)
        {
            m_units = new fsUnit[units.Length];
            for (int i = 0; i < units.Length; ++i)
            {
                m_units[i] = units[i];
            }
            CurrentUnit = m_units[0];
        }

        public fsUnit CurrentUnit
        {
            get { return m_currentUnit; }
            set { m_currentUnit = value; }
        }

        #endregion

        #region Characteristic Listing

        public static fsCharacteristic NoUnits = new fsCharacteristic(new[] {
            fsUnit.NoUnit,
        });

        public static fsCharacteristic Length = new fsCharacteristic(new[] {
            fsUnit.MilliMeter,
            fsUnit.Meter
        });

        public static fsCharacteristic Area = new fsCharacteristic(new[] {
            fsUnit.SquareMeter,
            fsUnit.SquareSantiMeter,
            fsUnit.SquareMilliMeter
        });

        public static fsCharacteristic Pressure = new fsCharacteristic(new[] {
            fsUnit.Bar,
            fsUnit.Pascal
        });

        public static fsCharacteristic Time = new fsCharacteristic(new[] {
            fsUnit.Second,
            fsUnit.Minute
        });

        public static fsCharacteristic Frequency = new fsCharacteristic(new[] {
            fsUnit.PerSecond,
            fsUnit.PerMinute
        });

        public static fsCharacteristic Concentration = new fsCharacteristic(new[] {
            fsUnit.Percent,
            fsUnit.NoUnit
        });


        public static fsCharacteristic CakeWashOutContent = new fsCharacteristic(new[] {
            fsUnit.GrammeOverKilogramSolids,
            fsUnit.Percent,
            fsUnit.MilliGrammHPlusOverKiloGramme
        });

        public static fsCharacteristic SolidsConcentration = new fsCharacteristic(new[] {
            fsUnit.GrammePerLiter
        });

        public static fsCharacteristic Density = new fsCharacteristic(new[] {
            fsUnit.KiloGrammePerCubicMeter
        });

        public static fsCharacteristic Viscosity = new fsCharacteristic(new[] {
            fsUnit.MilliPascalSecond
        });

        public static fsCharacteristic SurfaceTension = new fsCharacteristic(new[] {
            fsUnit.MilliNewtonPerMeter
        });

        public static fsCharacteristic Mass = new fsCharacteristic(new[] {
            fsUnit.KiloGramme,
            fsUnit.Gramme
        });

        public static fsCharacteristic Volume = new fsCharacteristic(new[] {
            fsUnit.Liter,
            fsUnit.MilliLiter,
            fsUnit.CubicMeter
        });

        public static fsCharacteristic Flowrate = new fsCharacteristic(new[] {
            fsUnit.KiloGrammePerHour
        });

        public static fsCharacteristic CakePermeability = new fsCharacteristic(new[] {
            fsUnit.PerTen13SquareMeter
        });

        public static fsCharacteristic CakeResistance = new fsCharacteristic(new[] {
            fsUnit.Ten13PerSquareMeter
        });

        public static fsCharacteristic CakeResistanceAlpha = new fsCharacteristic(new[] {
            fsUnit.Ten10MeterPerKiloGramme
        });

        public static fsCharacteristic FilterMediumResistance = new fsCharacteristic(new[] {
            fsUnit.Ten10MeterPerKiloGramme
        });

        #endregion
    }
}
