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
            return FullName == Name ? Name : FullName + " (" + Name + ")";
        }

        #endregion

        #region Parameters Collection

        public static fsParameterIdentifier CakePorosity = new fsParameterIdentifier("eps", "Cake Porosity", fsUnits.Concentration);
        public static fsParameterIdentifier Kappa = new fsParameterIdentifier("kappa");
        public static fsParameterIdentifier Pc = new fsParameterIdentifier("Pc", fsUnits.PermeabilityPc);
        public static fsParameterIdentifier Rc = new fsParameterIdentifier("rc", fsUnits.CakeResistanceRc);
        public static fsParameterIdentifier Alpha = new fsParameterIdentifier("alpha", fsUnits.CakeResistanceAlpha);

        public static fsParameterIdentifier FilterArea = new fsParameterIdentifier("A", "Filter Area", fsUnits.Area);
        public static fsParameterIdentifier MachineDiameter = new fsParameterIdentifier("D", "Machine Diameter", fsUnits.Length);
        public static fsParameterIdentifier FilterElementDiameter = new fsParameterIdentifier("d", "Filter Element Diameter", fsUnits.Length);
        public static fsParameterIdentifier FilterB = new fsParameterIdentifier("b", fsUnits.Length);
        public static fsParameterIdentifier FilterBOverDiameter = new fsParameterIdentifier("b/D", fsUnits.NoUnits);

        public static fsParameterIdentifier Pressure = new fsParameterIdentifier("Dp", fsUnits.Pressure);
        public static fsParameterIdentifier CycleTime = new fsParameterIdentifier("tc", fsUnits.Time);
        public static fsParameterIdentifier RotationalSpeed = new fsParameterIdentifier("n", fsUnits.Frequency);
        public static fsParameterIdentifier FormationRelativeTime = new fsParameterIdentifier("sf", fsUnits.Concentration);
        public static fsParameterIdentifier FormationTime = new fsParameterIdentifier("tf", fsUnits.Time);
        public static fsParameterIdentifier CakeHeight = new fsParameterIdentifier("hc", fsUnits.Length);

        public static fsParameterIdentifier WetCakeMass = new fsParameterIdentifier("Mcw", "Wet Cake Mass", fsUnits.Mass);
        public static fsParameterIdentifier DryCakeMass = new fsParameterIdentifier("Mcd", "Dry Cake Mass", fsUnits.Mass);
        public static fsParameterIdentifier SuspensionMass = new fsParameterIdentifier("Msus", "Suspension Mass", fsUnits.Mass);
        public static fsParameterIdentifier FiltrateMass = new fsParameterIdentifier("Mf", "Fitrate Mass", fsUnits.Mass);
        public static fsParameterIdentifier LiquidMass = new fsParameterIdentifier("Ml", "Liquid Mass", fsUnits.Mass);
        public static fsParameterIdentifier SolidsMass = new fsParameterIdentifier("Ms", "Solids Mass", fsUnits.Mass);
        public static fsParameterIdentifier CakeMass = new fsParameterIdentifier("Mc", "Cake Mass", fsUnits.Mass);
        
        public static fsParameterIdentifier SuspensionVolume = new fsParameterIdentifier("Vsus", fsUnits.Volume);

        public static fsParameterIdentifier SuspensionMassFlowrate = new fsParameterIdentifier("Qmsus", fsUnits.Flowrate);

        
        public static fsParameterIdentifier FiltrateViscosity = new fsParameterIdentifier("etaf", fsUnits.Viscosity);
        public static fsParameterIdentifier FiltrateDensity = new fsParameterIdentifier("rho_f", "Filtrate Density", fsUnits.Density);
        public static fsParameterIdentifier LiquidDensity = new fsParameterIdentifier("rho_l", "Liquid Density", fsUnits.Density);
        public static fsParameterIdentifier SolidsDensity = new fsParameterIdentifier("rho_s", "Solids Density", fsUnits.Density);
        public static fsParameterIdentifier SuspensionDensity = new fsParameterIdentifier("rho_sus", "Suspension Density", fsUnits.Density);
        public static fsParameterIdentifier SolidsMassFraction = new fsParameterIdentifier("Cm", "Solids Mass Fraction", fsUnits.Concentration);
        public static fsParameterIdentifier SolidsVolumeFraction = new fsParameterIdentifier("Cv", "Solids Volume Fraction", fsUnits.Concentration);
        public static fsParameterIdentifier SolidsConcentration = new fsParameterIdentifier("C", "Solids Concentration", fsUnits.SolidsConcentration);
        public static fsParameterIdentifier CakePorosity0 = new fsParameterIdentifier("eps0", "Cake Porosity 0", fsUnits.Concentration);
        public static fsParameterIdentifier Kappa0 = new fsParameterIdentifier("kappa0");
        public static fsParameterIdentifier Ne = new fsParameterIdentifier("ne");
        public static fsParameterIdentifier Pc0 = new fsParameterIdentifier("Pc0", fsUnits.PermeabilityPc);
        public static fsParameterIdentifier Rc0 = new fsParameterIdentifier("rc0", fsUnits.CakeResistanceRc);
        public static fsParameterIdentifier CakeCompressibility = new fsParameterIdentifier("nc", "Cake Compressibility");
        public static fsParameterIdentifier Alpha0 = new fsParameterIdentifier("alpha0", fsUnits.CakeResistanceAlpha);
        public static fsParameterIdentifier Hce0 = new fsParameterIdentifier("hce0", fsUnits.Length);
        public static fsParameterIdentifier Rm0 = new fsParameterIdentifier("Rm0", fsUnits.FilterMediumResistance);

        public static fsParameterIdentifier SaltConcentrationInTheCakeLiquid = new fsParameterIdentifier("Cw", "Salt concentration in the cake liquid", fsUnits.SolidsConcentration);
        public static fsParameterIdentifier SaltMassFractionInTheCakeLiquid = new fsParameterIdentifier("Cwm", "Salt Mass fraction in the cake liquid", fsUnits.Concentration);
        public static fsParameterIdentifier WashOutMassFractionOfLiquidAfterResuspension = new fsParameterIdentifier("Cwm", "Wash Out Mass Fration Of Liquid After Resuspension", fsUnits.Concentration);
        public static fsParameterIdentifier WashOutConcentrationOfLiquidAfterResuspension = new fsParameterIdentifier("Cw", "Wash Out Concentration Of Liquid After Resuspension", fsUnits.SolidsConcentration);
        public static fsParameterIdentifier CakeSaturation = new fsParameterIdentifier("S", "Cake Saturation", fsUnits.Concentration);
        public static fsParameterIdentifier CakeMoistureContent = new fsParameterIdentifier("RF", "Cake Moisture Content", fsUnits.Concentration);
        public static fsParameterIdentifier CakeWashOutContent = new fsParameterIdentifier("X", "Cake Wash Out Content", fsUnits.CakeWashOutContent);
        public static fsParameterIdentifier pH = new fsParameterIdentifier("pH", "pH of liquid after resuspension", fsUnits.NoUnits);
        public static fsParameterIdentifier pHcake = new fsParameterIdentifier("pH_c", "pH of liquid in the cake", fsUnits.NoUnits);

        #endregion
    }
}
