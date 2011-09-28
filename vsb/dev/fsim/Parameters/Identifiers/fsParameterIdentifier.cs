using Units;

namespace Parameters
{
    public class fsParameterIdentifier
    {
        #region fsParameterIdentifier

        public string Name { get; private set; }

        public string FullName { get; private set; }

        public fsUnits Units { get; private set; }

        public fsParameterIdentifier(string name)
        {
            Name = name;
            FullName = name;
            Units = fsUnits.NoUnits;
        }

        public fsParameterIdentifier(string name, fsUnits units)
        {
            Name = name;
            FullName = name;
            Units = units;
        }

        public fsParameterIdentifier(string name, string fullName, fsUnits units)
        {
            Name = name;
            FullName = fullName;
            Units = units;
        }

        public fsParameterIdentifier(string name, string fullName)
        {
            Name = name;
            FullName = fullName;
            Units = fsUnits.NoUnits;
        }

        public override string ToString()
        {
            return FullName + " (" + Name + ")";
        }

        #endregion

        #region Parameters Collection

        public static fsParameterIdentifier Porosity = new fsParameterIdentifier("eps", fsUnits.Concentration);
        public static fsParameterIdentifier Kappa = new fsParameterIdentifier("kappa");
        public static fsParameterIdentifier Pc = new fsParameterIdentifier("Pc", fsUnits.PermeabilityPc);
        public static fsParameterIdentifier Rc = new fsParameterIdentifier("rc", fsUnits.CakeResistanceRc);
        public static fsParameterIdentifier Alpha = new fsParameterIdentifier("alpha", fsUnits.CakeResistanceAlpha);

        public static fsParameterIdentifier FilterArea = new fsParameterIdentifier("A", fsUnits.Area);
        public static fsParameterIdentifier Pressure = new fsParameterIdentifier("Dp", fsUnits.Pressure);
        public static fsParameterIdentifier CycleTime = new fsParameterIdentifier("tc", fsUnits.Time);
        public static fsParameterIdentifier RotationalSpeed = new fsParameterIdentifier("n", fsUnits.Frequency);
        public static fsParameterIdentifier FormationRelativeTime = new fsParameterIdentifier("sf", fsUnits.Concentration);
        public static fsParameterIdentifier FormationTime = new fsParameterIdentifier("tf", fsUnits.Time);
        public static fsParameterIdentifier CakeHeight = new fsParameterIdentifier("hc", fsUnits.Length);
        public static fsParameterIdentifier SuspensionMass = new fsParameterIdentifier("Msus", fsUnits.Mass);
        public static fsParameterIdentifier SuspensionVolume = new fsParameterIdentifier("Vsus", fsUnits.Volume);
        public static fsParameterIdentifier SuspensionMassFlowrate = new fsParameterIdentifier("Qmsus", fsUnits.Flowrate);

        
        public static fsParameterIdentifier FiltrateViscosity = new fsParameterIdentifier("etaf", fsUnits.Viscosity);
        public static fsParameterIdentifier FiltrateDensity = new fsParameterIdentifier("rho_f", "Filtrate Density", fsUnits.Density);
        public static fsParameterIdentifier SolidsDensity = new fsParameterIdentifier("rho_s", "Solids Density", fsUnits.Density);
        public static fsParameterIdentifier SuspensionDensity = new fsParameterIdentifier("rho_sus", "Suspension Density", fsUnits.Density);
        public static fsParameterIdentifier SolidsMassFraction = new fsParameterIdentifier("Cm", "Solids Mass Fraction", fsUnits.Concentration);
        public static fsParameterIdentifier SolidsVolumeFraction = new fsParameterIdentifier("Cv", "Solids Volume Fraction", fsUnits.Concentration);
        public static fsParameterIdentifier SolidsConcentration = new fsParameterIdentifier("C", "Solids Concentration", fsUnits.SolidsConcentration);
        public static fsParameterIdentifier Porosity0 = new fsParameterIdentifier("eps0", "Porosity0", fsUnits.Concentration);
        public static fsParameterIdentifier Kappa0 = new fsParameterIdentifier("kappa0");
        public static fsParameterIdentifier Ne = new fsParameterIdentifier("ne");
        public static fsParameterIdentifier Pc0 = new fsParameterIdentifier("Pc0", fsUnits.PermeabilityPc);
        public static fsParameterIdentifier Rc0 = new fsParameterIdentifier("rc0", fsUnits.CakeResistanceRc);
        public static fsParameterIdentifier Nc = new fsParameterIdentifier("nc");
        public static fsParameterIdentifier Alpha0 = new fsParameterIdentifier("alpha0", fsUnits.CakeResistanceAlpha);
        public static fsParameterIdentifier Hce0 = new fsParameterIdentifier("hce0", fsUnits.Length);
        public static fsParameterIdentifier Rm0 = new fsParameterIdentifier("Rm0", fsUnits.FilterMediumResistance);

        #endregion
    }
}
