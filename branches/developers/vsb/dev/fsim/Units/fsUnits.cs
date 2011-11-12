using System;
namespace Units
{
    public class fsCharacteristic
    {
        #region fsCharacteristic

        public struct fsUnit
        {
            public string Name { get; private set; }

            public double Coefficient { get; private set; }

            public fsUnit(string name, double coefficient) : this()
            {
                Name = name;
                Coefficient = coefficient;
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

        #region Characteristic Listing

        public static fsCharacteristic NoUnits = new fsCharacteristic(new[] {
            new fsUnit("-", 1),
        });

        public static fsCharacteristic Length = new fsCharacteristic(new[] {
            new fsUnit("mm", 1e-3),
            new fsUnit("m", 1)
        });

        public static fsCharacteristic Area = new fsCharacteristic(new[] {
            new fsUnit("m2", 1),
            new fsUnit("cm2", 1e-4),
            new fsUnit("mm2", 1e-6)
        });

        public static fsCharacteristic Pressure = new fsCharacteristic(new[] {
            new fsUnit("bar", 1e5),
            new fsUnit("Pa", 1)
        });

        public static fsCharacteristic Time = new fsCharacteristic(new[] {
            new fsUnit("s", 1),
            new fsUnit("m", 60)
        });

        public static fsCharacteristic Frequency = new fsCharacteristic(new[] {
            new fsUnit("1/s", 1),
            new fsUnit("1/m", 1.0 / 60)
        });

        public static fsCharacteristic Concentration = new fsCharacteristic(new[] {
            new fsUnit("%", 1e-2),
            new fsUnit("-", 1)
        });


        public static fsCharacteristic CakeWashOutContent = new fsCharacteristic(new[] {
            new fsUnit("g/kg_solids", 1e-3),
            new fsUnit("%", 1e-2),
            new fsUnit("mg H+/kg solids", 1e-6)
        });

        public static fsCharacteristic SolidsConcentration = new fsCharacteristic(new[] {
            new fsUnit("g/l", 1)
        });

        public static fsCharacteristic Density = new fsCharacteristic(new[] {
            new fsUnit("kg/m3", 1)
        });

        public static fsCharacteristic Viscosity = new fsCharacteristic(new[] {
            new fsUnit("mPa s", 1e-3)
        });

        public static fsCharacteristic SurfaceTension = new fsCharacteristic(new[] {
            new fsUnit("10-3 N m-1", 1e-3)
        });

        public static fsCharacteristic Mass = new fsCharacteristic(new[] {
            new fsUnit("kg", 1),
            new fsUnit("g", 1e-3)
        });

        public static fsCharacteristic Volume = new fsCharacteristic(new[] {
            new fsUnit("l", 1e-3),
            new fsUnit("ml", 1e-6),
            new fsUnit("m3", 1)
        });

        public static fsCharacteristic Flowrate = new fsCharacteristic(new[] {
            new fsUnit("kg/h", 1/3600.0),
        });

        public static fsCharacteristic CakePermeability = new fsCharacteristic(new[] {
            new fsUnit("10-13m2", 1e-13)
        });

        public static fsCharacteristic CakeResistance = new fsCharacteristic(new[] {
            new fsUnit("10+13m-2", 1e13)
        });

        public static fsCharacteristic CakeResistanceAlpha = new fsCharacteristic(new[] {
            new fsUnit("10+10m/kg", 1e10)
        });

        public static fsCharacteristic FilterMediumResistance = new fsCharacteristic(new[] {
            new fsUnit("10+10m/kg", 1e10)
        });

        #endregion
    }
}
