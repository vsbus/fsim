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
        readonly fsCalculatorVariable m_area;
        readonly fsCalculatorVariable m_diameter;
        readonly fsCalculatorVariable m_b;
        readonly fsCalculatorVariable m_bOverD;
        readonly fsCalculatorConstant m_rhoL;
        readonly fsCalculatorConstant m_rhoS;
        readonly fsCalculatorConstant m_hc;
        readonly fsCalculatorConstant m_Mcw;
        readonly fsCalculatorConstant m_Mcd;
        readonly fsCalculatorConstant m_C;
        readonly fsCalculatorVariable m_eps;

        public fsCakePorosityCalculator()
        {
            #region Parameters Initialization

            m_area = AddVariable(fsParameterIdentifier.FilterArea);
            m_diameter = AddVariable(fsParameterIdentifier.FilterDiameter);
            m_b = AddVariable(fsParameterIdentifier.FilterB);
            m_bOverD = AddVariable(fsParameterIdentifier.FilterBOverDiameter);
            m_rhoL = AddConstant(fsParameterIdentifier.LiquidDensity);
            m_rhoS = AddConstant(fsParameterIdentifier.SolidsDensity);
            m_hc = AddConstant(fsParameterIdentifier.CakeHeight);
            m_Mcw = AddConstant(fsParameterIdentifier.WetCakeMass);
            m_Mcd = AddConstant(fsParameterIdentifier.DryCakeMass);
            m_C = AddConstant(fsParameterIdentifier.SolidsConcentration);
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
            if (m_machineTypeOption == fsMachineTypeOption.ConcaveCylindric)
            {
                AddEquation(new fsCylinderAreaEquation(m_area, m_diameter, m_b));
                AddEquation(new fsProductEquation(m_b, m_diameter, m_bOverD));
            }

            AddEquation(new fsPorosityEquation(
                            m_saltContentOption == fsSaltContentOption.Neglected,
                            m_saturationOption == fsSaturationOption.SaturatedCake,
                            m_eps,
                            m_Mcd,
                            m_Mcw,
                            m_rhoS,
                            m_rhoL,
                            m_area,
                            m_C,
                            m_hc));
        }
    }
}
