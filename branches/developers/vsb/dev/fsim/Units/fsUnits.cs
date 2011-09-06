using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Units
{
    public class fsUnits
    {
        #region fsUnits

        struct UnitRecord
        {
            string m_name;
            public string Name
            {
                get { return m_name; }
                set { m_name = value; }
            }

            double m_coefficient;
            public double Coefficient
            {
                get { return m_coefficient; }
                set { m_coefficient = value; }
            }

            public UnitRecord(string name, double coefficient)
            {
                m_name = name;
                m_coefficient = coefficient;
            }
        }

        private UnitRecord [] m_units;
        private UnitRecord m_currentUnit;

        private fsUnits(params UnitRecord[] units)
        {
            m_units = new UnitRecord[units.Length];
            for (int i = 0; i < units.Length; ++i)
            {
                m_units[i] = units[i];
            }
            m_currentUnit = m_units[0];
        }

        public string CurrentName
        {
            get
            {
                return m_currentUnit.Name;
            }
        }

        public double CurrentCoefficient
        {
            get
            {
                return m_currentUnit.Coefficient;
            }
        }

        #endregion

        #region Units Collection

        public static fsUnits NoUnits = new fsUnits(new UnitRecord[] {
            new UnitRecord("-", 1),
        });

        public static fsUnits Length = new fsUnits(new UnitRecord[] {
            new UnitRecord("mm", 1e-3),
            new UnitRecord("m", 1)
        });

        public static fsUnits Area = new fsUnits(new UnitRecord[] {
            new UnitRecord("m2", 1),
            new UnitRecord("cm2", 1e-4),
            new UnitRecord("mm2", 1e-6)
        });

        public static fsUnits Pressure = new fsUnits(new UnitRecord[] {
            new UnitRecord("bar", 1e5),
            new UnitRecord("Pa", 1)
        });

        public static fsUnits Time = new fsUnits(new UnitRecord[] {
            new UnitRecord("s", 1),
            new UnitRecord("m", 60)
        });

        public static fsUnits Frequency = new fsUnits(new UnitRecord[] {
            new UnitRecord("1/s", 1),
            new UnitRecord("1/m", 1.0 / 60)
        });

        public static fsUnits Concentration = new fsUnits(new UnitRecord[] {
            new UnitRecord("%", 1e-2),
            new UnitRecord("-", 1)
        });

        public static fsUnits Density = new fsUnits(new UnitRecord[] {
            new UnitRecord("kg/m3", 1),
        });

        public static fsUnits Viscosity = new fsUnits(new UnitRecord[] {
            new UnitRecord("mPa s", 1e-3),
        });

        public static fsUnits Mass = new fsUnits(new UnitRecord[] {
            new UnitRecord("kg", 1),
            new UnitRecord("g", 1e-3)
        });

        public static fsUnits Volume = new fsUnits(new UnitRecord[] {
            new UnitRecord("l", 1e-3),
            new UnitRecord("m3", 1)
        });

        public static fsUnits PermeabilityPc = new fsUnits(new UnitRecord[] {
            new UnitRecord("10-13m2", 1e-13)
        });

        public static fsUnits CakeResistanceRc = new fsUnits(new UnitRecord[] {
            new UnitRecord("10+13m-2", 1e13)
        });

        public static fsUnits CakeResistanceAlpha = new fsUnits(new UnitRecord[] {
            new UnitRecord("10+10m/kg", 1e10)
        });

        public static fsUnits FilterMediumResistance = new fsUnits(new UnitRecord[] {
            new UnitRecord("10+10m/kg", 1e10)
        });

        #endregion
    }
}
