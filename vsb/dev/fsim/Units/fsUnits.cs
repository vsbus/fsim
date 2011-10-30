using System;
namespace Units
{
    public class fsUnits
    {
        #region fsUnits

        struct fsUnitRecord
        {
            public string Name { get; private set; }

            public double Coefficient { get; private set; }

            public fsUnitRecord(string name, double coefficient) : this()
            {
                Name = name;
                Coefficient = coefficient;
            }
        }

        private readonly fsUnitRecord [] m_units;
        private fsUnitRecord m_currentUnit;

        private fsUnits(params fsUnitRecord[] units)
        {
            m_units = new fsUnitRecord[units.Length];
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
            set
            {
                foreach (var unitRecord in m_units)
                {
                    if (unitRecord.Name == value)
                    {
                        m_currentUnit = unitRecord;
                        return;
                    }
                }
                throw new Exception("Desired units doesn't exist in m_units list.");
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

        public static fsUnits NoUnits = new fsUnits(new[] {
            new fsUnitRecord("-", 1),
        });

        public static fsUnits Length = new fsUnits(new[] {
            new fsUnitRecord("mm", 1e-3),
            new fsUnitRecord("m", 1)
        });

        public static fsUnits Area = new fsUnits(new[] {
            new fsUnitRecord("m2", 1),
            new fsUnitRecord("cm2", 1e-4),
            new fsUnitRecord("mm2", 1e-6)
        });

        public static fsUnits Pressure = new fsUnits(new[] {
            new fsUnitRecord("bar", 1e5),
            new fsUnitRecord("Pa", 1)
        });

        public static fsUnits Time = new fsUnits(new[] {
            new fsUnitRecord("s", 1),
            new fsUnitRecord("m", 60)
        });

        public static fsUnits Frequency = new fsUnits(new[] {
            new fsUnitRecord("1/s", 1),
            new fsUnitRecord("1/m", 1.0 / 60)
        });

        public static fsUnits Concentration = new fsUnits(new[] {
            new fsUnitRecord("%", 1e-2),
            new fsUnitRecord("-", 1)
        });


        public static fsUnits CakeWashOutContent = new fsUnits(new[] {
            new fsUnitRecord("g/kg_solids", 1e-3),
            new fsUnitRecord("%", 1e-2),
            new fsUnitRecord("mg H+/kg solids", 1e-6)
        });

        public static fsUnits SolidsConcentration = new fsUnits(new[] {
            new fsUnitRecord("g/l", 1)
        });

        public static fsUnits Density = new fsUnits(new[] {
            new fsUnitRecord("kg/m3", 1)
        });

        public static fsUnits Viscosity = new fsUnits(new[] {
            new fsUnitRecord("mPa s", 1e-3)
        });

        public static fsUnits SurfaceTension = new fsUnits(new[] {
            new fsUnitRecord("10-3 N m-1", 1e-3)
        });

        public static fsUnits Mass = new fsUnits(new[] {
            new fsUnitRecord("kg", 1),
            new fsUnitRecord("g", 1e-3)
        });

        public static fsUnits Volume = new fsUnits(new[] {
            new fsUnitRecord("l", 1e-3),
            new fsUnitRecord("ml", 1e-6),
            new fsUnitRecord("m3", 1)
        });

        public static fsUnits Flowrate = new fsUnits(new[] {
            new fsUnitRecord("kg/h", 1/3600.0),
        });

        public static fsUnits CakePermeability = new fsUnits(new[] {
            new fsUnitRecord("10-13m2", 1e-13)
        });

        public static fsUnits CakeResistance = new fsUnits(new[] {
            new fsUnitRecord("10+13m-2", 1e13)
        });

        public static fsUnits CakeResistanceAlpha = new fsUnits(new[] {
            new fsUnitRecord("10+10m/kg", 1e10)
        });

        public static fsUnits FilterMediumResistance = new fsUnits(new[] {
            new fsUnitRecord("10+10m/kg", 1e10)
        });

        #endregion
    }
}
