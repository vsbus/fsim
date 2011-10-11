using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Equations;
using Parameters;

namespace StepCalculators
{
    public class fsCakePorosityCalculator : fsCalculator
    {
        readonly fsCalculatorVariable m_machineArea;
        readonly fsCalculatorVariable m_cakeArea;
        readonly fsCalculatorVariable m_machineDiameter;
        readonly fsCalculatorVariable m_filterElementDiameter;
        readonly fsCalculatorVariable m_b;
        readonly fsCalculatorVariable m_bOverD;
        readonly fsCalculatorConstant m_rhoL;
        readonly fsCalculatorConstant m_rhoS;
        readonly fsCalculatorConstant m_cakeHeight;
        readonly fsCalculatorConstant m_wetCakeMass;
        readonly fsCalculatorConstant m_dryCakeMass;
        readonly fsCalculatorConstant m_c;
        readonly fsCalculatorVariable m_eps;

        public fsCakePorosityCalculator()
        {
            #region Parameters Initialization

            m_machineArea = AddVariable(fsParameterIdentifier.FilterArea);
            m_machineDiameter = AddVariable(fsParameterIdentifier.MachineDiameter);
            m_filterElementDiameter = AddVariable(fsParameterIdentifier.FilterElementDiameter);
            m_cakeArea = AddVariable(new fsParameterIdentifier("cakeArea"));
            m_b = AddVariable(fsParameterIdentifier.FilterB);
            m_bOverD = AddVariable(fsParameterIdentifier.FilterBOverDiameter);
            m_rhoL = AddConstant(fsParameterIdentifier.LiquidDensity);
            m_rhoS = AddConstant(fsParameterIdentifier.SolidsDensity);
            m_cakeHeight = AddConstant(fsParameterIdentifier.CakeHeight);
            m_wetCakeMass = AddConstant(fsParameterIdentifier.WetCakeMass);
            m_dryCakeMass = AddConstant(fsParameterIdentifier.DryCakeMass);
            m_c = AddConstant(fsParameterIdentifier.SolidsConcentration);
            m_eps = AddVariable(fsParameterIdentifier.Porosity);

            #endregion

            Equations = null;
        }

        public enum fsSaltContentOption
        {
            Neglected,
            NotNeglected
        }
        public fsSaltContentOption m_saltContentOption;

        public enum fsSaturationOption
        {
            NotSaturatedCake,
            SaturatedCake
        }
        public fsSaturationOption m_saturationOption;

        public enum fsMachineTypeOption
        {
            PlainArea,
            ConvexCylindric,
            ConcaveCylindric
        }
        public fsMachineTypeOption m_machineTypeOption;

        public void RebuildEquationsList()
        {
            Equations = new List<fsCalculatorEquation>();

            switch (m_machineTypeOption)
            {
                case fsMachineTypeOption.PlainArea:
                    AddEquation(new fsAssignEquation(m_cakeArea, m_machineArea));
                    break;
                case fsMachineTypeOption.ConvexCylindric:
                    AddEquation(new fsConvexCakeAreaEquation(m_cakeArea, m_machineArea, m_cakeHeight, m_filterElementDiameter));
                    break;
                case fsMachineTypeOption.ConcaveCylindric:
                    AddEquation(new fsConcaveCakeAreaEquation(m_cakeArea, m_machineArea, m_cakeHeight, m_machineDiameter));
                    AddEquation(new fsCylinderAreaEquation(m_machineArea, m_machineDiameter, m_b));
                    AddEquation(new fsProductEquation(m_b, m_machineDiameter, m_bOverD));
                    break;
            }

            AddEquation(new fsPorosityEquation(
                            m_saltContentOption == fsSaltContentOption.Neglected,
                            m_saturationOption == fsSaturationOption.SaturatedCake,
                            m_eps,
                            m_dryCakeMass,
                            m_wetCakeMass,
                            m_rhoS,
                            m_rhoL,
                            m_cakeArea,
                            m_c,
                            m_cakeHeight));
        }
    }
}
