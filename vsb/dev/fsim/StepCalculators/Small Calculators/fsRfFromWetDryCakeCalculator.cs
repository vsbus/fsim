using System.Collections.Generic;
using System.ComponentModel;
using Equations;
using Parameters;
using Value;

namespace StepCalculators
{
    public class fsRfFromWetDryCakeCalculator : fsCalculator
    {
        readonly fsCalculatorConstant m_wetMass;
        readonly fsCalculatorConstant m_dryMass;
        readonly fsCalculatorConstant m_solidsMassFraction;
        readonly fsCalculatorConstant m_solidsMassConcentration;
        readonly fsCalculatorConstant m_liquidDensity;
        readonly fsCalculatorVariable m_cakeMoistureContent;
        readonly fsCalculatorVariable m_internalC;

        public fsRfFromWetDryCakeCalculator()
        {
            #region Parameters Initialization

            m_wetMass = AddConstant(fsParameterIdentifier.WetCakeMass);
            m_dryMass = AddConstant(fsParameterIdentifier.DryCakeMass);
            m_solidsMassFraction = AddConstant(fsParameterIdentifier.SolidsMassFraction);
            m_solidsMassConcentration = AddConstant(fsParameterIdentifier.SolidsConcentration);
            m_liquidDensity = AddConstant(fsParameterIdentifier.LiquidDensity);
            m_cakeMoistureContent = AddVariable(fsParameterIdentifier.CakeMoistureContent);
            m_internalC = AddVariable(new fsParameterIdentifier("internalC"));

            #endregion

            Equations = null;
        }

        public enum fsSaltContentOption
        {
            Neglected,
            Considered
        }
        public fsSaltContentOption SaltContentOption;

        public enum fsConcentrationOption
        {
            [Description("Mass fraction Cm (%)")]
            SolidsMassFraction,
            [Description("Concentration C (g/l)")]
            Concentration
        }
        public fsConcentrationOption ConcentrationOption;

        public void RebuildEquationsList()
        {
            Equations = new List<fsCalculatorEquation>();

            if (SaltContentOption == fsSaltContentOption.Neglected)
            {
                m_internalC.Value = fsValue.Zero;
                m_internalC.IsInput = true;
                AddEquation(new fsMoistureContentEquation(m_cakeMoistureContent, m_dryMass, m_wetMass, m_internalC));
            }
            else
            {
                if (ConcentrationOption == fsConcentrationOption.SolidsMassFraction)
                {
                    AddEquation(new fsMoistureContentEquation(m_cakeMoistureContent, m_dryMass, m_wetMass, m_solidsMassFraction));
                }
                else
                {
                    m_internalC.IsInput = false;
                    AddEquation(new fsProductEquation(m_solidsMassConcentration, m_internalC, m_liquidDensity));
                    AddEquation(new fsMoistureContentEquation(m_cakeMoistureContent, m_dryMass, m_wetMass, m_internalC));
                }
            }
        }
    }
}
