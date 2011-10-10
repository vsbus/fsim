using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Equations;
using Parameters;
using Value;

namespace StepCalculators
{
    public class fsRfFromWetDryCakeCalculator : fsCalculator
    {
        readonly fsCalculatorConstant m_wetMass;
        readonly fsCalculatorConstant m_dryMass;
        readonly fsCalculatorConstant m_Cm;
        readonly fsCalculatorConstant m_C;
        readonly fsCalculatorConstant m_rhoL;
        readonly fsCalculatorVariable m_Rf;
        readonly fsCalculatorVariable m_internalC;

        public fsRfFromWetDryCakeCalculator()
        {
            #region Parameters Initialization

            m_wetMass = AddConstant(fsParameterIdentifier.WetCakeMass);
            m_dryMass = AddConstant(fsParameterIdentifier.DryCakeMass);
            m_Cm = AddConstant(fsParameterIdentifier.SolidsMassFraction);
            m_C = AddConstant(fsParameterIdentifier.SolidsConcentration);
            m_rhoL = AddConstant(fsParameterIdentifier.LiquidDensity);
            m_Rf = AddVariable(fsParameterIdentifier.CakeMoistureContent);
            m_internalC = AddVariable(new fsParameterIdentifier("internalC"));

            #endregion

            Equations = null;
        }

        public enum fsSaltContentOption
        {
            Neglected,
            Considered
        }
        public fsSaltContentOption m_saltContentOption;

        public enum fsConcentrationOption
        {
            [Description("Mass fraction Cm (%)")]
            SolidsMassFraction,
            [Description("Concentration C (g/l)")]
            Concentration
        }
        public fsConcentrationOption m_concentrationOption;

        public void RebuildEquationsList()
        {
            Equations = new List<fsCalculatorEquation>();

            if (m_saltContentOption == fsSaltContentOption.Neglected)
            {
                m_internalC.Value = fsValue.Zero;
                m_internalC.IsInput = true;
                AddEquation(new fsMoistureContentEquation(m_Rf, m_dryMass, m_wetMass, m_internalC));
            }
            else
            {
                if (m_concentrationOption == fsConcentrationOption.SolidsMassFraction)
                {
                    AddEquation(new fsMoistureContentEquation(m_Rf, m_dryMass, m_wetMass, m_Cm));
                }
                else
                {
                    m_internalC.IsInput = false;
                    AddEquation(new fsProductEquation(m_C, m_internalC, m_rhoL));
                    AddEquation(new fsMoistureContentEquation(m_Rf, m_dryMass, m_wetMass, m_internalC));
                }
            }
        }
    }
}
