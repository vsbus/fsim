using Units;

namespace Parameters
{
    public class fsParameterIdentifier
    {
        #region fsParameterIdentifier

        public string Name { get; private set; }

        public string FullName { get; private set; }

        public fsCharacteristic Units { get; private set; }

        public fsParameterIdentifier(string name)
        {
            Name = name;
            FullName = name;
            Units = fsCharacteristic.NoUnits;
        }

        public fsParameterIdentifier(string name, fsCharacteristic units)
        {
            Name = name;
            FullName = name;
            Units = units;
        }

        public fsParameterIdentifier(string name, string fullName, fsCharacteristic units)
        {
            Name = name;
            FullName = fullName;
            Units = units;
        }

        public fsParameterIdentifier(string name, string fullName)
        {
            Name = name;
            FullName = fullName;
            Units = fsCharacteristic.NoUnits;
        }

        public override string ToString()
        {
            return FullName == Name ? Name : FullName + " (" + Name + ")";
        }

        #endregion

        #region Parameters Collection

        public static fsParameterIdentifier CakePorosity = new fsParameterIdentifier("eps", "Cake Porosity", fsCharacteristic.Concentration);
        public static fsParameterIdentifier Kappa = new fsParameterIdentifier("kappa");
        public static fsParameterIdentifier CakePermeability = new fsParameterIdentifier("Pc", "Cake Premeability", fsCharacteristic.CakePermeability);
        public static fsParameterIdentifier CakeResistance = new fsParameterIdentifier("rc", "Cake Resistance", fsCharacteristic.CakeResistance);
        public static fsParameterIdentifier CakeResistanceAlpha = new fsParameterIdentifier("alpha", "Cake Resistance", fsCharacteristic.CakeResistanceAlpha);

        public static fsParameterIdentifier FilterArea = new fsParameterIdentifier("A", "Filter Area", fsCharacteristic.Area);
        public static fsParameterIdentifier MachineDiameter = new fsParameterIdentifier("D", "Machine Diameter", fsCharacteristic.Length);
        public static fsParameterIdentifier FilterElementDiameter = new fsParameterIdentifier("d", "Filter Element Diameter", fsCharacteristic.Length);
        public static fsParameterIdentifier FilterB = new fsParameterIdentifier("b", fsCharacteristic.Length);
        public static fsParameterIdentifier FilterBOverDiameter = new fsParameterIdentifier("b/D", fsCharacteristic.NoUnits);

        public static fsParameterIdentifier Pressure = new fsParameterIdentifier("Dp", fsCharacteristic.Pressure);
        public static fsParameterIdentifier CycleTime = new fsParameterIdentifier("tc", fsCharacteristic.Time);
        public static fsParameterIdentifier RotationalSpeed = new fsParameterIdentifier("n", fsCharacteristic.Frequency);
        public static fsParameterIdentifier FormationRelativeTime = new fsParameterIdentifier("sf", fsCharacteristic.Concentration);
        public static fsParameterIdentifier FormationTime = new fsParameterIdentifier("tf", fsCharacteristic.Time);
        public static fsParameterIdentifier CakeHeight = new fsParameterIdentifier("hc", fsCharacteristic.Length);

        public static fsParameterIdentifier WetCakeMass = new fsParameterIdentifier("Mcw", "Wet Cake Mass", fsCharacteristic.Mass);
        public static fsParameterIdentifier DryCakeMass = new fsParameterIdentifier("Mcd", "Dry Cake Mass", fsCharacteristic.Mass);
        public static fsParameterIdentifier SuspensionMass = new fsParameterIdentifier("Msus", "Suspension Mass", fsCharacteristic.Mass);
        public static fsParameterIdentifier FiltrateMass = new fsParameterIdentifier("Mf", "Fitrate Mass", fsCharacteristic.Mass);
        public static fsParameterIdentifier LiquidMass = new fsParameterIdentifier("Ml", "Liquid Mass", fsCharacteristic.Mass);
        public static fsParameterIdentifier SolidsMass = new fsParameterIdentifier("Ms", "Solids Mass", fsCharacteristic.Mass);
        public static fsParameterIdentifier CakeMass = new fsParameterIdentifier("Mc", "Cake Mass", fsCharacteristic.Mass);
        
        public static fsParameterIdentifier SuspensionVolume = new fsParameterIdentifier("Vsus", fsCharacteristic.Volume);

        public static fsParameterIdentifier SuspensionMassFlowrate = new fsParameterIdentifier("Qmsus", fsCharacteristic.Flowrate);

        
        public static fsParameterIdentifier FiltrateViscosity = new fsParameterIdentifier("etaf", fsCharacteristic.Viscosity);
        public static fsParameterIdentifier SurfaceTensionLiquidOfCake = new fsParameterIdentifier("sigma", "Surface Tension Liquid of Cake", fsCharacteristic.SurfaceTension);
        public static fsParameterIdentifier StandartCapillaryPressure = new fsParameterIdentifier("pke_st", "Standart Capillary Pressure", fsCharacteristic.Pressure);
        public static fsParameterIdentifier CapillaryPressure = new fsParameterIdentifier("pke", "Capillary Pressure", fsCharacteristic.Pressure);

