using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Equations;
using Parameters;

namespace StepCalculators
{
    public class fsRfFromWetDryCakeCalculator : fsCalculator
    {
        readonly fsCalculatorVariable m_area;
        readonly fsCalculatorConstant m_rhoL;

        public fsRfFromWetDryCakeCalculator()
        {
            #region Parameters Initialization

            m_area = AddVariable(fsParameterIdentifier.FilterArea);
            m_rhoL = AddConstant(fsParameterIdentifier.LiquidDensity);

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
            SolidsMassFraction,
            Concentration
        }
        public fsConcentrationOption m_concentrationOption;

        public void RebuildEquationsList()
        {
            Equations = new List<fsCalculatorEquation>();

            //AddEquation(new fsPorosityEquation(
            //                m_saltContentOption == fsSaltContentOption.Neglected,
            //                m_saturationOption == fsSaturationOption.SaturatedCake,
            //                m_eps,
            //                m_Mcd,
            //                m_Mcw,
            //                m_rhoS,
            //                m_rhoL,
            //                m_area,
            //                m_C,
            //                m_hc));
        }
    }
}
