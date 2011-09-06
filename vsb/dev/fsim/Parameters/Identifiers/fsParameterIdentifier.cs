using System;
using System.Collections.Generic;

using System.Text;

namespace Parameters
{
    public class fsParameterIdentifier
    {
        private string m_name;
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public fsParameterIdentifier(string name)
        {
            m_name = name;
        }

        public override string ToString()
        {
            return m_name;
        }

        public static fsParameterIdentifier height = new fsParameterIdentifier("height");
        public static fsParameterIdentifier length = new fsParameterIdentifier("length");
        public static fsParameterIdentifier width = new fsParameterIdentifier("width");
        public static fsParameterIdentifier side = new fsParameterIdentifier("side");
        public static fsParameterIdentifier volume = new fsParameterIdentifier("volume");
        public static fsParameterIdentifier coefficient = new fsParameterIdentifier("coefficient");

        public static fsParameterIdentifier q = new fsParameterIdentifier("q");
        public static fsParameterIdentifier a1 = new fsParameterIdentifier("a1");
        public static fsParameterIdentifier a2 = new fsParameterIdentifier("a2");
        public static fsParameterIdentifier a3 = new fsParameterIdentifier("a3");
        public static fsParameterIdentifier a4 = new fsParameterIdentifier("a4");
        public static fsParameterIdentifier a5 = new fsParameterIdentifier("a5");

        public static fsParameterIdentifier kappa = new fsParameterIdentifier("kappa");
        public static fsParameterIdentifier Pc = new fsParameterIdentifier("Pc");

        public static fsParameterIdentifier FilterArea = new fsParameterIdentifier("A");
        public static fsParameterIdentifier Pressure = new fsParameterIdentifier("Dp");
        public static fsParameterIdentifier CycleTime = new fsParameterIdentifier("tc");
        public static fsParameterIdentifier RotationalSpeed = new fsParameterIdentifier("n");
        public static fsParameterIdentifier FormationRelativeTime = new fsParameterIdentifier("sf");
        public static fsParameterIdentifier FormationTime = new fsParameterIdentifier("tf");
        public static fsParameterIdentifier CakeHeight = new fsParameterIdentifier("hc");
        public static fsParameterIdentifier SuspensionMass = new fsParameterIdentifier("Msus");
        public static fsParameterIdentifier SuspensionVolume = new fsParameterIdentifier("Vsus");

        
        public static fsParameterIdentifier FiltrateViscosity = new fsParameterIdentifier("etaf");
        public static fsParameterIdentifier FiltrateDensity = new fsParameterIdentifier("rho_f");
        public static fsParameterIdentifier SolidsDensity = new fsParameterIdentifier("rho_s");
        public static fsParameterIdentifier SuspensionDensity = new fsParameterIdentifier("rho_sus");
        public static fsParameterIdentifier MassConcentration = new fsParameterIdentifier("Cm");
        public static fsParameterIdentifier VolumeConcentration = new fsParameterIdentifier("Cv");
        public static fsParameterIdentifier Concentration = new fsParameterIdentifier("C");
        public static fsParameterIdentifier Porosity0 = new fsParameterIdentifier("eps0");
        public static fsParameterIdentifier kappa0 = new fsParameterIdentifier("kappa0");
        public static fsParameterIdentifier ne = new fsParameterIdentifier("ne");
        public static fsParameterIdentifier Pc0 = new fsParameterIdentifier("Pc0");
        public static fsParameterIdentifier rc0 = new fsParameterIdentifier("rc0");
        public static fsParameterIdentifier nc = new fsParameterIdentifier("nc");
        public static fsParameterIdentifier alpha0 = new fsParameterIdentifier("alpha0");
        public static fsParameterIdentifier hce0 = new fsParameterIdentifier("hce0");
        public static fsParameterIdentifier Rm0 = new fsParameterIdentifier("Rm0");
    }
}