        public static fsParameterIdentifier BulkDensityDrySolids = new fsParameterIdentifier("rhos_bulk", "Bulk Density Dry Solids", fsCharacteristic.Density);
        public static fsParameterIdentifier MotherLiquidDensity = new fsParameterIdentifier("rho_f", "Density of Mother Liquid", fsCharacteristic.Density);
        public static fsParameterIdentifier FiltrateDensity = new fsParameterIdentifier("rho_f", "Filtrate Density", fsCharacteristic.Density);
        public static fsParameterIdentifier LiquidDensity = new fsParameterIdentifier("rho_l", "Liquid Density", fsCharacteristic.Density);
        public static fsParameterIdentifier SolidsDensity = new fsParameterIdentifier("rho_s", "Solids Density", fsCharacteristic.Density);
        public static fsParameterIdentifier SuspensionDensity = new fsParameterIdentifier("rho_sus", "Suspension Density", fsCharacteristic.Density);
        public static fsParameterIdentifier SuspensionSolidsMassFraction = new fsParameterIdentifier("Cm", "Suspension Solids Mass Fraction", fsCharacteristic.Concentration);
        public static fsParameterIdentifier SolidsVolumeFraction = new fsParameterIdentifier("Cv", "Solids Volume Fraction", fsCharacteristic.Concentration);
        public static fsParameterIdentifier SolidsConcentration = new fsParameterIdentifier("C", "Solids Concentration", fsCharacteristic.SolidsConcentration);
        public static fsParameterIdentifier CakePorosity0 = new fsParameterIdentifier("eps0", "Cake Porosity 0", fsCharacteristic.Concentration);
        public static fsParameterIdentifier Kappa0 = new fsParameterIdentifier("kappa0");
        public static fsParameterIdentifier Ne = new fsParameterIdentifier("ne");
        public static fsParameterIdentifier CakePermeability0 = new fsParameterIdentifier("Pc0", "Cake Permeability0", fsCharacteristic.CakePermeability);
        public static fsParameterIdentifier CakeResistance0 = new fsParameterIdentifier("rc0", "Cake Resistance0", fsCharacteristic.CakeResistance);
        public static fsParameterIdentifier CakeCompressibility = new fsParameterIdentifier("nc", "Cake Compressibility");
        public static fsParameterIdentifier Alpha0 = new fsParameterIdentifier("alpha0", fsCharacteristic.CakeResistanceAlpha);
        public static fsParameterIdentifier Hce0 = new fsParameterIdentifier("hce0", fsCharacteristic.Length);
        public static fsParameterIdentifier Rm0 = new fsParameterIdentifier("Rm0", fsCharacteristic.FilterMediumResistance);

        public static fsParameterIdentifier SaltConcentrationInTheMotherLiquid = new fsParameterIdentifier("Cf", "Salt concentration in the mother liquid", fsCharacteristic.SolidsConcentration);
        public static fsParameterIdentifier SaltMassFractionInTheMotherLiquid = new fsParameterIdentifier("Cfm", "Salt Mass fraction in the mother liquid", fsCharacteristic.Concentration);
        public static fsParameterIdentifier SaltConcentrationInTheCakeLiquid = new fsParameterIdentifier("Cw", "Salt concentration in the cake liquid", fsCharacteristic.SolidsConcentration);
        public static fsParameterIdentifier SaltMassFractionInTheCakeLiquid = new fsParameterIdentifier("Cwm", "Salt Mass fraction in the cake liquid", fsCharacteristic.Concentration);
        public static fsParameterIdentifier WashOutMassFraction = new fsParameterIdentifier("Cwm", "Wash Out Mass Fration", fsCharacteristic.Concentration);
        public static fsParameterIdentifier WashOutConcentration = new fsParameterIdentifier("Cw", "Wash Out Concentration", fsCharacteristic.SolidsConcentration);
        public static fsParameterIdentifier CakeSaturation = new fsParameterIdentifier("S", "Cake Saturation", fsCharacteristic.Concentration);
        public static fsParameterIdentifier CakeMoistureContent = new fsParameterIdentifier("RF", "Cake Moisture Content", fsCharacteristic.Concentration);
        public static fsParameterIdentifier CakeWashOutContent = new fsParameterIdentifier("X", "Cake Wash Out Content", fsCharacteristic.CakeWashOutContent);
        public static fsParameterIdentifier Ph = new fsParameterIdentifier("pH", "pH of liquid after resuspension", fsCharacteristic.NoUnits);
        public static fsParameterIdentifier PHcake = new fsParameterIdentifier("pH_c", "pH of liquid in the cake", fsCharacteristic.NoUnits);

        #endregion
    }
}
